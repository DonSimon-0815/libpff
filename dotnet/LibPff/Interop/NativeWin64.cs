// AUTOMATICALLY GENERATED. DO NOT MODIFY.

using System.Runtime.InteropServices;
using System.Text;

namespace LibPff.Interop
{
    internal static class NativeWin64
    {
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_attachment_get_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AttachmentGetType(IntPtr attachment, out int attachment_type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_attachment_get_data_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AttachmentGetDataSize(IntPtr attachment, out long size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_attachment_data_read_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern long AttachmentDataReadBuffer(IntPtr attachment, byte[] buffer, UIntPtr buffer_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_attachment_data_seek_offset", CallingConvention = CallingConvention.Cdecl)]
        public static extern long AttachmentDataSeekOffset(IntPtr attachment, long offset, int whence, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_attachment_get_data_file_io_handle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AttachmentGetDataFileIoHandle(IntPtr attachment, out IntPtr file_io_handle, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_attachment_get_item", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AttachmentGetItem(IntPtr attachment, out IntPtr attached_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_error_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ErrorFree(out IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_error_fprint", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ErrorFprint(IntPtr error, IntPtr stream);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_error_sprint", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ErrorSprint(IntPtr error, StringBuilder string_2, UIntPtr size);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_error_backtrace_fprint", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ErrorBacktraceFprint(IntPtr error, IntPtr stream);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_error_backtrace_sprint", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ErrorBacktraceSprint(IntPtr error, StringBuilder string_2, UIntPtr size);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileInitialize(out IntPtr file, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileFree(out IntPtr file, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_signal_abort", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileSignalAbort(IntPtr file, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileOpen(IntPtr file, [MarshalAs(UnmanagedType.LPStr)] string filename, int access_flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_open_wide", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileOpenWide(IntPtr file, [MarshalAs(UnmanagedType.LPWStr)] string filename, int access_flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_open_file_io_handle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileOpenFileIoHandle(IntPtr file, IntPtr file_io_handle, int access_flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileClose(IntPtr file, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_is_corrupted", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileIsCorrupted(IntPtr file, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_recover_items", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileRecoverItems(IntPtr file, byte recovery_flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetSize(IntPtr file, out long size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_content_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetContentType(IntPtr file, out byte content_type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetType(IntPtr file, out byte type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_encryption_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetEncryptionType(IntPtr file, out byte encryption_type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_ascii_codepage", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetAsciiCodepage(IntPtr file, out int ascii_codepage, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_set_ascii_codepage", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileSetAsciiCodepage(IntPtr file, int ascii_codepage, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_number_of_unallocated_blocks", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetNumberOfUnallocatedBlocks(IntPtr file, int unallocated_block_type, out int number_of_unallocated_blocks, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_unallocated_block", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetUnallocatedBlock(IntPtr file, int unallocated_block_type, int unallocated_block_index, out long offset, out long size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_root_item", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetRootItem(IntPtr file, out IntPtr root_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_message_store", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetMessageStore(IntPtr file, out IntPtr message_store, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_name_to_id_map", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetNameToIdMap(IntPtr file, out IntPtr name_to_id_map, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_root_folder", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetRootFolder(IntPtr file, out IntPtr root_folder, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_item_by_identifier", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetItemByIdentifier(IntPtr file, uint item_identifier, out IntPtr item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_number_of_orphan_items", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetNumberOfOrphanItems(IntPtr file, out int number_of_orphan_items, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_orphan_item_by_index", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetOrphanItemByIndex(IntPtr file, int orphan_item_index, out IntPtr orphan_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_number_of_recovered_items", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetNumberOfRecoveredItems(IntPtr file, out int number_of_recovered_items, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_recovered_item_by_index", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetRecoveredItemByIndex(IntPtr file, int recovered_item_index, out IntPtr recovered_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetType(IntPtr folder, out byte type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_utf8_name_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetUtf8NameSize(IntPtr folder, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetUtf8Name(IntPtr folder, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_utf16_name_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetUtf16NameSize(IntPtr folder, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetUtf16Name(IntPtr folder, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_number_of_sub_folders", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetNumberOfSubFolders(IntPtr folder, out int number_of_sub_folders, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_folder", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubFolder(IntPtr folder, int sub_folder_index, out IntPtr sub_folder, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_folder_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubFolderByUtf8Name(IntPtr folder, byte[] utf8_sub_folder_name, UIntPtr utf8_sub_folder_name_size, out IntPtr sub_folder, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_folder_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubFolderByUtf16Name(IntPtr folder, ushort[] utf16_sub_folder_name, UIntPtr utf16_sub_folder_name_size, out IntPtr sub_folder, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_folders", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubFolders(IntPtr item, out IntPtr sub_folders, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_number_of_sub_messages", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetNumberOfSubMessages(IntPtr folder, out int number_of_sub_messages, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_message", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubMessage(IntPtr folder, int sub_message_index, out IntPtr sub_message, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_message_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubMessageByUtf8Name(IntPtr folder, byte[] utf8_sub_message_name, UIntPtr utf8_sub_message_name_size, out IntPtr sub_message, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_message_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubMessageByUtf16Name(IntPtr folder, ushort[] utf16_sub_message_name, UIntPtr utf16_sub_message_name_size, out IntPtr sub_message, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_messages", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubMessages(IntPtr item, out IntPtr sub_messages, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_number_of_sub_associated_contents", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetNumberOfSubAssociatedContents(IntPtr folder, out int number_of_sub_associated_contents, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_associated_content", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubAssociatedContent(IntPtr folder, int sub_associated_content_index, out IntPtr sub_associated_content, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_sub_associated_contents", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetSubAssociatedContents(IntPtr item, out IntPtr sub_associated_contents, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_folder_get_unknowns", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FolderGetUnknowns(IntPtr folder, out IntPtr unknowns, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemFree(out IntPtr item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_identifier", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetIdentifier(IntPtr item, out uint identifier, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_number_of_record_sets", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetNumberOfRecordSets(IntPtr item, out int number_of_record_sets, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_record_set_by_index", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetRecordSetByIndex(IntPtr item, int record_set_index, out IntPtr record_set, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_number_of_entries", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetNumberOfEntries(IntPtr item, out uint number_of_entries, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetType(IntPtr item, out byte item_type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_number_of_sub_items", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetNumberOfSubItems(IntPtr item, out int number_of_sub_items, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_sub_item", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetSubItem(IntPtr item, int sub_item_index, out IntPtr sub_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_sub_item_by_identifier", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetSubItemByIdentifier(IntPtr item, uint sub_item_identifier, out IntPtr sub_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_orphan_item", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetOrphanItem(IntPtr file, int orphan_item_index, out IntPtr orphan_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_file_get_recovered_item", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileGetRecoveredItem(IntPtr file, int recovered_item_index, out IntPtr recovered_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_clone", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemClone(out IntPtr destination_item, IntPtr source_item, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_number_of_sets", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetNumberOfSets(IntPtr item, out uint number_of_sets, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryType(IntPtr item, int set_index, int entry_index, out uint entry_type, out uint value_type, out IntPtr name_to_id_map_entry, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_value_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetValueType(IntPtr item, int set_index, uint entry_type, out uint value_type, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue(IntPtr item, int set_index, uint entry_type, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_boolean", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBoolean(IntPtr item, int set_index, uint entry_type, out byte entry_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_boolean_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBooleanByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out byte entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_boolean_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBooleanByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out byte entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_16bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue16bit(IntPtr item, int set_index, uint entry_type, out ushort entry_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_16bit_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue16bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ushort entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_16bit_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue16bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ushort entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_32bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue32bit(IntPtr item, int set_index, uint entry_type, out uint entry_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_32bit_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue32bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out uint entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_32bit_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue32bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out uint entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_64bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue64bit(IntPtr item, int set_index, uint entry_type, out ulong entry_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_64bit_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue64bitByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ulong entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_64bit_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValue64bitByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ulong entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_filetime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueFiletime(IntPtr item, int set_index, uint entry_type, out ulong entry_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_filetime_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueFiletimeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out ulong entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_filetime_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueFiletimeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out ulong entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueSize(IntPtr item, int set_index, uint entry_type, out UIntPtr entry_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_size_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_size_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_floating_point", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueFloatingPoint(IntPtr item, int set_index, uint entry_type, out double entry_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_floating_point_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueFloatingPointByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out double entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_floating_point_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueFloatingPointByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out double entry_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf8_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf8StringSize(IntPtr item, int set_index, uint entry_type, out UIntPtr utf8_string_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf8_string_size_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf8StringSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf8_string_size_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf8StringSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf8_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf8String(IntPtr item, int set_index, uint entry_type, byte[] utf8_string, UIntPtr utf8_string_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf8_string_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf8StringByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf8_string_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf8StringByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf16_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf16StringSize(IntPtr item, int set_index, uint entry_type, out UIntPtr utf16_string_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf16_string_size_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf16StringSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf16_string_size_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf16StringSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf16_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf16String(IntPtr item, int set_index, uint entry_type, ushort[] utf16_string, UIntPtr utf16_string_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf16_string_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf16StringByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_utf16_string_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueUtf16StringByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_binary_data_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBinaryDataSize(IntPtr item, int set_index, uint entry_type, out UIntPtr binary_data_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_binary_data_size_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBinaryDataSizeByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, out UIntPtr binary_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_binary_data_size_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBinaryDataSizeByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, out UIntPtr binary_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_binary_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBinaryData(IntPtr item, int set_index, uint entry_type, byte[] binary_data, UIntPtr binary_data_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_binary_data_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBinaryDataByUtf8Name(IntPtr item, int set_index, byte[] utf8_entry_name, UIntPtr utf8_entry_name_length, byte[] binary_data, UIntPtr binary_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_binary_data_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueBinaryDataByUtf16Name(IntPtr item, int set_index, ushort[] utf16_entry_name, UIntPtr utf16_entry_name_length, byte[] binary_data, UIntPtr binary_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_value_guid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryValueGuid(IntPtr item, int set_index, uint entry_type, byte[] guid, UIntPtr guid_size, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_item_get_entry_multi_value", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ItemGetEntryMultiValue(IntPtr item, int set_index, uint entry_type, out IntPtr multi_value, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_data_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueDataSize(IntPtr record_entry, out UIntPtr value_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_copy_value_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryCopyValueData(IntPtr record_entry, byte[] value_data, UIntPtr value_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_boolean", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueBoolean(IntPtr record_entry, out byte value_boolean, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_16bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValue16bit(IntPtr record_entry, out ushort value_16bit, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_32bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValue32bit(IntPtr record_entry, out uint value_32bit, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_64bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValue64bit(IntPtr record_entry, out ulong value_64bit, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_filetime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueFiletime(IntPtr record_entry, out ulong value_64bit, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueSize(IntPtr record_entry, out UIntPtr value_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_floating_point", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueFloatingPoint(IntPtr record_entry, out double value_floating_point, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_utf8_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueUtf8StringSize(IntPtr record_entry, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_utf8_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueUtf8String(IntPtr record_entry, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_utf16_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueUtf16StringSize(IntPtr record_entry, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_utf16_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueUtf16String(IntPtr record_entry, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_entry_value_utf8_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetEntryValueUtf8StringSize(IntPtr message, uint entry_type, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_entry_value_utf8_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetEntryValueUtf8String(IntPtr message, uint entry_type, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_entry_value_utf16_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetEntryValueUtf16StringSize(IntPtr message, uint entry_type, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_entry_value_utf16_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetEntryValueUtf16String(IntPtr message, uint entry_type, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_client_submit_time", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetClientSubmitTime(IntPtr message, out ulong filetime, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_delivery_time", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetDeliveryTime(IntPtr message, out ulong filetime, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_creation_time", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetCreationTime(IntPtr message, out ulong filetime, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_modification_time", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetModificationTime(IntPtr message, out ulong filetime, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_number_of_attachments", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetNumberOfAttachments(IntPtr message, out int number_of_attachments, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_attachment", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetAttachment(IntPtr message, int attachment_index, out IntPtr attachment, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_attachments", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetAttachments(IntPtr message, out IntPtr attachments, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_recipients", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetRecipients(IntPtr message, out IntPtr recipients, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_plain_text_body_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetPlainTextBodySize(IntPtr message, out UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_plain_text_body", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetPlainTextBody(IntPtr message, byte[] message_body, UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_rtf_body_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetRtfBodySize(IntPtr message, out UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_rtf_body", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetRtfBody(IntPtr message, byte[] message_body, UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_html_body_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetHtmlBodySize(IntPtr message, out UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_message_get_html_body", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MessageGetHtmlBody(IntPtr message, byte[] message_body, UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueFree(out IntPtr multi_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_number_of_values", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetNumberOfValues(IntPtr multi_value, out int number_of_values, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValue(IntPtr multi_value, int value_index, out uint value_type, out IntPtr value_data, out UIntPtr value_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_32bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValue32bit(IntPtr multi_value, int value_index, out uint value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_64bit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValue64bit(IntPtr multi_value, int value_index, out ulong value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_filetime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueFiletime(IntPtr multi_value, int value_index, out ulong filetime, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_utf8_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueUtf8StringSize(IntPtr multi_value, int value_index, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_utf8_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueUtf8String(IntPtr multi_value, int value_index, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_utf16_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueUtf16StringSize(IntPtr multi_value, int value_index, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_utf16_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueUtf16String(IntPtr multi_value, int value_index, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_binary_data_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueBinaryDataSize(IntPtr multi_value, int value_index, out UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_binary_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueBinaryData(IntPtr multi_value, int value_index, byte[] binary_data, UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_multi_value_get_value_guid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MultiValueGetValueGuid(IntPtr multi_value, int value_index, byte[] guid, UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_name_to_id_map_entry_get_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NameToIdMapEntryGetType(IntPtr name_to_id_map_entry, out byte entry_type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_name_to_id_map_entry_get_number", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NameToIdMapEntryGetNumber(IntPtr name_to_id_map_entry, out uint number, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_name_to_id_map_entry_get_utf8_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NameToIdMapEntryGetUtf8StringSize(IntPtr name_to_id_map_entry, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_name_to_id_map_entry_get_utf8_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NameToIdMapEntryGetUtf8String(IntPtr name_to_id_map_entry, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_name_to_id_map_entry_get_utf16_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NameToIdMapEntryGetUtf16StringSize(IntPtr name_to_id_map_entry, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_name_to_id_map_entry_get_utf16_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NameToIdMapEntryGetUtf16String(IntPtr name_to_id_map_entry, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_name_to_id_map_entry_get_guid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NameToIdMapEntryGetGuid(IntPtr name_to_id_map_entry, byte[] guid, UIntPtr size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_notify_set_verbose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void NotifySetVerbose(int verbose);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_notify_set_stream", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NotifySetStream(IntPtr stream, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_notify_stream_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NotifyStreamOpen([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_notify_stream_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int NotifyStreamClose(IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryFree(out IntPtr record_entry, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_entry_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetEntryType(IntPtr record_entry, out uint entry_type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_value_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetValueType(IntPtr record_entry, out uint value_type, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_name_to_id_map_entry", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetNameToIdMapEntry(IntPtr record_entry, out IntPtr name_to_id_map_entry, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataSize(IntPtr record_entry, out UIntPtr data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetData(IntPtr record_entry, byte[] data, UIntPtr data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_boolean", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsBoolean(IntPtr record_entry, out byte value_boolean, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_16bit_integer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAs16bitInteger(IntPtr record_entry, out ushort value_16bit, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_32bit_integer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAs32bitInteger(IntPtr record_entry, out uint value_32bit, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_64bit_integer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAs64bitInteger(IntPtr record_entry, out ulong value_64bit, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_filetime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsFiletime(IntPtr record_entry, out ulong filetime, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_floatingtime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsFloatingtime(IntPtr record_entry, out ulong floatingtime, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsSize(IntPtr record_entry, out long value_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_floating_point", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsFloatingPoint(IntPtr record_entry, out double value_floating_point, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_utf8_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsUtf8StringSize(IntPtr record_entry, out UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_utf8_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsUtf8String(IntPtr record_entry, byte[] utf8_string, UIntPtr utf8_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_utf16_string_size", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsUtf16StringSize(IntPtr record_entry, out UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_utf16_string", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsUtf16String(IntPtr record_entry, ushort[] utf16_string, UIntPtr utf16_string_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_data_as_guid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetDataAsGuid(IntPtr record_entry, byte[] gui_data, UIntPtr guid_data_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_get_multi_value", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordEntryGetMultiValue(IntPtr record_entry, out IntPtr multi_value, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_read_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern long RecordEntryReadBuffer(IntPtr record_entry, byte[] buffer, UIntPtr buffer_size, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_entry_seek_offset", CallingConvention = CallingConvention.Cdecl)]
        public static extern long RecordEntrySeekOffset(IntPtr record_entry, long offset, int whence, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_set_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordSetFree(out IntPtr record_set, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_set_get_number_of_entries", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordSetGetNumberOfEntries(IntPtr record_set, out int number_of_entries, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_set_get_entry_by_index", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordSetGetEntryByIndex(IntPtr record_set, int entry_index, out IntPtr record_entry, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_set_get_entry_by_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordSetGetEntryByType(IntPtr record_set, uint entry_type, uint value_type, out IntPtr record_entry, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_set_get_entry_by_utf8_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordSetGetEntryByUtf8Name(IntPtr record_set, byte[] utf8_string, UIntPtr utf8_string_length, uint value_type, out IntPtr record_entry, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_record_set_get_entry_by_utf16_name", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RecordSetGetEntryByUtf16Name(IntPtr record_set, ushort[] utf16_string, UIntPtr utf16_string_length, uint value_type, out IntPtr record_entry, byte flags, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_get_access_flags_read", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetAccessFlagsRead();
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_get_codepage", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCodepage(out int codepage, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_set_codepage", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetCodepage(int codepage, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_check_file_signature", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CheckFileSignature([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_check_file_signature_wide", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CheckFileSignatureWide([MarshalAs(UnmanagedType.LPWStr)] string filename, IntPtr error);
        [DllImport("lib/win64/libpff.dll", EntryPoint = "libpff_check_file_signature_file_io_handle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CheckFileSignatureFileIoHandle(IntPtr file_io_handle, IntPtr error);
    }
}