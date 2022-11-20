namespace Logger.Core.IO
{
    using Logger.Core.Exceptions;
    using Logger.Core.IO.Interfaces;
    using Logger.Core.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class LogFile : ILogFile
    {
        private string name;
        private string path;
        //private int size;
        private StringBuilder content;

        public string Name 
        { 
            get { return this.name;  } 
            private set 
            { 
                if(string.IsNullOrEmpty(value)) 
                {
                    throw new EmptyFileNameException();
                }
                this.name = value;  
            } 
        }

        public string Path 
        { 
            get { return this.path; } 
            private set 
            {
                if (!FileValidator.PathExists(value))
                {
                    throw new InvalidPathException();
                }
                this.path = System.IO.Path.GetFullPath(value); 
            } 
        }

        public string FullPath { get { return this.Path + "\\" + this.Name; } }

        public int Size 
        { 
            get { return this.content.Length; } 
            //private set { this.size = value; } 
        }

        public string Content
        {
            get { return this.content.ToString(); }
            //private set { this.content = value; }
        }

        public LogFile()
        {
            this.content = new StringBuilder();
        }

        public LogFile(string content, string path, string fileName) : this()
        {
            this.content.Append(content);
            this.Path = path;
            this.Name = fileName;
        }


        public void Write(string text)
        {
            this.content.Append(text);
        }

        public void WriteLine(string text)
        {
            this.content.AppendLine(text);
        }

        public void SaveContent()
        {
            File.AppendAllText(this.FullPath, this.Content);
            this.content.Clear();
        }

        public void DeleteContent()
        {
            File.Delete(this.FullPath);
            File.Create(this.FullPath);
            this.content.Clear();
        }

        public void LoadContent()
        {
            this.content.Clear();
            this.content.AppendLine(File.ReadAllText(this.FullPath));
        }

    }
}
