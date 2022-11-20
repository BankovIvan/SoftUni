namespace P01.Stream_Progress
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStreamProgress
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}
