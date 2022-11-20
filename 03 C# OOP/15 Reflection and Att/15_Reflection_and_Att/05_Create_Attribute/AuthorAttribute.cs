namespace AuthorProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        private string name;

        public string Name { get { return name; } }

        public AuthorAttribute(string name)
        {
            this.name = name;
        }
    }
}
