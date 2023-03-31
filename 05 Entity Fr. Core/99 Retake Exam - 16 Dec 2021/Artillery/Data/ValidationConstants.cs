namespace Artillery.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ValidationConstants
    {

        public const int MaxLengthCountryName = 60;
        public const int MinLengthCountryName = 4;
        public const int MaxValueCountryArmySize = 10000000;
        public const int MinValueCountryArmySize = 50000;

        public const int MaxLengthManufacturerManufacturerName  = 40;
        public const int MinLengthManufacturerManufacturerName = 4;
        public const int MaxLengthManufacturerFounded = 100;
        public const int MinLengthManufacturerFounded = 10;

        public const double MaxValueShellShellWeight = 1680;
        public const double MinValueShellShellWeight = 2;
        public const int MaxLengthShellCaliber = 30;
        public const int MinLengthShellCaliber = 4;

        public const int MaxValueGunGunWeight = 1350000;
        public const int MinValueGunGunWeight = 100;
        public const double MaxValueGunBarrelLength = 35;
        public const double MinValueGunBarrelLength = 2;
        public const int MaxValueGunRange = 100000;
        public const int MinValueGunRange = 1;




    }
}
