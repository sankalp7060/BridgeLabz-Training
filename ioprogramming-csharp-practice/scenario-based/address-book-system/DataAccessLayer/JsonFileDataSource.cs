using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public class JsonFileDataSource : IDataSource
    {
        private string folderPath = "JsonData";

        public async Task SaveAsync(AddressBook addressBook)
        {
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, addressBook.Name + ".json");
            string json = JsonSerializer.Serialize(
                addressBook,
                new JsonSerializerOptions { WriteIndented = true }
            );
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task<AddressBook> LoadAsync(string addressBookName)
        {
            string filePath = Path.Combine(folderPath, addressBookName + ".json");
            if (!File.Exists(filePath))
                return new AddressBook { Name = addressBookName };
            string json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<AddressBook>(json);
        }
    }
}
