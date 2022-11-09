namespace _04_Border_Control.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IIdentity
    {
        public string Id { get; set; }

        public bool IsFakeId(string id);

    }
}
