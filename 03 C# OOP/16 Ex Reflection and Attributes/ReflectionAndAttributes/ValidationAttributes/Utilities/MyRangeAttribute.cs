namespace ValidationAttributes.Utilities
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            bool ret = false;

            ret = (int) obj >= minValue && (int) obj <= maxValue;

            return ret;
        }
    }
}
