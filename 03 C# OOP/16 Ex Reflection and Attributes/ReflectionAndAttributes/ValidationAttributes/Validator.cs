namespace ValidationAttributes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Metadata;
    using ValidationAttributes.Utilities;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            bool ret = true;
            Type objType= obj.GetType();

            foreach (PropertyInfo prop in objType.GetProperties())
            {
                foreach(Attribute custom in prop.GetCustomAttributes())
                {
                    Type attrType = custom.GetType();
                    if(/*custom.GetType().*/ attrType.BaseType.Name == "MyValidationAttribute")
                    {
                        object objValue = prop.GetValue(obj);
                        MethodInfo methodInstance = custom.GetType().GetMethod("IsValid");
                        ret = ret && (bool)methodInstance.Invoke(custom, new object[] { objValue });
                    }
                }
            }

            return ret;
        }
    }
}
