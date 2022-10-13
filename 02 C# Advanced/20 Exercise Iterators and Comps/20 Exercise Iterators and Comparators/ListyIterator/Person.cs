namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public class Person : IComparable<Person>, IEquatable<Person>, IEqualityComparer<Person>
    {
        private static int id_index = 0;
        private string name;
        private int age;
        private string town;

        public readonly int Id;
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public string Town { get { return this.town; } set { this.town = value; } }

        public Person()
        {
            this.Id = id_index++;
        }

        public Person(string name, int age, string town) : this()
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo([AllowNull] Person other)
        {
            int ret = -1;

            if(other != null)
            {
                ret = this.Name.CompareTo(other.Name);
                if (ret == 0) ret = this.Age.CompareTo(other.Age);
                if (ret == 0) ret = this.Town.CompareTo(other.Town);
            }


            return ret;
        }

        public bool Equals([AllowNull] Person other)
        {
            bool ret = false;

            if(other != null)
            {
                ret = this.Name.Equals(other.Name) && this.Age.Equals(other.Age);
            }

            return ret;
        }

        public bool Equals([AllowNull] Person x, [AllowNull] Person y)
        {
            bool ret = false;

            if(x != null)
            {
                ret = x.Equals(y);
            }

            return ret;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            //
            // !!! NOT USED BY HashSet !!!
            //

            int ret = 0;

            ret = this.Name.GetHashCode() + this.Age.GetHashCode();

            return ret;
        }

        
        public override int GetHashCode()
        {
            //
            // !!! OVERRIDES Object.GetHashCode() !!!
            //
            // !!! HashSet USES THIS ONE !!!
            //

            int ret = 0;

            ret = this.Name.GetHashCode() + this.Age.GetHashCode();

            return ret;
        }
        
    }

}
