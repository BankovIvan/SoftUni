namespace Military.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate p);
    }
}
