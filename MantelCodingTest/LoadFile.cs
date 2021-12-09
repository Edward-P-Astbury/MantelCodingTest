using System;
using System.IO;

namespace MantelCodingTest
{
    class LoadFile
    {
        private string _filePath;
        private string[] _fileLines;

        public LoadFile(string filePath)
        {
            _filePath = filePath;
        }

        public string[] FileLines { get => _fileLines; set => _fileLines = value; }

        public void ReadFile()
        {
            if (!File.Exists(_filePath))
            {
                throw new ArgumentException($"File ({_filePath}), does not exist. Please check system directory.");
            }
            else
            {
                FileLines = File.ReadAllLines(_filePath);
            }
        }
    }
}
