namespace Code;

public class DatabaseConnection
{
    public bool IsConnected { get; private set; } = false;

    public void Connect() => IsConnected = true;
    public void Disconnect() => IsConnected = false;
}
