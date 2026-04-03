using System.IO;
using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public class CsvDataSource : IDataSource
    {
        private string folderPath = "CSVData";

        public async Task SaveAsync(AddressBook addressBook)
        {
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, addressBook.Name + ".csv");

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                await sw.WriteLineAsync(
                    "FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email"
                );
                foreach (var c in addressBook.Contacts)
                {
                    await sw.WriteLineAsync(
                        $"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State},{c.Zip},{c.PhoneNumber},{c.Email}"
                    );
                }
            }
        }

        public async Task<AddressBook> LoadAsync(string addressBookName)
        {
            string filePath = Path.Combine(folderPath, addressBookName + ".csv");
            AddressBook ab = new AddressBook { Name = addressBookName };

            if (!File.Exists(filePath))
                return ab;

            using (StreamReader sr = new StreamReader(filePath))
            {
                await sr.ReadLineAsync(); // skip header
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 8)
                    {
                        ab.Contacts.Add(
                            new Contact
                            {
                                FirstName = parts[0],
                                LastName = parts[1],
                                Address = parts[2],
                                City = parts[3],
                                State = parts[4],
                                Zip = parts[5],
                                PhoneNumber = parts[6],
                                Email = parts[7],
                            }
                        );
                    }
                }
            }

            return ab;
        }
    }
}
