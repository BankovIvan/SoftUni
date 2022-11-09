namespace Military.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMission
    {
        string CodeName { get; set; }
        string State { get; set; }

        void CompleteMission();
    }
}
