// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LibPff.Interop
{
    internal sealed class NativeAdapterWin32 : INativeAdapter
    {
        public int AttachmentGetType(IntPtr attachment, out int attachment_type, IntPtr error)
        {
            return NativeWin32.AttachmentGetType(attachment, out attachment_type, error);
        }
        public int AttachmentGetDataSize(IntPtr attachment, out long size, IntPtr error)
        {
            return NativeWin32.AttachmentGetDataSize(attachment, out size, error);
        }
        public long AttachmentDataReadBuffer(IntPtr attachment, byte[] buffer, UIntPtr buffer_size, IntPtr error)
        {
            int native_result = NativeWin32.AttachmentDataReadBuffer(attachment, buffer, buffer_size, error);
            return native_result;  // 'int' to 'long' (32-Bit Plattforms)
        }
        public long AttachmentDataSeekOffset(IntPtr attachment, long offset, int whence, IntPtr error)
        {
            int native_result = NativeWin32.AttachmentDataSeekOffset(attachment, offset, whence, error);
            return native_result;  // 'int' to 'long' (32-Bit Plattforms)
        }
        public int AttachmentGetDataFileIoHandle(IntPtr attachment, out IntPtr file_io_handle, IntPtr error)
        {
            return NativeWin32.AttachmentGetDataFileIoHandle(attachment, out file_io_handle, error);
        }
        public int AttachmentGetItem(IntPtr attachment, out IntPtr attached_item, IntPtr error)
        {
            return NativeWin32.AttachmentGetItem(attachment, out attached_item, error);
        }
        public void ErrorFree(out IntPtr error)
        {
            NativeWin32.ErrorFree(out error);
        }
        public int ErrorFprint(IntPtr error, IntPtr stream)
        {
            return NativeWin32.ErrorFprint(error, stream);
        }
        public int ErrorSprint(IntPtr error, StringBuilder string_2, UIntPtr size)
        {
            return NativeWin32.ErrorSprint(error, string_2, size);
        }
        public int ErrorBacktraceFprint(IntPtr error, IntPtr stream)
        {
            return NativeWin32.ErrorBacktraceFprint(error, stream);
        }
        public int ErrorBacktraceSprint(IntPtr error, StringBuilder string_2, UIntPtr size)
        {
            return NativeWin32.ErrorBacktraceSprint(error, string_2, size);
        }
        public int FileInitialize(out IntPtr file, IntPtr error)
        {
            return NativeWin32.FileInitialize(out file, error);
        }
        public int FileFree(out IntPtr file, IntPtr error)
        {
            return NativeWin32.FileFree(out file, error);
        }
        public int FileSignalAbort(IntPtr file, IntPtr error)
        {
            return NativeWin32.FileSignalAbort(file, error);
        }
        public int FileOpen(IntPtr file, [MarshalAs(UnmanagedType.LPStr)] string filename, int access_flags, IntPtr error)
        {
            return NativeWin32.FileOpen(file, filename, access_flags, error);
        }
        public int FileOpenWide(IntPtr file, [MarshalAs(UnmanagedType.LPWStr)] string filename, int access_flags, IntPtr error)
        {
            return NativeWin32.FileOpenWide(file, filename, access_flags, error);
        }
        public int FileOpenFileIoHandle(IntPtr file, IntPtr file_io_handle, int access_flags, IntPtr error)
        {
            return NativeWin32.FileOpenFileIoHandle(file, file_io_handle, access_flags, error);
        }
        public int FileClose(IntPtr file, IntPtr error)
        {
            return NativeWin32.FileClose(file, error);
        }
        public int FileIsCorrupted(IntPtr file, IntPtr error)
        {
            return NativeWin32.FileIsCorrupted(file, error);
        }
        public int FileRecoverItems(IntPtr file, byte recovery_flags, IntPtr error)
        {
            return NativeWin32.FileRecoverItems(file, recovery_flags, error);
        }
        public int FileGetSize(IntPtr file, out long size, IntPtr error)
        {
            return NativeWin32.FileGetSize(file, out size, error);
        }
        public int FileGetContentType(IntPtr file, out byte content_type, IntPtr error)
        {
            return NativeWin32.FileGetContentType(file, out content_type, error);
        }
        public int FileGetType(IntPtr file, out byte type, IntPtr error)
        {
            return NativeWin32.FileGetType(file, out type, error);
        }
        public int FileGetEncryptionType(IntPtr file, out byte encryption_type, IntPtr error)
        {
            return NativeWin32.FileGetEncryptionType(file, out encryption_type, error);
        }
        public int FileGetAsciiCodepage(IntPtr file, out int ascii_codepage, IntPtr error)
        {
            return NativeWin32.FileGetAsciiCodepage(file, out ascii_codepage, error);
        }
        public int FileSetAsciiCodepage(IntPtr file, int ascii_codepage, IntPtr error)
        {
            return NativeWin32.FileSetAsciiCodepage(file, ascii_codepage, error);
        }
        public int FileGetNumberOfUnallocatedBlocks(IntPtr file, int unallocated_block_type, out int number_of_unallocated_blocks, IntPtr error)
        {
            return NativeWin32.FileGetNumberOfUnallocatedBlocks(file, unallocated_block_type, out number_of_unallocated_blocks, error);
        }
        public int FileGetUnallocatedBlock(IntPtr file, int unallocated_block_type, int unallocated_block_index, out long offset, out long size, IntPtr error)
        {
            return NativeWin32.FileGetUnallocatedBlock(file, unallocated_block_type, unallocated_block_index, out offset, out size, error);
        }
        public int FileGetRootItem(IntPtr file, out IntPtr root_item, IntPtr error)
        {
            return NativeWin32.FileGetRootItem(file, out root_item, error);
        }
        public int FileGetMessageStore(IntPtr file, out IntPtr message_store, IntPtr error)
        {
            return NativeWin32.FileGetMessageStore(file, out message_store, error);
        }
        public int FileGetNameToIdMap(IntPtr file, out IntPtr name_to_id_map, IntPtr error)
        {
            return NativeWin32.FileGetNameToIdMap(file, out name_to_id_map, error);
        }
        public int FileGetRootFolder(IntPtr file, out IntPtr root_folder, IntPtr error)
        {
            return NativeWin32.FileGetRootFolder(file, out root_folder, error);
        }
        public int FileGetItemByIdentifier(IntPtr file, uint item_identifier, out IntPtr item, IntPtr error)
        {
            return NativeWin32.FileGetItemByIdentifier(file, item_identifier, out item, error);
        }
        public int FileGetNumberOfOrphanItems(IntPtr file, out int number_of_orphan_items, IntPtr error)
        {
            return NativeWin32.FileGetNumberOfOrphanItems(file, out number_of_orphan_items, error);
        }
        public int FileGetOrphanItemByIndex(IntPtr file, int orphan_item_index, out IntPtr orphan_item, IntPtr error)
        {
            return NativeWin32.FileGetOrphanItemByIndex(file, orphan_item_index, out orphan_item, error);
        }
        public int FileGetNumberOfRecoveredItems(IntPtr file, out int number_of_recovered_items, IntPtr error)
        {
            return NativeWin32.FileGetNumberOfRecoveredItems(file, out number_of_recovered_items, error);
        }
        public int FileGetRecoveredItemByIndex(IntPtr file, int recovered_item_index, out IntPtr recovered_item, IntPtr error)
        {
            return NativeWin32.FileGetRecoveredItemByIndex(file, recovered_item_index, out recovered_item, error);
        }
        public int FolderGetType(IntPtr folder, out byte type, IntPtr error)
        {
            return NativeWin32.FolderGetType(folder, out type, error);
        }
        public int FolderGetUtf8NameSize(IntPtr folder, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.FolderGetUtf8NameSize(folder, out utf8_string_size, error);
        }
        public int FolderGetUtf8Name(IntPtr folder, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.FolderGetUtf8Name(folder, utf8_string, utf8_string_size, error);
        }
        public int FolderGetUtf16NameSize(IntPtr folder, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.FolderGetUtf16NameSize(folder, out utf16_string_size, error);
        }
        public int FolderGetUtf16Name(IntPtr folder, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.FolderGetUtf16Name(folder, utf16_string, utf16_string_size, error);
        }
        public int FolderGetNumberOfSubFolders(IntPtr folder, out int number_of_sub_folders, IntPtr error)
        {
            return NativeWin32.FolderGetNumberOfSubFolders(folder, out number_of_sub_folders, error);
        }
        public int FolderGetSubFolder(IntPtr folder, int sub_folder_index, out IntPtr sub_folder, IntPtr error)
        {
            return NativeWin32.FolderGetSubFolder(folder, sub_folder_index, out sub_folder, error);
        }
        public int FolderGetSubFolderByUtf8Name(IntPtr folder, byte[] utf8_sub_folder_name, UIntPtr utf8_sub_folder_name_size, out IntPtr sub_folder, IntPtr error)
        {
            return NativeWin32.FolderGetSubFolderByUtf8Name(folder, utf8_sub_folder_name, utf8_sub_folder_name_size, out sub_folder, error);
        }
        public int FolderGetSubFolderByUtf16Name(IntPtr folder, ushort[] utf16_sub_folder_name, UIntPtr utf16_sub_folder_name_size, out IntPtr sub_folder, IntPtr error)
        {
            return NativeWin32.FolderGetSubFolderByUtf16Name(folder, utf16_sub_folder_name, utf16_sub_folder_name_size, out sub_folder, error);
        }
        public int FolderGetSubFolders(IntPtr item, out IntPtr sub_folders, IntPtr error)
        {
            return NativeWin32.FolderGetSubFolders(item, out sub_folders, error);
        }
        public int FolderGetNumberOfSubMessages(IntPtr folder, out int number_of_sub_messages, IntPtr error)
        {
            return NativeWin32.FolderGetNumberOfSubMessages(folder, out number_of_sub_messages, error);
        }
        public int FolderGetSubMessage(IntPtr folder, int sub_message_index, out IntPtr sub_message, IntPtr error)
        {
            return NativeWin32.FolderGetSubMessage(folder, sub_message_index, out sub_message, error);
        }
        public int FolderGetSubMessageByUtf8Name(IntPtr folder, byte[] utf8_sub_message_name, UIntPtr utf8_sub_message_name_size, out IntPtr sub_message, IntPtr error)
        {
            return NativeWin32.FolderGetSubMessageByUtf8Name(folder, utf8_sub_message_name, utf8_sub_message_name_size, out sub_message, error);
        }
        public int FolderGetSubMessageByUtf16Name(IntPtr folder, ushort[] utf16_sub_message_name, UIntPtr utf16_sub_message_name_size, out IntPtr sub_message, IntPtr error)
        {
            return NativeWin32.FolderGetSubMessageByUtf16Name(folder, utf16_sub_message_name, utf16_sub_message_name_size, out sub_message, error);
        }
        public int FolderGetSubMessages(IntPtr item, out IntPtr sub_messages, IntPtr error)
        {
            return NativeWin32.FolderGetSubMessages(item, out sub_messages, error);
        }
        public int FolderGetNumberOfSubAssociatedContents(IntPtr folder, out int number_of_sub_associated_contents, IntPtr error)
        {
            return NativeWin32.FolderGetNumberOfSubAssociatedContents(folder, out number_of_sub_associated_contents, error);
        }
        public int FolderGetSubAssociatedContent(IntPtr folder, int sub_associated_content_index, out IntPtr sub_associated_content, IntPtr error)
        {
            return NativeWin32.FolderGetSubAssociatedContent(folder, sub_associated_content_index, out sub_associated_content, error);
        }
        public int FolderGetSubAssociatedContents(IntPtr item, out IntPtr sub_associated_contents, IntPtr error)
        {
            return NativeWin32.FolderGetSubAssociatedContents(item, out sub_associated_contents, error);
        }
        public int FolderGetUnknowns(IntPtr folder, out IntPtr unknowns, IntPtr error)
        {
            return NativeWin32.FolderGetUnknowns(folder, out unknowns, error);
        }
        public int ItemFree(out IntPtr item, IntPtr error)
        {
            return NativeWin32.ItemFree(out item, error);
        }
        public int ItemGetIdentifier(IntPtr item, out uint identifier, IntPtr error)
        {
            return NativeWin32.ItemGetIdentifier(item, out identifier, error);
        }
        public int ItemGetNumberOfRecordSets(IntPtr item, out int number_of_record_sets, IntPtr error)
        {
            return NativeWin32.ItemGetNumberOfRecordSets(item, out number_of_record_sets, error);
        }
        public int ItemGetRecordSetByIndex(IntPtr item, int record_set_index, out IntPtr record_set, IntPtr error)
        {
            return NativeWin32.ItemGetRecordSetByIndex(item, record_set_index, out record_set, error);
        }
        public int ItemGetNumberOfEntries(IntPtr item, out uint number_of_entries, IntPtr error)
        {
            return NativeWin32.ItemGetNumberOfEntries(item, out number_of_entries, error);
        }
        public int ItemGetType(IntPtr item, out byte item_type, IntPtr error)
        {
            return NativeWin32.ItemGetType(item, out item_type, error);
        }
        public int ItemGetNumberOfSubItems(IntPtr item, out int number_of_sub_items, IntPtr error)
        {
            return NativeWin32.ItemGetNumberOfSubItems(item, out number_of_sub_items, error);
        }
        public int ItemGetSubItem(IntPtr item, int sub_item_index, out IntPtr sub_item, IntPtr error)
        {
            return NativeWin32.ItemGetSubItem(item, sub_item_index, out sub_item, error);
        }
        public int ItemGetSubItemByIdentifier(IntPtr item, uint sub_item_identifier, out IntPtr sub_item, IntPtr error)
        {
            return NativeWin32.ItemGetSubItemByIdentifier(item, sub_item_identifier, out sub_item, error);
        }
        public int FileGetOrphanItem(IntPtr file, int orphan_item_index, out IntPtr orphan_item, IntPtr error)
        {
            return NativeWin32.FileGetOrphanItem(file, orphan_item_index, out orphan_item, error);
        }
        public int FileGetRecoveredItem(IntPtr file, int recovered_item_index, out IntPtr recovered_item, IntPtr error)
        {
            return NativeWin32.FileGetRecoveredItem(file, recovered_item_index, out recovered_item, error);
        }
        public int ItemClone(out IntPtr destination_item, IntPtr source_item, IntPtr error)
        {
            return NativeWin32.ItemClone(out destination_item, source_item, error);
        }
        public int ItemGetNumberOfSets(IntPtr item, out uint number_of_sets, IntPtr error)
        {
            return NativeWin32.ItemGetNumberOfSets(item, out number_of_sets, error);
        }
        public int ItemGetEntryType(IntPtr item, int set_index, int entry_index, out uint entry_type, out uint value_type, out IntPtr name_to_id_map_entry, IntPtr error)
        {
            return NativeWin32.ItemGetEntryType(item, set_index, entry_index, out entry_type, out value_type, out name_to_id_map_entry, error);
        }
        public int ItemGetValueType(IntPtr item, int set_index, uint entry_type, out uint value_type, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetValueType(item, set_index, entry_type, out value_type, flags, error);
        }
        public int ItemGetEntryValue(IntPtr item, int set_index, uint entry_type, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue(item, set_index, entry_type, out value_type, out value_data, out value_data_size, flags, error);
        }
        public int ItemGetEntryValueByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out value_type, out value_data, out value_data_size, error);
        }
        public int ItemGetEntryValueByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out value_type, out value_data, out value_data_size, error);
        }
        public int ItemGetEntryValueBoolean(IntPtr item, int set_index, uint entry_type, out byte entry_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBoolean(item, set_index, entry_type, out entry_value, flags, error);
        }
        public int ItemGetEntryValueBooleanByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out byte entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBooleanByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueBooleanByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out byte entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBooleanByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValue16bit(IntPtr item, int set_index, uint entry_type, out ushort entry_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue16bit(item, set_index, entry_type, out entry_value, flags, error);
        }
        public int ItemGetEntryValue16bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ushort entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue16bitByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValue16bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ushort entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue16bitByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValue32bit(IntPtr item, int set_index, uint entry_type, out uint entry_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue32bit(item, set_index, entry_type, out entry_value, flags, error);
        }
        public int ItemGetEntryValue32bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out uint entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue32bitByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValue32bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out uint entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue32bitByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValue64bit(IntPtr item, int set_index, uint entry_type, out ulong entry_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue64bit(item, set_index, entry_type, out entry_value, flags, error);
        }
        public int ItemGetEntryValue64bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ulong entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue64bitByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValue64bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ulong entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValue64bitByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueFiletime(IntPtr item, int set_index, uint entry_type, out ulong entry_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueFiletime(item, set_index, entry_type, out entry_value, flags, error);
        }
        public int ItemGetEntryValueFiletimeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ulong entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueFiletimeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueFiletimeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ulong entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueFiletimeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueSize(IntPtr item, int set_index, uint entry_type, out UIntPtr entry_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueSize(item, set_index, entry_type, out entry_value, flags, error);
        }
        public int ItemGetEntryValueSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueFloatingPoint(IntPtr item, int set_index, uint entry_type, out double entry_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueFloatingPoint(item, set_index, entry_type, out entry_value, flags, error);
        }
        public int ItemGetEntryValueFloatingPointByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out double entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueFloatingPointByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueFloatingPointByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out double entry_value, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueFloatingPointByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, error);
        }
        public int ItemGetEntryValueUtf8StringSize(IntPtr item, int set_index, uint entry_type, out UIntPtr utf8_string_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf8StringSize(item, set_index, entry_type, out utf8_string_size, flags, error);
        }
        public int ItemGetEntryValueUtf8StringSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf8StringSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out utf8_string_size, error);
        }
        public int ItemGetEntryValueUtf8StringSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf8StringSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out utf8_string_size, error);
        }
        public int ItemGetEntryValueUtf8String(IntPtr item, int set_index, uint entry_type, byte[] utf8_string, UIntPtr utf8_string_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf8String(item, set_index, entry_type, utf8_string, utf8_string_size, flags, error);
        }
        public int ItemGetEntryValueUtf8StringByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf8StringByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, utf8_string, utf8_string_size, error);
        }
        public int ItemGetEntryValueUtf8StringByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf8StringByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, utf8_string, utf8_string_size, error);
        }
        public int ItemGetEntryValueUtf16StringSize(IntPtr item, int set_index, uint entry_type, out UIntPtr utf16_string_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf16StringSize(item, set_index, entry_type, out utf16_string_size, flags, error);
        }
        public int ItemGetEntryValueUtf16StringSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf16StringSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out utf16_string_size, error);
        }
        public int ItemGetEntryValueUtf16StringSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf16StringSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out utf16_string_size, error);
        }
        public int ItemGetEntryValueUtf16String(IntPtr item, int set_index, uint entry_type, ushort[] utf16_string, UIntPtr utf16_string_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf16String(item, set_index, entry_type, utf16_string, utf16_string_size, flags, error);
        }
        public int ItemGetEntryValueUtf16StringByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf16StringByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, utf16_string, utf16_string_size, error);
        }
        public int ItemGetEntryValueUtf16StringByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueUtf16StringByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, utf16_string, utf16_string_size, error);
        }
        public int ItemGetEntryValueBinaryDataSize(IntPtr item, int set_index, uint entry_type, out UIntPtr binary_data_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBinaryDataSize(item, set_index, entry_type, out binary_data_size, flags, error);
        }
        public int ItemGetEntryValueBinaryDataSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr binary_data_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBinaryDataSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out binary_data_size, error);
        }
        public int ItemGetEntryValueBinaryDataSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr binary_data_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBinaryDataSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out binary_data_size, error);
        }
        public int ItemGetEntryValueBinaryData(IntPtr item, int set_index, uint entry_type, byte[] binary_data, UIntPtr binary_data_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBinaryData(item, set_index, entry_type, binary_data, binary_data_size, flags, error);
        }
        public int ItemGetEntryValueBinaryDataByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, byte[] binary_data, UIntPtr binary_data_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBinaryDataByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, binary_data, binary_data_size, error);
        }
        public int ItemGetEntryValueBinaryDataByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, byte[] binary_data, UIntPtr binary_data_size, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueBinaryDataByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, binary_data, binary_data_size, error);
        }
        public int ItemGetEntryValueGuid(IntPtr item, int set_index, uint entry_type, byte[] guid, UIntPtr guid_size, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryValueGuid(item, set_index, entry_type, guid, guid_size, flags, error);
        }
        public int ItemGetEntryMultiValue(IntPtr item, int set_index, uint entry_type, out IntPtr multi_value, byte flags, IntPtr error)
        {
            return NativeWin32.ItemGetEntryMultiValue(item, set_index, entry_type, out multi_value, flags, error);
        }
        public int RecordEntryGetValueDataSize(IntPtr record_entry, out UIntPtr value_data_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueDataSize(record_entry, out value_data_size, error);
        }
        public int RecordEntryCopyValueData(IntPtr record_entry, byte[] value_data, UIntPtr value_data_size, IntPtr error)
        {
            return NativeWin32.RecordEntryCopyValueData(record_entry, value_data, value_data_size, error);
        }
        public int RecordEntryGetValueBoolean(IntPtr record_entry, out byte value_boolean, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueBoolean(record_entry, out value_boolean, error);
        }
        public int RecordEntryGetValue16bit(IntPtr record_entry, out ushort value_16bit, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValue16bit(record_entry, out value_16bit, error);
        }
        public int RecordEntryGetValue32bit(IntPtr record_entry, out uint value_32bit, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValue32bit(record_entry, out value_32bit, error);
        }
        public int RecordEntryGetValue64bit(IntPtr record_entry, out ulong value_64bit, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValue64bit(record_entry, out value_64bit, error);
        }
        public int RecordEntryGetValueFiletime(IntPtr record_entry, out ulong value_64bit, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueFiletime(record_entry, out value_64bit, error);
        }
        public int RecordEntryGetValueSize(IntPtr record_entry, out UIntPtr value_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueSize(record_entry, out value_size, error);
        }
        public int RecordEntryGetValueFloatingPoint(IntPtr record_entry, out double value_floating_point, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueFloatingPoint(record_entry, out value_floating_point, error);
        }
        public int RecordEntryGetValueUtf8StringSize(IntPtr record_entry, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueUtf8StringSize(record_entry, out utf8_string_size, error);
        }
        public int RecordEntryGetValueUtf8String(IntPtr record_entry, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueUtf8String(record_entry, utf8_string, utf8_string_size, error);
        }
        public int RecordEntryGetValueUtf16StringSize(IntPtr record_entry, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueUtf16StringSize(record_entry, out utf16_string_size, error);
        }
        public int RecordEntryGetValueUtf16String(IntPtr record_entry, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueUtf16String(record_entry, utf16_string, utf16_string_size, error);
        }
        public int MessageGetEntryValueUtf8StringSize(IntPtr message, uint entry_type, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.MessageGetEntryValueUtf8StringSize(message, entry_type, out utf8_string_size, error);
        }
        public int MessageGetEntryValueUtf8String(IntPtr message, uint entry_type, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.MessageGetEntryValueUtf8String(message, entry_type, utf8_string, utf8_string_size, error);
        }
        public int MessageGetEntryValueUtf16StringSize(IntPtr message, uint entry_type, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.MessageGetEntryValueUtf16StringSize(message, entry_type, out utf16_string_size, error);
        }
        public int MessageGetEntryValueUtf16String(IntPtr message, uint entry_type, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.MessageGetEntryValueUtf16String(message, entry_type, utf16_string, utf16_string_size, error);
        }
        public int MessageGetClientSubmitTime(IntPtr message, out ulong filetime, IntPtr error)
        {
            return NativeWin32.MessageGetClientSubmitTime(message, out filetime, error);
        }
        public int MessageGetDeliveryTime(IntPtr message, out ulong filetime, IntPtr error)
        {
            return NativeWin32.MessageGetDeliveryTime(message, out filetime, error);
        }
        public int MessageGetCreationTime(IntPtr message, out ulong filetime, IntPtr error)
        {
            return NativeWin32.MessageGetCreationTime(message, out filetime, error);
        }
        public int MessageGetModificationTime(IntPtr message, out ulong filetime, IntPtr error)
        {
            return NativeWin32.MessageGetModificationTime(message, out filetime, error);
        }
        public int MessageGetNumberOfAttachments(IntPtr message, out int number_of_attachments, IntPtr error)
        {
            return NativeWin32.MessageGetNumberOfAttachments(message, out number_of_attachments, error);
        }
        public int MessageGetAttachment(IntPtr message, int attachment_index, out IntPtr attachment, IntPtr error)
        {
            return NativeWin32.MessageGetAttachment(message, attachment_index, out attachment, error);
        }
        public int MessageGetAttachments(IntPtr message, out IntPtr attachments, IntPtr error)
        {
            return NativeWin32.MessageGetAttachments(message, out attachments, error);
        }
        public int MessageGetRecipients(IntPtr message, out IntPtr recipients, IntPtr error)
        {
            return NativeWin32.MessageGetRecipients(message, out recipients, error);
        }
        public int MessageGetPlainTextBodySize(IntPtr message, out UIntPtr size, IntPtr error)
        {
            return NativeWin32.MessageGetPlainTextBodySize(message, out size, error);
        }
        public int MessageGetPlainTextBody(IntPtr message, byte[] message_body, UIntPtr size, IntPtr error)
        {
            return NativeWin32.MessageGetPlainTextBody(message, message_body, size, error);
        }
        public int MessageGetRtfBodySize(IntPtr message, out UIntPtr size, IntPtr error)
        {
            return NativeWin32.MessageGetRtfBodySize(message, out size, error);
        }
        public int MessageGetRtfBody(IntPtr message, byte[] message_body, UIntPtr size, IntPtr error)
        {
            return NativeWin32.MessageGetRtfBody(message, message_body, size, error);
        }
        public int MessageGetHtmlBodySize(IntPtr message, out UIntPtr size, IntPtr error)
        {
            return NativeWin32.MessageGetHtmlBodySize(message, out size, error);
        }
        public int MessageGetHtmlBody(IntPtr message, byte[] message_body, UIntPtr size, IntPtr error)
        {
            return NativeWin32.MessageGetHtmlBody(message, message_body, size, error);
        }
        public int MultiValueFree(out IntPtr multi_value, IntPtr error)
        {
            return NativeWin32.MultiValueFree(out multi_value, error);
        }
        public int MultiValueGetNumberOfValues(IntPtr multi_value, out int number_of_values, IntPtr error)
        {
            return NativeWin32.MultiValueGetNumberOfValues(multi_value, out number_of_values, error);
        }
        public int MultiValueGetValue(IntPtr multi_value, int value_index, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValue(multi_value, value_index, out value_type, out value_data, out value_data_size, error);
        }
        public int MultiValueGetValue32bit(IntPtr multi_value, int value_index, out uint value, IntPtr error)
        {
            return NativeWin32.MultiValueGetValue32bit(multi_value, value_index, out value, error);
        }
        public int MultiValueGetValue64bit(IntPtr multi_value, int value_index, out ulong value, IntPtr error)
        {
            return NativeWin32.MultiValueGetValue64bit(multi_value, value_index, out value, error);
        }
        public int MultiValueGetValueFiletime(IntPtr multi_value, int value_index, out ulong filetime, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueFiletime(multi_value, value_index, out filetime, error);
        }
        public int MultiValueGetValueUtf8StringSize(IntPtr multi_value, int value_index, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueUtf8StringSize(multi_value, value_index, out utf8_string_size, error);
        }
        public int MultiValueGetValueUtf8String(IntPtr multi_value, int value_index, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueUtf8String(multi_value, value_index, utf8_string, utf8_string_size, error);
        }
        public int MultiValueGetValueUtf16StringSize(IntPtr multi_value, int value_index, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueUtf16StringSize(multi_value, value_index, out utf16_string_size, error);
        }
        public int MultiValueGetValueUtf16String(IntPtr multi_value, int value_index, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueUtf16String(multi_value, value_index, utf16_string, utf16_string_size, error);
        }
        public int MultiValueGetValueBinaryDataSize(IntPtr multi_value, int value_index, out UIntPtr size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueBinaryDataSize(multi_value, value_index, out size, error);
        }
        public int MultiValueGetValueBinaryData(IntPtr multi_value, int value_index, byte[] binary_data, UIntPtr size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueBinaryData(multi_value, value_index, binary_data, size, error);
        }
        public int MultiValueGetValueGuid(IntPtr multi_value, int value_index, byte[] guid, UIntPtr size, IntPtr error)
        {
            return NativeWin32.MultiValueGetValueGuid(multi_value, value_index, guid, size, error);
        }
        public int NameToIdMapEntryGetType(IntPtr name_to_id_map_entry, out byte entry_type, IntPtr error)
        {
            return NativeWin32.NameToIdMapEntryGetType(name_to_id_map_entry, out entry_type, error);
        }
        public int NameToIdMapEntryGetNumber(IntPtr name_to_id_map_entry, out uint number, IntPtr error)
        {
            return NativeWin32.NameToIdMapEntryGetNumber(name_to_id_map_entry, out number, error);
        }
        public int NameToIdMapEntryGetUtf8StringSize(IntPtr name_to_id_map_entry, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.NameToIdMapEntryGetUtf8StringSize(name_to_id_map_entry, out utf8_string_size, error);
        }
        public int NameToIdMapEntryGetUtf8String(IntPtr name_to_id_map_entry, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.NameToIdMapEntryGetUtf8String(name_to_id_map_entry, utf8_string, utf8_string_size, error);
        }
        public int NameToIdMapEntryGetUtf16StringSize(IntPtr name_to_id_map_entry, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.NameToIdMapEntryGetUtf16StringSize(name_to_id_map_entry, out utf16_string_size, error);
        }
        public int NameToIdMapEntryGetUtf16String(IntPtr name_to_id_map_entry, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.NameToIdMapEntryGetUtf16String(name_to_id_map_entry, utf16_string, utf16_string_size, error);
        }
        public int NameToIdMapEntryGetGuid(IntPtr name_to_id_map_entry, byte[] guid, UIntPtr size, IntPtr error)
        {
            return NativeWin32.NameToIdMapEntryGetGuid(name_to_id_map_entry, guid, size, error);
        }
        public void NotifySetVerbose(int verbose)
        {
            NativeWin32.NotifySetVerbose(verbose);
        }
        public int NotifySetStream(IntPtr stream, IntPtr error)
        {
            return NativeWin32.NotifySetStream(stream, error);
        }
        public int NotifyStreamOpen([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr error)
        {
            return NativeWin32.NotifyStreamOpen(filename, error);
        }
        public int NotifyStreamClose(IntPtr error)
        {
            return NativeWin32.NotifyStreamClose(error);
        }
        public int RecordEntryFree(out IntPtr record_entry, IntPtr error)
        {
            return NativeWin32.RecordEntryFree(out record_entry, error);
        }
        public int RecordEntryGetEntryType(IntPtr record_entry, out uint entry_type, IntPtr error)
        {
            return NativeWin32.RecordEntryGetEntryType(record_entry, out entry_type, error);
        }
        public int RecordEntryGetValueType(IntPtr record_entry, out uint value_type, IntPtr error)
        {
            return NativeWin32.RecordEntryGetValueType(record_entry, out value_type, error);
        }
        public int RecordEntryGetNameToIdMapEntry(IntPtr record_entry, out IntPtr name_to_id_map_entry, IntPtr error)
        {
            return NativeWin32.RecordEntryGetNameToIdMapEntry(record_entry, out name_to_id_map_entry, error);
        }
        public int RecordEntryGetDataSize(IntPtr record_entry, out UIntPtr data_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataSize(record_entry, out data_size, error);
        }
        public int RecordEntryGetData(IntPtr record_entry, byte[] data, UIntPtr data_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetData(record_entry, data, data_size, error);
        }
        public int RecordEntryGetDataAsBoolean(IntPtr record_entry, out byte value_boolean, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsBoolean(record_entry, out value_boolean, error);
        }
        public int RecordEntryGetDataAs16bitInteger(IntPtr record_entry, out ushort value_16bit, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAs16bitInteger(record_entry, out value_16bit, error);
        }
        public int RecordEntryGetDataAs32bitInteger(IntPtr record_entry, out uint value_32bit, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAs32bitInteger(record_entry, out value_32bit, error);
        }
        public int RecordEntryGetDataAs64bitInteger(IntPtr record_entry, out ulong value_64bit, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAs64bitInteger(record_entry, out value_64bit, error);
        }
        public int RecordEntryGetDataAsFiletime(IntPtr record_entry, out ulong filetime, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsFiletime(record_entry, out filetime, error);
        }
        public int RecordEntryGetDataAsFloatingtime(IntPtr record_entry, out ulong floatingtime, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsFloatingtime(record_entry, out floatingtime, error);
        }
        public int RecordEntryGetDataAsSize(IntPtr record_entry, out long value_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsSize(record_entry, out value_size, error);
        }
        public int RecordEntryGetDataAsFloatingPoint(IntPtr record_entry, out double value_floating_point, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsFloatingPoint(record_entry, out value_floating_point, error);
        }
        public int RecordEntryGetDataAsUtf8StringSize(IntPtr record_entry, out UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsUtf8StringSize(record_entry, out utf8_string_size, error);
        }
        public int RecordEntryGetDataAsUtf8String(IntPtr record_entry, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsUtf8String(record_entry, utf8_string, utf8_string_size, error);
        }
        public int RecordEntryGetDataAsUtf16StringSize(IntPtr record_entry, out UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsUtf16StringSize(record_entry, out utf16_string_size, error);
        }
        public int RecordEntryGetDataAsUtf16String(IntPtr record_entry, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsUtf16String(record_entry, utf16_string, utf16_string_size, error);
        }
        public int RecordEntryGetDataAsGuid(IntPtr record_entry, byte[] gui_data, UIntPtr guid_data_size, IntPtr error)
        {
            return NativeWin32.RecordEntryGetDataAsGuid(record_entry, gui_data, guid_data_size, error);
        }
        public int RecordEntryGetMultiValue(IntPtr record_entry, out IntPtr multi_value, IntPtr error)
        {
            return NativeWin32.RecordEntryGetMultiValue(record_entry, out multi_value, error);
        }
        public long RecordEntryReadBuffer(IntPtr record_entry, byte[] buffer, UIntPtr buffer_size, IntPtr error)
        {
            int native_result = NativeWin32.RecordEntryReadBuffer(record_entry, buffer, buffer_size, error);
            return native_result;  // 'int' to 'long' (32-Bit Plattforms)
        }
        public long RecordEntrySeekOffset(IntPtr record_entry, long offset, int whence, IntPtr error)
        {
            int native_result = NativeWin32.RecordEntrySeekOffset(record_entry, offset, whence, error);
            return native_result;  // 'int' to 'long' (32-Bit Plattforms)
        }
        public int RecordSetFree(out IntPtr record_set, IntPtr error)
        {
            return NativeWin32.RecordSetFree(out record_set, error);
        }
        public int RecordSetGetNumberOfEntries(IntPtr record_set, out int number_of_entries, IntPtr error)
        {
            return NativeWin32.RecordSetGetNumberOfEntries(record_set, out number_of_entries, error);
        }
        public int RecordSetGetEntryByIndex(IntPtr record_set, int entry_index, out IntPtr record_entry, IntPtr error)
        {
            return NativeWin32.RecordSetGetEntryByIndex(record_set, entry_index, out record_entry, error);
        }
        public int RecordSetGetEntryByType(IntPtr record_set, uint entry_type, uint value_type, out IntPtr record_entry, byte flags, IntPtr error)
        {
            return NativeWin32.RecordSetGetEntryByType(record_set, entry_type, value_type, out record_entry, flags, error);
        }
        public int RecordSetGetEntryByUtf8Name(IntPtr record_set, byte[] utf8_string, UIntPtr utf8_string_length, uint value_type, out IntPtr record_entry, byte flags, IntPtr error)
        {
            return NativeWin32.RecordSetGetEntryByUtf8Name(record_set, utf8_string, utf8_string_length, value_type, out record_entry, flags, error);
        }
        public int RecordSetGetEntryByUtf16Name(IntPtr record_set, ushort[] utf16_string, UIntPtr utf16_string_length, uint value_type, out IntPtr record_entry, byte flags, IntPtr error)
        {
            return NativeWin32.RecordSetGetEntryByUtf16Name(record_set, utf16_string, utf16_string_length, value_type, out record_entry, flags, error);
        }
        public int GetAccessFlagsRead()
        {
            return NativeWin32.GetAccessFlagsRead();
        }
        public int GetCodepage(out int codepage, IntPtr error)
        {
            return NativeWin32.GetCodepage(out codepage, error);
        }
        public int SetCodepage(int codepage, IntPtr error)
        {
            return NativeWin32.SetCodepage(codepage, error);
        }
        public int CheckFileSignature([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr error)
        {
            return NativeWin32.CheckFileSignature(filename, error);
        }
        public int CheckFileSignatureWide([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr error)
        {
            return NativeWin32.CheckFileSignatureWide(filename, error);
        }
        public int CheckFileSignatureFileIoHandle(IntPtr file_io_handle, IntPtr error)
        {
            return NativeWin32.CheckFileSignatureFileIoHandle(file_io_handle, error);
        }
    }
}