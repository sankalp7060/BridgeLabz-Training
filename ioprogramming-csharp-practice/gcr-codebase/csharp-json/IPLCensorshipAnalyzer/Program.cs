using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

class Program
{
    class Match
    {
        public int Match_id { get; set; }
        public string? Team1 { get; set; }
        public string? Team2 { get; set; }
        public Dictionary<string, int>? Score { get; set; }
        public string? Winner { get; set; }
        public string? Player_of_match { get; set; }
    }

    static string CensorTeam(string? team)
    {
        if (string.IsNullOrEmpty(team))
            return "***";
        var parts = team.Split(' ');
        if (parts.Length > 1)
            parts[1] = "***"; // Replace 2nd word with ***
        else
            parts[0] = "***";
        return string.Join(" ", parts);
    }

    static void Main(string[] args)
    {
        // JSON Input
        string jsonInputFile = "ipl_matches.json";
        string jsonOutputFile = "ipl_matches_censored.json";

        if (File.Exists(jsonInputFile))
        {
            var matches =
                JsonConvert.DeserializeObject<List<Match>>(File.ReadAllText(jsonInputFile))
                ?? new List<Match>();

            foreach (var match in matches)
            {
                // Censor team names
                string oldTeam1 = match.Team1 ?? "";
                string oldTeam2 = match.Team2 ?? "";

                match.Team1 = CensorTeam(match.Team1);
                match.Team2 = CensorTeam(match.Team2);

                // Update score dictionary keys
                var newScore = new Dictionary<string, int>();
                if (match.Score != null)
                {
                    if (match.Score.ContainsKey(oldTeam1))
                        newScore[match.Team1] = match.Score[oldTeam1];
                    if (match.Score.ContainsKey(oldTeam2))
                        newScore[match.Team2] = match.Score[oldTeam2];
                }
                match.Score = newScore;

                // Censor winner and player of match
                match.Winner = CensorTeam(match.Winner);
                match.Player_of_match = "REDACTED";
            }

            string censoredJson = JsonConvert.SerializeObject(matches, Formatting.Indented);
            File.WriteAllText(jsonOutputFile, censoredJson);
            Console.WriteLine($"Censored JSON saved to {jsonOutputFile}");
        }

        // CSV Input
        string csvInputFile = "ipl_matches.csv";
        string csvOutputFile = "ipl_matches_censored.csv";

        if (File.Exists(csvInputFile))
        {
            using var reader = new StreamReader(csvInputFile);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<dynamic>() ?? new List<dynamic>();

            var censoredRecords = new List<dynamic>();
            foreach (var r in records)
            {
                var dict = r as IDictionary<string, object>;
                if (dict != null)
                {
                    dict["team1"] = CensorTeam(dict["team1"]?.ToString());
                    dict["team2"] = CensorTeam(dict["team2"]?.ToString());
                    dict["winner"] = CensorTeam(dict["winner"]?.ToString());
                    dict["player_of_match"] = "REDACTED";
                    censoredRecords.Add(dict);
                }
            }

            using var writer = new StreamWriter(csvOutputFile);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(censoredRecords);
            Console.WriteLine($"Censored CSV saved to {csvOutputFile}");
        }
    }
}
