namespace SquareRoot.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using SquareRoot.IO.Interfaces;

    public class FileReader : IReader
    {
        private string filePath;
        private string[] fileAllLines;
        private int currentLine;

        public string FilePath
        {
            get { return filePath; }
            set {
                if(!Directory.Exists(value))
                {
                    throw new ArgumentException("Да не губиме време!");
                }
                
                this.filePath = value; 
            }
        }

        public int CurrentLine { get { return currentLine; } set { this.currentLine = value; } }

        public FileReader(string filePath)
        {
            this.FilePath = filePath;
            this.CurrentLine = 0;
            this.fileAllLines = File.ReadAllLines(this.FilePath);
        }

        public string ReadLine()
        {
            if(this.CurrentLine < 0 || this.CurrentLine >= this.fileAllLines.Length)
            {
                throw new InvalidOperationException("No more content in the file!");
            }

            return this.fileAllLines[this.CurrentLine++];
        }
    }
}
