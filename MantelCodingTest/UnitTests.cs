using NUnit.Framework;

namespace MantelCodingTest
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void NumberOfUniqueIps()
        {
            const string path = @"C:\Users\Edward\source\repos\FutureAssociatesProgram\FutureAssociatesProgram\programming-task-example-data.txt";

            LoadFile loadFile = new LoadFile(path);

            loadFile.ReadFile();

            FileParser fileParser = new FileParser();

            fileParser.PopulateIps(loadFile.FileLines);

            Assert.AreEqual(fileParser.NumberOfUniqueIps(), 11);
            Assert.AreNotEqual(fileParser.NumberOfUniqueIps(), 12);
        }

        [Test]
        public void MostVisitedURLs()
        {
            const string path = @"C:\Users\Edward\source\repos\FutureAssociatesProgram\FutureAssociatesProgram\programming-task-example-data.txt";

            LoadFile loadFile = new LoadFile(path);

            loadFile.ReadFile();

            FileParser fileParser = new FileParser();

            fileParser.PopulateUrls(loadFile.FileLines);
            fileParser.CountListItemsOccurrences(fileParser.MostVisitedUrls, fileParser.Urls);

            Assert.That(fileParser.MostVisitedUrls, Contains.Key("/docs/manage-websites/ "));
            Assert.That(fileParser.MostVisitedUrls, Does.Not.ContainKey("/docs/false-directory "));
        }

        [Test]
        public void MostActiveIPs()
        {
            const string path = @"C:\Users\Edward\source\repos\FutureAssociatesProgram\FutureAssociatesProgram\programming-task-example-data.txt";

            LoadFile loadFile = new LoadFile(path);

            loadFile.ReadFile();

            FileParser fileParser = new FileParser();

            fileParser.PopulateIps(loadFile.FileLines);
            fileParser.CountListItemsOccurrences(fileParser.MostActiveIps, fileParser.IpAddresses);

            Assert.That(fileParser.MostActiveIps, Contains.Key("168.41.191.40"));
        }
    }
}