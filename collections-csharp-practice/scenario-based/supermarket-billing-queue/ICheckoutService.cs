public interface ICheckoutService
{
    void AddCustomer(Customer customer);
    void ProcessNextCustomer();
    void DisplayQueue();
}
