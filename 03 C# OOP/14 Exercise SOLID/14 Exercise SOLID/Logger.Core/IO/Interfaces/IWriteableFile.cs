namespace Logger.Core.IO.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IWriteableFile
    {
        public void Write(string text);

        public void WriteLine(string text);

        public void SaveContent();

        public void DeleteContent();
    }
}
