namespace Military.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
