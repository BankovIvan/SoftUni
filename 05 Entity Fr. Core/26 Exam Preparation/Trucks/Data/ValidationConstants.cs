namespace Trucks.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ValidationConstants
    {

        public const int ExactLengthTrucksRegistrationNumber = 8;
        public const string RegExValidTrucksRegistrationNumber = @"[A-Z][A-Z][0-9][0-9][0-9][0-9][A-Z][A-Z]";
        public const int ExactLengthTrucksVinNumber = 17;
        public const int MinValueTrucksTankCapacity  = 950;
        public const int MaxValueTrucksTankCapacity = 1420;
        public const int MinValueTrucksCargoCapacity = 5000;
        public const int MaxValueTrucksCargoCapacity = 29000;

        public const int MaxLengthClientName = 40;
        public const int MinLengthClientName = 3;
        public const int MaxLengthClientNationality = 40;
        public const int MinLengthClientNationality = 2;


        public const int MaxLengthDespatcherName = 40;
        public const int MinLengthDespatcherName = 2;


    }
}
