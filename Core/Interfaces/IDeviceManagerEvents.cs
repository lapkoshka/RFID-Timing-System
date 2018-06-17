namespace Core.Interfaces
{
    public delegate void ConnectionStatusDelegate(ConnectionStatusEventArgs connectionStatusEventArgs);
    public delegate void TagCatchDelegate(TagCatchEventArgs tagCatchEventArgs);

    public interface IDeviceManagerEvents
    {
        event ConnectionStatusDelegate ConnectionStatusEvent;
        event TagCatchDelegate TagCatchEvent;
    }
}
