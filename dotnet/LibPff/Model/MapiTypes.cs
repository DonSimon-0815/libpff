namespace LibPff.Model
{
    // Attachment methods
    public enum AttachmentMethod
    {
        None = 0,
        ByValue = 1,
        ByReference = 2,
        ByReferenceResolve = 3,
        ByReferenceOnly = 4,
        EmbeddedMessage = 5,
        Ole = 6
    }

    // Message flags (bitmask)
    [Flags]
    public enum MessageFlags
    {
        Read = 0x00000001,
        Unmodified = 0x00000002,
        Submit = 0x00000004,
        Unsent = 0x00000008,
        HasAttachments = 0x00000010,
        FromMe = 0x00000020,
        Associated = 0x00000040,
        Resend = 0x00000080,
        RnPending = 0x00000100,
        NrnPending = 0x00000200
    }

    // Message importance
    public enum MessageImportance
    {
        Low = 0,
        Normal = 1,
        High = 2
    }

    // Message priority
    public enum MessagePriority
    {
        NonUrgent = -1,
        Normal = 0,
        Urgent = 1
    }

    // Message sensitivity
    public enum MessageSensitivity
    {
        None = 0,
        Personal = 1,
        Private = 2,
        Confidential = 3
    }

    // Message status flags (bitmask)
    [Flags]
    public enum MessageStatusFlags
    {
        Highlighted = 0x00000001,
        Tagged = 0x00000002,
        Hidden = 0x00000004,
        Deleted = 0x00000008,

        Draft = 0x00000100,
        Answered = 0x00000200,

        RemoteDownload = 0x00001000,
        RemoteDeleted = 0x00002000
    }

    // Valid folder masks (bitmask)
    [Flags]
    public enum ValidFolderMask
    {
        Subtree = 0x00000001,
        Inbox = 0x00000002,
        Outbox = 0x00000004,
        Wastebox = 0x00000008,
        SentMail = 0x00000010,
        Views = 0x00000020,
        CommonViews = 0x00000040,
        Finder = 0x00000080
    }

    // Object types (MAPI)
    public enum ObjectType
    {
        Store = 0x00000001,
        AddressBook = 0x00000002,
        Folder = 0x00000003,
        AddressBookContainer = 0x00000004,
        Message = 0x00000005,
        MailUser = 0x00000006,
        Attachment = 0x00000007,
        DistributionList = 0x00000008,
        ProfileSection = 0x00000009,
        Status = 0x0000000a,
        Session = 0x0000000b,
        FormInfo = 0x0000000c
    }

    // Recipient types
    public enum RecipientType
    {
        Originator = 0,
        To = 1,
        Cc = 2,
        Bcc = 3
    }

    // Value types
    public enum ValueType
    {
        Unspecified = 0x0000,
        Null = 0x0001,
        Int16 = 0x0002,
        Int32 = 0x0003,
        Float32 = 0x0004,
        Double64 = 0x0005,
        Currency = 0x0006,
        FloatingTime = 0x0007,
        Error = 0x000a,
        Boolean = 0x000b,
        Object = 0x000d,
        Int64 = 0x0014,
        AsciiString = 0x001e,
        UnicodeString = 0x001f,
        FileTime = 0x0040,
        Guid = 0x0048,
        ServerId = 0x00fb,
        Restriction = 0x00fd,
        RuleAction = 0x00fe,
        Binary = 0x0102,

        MultiInt16 = 0x1002,
        MultiInt32 = 0x1003,
        MultiFloat32 = 0x1004,
        MultiDouble64 = 0x1005,
        MultiCurrency = 0x1006,
        MultiFloatingTime = 0x1007,
        MultiInt64 = 0x1014,
        MultiAsciiString = 0x101e,
        MultiUnicodeString = 0x101f,
        MultiFileTime = 0x1040,
        MultiGuid = 0x1048,
        MultiBinary = 0x1102,

        // Preprocessor defines mapped into enum
        MultiValueFlag = 0x1000,

        ApplicationTime = FloatingTime,
        MultiApplicationTime = MultiFloatingTime
    }

    // Entry types
    public enum EntryType
    {
        MessageImportance = 0x0017,
        MessageClass = 0x001a,
        MessagePriority = 0x0026,
        MessageSensitivity = 0x0036,
        MessageSubject = 0x0037,
        MessageClientSubmitTime = 0x0039,
        MessageSentRepresentingSearchKey = 0x003b,

        MessageReceivedByEntryId = 0x003f,
        MessageReceivedByName = 0x0040,
        MessageSentRepresentingEntryId = 0x0041,
        MessageSentRepresentingName = 0x0042,
        MessageReceivedRepresentingEntryId = 0x0043,
        MessageReceivedRepresentingName = 0x0044,

        MessageReplyRecipientEntries = 0x004f,
        MessageReplyRecipientNames = 0x0050,
        MessageReceivedBySearchKey = 0x0051,
        MessageReceivedRepresentingSearchKey = 0x0052,

        MessageSentRepresentingAddressType = 0x0064,
        MessageSentRepresentingEmailAddress = 0x0065,

        MessageConversationTopic = 0x0070,
        MessageConversationIndex = 0x0071,

        MessageReceivedByAddressType = 0x0075,
        MessageReceivedByEmailAddress = 0x0076,
        MessageReceivedRepresentingAddressType = 0x0077,
        MessageReceivedRepresentingEmailAddress = 0x0078,

        MessageTransportHeaders = 0x007d,

        RecipientType = 0x0c15,

        MessageSenderEntryId = 0x0c19,
        MessageSenderName = 0x0c1a,
        MessageSenderSearchKey = 0x0c1d,
        MessageSenderAddressType = 0x0c1e,
        MessageSenderEmailAddress = 0x0c1f,

        MessageDisplayTo = 0x0e04,
        MessageDeliveryTime = 0x0e06,
        MessageFlags = 0x0e07,
        MessageSize = 0x0e08,
        MessageStatus = 0x0e17,
        AttachmentSize = 0x0e20,
        MessageInternetArticleNumber = 0x0e23,
        MessagePermission = 0x0e27,
        MessageUrlComputerNameSet = 0x0e62,
        MessageTrustSender = 0x0e79,

        MessageBodyPlainText = 0x1000,
        MessageBodyCompressedRtf = 0x1009,
        MessageBodyHtml = 0x1013,
        EmailEmlFilename = 0x10f3,

        DisplayName = 0x3001,
        AddressType = 0x3002,
        EmailAddress = 0x3003,
        MessageCreationTime = 0x3007,
        MessageModificationTime = 0x3008,

        MessageStoreValidFolderMask = 0x35df,

        FolderType = 0x3601,
        NumberOfContentItems = 0x3602,
        NumberOfUnreadContentItems = 0x3603,
        HasSubFolders = 0x360a,
        ContainerClass = 0x3613,
        NumberOfAssociatedContent = 0x3617,

        AttachmentDataObject = 0x3701,
        AttachmentFilenameShort = 0x3704,
        AttachmentMethod = 0x3705,
        AttachmentFilenameLong = 0x3707,
        AttachmentRenderingPosition = 0x370b,

        ContactCallbackPhoneNumber = 0x3a02,
        ContactGenerationalAbbreviation = 0x3a05,
        ContactGivenName = 0x3a06,
        ContactBusinessPhone1 = 0x3a08,
        ContactHomePhone = 0x3a09,
        ContactInitials = 0x3a0a,
        ContactSurname = 0x3a11,
        ContactPostalAddress = 0x3a15,
        ContactCompanyName = 0x3a16,
        ContactJobTitle = 0x3a17,
        ContactDepartmentName = 0x3a18,
        ContactOfficeLocation = 0x3a19,
        ContactPrimaryPhone = 0x3a1a,
        ContactBusinessPhone2 = 0x3a1b,
        ContactMobilePhone = 0x3a1c,
        ContactBusinessFax = 0x3a24,
        ContactCountry = 0x3a26,
        ContactLocality = 0x3a27,
        ContactTitle = 0x3a45,

        MessageBodyCodepage = 0x3fde,
        MessageCodepage = 0x3ffd,

        RecipientDisplayName = 0x5ff6,

        FolderChildCount = 0x6638,
        SubItemId = 0x67f2,
        MessageStorePasswordChecksum = 0x67ff,

        AddressFileUnder = 0x8005,

        DistributionListName = 0x8053,
        DistributionListMemberOneOffEntryIds = 0x8054,
        DistributionListMemberEntryIds = 0x8055,

        ContactEmailAddress1 = 0x8083,
        ContactEmailAddress2 = 0x8093,
        ContactEmailAddress3 = 0x80a3,

        TaskStatus = 0x8101,
        TaskPercentageComplete = 0x8102,
        TaskStartDate = 0x8104,
        TaskDueDate = 0x8105,
        TaskActualEffort = 0x8110,
        TaskTotalEffort = 0x8111,
        TaskVersion = 0x8112,
        TaskIsComplete = 0x811c,
        TaskIsRecurring = 0x8126,

        AppointmentBusyStatus = 0x8205,
        AppointmentLocation = 0x8208,
        AppointmentStartTime = 0x820d,
        AppointmentEndTime = 0x820e,
        AppointmentDuration = 0x8213,
        AppointmentIsRecurring = 0x8223,
        AppointmentRecurrencePattern = 0x8232,
        AppointmentTimezoneDescription = 0x8234,
        AppointmentFirstEffectiveTime = 0x8235,
        AppointmentLastEffectiveTime = 0x8236,

        MessageReminderTime = 0x8502,
        MessageIsReminder = 0x8503,
        MessageIsPrivate = 0x8506,
        MessageReminderSignalTime = 0x8550
    }
}
