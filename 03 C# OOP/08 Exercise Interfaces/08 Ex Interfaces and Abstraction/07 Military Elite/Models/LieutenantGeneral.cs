namespace Military.Models
{
    using Military.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public IReadOnlyCollection<IPrivate> Privates { get => this.privates.AsReadOnly(); }

        public LieutenantGeneral(long id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public void AddPrivate(IPrivate p)
        {
            this.privates.Add(p);
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(base.ToString());
            ret.AppendLine("Privates:");
            foreach(var v in this.Privates)
            {
                ret.Append("  ");
                ret.AppendLine(v.ToString());
            }

            return ret.ToString().Trim();
        }

    }
}
