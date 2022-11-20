namespace AuthorProblem
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            //var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                object[] customAttributes = method.GetCustomAttributes(typeof(AuthorAttribute), true);
                
                foreach(var attribute in customAttributes)
                {
                    Console.WriteLine("{0} is written by {1}", method.Name, ((AuthorAttribute)attribute).Name);
                    
                }
            }

        }
    }
}
