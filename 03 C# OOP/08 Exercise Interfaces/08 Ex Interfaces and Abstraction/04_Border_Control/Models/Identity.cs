namespace _04_Border_Control.Models
{
    using _04_Border_Control.Models.Interfaces;
    using System;

    public class Identity : IIdentity
    {
        private string id;

        public string Id
        {
            get { return this.id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Empty Id");
                }
                this.id = value;
            }
        }

        public Identity(string id)
        {
            this.Id = id;
        }

        public bool IsFakeId(string id)
        {
            bool ret = false;

            if (id.Length > 0 && id.Length <= this.Id.Length)
            {
                ret = string.Compare(this.Id, this.Id.Length - id.Length, id, 0, id.Length) == 0;
            }

            return ret;
        }
    }
}
