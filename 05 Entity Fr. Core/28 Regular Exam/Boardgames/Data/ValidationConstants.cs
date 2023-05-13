namespace Boardgames.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ValidationConstants
    {

        public const int MaxLengthBoardgameName = 20;
        public const int MinLengthBoardgameName = 10;
        public const double MaxValueBoardgameRating = 10.00;
        public const double MinValueBoardgameRating = 1.00;
        public const int MaxValueBoardgameYearPublished = 2023;
        public const int MinValueBoardgameYearPublished = 2018;
        public const int MaxLengthBoardgameMechanics = 4000;


        public const int MaxLengthSellerName = 20;
        public const int MinLengthSellerName = 5;
        public const int MaxLengthSellerAddress = 30;
        public const int MinLengthSellerAddress = 2;
        public const string RegExValidSellerWebsite = @"www(\.[A-Za-z0-9-]+\.)+com";
        public const int MaxLengthSellerCountry = 4000;
        public const int MaxLengthSellerWebsite = 4000;

        public const int MaxLengthCreatorFirstName = 7;
        public const int MinLengthCreatorFirstName = 2;
        public const int MaxLengthCreatorLastName = 7;
        public const int MinLengthCreatorLastName = 2;

    }
}
