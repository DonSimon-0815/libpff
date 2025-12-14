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