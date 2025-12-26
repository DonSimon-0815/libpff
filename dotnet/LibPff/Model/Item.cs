using LibPff.Interop;

namespace LibPff.Model
{
    /// <summary>
    /// Generic PffItem which implements IItem for basic properties via libpff_item_* calls.
    /// </summary>
    internal class Item :  IItem
    {
        protected readonly ItemHandle Handle;
        protected readonly INativeAdapter Native;

        private Dictionary<uint, List<RecordEntry>>? _recordIndex;

        protected nint RawHandle
        {
            get
            {
                if (Handle.IsInvalid || Handle.IsClosed)
                    throw new ObjectDisposedException(nameof(File));

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
                int rc = Native.ItemGetIdentifier(RawHandle, out uint identifier, nint.Zero);
                if (rc != 1) throw new PffException($"ItemGetIdentifier failed: {rc}", rc);
                return (int)identifier;
            }
        }

        public ItemType Type
        {
            get
            {
                int rc = Native.ItemGetType(RawHandle, out byte itemType, nint.Zero);
                if (rc != 1) throw new PffException($"ItemGetType failed: {rc}", rc);
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
                int rc = Native.ItemGetNumberOfRecordSets(RawHandle, out int count, nint.Zero);
                if (rc != 1) throw new PffException($"ItemGetNumberOfRecordSets failed: {rc}", rc);
                return count;
            }
        }

        protected IReadOnlyList<RecordSet> RecordSets
        {
            get
            {
                var list = new List<RecordSet>();
                int count = RecordsCount;
                for (var i = 0; i < count; i++)
                {
                    list.Add(GetRecordSet(i)!);
                }
                return list;
            }
        }

        protected RecordSet? GetRecordSet(int index)
        {
            int rc = Native.ItemGetRecordSetByIndex(RawHandle, index, out nint handle, nint.Zero);
            if (rc != 1 || handle == nint.Zero) throw new PffException($"ItemGetRecordSetByIndex failed: {rc}", rc);
            return new RecordSet(handle, Native, true);
        }

        protected Dictionary<uint, List<RecordEntry>> RecordIndex
        {
            get
            {
                if (_recordIndex != null) return _recordIndex; 
                var dict = new Dictionary<uint, List<RecordEntry>>();
                foreach (var rs in RecordSets)
                {
                    foreach (var entry in rs.Entries)
                    {
                        if (!dict.TryGetValue(entry.EntryType, out var list))
                        {
                            list = new List<RecordEntry>();
                            dict[entry.EntryType] = list;
                        }
                        list.Add(entry);
                    }
                }
                _recordIndex = dict;
                return dict;
            }
        }

        //protected bool TryGetRecordValue<T>(uint entryType, out T? value)
        //{
        //    value = default;
        //    if (!RecordIndex.TryGetValue(entryType, out var entries) || entries.Count == 0) return false;
        //    var entry = entries[0];
        //    object? result = entry.ValueType switch
        //    {
        //        0x001F => entry.GetUtf16String(), // PT_UNICODE
        //        0x001E => entry.GetUtf8String(), // PT_STRING8
        //        0x000B => entry.GetBoolean(), // PT_BOOLEAN
        //        0x0002 => entry.GetInt16(), // PT_I2
        //        0x0003 => entry.GetInt32(), // PT_I4
        //        0x0005 => entry.GetDouble(), // PT_DOUBLE
        //        0x0014 => entry.GetInt64(), // PT_I8
        //        0x0040 => entry.GetFileTime(), // PT_SYSTIME
        //        0x0048 => entry.GetGuid(), // PT_CLSID
        //             _ => entry.GetRawData()
        //    };
        //    if (result is T casted)
        //    {
        //        value = casted;
        //        return true;
        //    }
        //    return false;
        //}

        protected bool TryGetRecordValue<T>(uint entryType, out T? value)
        {
            value = default;

            // 1) Wenn wir den EntryType bereits kennen → sofort zurück
            if (_recordIndex != null &&
                _recordIndex.TryGetValue(entryType, out var cachedEntries) &&
                cachedEntries.Count > 0)
            {
                return TryConvertRecordEntry(cachedEntries[0], out value);
            }

            // 2) Sonst: inkrementell suchen
            foreach (var rs in RecordSets)
            {
                foreach (var entry in rs.Entries)
                {
                    if (entry.EntryType != entryType)
                        continue;

                    // Cache initialisieren falls nötig
                    _recordIndex ??= new();

                    // Nur diesen EntryType cachen
                    _recordIndex[entryType] = new List<RecordEntry> { entry };

                    return TryConvertRecordEntry(entry, out value);
                }
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
                int rc = Native.ItemGetNumberOfEntries(RawHandle, out uint count, nint.Zero);
                if (rc != 1) throw new PffException($"ItemGetNumberOfEntries failed: {rc}", rc);
                return count;
            }
        }

        protected int SubItemsCount
        {
            get
            {
                int rc = Native.ItemGetNumberOfSubItems(RawHandle, out int count, nint.Zero);
                if (rc != 1) throw new PffException($"ItemGetNumberOfSubItems failed: {rc}", rc);
                return count;
            }
        }

        protected IReadOnlyList<Item> SubItems
        {
            get
            {
                var list = new List<Item>();
                var count = SubItemsCount;
                for (var i = 0; i < count; i++)
                {
                    list.Add(GetSubItem(i)!);
                }
                return list;
            }
        }

        protected Item? GetSubItem(int index)
        {
            int rc = Native.ItemGetSubItemByIdentifier(RawHandle, (uint)index, out nint itemHandle, nint.Zero);
            if (rc != 1 || itemHandle == nint.Zero) throw new PffException($"ItemGetSubItem failed: {rc}", rc);
            return new Item(itemHandle, Native, true);
        }
    }
}