using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class Program
{
    // Nullable-safe User class
    class User
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
    }

    static void Main(string[] args)
    {
        // --------------------------
        // 1️⃣ Read JSON file and print all keys/values
        // --------------------------
        string jsonFile = "users.json";
        if (File.Exists(jsonFile))
        {
            Console.WriteLine("Reading users.json ...");
            var jsonData = JArray.Parse(File.ReadAllText(jsonFile));
            foreach (var obj in jsonData)
            {
                Console.WriteLine("--- User ---");
                foreach (var prop in obj.Children<JProperty>())
                {
                    Console.WriteLine($"{prop.Name}: {prop.Value}");
                }
            }
            Console.WriteLine();
        }

        // --------------------------
        // 2️⃣ Convert a list of objects into JSON array
        // --------------------------
        var users = new List<User>
        {
            new User
            {
                Name = "John",
                Age = 30,
                Email = "john@mail.com",
            },
            new User
            {
                Name = "Alice",
                Age = 22,
                Email = "alice@mail.com",
            },
        };
        string jsonArray = JsonConvert.SerializeObject(users, Formatting.Indented);
        Console.WriteLine("Users JSON Array:");
        Console.WriteLine(jsonArray);
        Console.WriteLine();

        // --------------------------
        // 3️⃣ Filter JSON data: age > 25
        // --------------------------
        var json = JArray.Parse(jsonArray);
        Console.WriteLine("Filtered users (Age > 25):");
        foreach (var u in json)
        {
            if ((int)u["Age"]! > 25)
                Console.WriteLine($"Name: {u["Name"]}, Age: {u["Age"]}");
        }
        Console.WriteLine();

        // --------------------------
        // 4️⃣ Validate Email using JSON Schema (optional)
        // --------------------------
        try
        {
            string schemaJson =
                @"
            {
                'type':'object',
                'properties':{
                    'Email':{'type':'string','format':'email'}
                },
                'required':['Email']
            }";

            JSchema schema = JSchema.Parse(schemaJson);
            foreach (var u in json)
            {
                bool valid = u.IsValid(schema);
                Console.WriteLine($"{u["Name"]} Email valid? {valid}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Newtonsoft.Json.Schema not installed. Skipping schema validation.");
        }
        Console.WriteLine();

        // --------------------------
        // 5️⃣ Merge two JSON files (file1.json, file2.json)
        // --------------------------
        string file1 = "file1.json";
        string file2 = "file2.json";
        if (File.Exists(file1) && File.Exists(file2))
        {
            var j1 = JArray.Parse(File.ReadAllText(file1));
            var j2 = JArray.Parse(File.ReadAllText(file2));
            j1.Merge(j2);
            Console.WriteLine("Merged JSON Files:");
            Console.WriteLine(j1.ToString(Formatting.Indented));
        }
        Console.WriteLine();

        // --------------------------
        // 6️⃣ Convert JSON to XML safely
        // --------------------------
        try
        {
            // Wrap array in object before converting to XML
            string wrappedJson = "{ \"Users\": " + jsonArray + " }";
            var xml = JsonConvert.DeserializeXNode(wrappedJson, "Root")!.ToString();
            Console.WriteLine("JSON -> XML:");
            Console.WriteLine(xml);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting JSON to XML: {ex.Message}");
        }
        Console.WriteLine();

        // --------------------------
        // 7️⃣ Convert CSV to JSON
        // --------------------------
        string csvFile = "users.csv";
        if (File.Exists(csvFile))
        {
            using var reader = new StreamReader(csvFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<User>().ToList();
            string csvToJson = JsonConvert.SerializeObject(records, Formatting.Indented);
            Console.WriteLine("CSV -> JSON:");
            Console.WriteLine(csvToJson);
        }
        else
        {
            Console.WriteLine("CSV file not found. Skipping CSV -> JSON conversion.");
        }
        Console.WriteLine();

        // --------------------------
        // 8️⃣ Generate JSON report from database records (simulated)
        // --------------------------
        var dbRecords = new List<User>
        {
            new User
            {
                Name = "DBJohn",
                Age = 28,
                Email = "dbjohn@mail.com",
            },
            new User
            {
                Name = "DBAlice",
                Age = 35,
                Email = "dbalice@mail.com",
            },
        };
        string reportJson = JsonConvert.SerializeObject(dbRecords, Formatting.Indented);
        File.WriteAllText("DBReport.json", reportJson);
        Console.WriteLine("JSON Report saved as DBReport.json");
    }
}
