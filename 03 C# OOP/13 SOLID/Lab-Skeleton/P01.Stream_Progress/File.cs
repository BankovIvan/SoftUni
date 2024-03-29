﻿namespace P01.Stream_Progress
{
    public class File : IStreamProgress
    {
        private string name;
        private string v;

        public File(string v)
        {
            this.v = v;
        }

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
