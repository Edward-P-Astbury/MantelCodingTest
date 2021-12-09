using System;

namespace MantelCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\Edward\source\repos\FutureAssociatesProgram\FutureAssociatesProgram\programming-task-example-data.txt";

            LoadFile loadFile = new LoadFile(path);

            loadFile.ReadFile();

            FileParser fileParser = new FileParser();

            // Populate the URLs and IPs
            fileParser.PopulateUrls(loadFile.FileLines);
            fileParser.PopulateIps(loadFile.FileLines);

            Console.WriteLine("Number of unique IPs: " + fileParser.NumberOfUniqueIps());

            fileParser.CountListItemsOccurrences(fileParser.MostActiveIps, fileParser.IpAddresses);
            fileParser.CountListItemsOccurrences(fileParser.MostVisitedUrls, fileParser.Urls);

            Console.WriteLine("Top 3 most active IP addresses:");
            fileParser.GetTopItemsFromDict(3, fileParser.MostActiveIps);

            Console.WriteLine("Top 3 most visited URLs:");
            fileParser.GetTopItemsFromDict(3, fileParser.MostVisitedUrls);
        }
    }
}
