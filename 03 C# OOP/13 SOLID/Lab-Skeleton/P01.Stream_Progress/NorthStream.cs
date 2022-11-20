namespace P01.Stream_Progress
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NorthStream : IStreamProgress
    {
        private string manager;

        public NorthStream(string manager, int length, int bytesSent)
        {
            this.manager = manager;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set ; }
        public int BytesSent { get; set; }
    }
}
