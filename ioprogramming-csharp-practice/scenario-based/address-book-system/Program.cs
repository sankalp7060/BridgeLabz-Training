using System.Threading.Tasks;
using AddressBookSystem.Menu;

namespace AddressBookSystem
{
    class Program
    {
        static async Task Main()
        {
            MenuHandler menu = new MenuHandler();
            await menu.ShowMenuAsync();
        }
    }
}
