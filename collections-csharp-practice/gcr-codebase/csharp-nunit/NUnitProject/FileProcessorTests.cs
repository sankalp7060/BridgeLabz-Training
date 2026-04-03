using NUnit.Framework;
using Code;
using System.IO;
using System;

namespace NUnitProject
{
    [TestFixture]
    public class FileProcessorTests
    {
        private FileProcessor processor;
        private string fileName = "test.txt";

        [SetUp]
        public void Setup() => processor = new FileProcessor();

        [Test]
        public void WriteAndRead_ShouldMatchContent()
        {
            string content = "Hello World";
            processor.WriteToFile(fileName, content);
            Assert.AreEqual(content, processor.ReadFromFile(fileName));
            File.Delete(fileName);
        }

        [Test]
        public void ReadFromFile_FileDoesNotExist_ShouldThrow()
        {
            Assert.Throws<IOException>(() => processor.ReadFromFile("nofile.txt"));
        }
    }
}
