namespace Food.Models
{
    using Food.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    public class Birthdate : Identity, IBirthdate
    {
        private DateTime birthday;

        public DateTime Birthday { get => this.birthday; set => this.birthday = value; }

        public Birthdate(string id, DateTime birthday) : base(id)
        {
            this.Birthday = birthday;
        }

        public bool IsBirthYear(int year)
        {
            bool ret = false;

            if(this.Birthday.Year == year)
            {
                ret = true;
            }

            return ret;
        }
    }
}
