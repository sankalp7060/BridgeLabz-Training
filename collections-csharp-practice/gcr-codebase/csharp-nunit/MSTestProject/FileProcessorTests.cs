using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;
using System;
using System.IO;

namespace MSTestProject
{
    [TestClass]
    public class FileProcessorTests
    {
        private FileProcessor processor;
        private string fileName = "test.txt";

        [TestInitialize]
        public void Setup() => processor = new FileProcessor();

        [TestMethod]
        public void WriteAndRead_ShouldMatchContent()
        {
            string content = "Hello World";
            processor.WriteToFile(fileName, content);
            Assert.AreEqual(content, processor.ReadFromFile(fileName));
            File.Delete(fileName);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ReadFromFile_FileDoesNotExist_ShouldThrow() => processor.ReadFromFile("nofile.txt");
    }
}
