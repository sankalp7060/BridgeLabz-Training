public interface IContact
{
    void AddContact();
    void EditContact();
    void DeleteContact();
    void AddMultipleContact();
    bool SearchContact(string city, string state);
    void ViewPersonsByCity(string city);
    void ViewPersonsByState(string state);
    int CountByCity(string city);
    int CountByState(string state);
}
