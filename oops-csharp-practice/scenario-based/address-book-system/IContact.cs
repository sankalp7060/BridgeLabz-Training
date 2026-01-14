public interface IContact
{
    void AddContact();
    void EditContact();
    void DeleteContact();
    void AddMultipleContact();
    bool SearchContact(string city, string state);
    void ViewPersonsByCity();
    void ViewPersonsByState();
}
