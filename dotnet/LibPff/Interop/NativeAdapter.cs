// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LibPff.Interop
{
    internal sealed class NativeAdapter : INativeAdapter
    {
        public int AttachmentGetType(IntPtr attachment, out int attachment_type, out IntPtr error)
        {
            return Native.AttachmentGetType(attachment, out attachment_type, out error);
        }
        public int AttachmentGetDataSize(IntPtr attachment, out long size, out IntPtr error)
        {
            return Native.AttachmentGetDataSize(attachment, out size, out error);
        }
        public long AttachmentDataReadBuffer(IntPtr attachment, byte[] buffer, UIntPtr buffer_size, out IntPtr error)
        {
            return Native.AttachmentDataReadBuffer(attachment, buffer, buffer_size, out error);
        }
        public long AttachmentDataSeekOffset(IntPtr attachment, long offset, int whence, out IntPtr error)
        {
            return Native.AttachmentDataSeekOffset(attachment, offset, whence, out error);
        }
        public int AttachmentGetDataFileIoHandle(IntPtr attachment, out IntPtr file_io_handle, out IntPtr error)
        {
            return Native.AttachmentGetDataFileIoHandle(attachment, out file_io_handle, out error);
        }
        public int AttachmentGetItem(IntPtr attachment, out IntPtr attached_item, out IntPtr error)
        {
            return Native.AttachmentGetItem(attachment, out attached_item, out error);
        }
        public void ErrorFree(out IntPtr error)
        {
            Native.ErrorFree(out error);
        }
        public int ErrorFprint(IntPtr error, IntPtr stream)
        {
            return Native.ErrorFprint(error, stream);
        }
        public int ErrorSprint(IntPtr error, StringBuilder string_2, UIntPtr size)
        {
            return Native.ErrorSprint(error, string_2, size);
        }
        public int ErrorBacktraceFprint(IntPtr error, IntPtr stream)
        {
            return Native.ErrorBacktraceFprint(error, stream);
        }
        public int ErrorBacktraceSprint(IntPtr error, StringBuilder string_2, UIntPtr size)
        {
            return Native.ErrorBacktraceSprint(error, string_2, size);
        }
        public int FileInitialize(out IntPtr file, out IntPtr error)
        {
            return Native.FileInitialize(out file, out error);
        }
        public int FileFree(out IntPtr file, out IntPtr error)
        {
            return Native.FileFree(out file, out error);
        }
        public int FileSignalAbort(IntPtr file, out IntPtr error)
        {
            return Native.FileSignalAbort(file, out error);
        }
        public int FileOpen(IntPtr file, [MarshalAs(UnmanagedType.LPStr)] string filename, int access_flags, out IntPtr error)
        {
            return Native.FileOpen(file, filename, access_flags, out error);
        }
        public int FileOpenWide(IntPtr file, [MarshalAs(UnmanagedType.LPWStr)] string filename, int access_flags, out IntPtr error)
        {
            return Native.FileOpenWide(file, filename, access_flags, out error);
        }
        public int FileOpenFileIoHandle(IntPtr file, IntPtr file_io_handle, int access_flags, out IntPtr error)
        {
            return Native.FileOpenFileIoHandle(file, file_io_handle, access_flags, out error);
        }
        public int FileClose(IntPtr file, out IntPtr error)
        {
            return Native.FileClose(file, out error);
        }
        public int FileIsCorrupted(IntPtr file, out IntPtr error)
        {
            return Native.FileIsCorrupted(file, out error);
        }
        public int FileRecoverItems(IntPtr file, byte recovery_flags, out IntPtr error)
        {
            return Native.FileRecoverItems(file, recovery_flags, out error);
        }
        public int FileGetSize(IntPtr file, out long size, out IntPtr error)
        {
            return Native.FileGetSize(file, out size, out error);
        }
        public int FileGetContentType(IntPtr file, out byte content_type, out IntPtr error)
        {
            return Native.FileGetContentType(file, out content_type, out error);
        }
        public int FileGetType(IntPtr file, out byte type, out IntPtr error)
        {
            return Native.FileGetType(file, out type, out error);
        }
        public int FileGetEncryptionType(IntPtr file, out byte encryption_type, out IntPtr error)
        {
            return Native.FileGetEncryptionType(file, out encryption_type, out error);
        }
        public int FileGetAsciiCodepage(IntPtr file, out int ascii_codepage, out IntPtr error)
        {
            return Native.FileGetAsciiCodepage(file, out ascii_codepage, out error);
        }
        public int FileSetAsciiCodepage(IntPtr file, int ascii_codepage, out IntPtr error)
        {
            return Native.FileSetAsciiCodepage(file, ascii_codepage, out error);
        }
        public int FileGetNumberOfUnallocatedBlocks(IntPtr file, int unallocated_block_type, out int number_of_unallocated_blocks, out IntPtr error)
        {
            return Native.FileGetNumberOfUnallocatedBlocks(file, unallocated_block_type, out number_of_unallocated_blocks, out error);
        }
        public int FileGetUnallocatedBlock(IntPtr file, int unallocated_block_type, int unallocated_block_index, out long offset, out long size, out IntPtr error)
        {
            return Native.FileGetUnallocatedBlock(file, unallocated_block_type, unallocated_block_index, out offset, out size, out error);
        }
        public int FileGetRootItem(IntPtr file, out IntPtr root_item, out IntPtr error)
        {
            return Native.FileGetRootItem(file, out root_item, out error);
        }
        public int FileGetMessageStore(IntPtr file, out IntPtr message_store, out IntPtr error)
        {
            return Native.FileGetMessageStore(file, out message_store, out error);
        }
        public int FileGetNameToIdMap(IntPtr file, out IntPtr name_to_id_map, out IntPtr error)
        {
            return Native.FileGetNameToIdMap(file, out name_to_id_map, out error);
        }
        public int FileGetRootFolder(IntPtr file, out IntPtr root_folder, out IntPtr error)
        {
            return Native.FileGetRootFolder(file, out root_folder, out error);
        }
        public int FileGetItemByIdentifier(IntPtr file, uint item_identifier, out IntPtr item, out IntPtr error)
        {
            return Native.FileGetItemByIdentifier(file, item_identifier, out item, out error);
        }
        public int FileGetNumberOfOrphanItems(IntPtr file, out int number_of_orphan_items, out IntPtr error)
        {
            return Native.FileGetNumberOfOrphanItems(file, out number_of_orphan_items, out error);
        }
        public int FileGetOrphanItemByIndex(IntPtr file, int orphan_item_index, out IntPtr orphan_item, out IntPtr error)
        {
            return Native.FileGetOrphanItemByIndex(file, orphan_item_index, out orphan_item, out error);
        }
        public int FileGetNumberOfRecoveredItems(IntPtr file, out int number_of_recovered_items, out IntPtr error)
        {
            return Native.FileGetNumberOfRecoveredItems(file, out number_of_recovered_items, out error);
        }
        public int FileGetRecoveredItemByIndex(IntPtr file, int recovered_item_index, out IntPtr recovered_item, out IntPtr error)
        {
            return Native.FileGetRecoveredItemByIndex(file, recovered_item_index, out recovered_item, out error);
        }
        public int FolderGetType(IntPtr folder, out byte type, out IntPtr error)
        {
            return Native.FolderGetType(folder, out type, out error);
        }
        public int FolderGetUtf8NameSize(IntPtr folder, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.FolderGetUtf8NameSize(folder, out utf8_string_size, out error);
        }
        public int FolderGetUtf8Name(IntPtr folder, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.FolderGetUtf8Name(folder, utf8_string, utf8_string_size, out error);
        }
        public int FolderGetUtf16NameSize(IntPtr folder, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.FolderGetUtf16NameSize(folder, out utf16_string_size, out error);
        }
        public int FolderGetUtf16Name(IntPtr folder, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.FolderGetUtf16Name(folder, utf16_string, utf16_string_size, out error);
        }
        public int FolderGetNumberOfSubFolders(IntPtr folder, out int number_of_sub_folders, out IntPtr error)
        {
            return Native.FolderGetNumberOfSubFolders(folder, out number_of_sub_folders, out error);
        }
        public int FolderGetSubFolder(IntPtr folder, int sub_folder_index, out IntPtr sub_folder, out IntPtr error)
        {
            return Native.FolderGetSubFolder(folder, sub_folder_index, out sub_folder, out error);
        }
        public int FolderGetSubFolderByUtf8Name(IntPtr folder, byte[] utf8_sub_folder_name, UIntPtr utf8_sub_folder_name_size, out IntPtr sub_folder, out IntPtr error)
        {
            return Native.FolderGetSubFolderByUtf8Name(folder, utf8_sub_folder_name, utf8_sub_folder_name_size, out sub_folder, out error);
        }
        public int FolderGetSubFolderByUtf16Name(IntPtr folder, ushort[] utf16_sub_folder_name, UIntPtr utf16_sub_folder_name_size, out IntPtr sub_folder, out IntPtr error)
        {
            return Native.FolderGetSubFolderByUtf16Name(folder, utf16_sub_folder_name, utf16_sub_folder_name_size, out sub_folder, out error);
        }
        public int FolderGetSubFolders(IntPtr item, out IntPtr sub_folders, out IntPtr error)
        {
            return Native.FolderGetSubFolders(item, out sub_folders, out error);
        }
        public int FolderGetNumberOfSubMessages(IntPtr folder, out int number_of_sub_messages, out IntPtr error)
        {
            return Native.FolderGetNumberOfSubMessages(folder, out number_of_sub_messages, out error);
        }
        public int FolderGetSubMessage(IntPtr folder, int sub_message_index, out IntPtr sub_message, out IntPtr error)
        {
            return Native.FolderGetSubMessage(folder, sub_message_index, out sub_message, out error);
        }
        public int FolderGetSubMessageByUtf8Name(IntPtr folder, byte[] utf8_sub_message_name, UIntPtr utf8_sub_message_name_size, out IntPtr sub_message, out IntPtr error)
        {
            return Native.FolderGetSubMessageByUtf8Name(folder, utf8_sub_message_name, utf8_sub_message_name_size, out sub_message, out error);
        }
        public int FolderGetSubMessageByUtf16Name(IntPtr folder, ushort[] utf16_sub_message_name, UIntPtr utf16_sub_message_name_size, out IntPtr sub_message, out IntPtr error)
        {
            return Native.FolderGetSubMessageByUtf16Name(folder, utf16_sub_message_name, utf16_sub_message_name_size, out sub_message, out error);
        }
        public int FolderGetSubMessages(IntPtr item, out IntPtr sub_messages, out IntPtr error)
        {
            return Native.FolderGetSubMessages(item, out sub_messages, out error);
        }
        public int FolderGetNumberOfSubAssociatedContents(IntPtr folder, out int number_of_sub_associated_contents, out IntPtr error)
        {
            return Native.FolderGetNumberOfSubAssociatedContents(folder, out number_of_sub_associated_contents, out error);
        }
        public int FolderGetSubAssociatedContent(IntPtr folder, int sub_associated_content_index, out IntPtr sub_associated_content, out IntPtr error)
        {
            return Native.FolderGetSubAssociatedContent(folder, sub_associated_content_index, out sub_associated_content, out error);
        }
        public int FolderGetSubAssociatedContents(IntPtr item, out IntPtr sub_associated_contents, out IntPtr error)
        {
            return Native.FolderGetSubAssociatedContents(item, out sub_associated_contents, out error);
        }
        public int FolderGetUnknowns(IntPtr folder, out IntPtr unknowns, out IntPtr error)
        {
            return Native.FolderGetUnknowns(folder, out unknowns, out error);
        }
        public int ItemFree(out IntPtr item, out IntPtr error)
        {
            return Native.ItemFree(out item, out error);
        }
        public int ItemGetIdentifier(IntPtr item, out uint identifier, out IntPtr error)
        {
            return Native.ItemGetIdentifier(item, out identifier, out error);
        }
        public int ItemGetNumberOfRecordSets(IntPtr item, out int number_of_record_sets, out IntPtr error)
        {
            return Native.ItemGetNumberOfRecordSets(item, out number_of_record_sets, out error);
        }
        public int ItemGetRecordSetByIndex(IntPtr item, int record_set_index, out IntPtr record_set, out IntPtr error)
        {
            return Native.ItemGetRecordSetByIndex(item, record_set_index, out record_set, out error);
        }
        public int ItemGetNumberOfEntries(IntPtr item, out uint number_of_entries, out IntPtr error)
        {
            return Native.ItemGetNumberOfEntries(item, out number_of_entries, out error);
        }
        public int ItemGetType(IntPtr item, out byte item_type, out IntPtr error)
        {
            return Native.ItemGetType(item, out item_type, out error);
        }
        public int ItemGetNumberOfSubItems(IntPtr item, out int number_of_sub_items, out IntPtr error)
        {
            return Native.ItemGetNumberOfSubItems(item, out number_of_sub_items, out error);
        }
        public int ItemGetSubItem(IntPtr item, int sub_item_index, out IntPtr sub_item, out IntPtr error)
        {
            return Native.ItemGetSubItem(item, sub_item_index, out sub_item, out error);
        }
        public int ItemGetSubItemByIdentifier(IntPtr item, uint sub_item_identifier, out IntPtr sub_item, out IntPtr error)
        {
            return Native.ItemGetSubItemByIdentifier(item, sub_item_identifier, out sub_item, out error);
        }
        public int FileGetOrphanItem(IntPtr file, int orphan_item_index, out IntPtr orphan_item, out IntPtr error)
        {
            return Native.FileGetOrphanItem(file, orphan_item_index, out orphan_item, out error);
        }
        public int FileGetRecoveredItem(IntPtr file, int recovered_item_index, out IntPtr recovered_item, out IntPtr error)
        {
            return Native.FileGetRecoveredItem(file, recovered_item_index, out recovered_item, out error);
        }
        public int ItemClone(out IntPtr destination_item, IntPtr source_item, out IntPtr error)
        {
            return Native.ItemClone(out destination_item, source_item, out error);
        }
        public int ItemGetNumberOfSets(IntPtr item, out uint number_of_sets, out IntPtr error)
        {
            return Native.ItemGetNumberOfSets(item, out number_of_sets, out error);
        }
        public int ItemGetEntryType(IntPtr item, int set_index, int entry_index, out uint entry_type, out uint value_type, out IntPtr name_to_id_map_entry, out IntPtr error)
        {
            return Native.ItemGetEntryType(item, set_index, entry_index, out entry_type, out value_type, out name_to_id_map_entry, out error);
        }
        public int ItemGetValueType(IntPtr item, int set_index, uint entry_type, out uint value_type, byte flags, out IntPtr error)
        {
            return Native.ItemGetValueType(item, set_index, entry_type, out value_type, flags, out error);
        }
        public int ItemGetEntryValue(IntPtr item, int set_index, uint entry_type, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValue(item, set_index, entry_type, out value_type, out value_data, out value_data_size, flags, out error);
        }
        public int ItemGetEntryValueByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out value_type, out value_data, out value_data_size, out error);
        }
        public int ItemGetEntryValueByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out value_type, out value_data, out value_data_size, out error);
        }
        public int ItemGetEntryValueBoolean(IntPtr item, int set_index, uint entry_type, out byte entry_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueBoolean(item, set_index, entry_type, out entry_value, flags, out error);
        }
        public int ItemGetEntryValueBooleanByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out byte entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueBooleanByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueBooleanByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out byte entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueBooleanByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValue16bit(IntPtr item, int set_index, uint entry_type, out ushort entry_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValue16bit(item, set_index, entry_type, out entry_value, flags, out error);
        }
        public int ItemGetEntryValue16bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ushort entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValue16bitByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValue16bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ushort entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValue16bitByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValue32bit(IntPtr item, int set_index, uint entry_type, out uint entry_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValue32bit(item, set_index, entry_type, out entry_value, flags, out error);
        }
        public int ItemGetEntryValue32bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out uint entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValue32bitByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValue32bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out uint entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValue32bitByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValue64bit(IntPtr item, int set_index, uint entry_type, out ulong entry_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValue64bit(item, set_index, entry_type, out entry_value, flags, out error);
        }
        public int ItemGetEntryValue64bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ulong entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValue64bitByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValue64bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ulong entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValue64bitByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueFiletime(IntPtr item, int set_index, uint entry_type, out ulong entry_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueFiletime(item, set_index, entry_type, out entry_value, flags, out error);
        }
        public int ItemGetEntryValueFiletimeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ulong entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueFiletimeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueFiletimeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ulong entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueFiletimeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueSize(IntPtr item, int set_index, uint entry_type, out UIntPtr entry_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueSize(item, set_index, entry_type, out entry_value, flags, out error);
        }
        public int ItemGetEntryValueSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueFloatingPoint(IntPtr item, int set_index, uint entry_type, out double entry_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueFloatingPoint(item, set_index, entry_type, out entry_value, flags, out error);
        }
        public int ItemGetEntryValueFloatingPointByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out double entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueFloatingPointByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueFloatingPointByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out double entry_value, out IntPtr error)
        {
            return Native.ItemGetEntryValueFloatingPointByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out entry_value, out error);
        }
        public int ItemGetEntryValueUtf8StringSize(IntPtr item, int set_index, uint entry_type, out UIntPtr utf8_string_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf8StringSize(item, set_index, entry_type, out utf8_string_size, flags, out error);
        }
        public int ItemGetEntryValueUtf8StringSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf8StringSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out utf8_string_size, out error);
        }
        public int ItemGetEntryValueUtf8StringSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf8StringSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out utf8_string_size, out error);
        }
        public int ItemGetEntryValueUtf8String(IntPtr item, int set_index, uint entry_type, byte[] utf8_string, UIntPtr utf8_string_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf8String(item, set_index, entry_type, utf8_string, utf8_string_size, flags, out error);
        }
        public int ItemGetEntryValueUtf8StringByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf8StringByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, utf8_string, utf8_string_size, out error);
        }
        public int ItemGetEntryValueUtf8StringByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf8StringByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, utf8_string, utf8_string_size, out error);
        }
        public int ItemGetEntryValueUtf16StringSize(IntPtr item, int set_index, uint entry_type, out UIntPtr utf16_string_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf16StringSize(item, set_index, entry_type, out utf16_string_size, flags, out error);
        }
        public int ItemGetEntryValueUtf16StringSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf16StringSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out utf16_string_size, out error);
        }
        public int ItemGetEntryValueUtf16StringSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf16StringSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out utf16_string_size, out error);
        }
        public int ItemGetEntryValueUtf16String(IntPtr item, int set_index, uint entry_type, ushort[] utf16_string, UIntPtr utf16_string_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf16String(item, set_index, entry_type, utf16_string, utf16_string_size, flags, out error);
        }
        public int ItemGetEntryValueUtf16StringByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf16StringByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, utf16_string, utf16_string_size, out error);
        }
        public int ItemGetEntryValueUtf16StringByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueUtf16StringByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, utf16_string, utf16_string_size, out error);
        }
        public int ItemGetEntryValueBinaryDataSize(IntPtr item, int set_index, uint entry_type, out UIntPtr binary_data_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueBinaryDataSize(item, set_index, entry_type, out binary_data_size, flags, out error);
        }
        public int ItemGetEntryValueBinaryDataSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr binary_data_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueBinaryDataSizeByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, out binary_data_size, out error);
        }
        public int ItemGetEntryValueBinaryDataSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr binary_data_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueBinaryDataSizeByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, out binary_data_size, out error);
        }
        public int ItemGetEntryValueBinaryData(IntPtr item, int set_index, uint entry_type, byte[] binary_data, UIntPtr binary_data_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueBinaryData(item, set_index, entry_type, binary_data, binary_data_size, flags, out error);
        }
        public int ItemGetEntryValueBinaryDataByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, byte[] binary_data, UIntPtr binary_data_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueBinaryDataByUtf8Name(item, set_index, utf8_entry_name, utf8_entry_name_length, binary_data, binary_data_size, out error);
        }
        public int ItemGetEntryValueBinaryDataByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, byte[] binary_data, UIntPtr binary_data_size, out IntPtr error)
        {
            return Native.ItemGetEntryValueBinaryDataByUtf16Name(item, set_index, utf16_entry_name, utf16_entry_name_length, binary_data, binary_data_size, out error);
        }
        public int ItemGetEntryValueGuid(IntPtr item, int set_index, uint entry_type, byte[] guid, UIntPtr guid_size, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryValueGuid(item, set_index, entry_type, guid, guid_size, flags, out error);
        }
        public int ItemGetEntryMultiValue(IntPtr item, int set_index, uint entry_type, out IntPtr multi_value, byte flags, out IntPtr error)
        {
            return Native.ItemGetEntryMultiValue(item, set_index, entry_type, out multi_value, flags, out error);
        }
        public int RecordEntryGetValueDataSize(IntPtr record_entry, out UIntPtr value_data_size, out IntPtr error)
        {
            return Native.RecordEntryGetValueDataSize(record_entry, out value_data_size, out error);
        }
        public int RecordEntryCopyValueData(IntPtr record_entry, byte[] value_data, UIntPtr value_data_size, out IntPtr error)
        {
            return Native.RecordEntryCopyValueData(record_entry, value_data, value_data_size, out error);
        }
        public int RecordEntryGetValueBoolean(IntPtr record_entry, out byte value_boolean, out IntPtr error)
        {
            return Native.RecordEntryGetValueBoolean(record_entry, out value_boolean, out error);
        }
        public int RecordEntryGetValue16bit(IntPtr record_entry, out ushort value_16bit, out IntPtr error)
        {
            return Native.RecordEntryGetValue16bit(record_entry, out value_16bit, out error);
        }
        public int RecordEntryGetValue32bit(IntPtr record_entry, out uint value_32bit, out IntPtr error)
        {
            return Native.RecordEntryGetValue32bit(record_entry, out value_32bit, out error);
        }
        public int RecordEntryGetValue64bit(IntPtr record_entry, out ulong value_64bit, out IntPtr error)
        {
            return Native.RecordEntryGetValue64bit(record_entry, out value_64bit, out error);
        }
        public int RecordEntryGetValueFiletime(IntPtr record_entry, out ulong value_64bit, out IntPtr error)
        {
            return Native.RecordEntryGetValueFiletime(record_entry, out value_64bit, out error);
        }
        public int RecordEntryGetValueSize(IntPtr record_entry, out UIntPtr value_size, out IntPtr error)
        {
            return Native.RecordEntryGetValueSize(record_entry, out value_size, out error);
        }
        public int RecordEntryGetValueFloatingPoint(IntPtr record_entry, out double value_floating_point, out IntPtr error)
        {
            return Native.RecordEntryGetValueFloatingPoint(record_entry, out value_floating_point, out error);
        }
        public int RecordEntryGetValueUtf8StringSize(IntPtr record_entry, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetValueUtf8StringSize(record_entry, out utf8_string_size, out error);
        }
        public int RecordEntryGetValueUtf8String(IntPtr record_entry, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetValueUtf8String(record_entry, utf8_string, utf8_string_size, out error);
        }
        public int RecordEntryGetValueUtf16StringSize(IntPtr record_entry, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetValueUtf16StringSize(record_entry, out utf16_string_size, out error);
        }
        public int RecordEntryGetValueUtf16String(IntPtr record_entry, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetValueUtf16String(record_entry, utf16_string, utf16_string_size, out error);
        }
        public int MessageGetEntryValueUtf8StringSize(IntPtr message, uint entry_type, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.MessageGetEntryValueUtf8StringSize(message, entry_type, out utf8_string_size, out error);
        }
        public int MessageGetEntryValueUtf8String(IntPtr message, uint entry_type, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.MessageGetEntryValueUtf8String(message, entry_type, utf8_string, utf8_string_size, out error);
        }
        public int MessageGetEntryValueUtf16StringSize(IntPtr message, uint entry_type, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.MessageGetEntryValueUtf16StringSize(message, entry_type, out utf16_string_size, out error);
        }
        public int MessageGetEntryValueUtf16String(IntPtr message, uint entry_type, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.MessageGetEntryValueUtf16String(message, entry_type, utf16_string, utf16_string_size, out error);
        }
        public int MessageGetClientSubmitTime(IntPtr message, out ulong filetime, out IntPtr error)
        {
            return Native.MessageGetClientSubmitTime(message, out filetime, out error);
        }
        public int MessageGetDeliveryTime(IntPtr message, out ulong filetime, out IntPtr error)
        {
            return Native.MessageGetDeliveryTime(message, out filetime, out error);
        }
        public int MessageGetCreationTime(IntPtr message, out ulong filetime, out IntPtr error)
        {
            return Native.MessageGetCreationTime(message, out filetime, out error);
        }
        public int MessageGetModificationTime(IntPtr message, out ulong filetime, out IntPtr error)
        {
            return Native.MessageGetModificationTime(message, out filetime, out error);
        }
        public int MessageGetNumberOfAttachments(IntPtr message, out int number_of_attachments, out IntPtr error)
        {
            return Native.MessageGetNumberOfAttachments(message, out number_of_attachments, out error);
        }
        public int MessageGetAttachment(IntPtr message, int attachment_index, out IntPtr attachment, out IntPtr error)
        {
            return Native.MessageGetAttachment(message, attachment_index, out attachment, out error);
        }
        public int MessageGetAttachments(IntPtr message, out IntPtr attachments, out IntPtr error)
        {
            return Native.MessageGetAttachments(message, out attachments, out error);
        }
        public int MessageGetRecipients(IntPtr message, out IntPtr recipients, out IntPtr error)
        {
            return Native.MessageGetRecipients(message, out recipients, out error);
        }
        public int MessageGetPlainTextBodySize(IntPtr message, out UIntPtr size, out IntPtr error)
        {
            return Native.MessageGetPlainTextBodySize(message, out size, out error);
        }
        public int MessageGetPlainTextBody(IntPtr message, byte[] message_body, UIntPtr size, out IntPtr error)
        {
            return Native.MessageGetPlainTextBody(message, message_body, size, out error);
        }
        public int MessageGetRtfBodySize(IntPtr message, out UIntPtr size, out IntPtr error)
        {
            return Native.MessageGetRtfBodySize(message, out size, out error);
        }
        public int MessageGetRtfBody(IntPtr message, byte[] message_body, UIntPtr size, out IntPtr error)
        {
            return Native.MessageGetRtfBody(message, message_body, size, out error);
        }
        public int MessageGetHtmlBodySize(IntPtr message, out UIntPtr size, out IntPtr error)
        {
            return Native.MessageGetHtmlBodySize(message, out size, out error);
        }
        public int MessageGetHtmlBody(IntPtr message, byte[] message_body, UIntPtr size, out IntPtr error)
        {
            return Native.MessageGetHtmlBody(message, message_body, size, out error);
        }
        public int MultiValueFree(out IntPtr multi_value, out IntPtr error)
        {
            return Native.MultiValueFree(out multi_value, out error);
        }
        public int MultiValueGetNumberOfValues(IntPtr multi_value, out int number_of_values, out IntPtr error)
        {
            return Native.MultiValueGetNumberOfValues(multi_value, out number_of_values, out error);
        }
        public int MultiValueGetValue(IntPtr multi_value, int value_index, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, out IntPtr error)
        {
            return Native.MultiValueGetValue(multi_value, value_index, out value_type, out value_data, out value_data_size, out error);
        }
        public int MultiValueGetValue32bit(IntPtr multi_value, int value_index, out uint value, out IntPtr error)
        {
            return Native.MultiValueGetValue32bit(multi_value, value_index, out value, out error);
        }
        public int MultiValueGetValue64bit(IntPtr multi_value, int value_index, out ulong value, out IntPtr error)
        {
            return Native.MultiValueGetValue64bit(multi_value, value_index, out value, out error);
        }
        public int MultiValueGetValueFiletime(IntPtr multi_value, int value_index, out ulong filetime, out IntPtr error)
        {
            return Native.MultiValueGetValueFiletime(multi_value, value_index, out filetime, out error);
        }
        public int MultiValueGetValueUtf8StringSize(IntPtr multi_value, int value_index, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.MultiValueGetValueUtf8StringSize(multi_value, value_index, out utf8_string_size, out error);
        }
        public int MultiValueGetValueUtf8String(IntPtr multi_value, int value_index, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.MultiValueGetValueUtf8String(multi_value, value_index, utf8_string, utf8_string_size, out error);
        }
        public int MultiValueGetValueUtf16StringSize(IntPtr multi_value, int value_index, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.MultiValueGetValueUtf16StringSize(multi_value, value_index, out utf16_string_size, out error);
        }
        public int MultiValueGetValueUtf16String(IntPtr multi_value, int value_index, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.MultiValueGetValueUtf16String(multi_value, value_index, utf16_string, utf16_string_size, out error);
        }
        public int MultiValueGetValueBinaryDataSize(IntPtr multi_value, int value_index, out UIntPtr size, out IntPtr error)
        {
            return Native.MultiValueGetValueBinaryDataSize(multi_value, value_index, out size, out error);
        }
        public int MultiValueGetValueBinaryData(IntPtr multi_value, int value_index, byte[] binary_data, UIntPtr size, out IntPtr error)
        {
            return Native.MultiValueGetValueBinaryData(multi_value, value_index, binary_data, size, out error);
        }
        public int MultiValueGetValueGuid(IntPtr multi_value, int value_index, byte[] guid, UIntPtr size, out IntPtr error)
        {
            return Native.MultiValueGetValueGuid(multi_value, value_index, guid, size, out error);
        }
        public int NameToIdMapEntryGetType(IntPtr name_to_id_map_entry, out byte entry_type, out IntPtr error)
        {
            return Native.NameToIdMapEntryGetType(name_to_id_map_entry, out entry_type, out error);
        }
        public int NameToIdMapEntryGetNumber(IntPtr name_to_id_map_entry, out uint number, out IntPtr error)
        {
            return Native.NameToIdMapEntryGetNumber(name_to_id_map_entry, out number, out error);
        }
        public int NameToIdMapEntryGetUtf8StringSize(IntPtr name_to_id_map_entry, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.NameToIdMapEntryGetUtf8StringSize(name_to_id_map_entry, out utf8_string_size, out error);
        }
        public int NameToIdMapEntryGetUtf8String(IntPtr name_to_id_map_entry, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.NameToIdMapEntryGetUtf8String(name_to_id_map_entry, utf8_string, utf8_string_size, out error);
        }
        public int NameToIdMapEntryGetUtf16StringSize(IntPtr name_to_id_map_entry, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.NameToIdMapEntryGetUtf16StringSize(name_to_id_map_entry, out utf16_string_size, out error);
        }
        public int NameToIdMapEntryGetUtf16String(IntPtr name_to_id_map_entry, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.NameToIdMapEntryGetUtf16String(name_to_id_map_entry, utf16_string, utf16_string_size, out error);
        }
        public int NameToIdMapEntryGetGuid(IntPtr name_to_id_map_entry, byte[] guid, UIntPtr size, out IntPtr error)
        {
            return Native.NameToIdMapEntryGetGuid(name_to_id_map_entry, guid, size, out error);
        }
        public void NotifySetVerbose(int verbose)
        {
            Native.NotifySetVerbose(verbose);
        }
        public int NotifySetStream(IntPtr stream, out IntPtr error)
        {
            return Native.NotifySetStream(stream, out error);
        }
        public int NotifyStreamOpen([MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr error)
        {
            return Native.NotifyStreamOpen(filename, out error);
        }
        public int NotifyStreamClose(out IntPtr error)
        {
            return Native.NotifyStreamClose(out error);
        }
        public int RecordEntryFree(out IntPtr record_entry, out IntPtr error)
        {
            return Native.RecordEntryFree(out record_entry, out error);
        }
        public int RecordEntryGetEntryType(IntPtr record_entry, out uint entry_type, out IntPtr error)
        {
            return Native.RecordEntryGetEntryType(record_entry, out entry_type, out error);
        }
        public int RecordEntryGetValueType(IntPtr record_entry, out uint value_type, out IntPtr error)
        {
            return Native.RecordEntryGetValueType(record_entry, out value_type, out error);
        }
        public int RecordEntryGetNameToIdMapEntry(IntPtr record_entry, out IntPtr name_to_id_map_entry, out IntPtr error)
        {
            return Native.RecordEntryGetNameToIdMapEntry(record_entry, out name_to_id_map_entry, out error);
        }
        public int RecordEntryGetDataSize(IntPtr record_entry, out UIntPtr data_size, out IntPtr error)
        {
            return Native.RecordEntryGetDataSize(record_entry, out data_size, out error);
        }
        public int RecordEntryGetData(IntPtr record_entry, byte[] data, UIntPtr data_size, out IntPtr error)
        {
            return Native.RecordEntryGetData(record_entry, data, data_size, out error);
        }
        public int RecordEntryGetDataAsBoolean(IntPtr record_entry, out byte value_boolean, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsBoolean(record_entry, out value_boolean, out error);
        }
        public int RecordEntryGetDataAs16bitInteger(IntPtr record_entry, out ushort value_16bit, out IntPtr error)
        {
            return Native.RecordEntryGetDataAs16bitInteger(record_entry, out value_16bit, out error);
        }
        public int RecordEntryGetDataAs32bitInteger(IntPtr record_entry, out uint value_32bit, out IntPtr error)
        {
            return Native.RecordEntryGetDataAs32bitInteger(record_entry, out value_32bit, out error);
        }
        public int RecordEntryGetDataAs64bitInteger(IntPtr record_entry, out ulong value_64bit, out IntPtr error)
        {
            return Native.RecordEntryGetDataAs64bitInteger(record_entry, out value_64bit, out error);
        }
        public int RecordEntryGetDataAsFiletime(IntPtr record_entry, out ulong filetime, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsFiletime(record_entry, out filetime, out error);
        }
        public int RecordEntryGetDataAsFloatingtime(IntPtr record_entry, out ulong floatingtime, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsFloatingtime(record_entry, out floatingtime, out error);
        }
        public int RecordEntryGetDataAsSize(IntPtr record_entry, out long value_size, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsSize(record_entry, out value_size, out error);
        }
        public int RecordEntryGetDataAsFloatingPoint(IntPtr record_entry, out double value_floating_point, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsFloatingPoint(record_entry, out value_floating_point, out error);
        }
        public int RecordEntryGetDataAsUtf8StringSize(IntPtr record_entry, out UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsUtf8StringSize(record_entry, out utf8_string_size, out error);
        }
        public int RecordEntryGetDataAsUtf8String(IntPtr record_entry, byte[] utf8_string, UIntPtr utf8_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsUtf8String(record_entry, utf8_string, utf8_string_size, out error);
        }
        public int RecordEntryGetDataAsUtf16StringSize(IntPtr record_entry, out UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsUtf16StringSize(record_entry, out utf16_string_size, out error);
        }
        public int RecordEntryGetDataAsUtf16String(IntPtr record_entry, ushort[] utf16_string, UIntPtr utf16_string_size, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsUtf16String(record_entry, utf16_string, utf16_string_size, out error);
        }
        public int RecordEntryGetDataAsGuid(IntPtr record_entry, byte[] gui_data, UIntPtr guid_data_size, out IntPtr error)
        {
            return Native.RecordEntryGetDataAsGuid(record_entry, gui_data, guid_data_size, out error);
        }
        public int RecordEntryGetMultiValue(IntPtr record_entry, out IntPtr multi_value, out IntPtr error)
        {
            return Native.RecordEntryGetMultiValue(record_entry, out multi_value, out error);
        }
        public long RecordEntryReadBuffer(IntPtr record_entry, byte[] buffer, UIntPtr buffer_size, out IntPtr error)
        {
            return Native.RecordEntryReadBuffer(record_entry, buffer, buffer_size, out error);
        }
        public long RecordEntrySeekOffset(IntPtr record_entry, long offset, int whence, out IntPtr error)
        {
            return Native.RecordEntrySeekOffset(record_entry, offset, whence, out error);
        }
        public int RecordSetFree(out IntPtr record_set, out IntPtr error)
        {
            return Native.RecordSetFree(out record_set, out error);
        }
        public int RecordSetGetNumberOfEntries(IntPtr record_set, out int number_of_entries, out IntPtr error)
        {
            return Native.RecordSetGetNumberOfEntries(record_set, out number_of_entries, out error);
        }
        public int RecordSetGetEntryByIndex(IntPtr record_set, int entry_index, out IntPtr record_entry, out IntPtr error)
        {
            return Native.RecordSetGetEntryByIndex(record_set, entry_index, out record_entry, out error);
        }
        public int RecordSetGetEntryByType(IntPtr record_set, uint entry_type, uint value_type, out IntPtr record_entry, byte flags, out IntPtr error)
        {
            return Native.RecordSetGetEntryByType(record_set, entry_type, value_type, out record_entry, flags, out error);
        }
        public int RecordSetGetEntryByUtf8Name(IntPtr record_set, byte[] utf8_string, UIntPtr utf8_string_length, uint value_type, out IntPtr record_entry, byte flags, out IntPtr error)
        {
            return Native.RecordSetGetEntryByUtf8Name(record_set, utf8_string, utf8_string_length, value_type, out record_entry, flags, out error);
        }
        public int RecordSetGetEntryByUtf16Name(IntPtr record_set, ushort[] utf16_string, UIntPtr utf16_string_length, uint value_type, out IntPtr record_entry, byte flags, out IntPtr error)
        {
            return Native.RecordSetGetEntryByUtf16Name(record_set, utf16_string, utf16_string_length, value_type, out record_entry, flags, out error);
        }
        public int GetAccessFlagsRead()
        {
            return Native.GetAccessFlagsRead();
        }
        public int GetCodepage(out int codepage, out IntPtr error)
        {
            return Native.GetCodepage(out codepage, out error);
        }
        public int SetCodepage(int codepage, out IntPtr error)
        {
            return Native.SetCodepage(codepage, out error);
        }
        public int CheckFileSignature([MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr error)
        {
            return Native.CheckFileSignature(filename, out error);
        }
        public int CheckFileSignatureWide([MarshalAs(UnmanagedType.LPWStr)] string filename, out IntPtr error)
        {
            return Native.CheckFileSignatureWide(filename, out error);
        }
        public int CheckFileSignatureFileIoHandle(IntPtr file_io_handle, out IntPtr error)
        {
            return Native.CheckFileSignatureFileIoHandle(file_io_handle, out error);
        }
    }
}