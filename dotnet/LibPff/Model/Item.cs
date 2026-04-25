using LibPff.Interop;
using LibPff.Utility;
using System.Text;

namespace LibPff.Model
{
    internal class Item : IItem
    {
        protected readonly ItemHandle Handle;
        protected readonly INativeAdapter Native;

        private Dictionary<uint, RecordEntry>? _recordIndex;
        private IReadOnlyList<RecordSet>? _recordSets;

        protected nint RawHandle
        {
            get
            {
                if (Handle.IsInvalid || Handle.IsClosed)
                    throw new ObjectDisposedException(nameof(Item));

                return Handle.DangerousGetHandle();
            }
        }

        protected Item(nint handle, INativeAdapter native, bool ownsHandle)
        {
            Handle = new ItemHandle(handle, native, ownsHandle);
            Native = native ?? throw new ArgumentNullException(nameof(native));
        }

        public int Identifier
        {
            get
            {
                IntPtr error = IntPtr.Zero;
                int rc = Native.ItemGetIdentifier(RawHandle, out uint identifier, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.ItemGetIdentifier),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return (int)identifier;
            }
        }

        public ItemType Type
        {
            get
            {
                IntPtr error = IntPtr.Zero;
                int rc = Native.ItemGetType(RawHandle, out byte itemType, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.ItemGetType),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return itemType switch
                {
                    1 => ItemType.Folder,
                    2 => ItemType.Email,
                    3 => ItemType.Attachment,
                    _ => ItemType.Unknown
                };
            }
        }

        protected int RecordsCount
        {
            get
            {
                IntPtr error = IntPtr.Zero;
                int rc = Native.ItemGetNumberOfRecordSets(RawHandle, out int count, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.ItemGetNumberOfRecordSets),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return count;
            }
        }

        protected IReadOnlyList<RecordSet> RecordSets
        {
            get
            {
                if (_recordSets != null)
                    return _recordSets;

                int count = RecordsCount;
                var list = new List<RecordSet>(count);

                for (int i = 0; i < count; i++)
                {
                    IntPtr error = IntPtr.Zero;
                    int rc = Native.ItemGetRecordSetByIndex(RawHandle, i, out nint handle, out error);

                    ReturnCode.Check(
                        rc,
                        error,
                        nameof(Native.ItemGetRecordSetByIndex),
                        ptr =>
                        {
                            var sb = new StringBuilder(4096);
                            Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                            return sb.ToString();
                        },
                        ptr => Native.ErrorFree(out ptr)
                    );

                    list.Add(new RecordSet(handle, Native, ownsHandle: true));
                }

                _recordSets = list;
                return list;
            }
        }

        protected RecordSet? GetRecordSet(int index)
        {
            IntPtr error = IntPtr.Zero;
            int rc = Native.ItemGetRecordSetByIndex(RawHandle, index, out nint handle, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.ItemGetRecordSetByIndex),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new RecordSet(handle, Native, true);
        }

        protected Dictionary<uint, RecordEntry> RecordIndex =>
            _recordIndex ??= new Dictionary<uint, RecordEntry>();

        protected bool TryGetRecordValue<T>(uint entryType, out T? value)
        {
            value = default;

            // 1) Try message-level MAPI property
            if (typeof(T) == typeof(string))
            {
                IntPtr error = IntPtr.Zero;

                if (Native.MessageGetEntryValueUtf8StringSize(RawHandle, entryType, out nuint size, out error) == 1 &&
                    size > 0)
                {
                    var buf = new byte[(int)size];

                    int rc = Native.MessageGetEntryValueUtf8String(RawHandle, entryType, buf, size, out error);

                    if (rc == 1)
                    {
                        int valid = buf.Length;
                        if (valid > 0 && buf[valid - 1] == 0)
                            valid--;

                        value = (T)(object)Encoding.UTF8.GetString(buf, 0, valid);
                        return true;
                    }

                    if (error != IntPtr.Zero)
                        Native.ErrorFree(out error);
                }
            }

            // 2) Cached record entry
            if (_recordIndex != null && _recordIndex.TryGetValue(entryType, out var cached))
                return TryConvertRecordEntry(cached, out value);

            // 3) Search record sets
            foreach (var rs in RecordSets)
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.RecordSetGetEntryByType(
                    rs.RawHandle,
                    entryType,
                    0,
                    out nint entryHandle,
                    0,
                    out error
                );

                if (rc == 1 && entryHandle != IntPtr.Zero)
                {
                    var entry = new RecordEntry(entryHandle, Native, ownsHandle: true);

                    _recordIndex ??= new();
                    _recordIndex[entryType] = entry;

                    return TryConvertRecordEntry(entry, out value);
                }

                if (error != IntPtr.Zero)
                    Native.ErrorFree(out error);
            }

            return false;
        }

        private bool TryConvertRecordEntry<T>(RecordEntry entry, out T? value)
        {
            value = default;

            object? result = entry.ValueType switch
            {
                0x001F => entry.GetUtf16String(),  // PT_UNICODE
                0x001E => entry.GetUtf8String(),   // PT_STRING8
                0x000B => entry.GetBoolean(),      // PT_BOOLEAN
                0x0002 => entry.GetInt16(),        // PT_I2
                0x0003 => entry.GetInt32(),        // PT_I4
                0x0005 => entry.GetDouble(),       // PT_DOUBLE
                0x0014 => entry.GetInt64(),        // PT_I8
                0x0040 => entry.GetFileTime(),     // PT_SYSTIME
                0x0048 => entry.GetGuid(),         // PT_CLSID
                _ => entry.GetRawData()
            };

            if (result is T casted)
            {
                value = casted;
                return true;
            }

            return false;
        }

        protected uint EntriesCount
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.ItemGetNumberOfEntries(RawHandle, out uint count, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.ItemGetNumberOfEntries),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return count;
            }
        }

        protected int SubItemsCount
        {
            get
            {
                IntPtr error = IntPtr.Zero;

                int rc = Native.ItemGetNumberOfSubItems(RawHandle, out int count, out error);

                ReturnCode.Check(
                    rc,
                    error,
                    nameof(Native.ItemGetNumberOfSubItems),
                    ptr =>
                    {
                        var sb = new StringBuilder(4096);
                        Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                        return sb.ToString();
                    },
                    ptr => Native.ErrorFree(out ptr)
                );

                return count;
            }
        }

        protected IReadOnlyList<Item> SubItems
        {
            get
            {
                var list = new List<Item>();
                int count = SubItemsCount;

                for (int i = 0; i < count; i++)
                    list.Add(GetSubItem(i)!);

                return list;
            }
        }

        protected Item? GetSubItem(int index)
        {
            IntPtr error = IntPtr.Zero;

            int rc = Native.ItemGetSubItemByIdentifier(RawHandle, (uint)index, out nint itemHandle, out error);

            ReturnCode.Check(
                rc,
                error,
                nameof(Native.ItemGetSubItemByIdentifier),
                ptr =>
                {
                    var sb = new StringBuilder(4096);
                    Native.ErrorSprint(ptr, sb, (UIntPtr)sb.Capacity);
                    return sb.ToString();
                },
                ptr => Native.ErrorFree(out ptr)
            );

            return new Item(itemHandle, Native, true);
        }
    }
}
