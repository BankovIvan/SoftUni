namespace SquareRoot.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using SquareRoot.IO.Interfaces;
    using static System.Net.Mime.MediaTypeNames;

    public class FileWriter : IWriter
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentException("File not found!");
                }

                this.filePath = value;
            }
        }

        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public void Write(string text)
        {
            using (StreamWriter sw = File.AppendText(this.FilePath))
            {
                sw.Write(text);
                sw.Close();
            }
        }

        public void WriteLine(string text)
        {
            using (StreamWriter sw = File.AppendText(this.FilePath))
            {
                sw.WriteLine(text);
                sw.Close();
            }
        }

        public void Write(object value)
        {
            using (StreamWriter sw = File.AppendText(this.FilePath))
            {
                sw.Write(value.ToString());
                sw.Close();
            }
        }

        public void WriteLine(object value)
        {
            using (StreamWriter sw = File.AppendText(this.FilePath))
            {
                sw.WriteLine(value.ToString());
                sw.Close();
            }
        }
    }
}
