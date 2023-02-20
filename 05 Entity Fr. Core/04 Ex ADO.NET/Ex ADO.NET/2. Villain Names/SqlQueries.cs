namespace _02_Villain_Names
{
    using Azure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class SqlQueries
    {

        public const string _02_Select =
            @"  SELECT 
                    v.Name
                    , COUNT(mv.VillainId) AS MinionsCount  
                FROM 
                    Villains AS v 
                    JOIN MinionsVillains AS mv 
                    ON v.Id = mv.VillainId 
                GROUP BY 
                    v.Id
                    , v.Name 
                HAVING 
                    COUNT(mv.VillainId) > 3 
                ORDER BY 
                    COUNT(mv.VillainId)";

        public const string _03_SelectVillanName =
            @"SELECT 
                Name 
            FROM 
                Villains 
            WHERE 
                Id = @Id";

        public const string _03_SelectVillanMinionNames =
            @"SELECT 
                ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                m.Name, 
                m.Age
                FROM 
                    MinionsVillains AS mv
                    JOIN Minions As m 
                    ON mv.MinionId = m.Id
                WHERE 
                    mv.VillainId = @Id
                ORDER BY 
                    m.Name";

        public const string _04_SelectVillanId =
            @"SELECT Id FROM Villains WHERE Name = @Name"; //

        public const string _04_SelectMinionId =
            @"SELECT Id FROM Minions WHERE Name = @Name"; //

        public const string _04_SelectTownId =
            @"SELECT Id FROM Towns WHERE Name = @townName"; //

        public const string _04_InsertIntoMinionsVillains =
            @"INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@minionId, @villainId)"; //

        public const string _04_InsertIntoVillains =
            @"INSERT INTO Villains(Name, EvilnessFactorId)  VALUES(@villainName, 4)"; //

        public const string _04_InsertIntoMinions =
            @"INSERT INTO Minions(Name, Age, TownId) VALUES(@name, @age, @townId)"; //

        public const string _04_InsertIntoTowns =
            @"INSERT INTO Towns(Name) VALUES(@townName)"; //

        public const string _05_UpdateTownsByCountry =
            @"UPDATE 
                Towns
            SET 
                Name = UPPER(Name)
            WHERE 
                CountryCode = 
                    (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string _05_SelectTownsByCountry =
            @"SELECT 
                t.Name 
            FROM 
                Towns as t
                JOIN Countries AS c 
                ON c.Id = t.CountryCode
            WHERE 
                c.Name = @countryName";

        public const string _06_SelectVillainName =
            @"SELECT Name FROM Villains WHERE Id = @villainId";

        public const string _06_DeleteVillainRelation=
            @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

        public const string _06_DeleteVillain =
            @"DELETE FROM Villains WHERE Id = @villainId";

        public const string _07_SelectMinionNames =
            @"SELECT Name FROM Minions";

        public const string _08_UpdateMinionNamesAndAges =
            @"UPDATE
                Minions
            SET 
                Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name))
                , Age += 1
            WHERE 
                Id = @Id";

        public const string _08_SelectMinionNamesAndAges =
            @"SELECT Name, Age FROM Minions";

        public const string _09_MinionsAgeStoredProcedure =
            @"usp_GetOlder";


    }
}
