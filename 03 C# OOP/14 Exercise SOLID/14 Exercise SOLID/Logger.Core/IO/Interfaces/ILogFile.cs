namespace Logger.Core.IO.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILogFile : IWriteableFile
    {
        string Name { get; }
        string Path { get; }
        int Size { get; }
        string Content { get; }

        //void Write(string text);
        
    }
}
