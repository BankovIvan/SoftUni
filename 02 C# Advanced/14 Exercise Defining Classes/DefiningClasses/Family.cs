namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class Family
    {
        public List<Person> People { get; set; }
        //private List<Person> lstPersons;

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestPerson()
        {

            return People.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }
}
