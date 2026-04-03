public class Vault
{
    public string Password { get; private set; }

    public Vault(string password)
    {
        Password = password;
    }
}
