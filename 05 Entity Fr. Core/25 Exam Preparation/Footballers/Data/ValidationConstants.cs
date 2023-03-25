namespace Footballers.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ValidationConstants
    {

        public const int MaxSizeFootballerName = 40;
        public const int MinSizeFootballerName = 2;

        public const int MaxSizeTeamName = 40;
        public const int MinSizeTeamName = 3;
        public const int MaxSizeTeamNationality = 40;
        public const int MinSizeTeamNationality = 2;
        public const string RegExInvalidTeamName = @"[^A-Za-z0-9\s\.\-]";

        public const int MaxSizeCoachName = 40;
        public const int MinSizeCoachName = 2;
        public const int MaxSizeCoachNationality = 40;
        public const int MinSizeCoachNationality = 2;


    }
}
