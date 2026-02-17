using DataAccess;
using Models;
using Services;

namespace Views
{
    public class Menu
    {
        private readonly AddressBookService service;

        public Menu()
        {
            service = new AddressBookService(new ContactRepository(), new AddressBookRepository());
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("1 Add Contact");
                Console.WriteLine("2 Edit Contact");
                Console.WriteLine("3 Delete Contact");
                Console.WriteLine("4 Search by City");
                Console.WriteLine("5 Count by City");

                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        AddContactUI();
                        break;

                    case 2:
                        EditContactUI();
                        break;

                    case 3:
                        DeleteContactUI();
                        break;
                }
            }
        }

        private void AddContactUI()
        {
            Contact c = new Contact();

            Console.Write("First Name: ");
            c.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            c.LastName = Console.ReadLine();

            Console.Write("City: ");
            c.City = Console.ReadLine();

            service.AddContact(c);
        }

        private void EditContactUI()
        {
            Contact e = new Contact();

            Console.Write("First Name: ");
            e.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            e.LastName = Console.ReadLine();

            Console.Write("City: ");
            e.City = Console.ReadLine();

            service.EditContact(e);
        }

        private void DeleteContactUI()
        {
            Console.Write("First: ");
            string f = Console.ReadLine();

            Console.Write("Last: ");
            string l = Console.ReadLine();

            service.DeleteContact(f, l);
        }
    }
}
