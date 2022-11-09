namespace Military.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission m);
    }
}
