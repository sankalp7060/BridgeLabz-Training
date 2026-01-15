public interface ITabManager
{
    void Open();
    void Close();
    void RestoreClosedTab();
    void DisplayCurrentTab();
    void Visit();
    void Back();
    void Forward();
    string GetCurrentPage();
}
