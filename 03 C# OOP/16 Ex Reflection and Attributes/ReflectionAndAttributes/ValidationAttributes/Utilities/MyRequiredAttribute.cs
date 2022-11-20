namespace ValidationAttributes.Utilities
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public MyRequiredAttribute() 
        { 

        }

        public MyRequiredAttribute(params object[] data)
        {

        }

        public override bool IsValid(object obj)
        {
            bool ret = false;

            ret = obj != null;

            return ret;
        }
    }
}
