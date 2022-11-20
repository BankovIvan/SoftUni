namespace Stealer.Models
{
    using Stealer.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy : ISpy
    {
        public Spy() 
        {

        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder ret = new StringBuilder();
            
            foreach (var field in classFields)
            {
                ret.AppendLine(String.Format("{0} must be private!", field.Name));
            }

            foreach (var method in classPublicMethods)
            {
                if (method.Name.StartsWith("get"))
                {
                    ret.AppendLine(String.Format("{0} have to be public!", method.Name));
                }
                
            }

            foreach (var method in classNonPublicMethods)
            {
                if (method.Name.StartsWith("set"))
                {
                    ret.AppendLine(String.Format("{0} have to be private!", method.Name));
                }
                
            }

            return ret.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder ret = new StringBuilder();

            foreach (var method in classMethods)
            {
                if(method.Name.StartsWith("get") || method.Name.StartsWith("set"))
                {
                    ret.AppendLine(String.Format("{0} will return {1}", method.Name, method.ReturnType));
                }
            }

            return ret.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("All Private Methods of Class: {0}", className));
            ret.AppendLine(String.Format("Base Class: {0}", classType.BaseType.Name));

            foreach (var method in classNonPublicMethods)
            {
                ret.AppendLine(String.Format(method.Name));
            }

            return ret.ToString().Trim();
        }

        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classField = classType.GetFields(
                BindingFlags.Instance | 
                BindingFlags.Static | 
                BindingFlags.NonPublic |
                BindingFlags.Public);

            StringBuilder ret = new StringBuilder();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            
            ret.AppendLine(String.Format("Class under investigation: {0}", className));
            foreach(FieldInfo field in classField.Where(x => fieldNames.Contains(x.Name)))
            {
                ret.AppendLine(String.Format("{0} = {1}", field.Name, field.GetValue(classInstance)));
            }

            return ret.ToString().Trim();

        }
    }
}
