using System.ComponentModel;

namespace Core
{
    public enum DeviceType : uint
    {
        OTHER = 0x01,
        MAIN = 0x02,
        PORTABLE = 0x03
    }

    public enum DeviceStatus : uint
    {
        [Description("Searching...")]
        Searching = 0x01,

        [Description("Reader does not found")]
        NotFound = 0x02,

        [Description("Reader found")]
        Found = 0x03,

        [Description("Trying connect to reader...")]
        TryingConnect = 0x04,

        [Description("Connected")]
        Connected = 0x05,

        [Description("Does not connected to reader")]
        NotConnected = 0x06,

        [Description("Listening")]
        Listening = 0x07
    }

    public enum ErrorCode : uint
    {
        [Description("Success")]
        Success = 0x0,

        [Description("Return before Inventory finished")]
        InventoryFinished = 0x1,

        [Description("The Inventory-scan-time overflow")]
        InventoryScanOverflow = 0x2,

        [Description("More data")]
        MoreData = 0x3,

        [Description("Reader module MCU is Full")]
        ReaderModuleIsFull = 0x4,

        [Description("Access Password Error")]
        AccessPasswordError = 0x5,

        [Description("Destroy Password Error")]
        DestroyPasswordError = 0x09,

        [Description("Destroy Password Error Cannot be Zero")]
        DestroyPasswordErrorZero = 0x0a,

        [Description("Tag Not Support the command")]
        TagNotSupportCommand = 0x0b,

        [Description("Use the commmand, Access Password Cannot be Zero")]
        AccessPasswordZero = 0x0c,

        [Description("Tag is protected,cannot set it again")]
        TagIsProtected = 0x0d,

        [Description("Tag is unprotected,no need to reset it")]
        TagIsUnprotected = 0x0e,

        [Description("There is some locked bytes, write fail")]
        LockedBytes = 0x10,

        [Description("Can not lock it")]
        CanNotLock = 0x11,

        [Description("Is locked, cannot lock it again")]
        Locked = 0x12,

        [Description("Parameter save fail, сan use before power")]
        ParametrSaveFail = 0x13,

        [Description("Cannot adjust")]
        CannotAdjust = 0x14,

        [Description("Tag custom function error")]
        TagCustomFuctionError = 0x1A,

        [Description("Check antenna error")]
        AntenaError = 0xF8,

        [Description("Command execute error")]
        CommandExecuteError = 0xF9,

        [Description("Get Tag, Poor Communication, Inoperable")]
        PoorCommunication = 0xFA,

        [Description("No Tag Operable")]
        NoTagOperable = 0xFB,

        [Description("Tag Return ErrorCode")]
        TagReturnError = 0xFC,

        [Description("Command length wrong")]
        CommandLengthWrong = 0xFD,

        [Description("Illegal command")]
        IllegalComand = 0xFE,

        [Description("Parameter Error")]
        ParametrError = 0xFF,

        [Description("Communication error")]
        CommunicationError = 0x30,

        [Description("CRC checksummat error")]
        CrcError = 0x31,

        [Description("Return data length error")]
        DataLengthError = 0x32,

        [Description("Communication busy")]
        CommunicationBusy = 0x33,

        [Description("Busy, command is being executed")]
        CommandExecuted = 0x34,

        [Description("ComPort Opened")]
        ComPortOpened = 0x35,

        [Description("ComPort Closed")]
        ComPortClosed = 0x36,

        [Description("Invalid Handle")]
        InvalidHandle = 0x37,

        [Description("Invalid Port")]
        InvalidPort = 0x38,

        [Description("Return Command Error")]
        ReturnCommandError = 0xEE,
    }

    public enum BaudRate : byte
    {
        BPS_9600 = 0,
        BPS_19200 = 1,
        BPS_38400 = 2,
        BPS_57600 = 3,
        BPS_115200 = 4
    }
}
