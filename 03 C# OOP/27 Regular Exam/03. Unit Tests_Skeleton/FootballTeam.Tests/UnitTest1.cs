using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player1;
        private FootballPlayer player2;
        private FootballPlayer player3;
        private FootballTeam team1;

        [SetUp]
        public void Setup()
        {
            player1 = new FootballPlayer("Iceto", 9, "Forward");
            player2 = new FootballPlayer("Ivan", 11, "Forward");
            player3 = new FootballPlayer("Mesi", 10, "Forward");
            team1 = new FootballTeam("Bulgaria", 15);
        }

        [Test]
        public void Test_01_Constrictor_Valid()
        {
            Assert.AreEqual(team1.Name, "Bulgaria");
            Assert.AreEqual(team1.Capacity, 15);
            Assert.AreEqual(team1.Players.Count, 0);
        }

        [Test]
        public void Test_02_Constrictor_InValid()
        {
            FootballTeam team2;

            Assert.Throws<ArgumentException>(() => team2 = new FootballTeam(null, 15));
            Assert.Throws<ArgumentException>(() => team2 = new FootballTeam("", 15));
            Assert.Throws<ArgumentException>(() => team2 = new FootballTeam("France", 14));

        }

        [Test]
        public void Test_03_AddPlayer_Valid()
        {
            FootballTeam team2 = new FootballTeam("International", 15);

            team2.AddNewPlayer(player1);
            team2.AddNewPlayer(player2);

            Assert.AreEqual(team2.PickPlayer(player1.Name).Name, player1.Name);
            Assert.AreEqual(team2.PickPlayer(player2.Name).Name, player2.Name);
            Assert.AreEqual(team2.Players.Count, 2);
        }

        [Test]
        public void Test_04_AddPlayer_Invalid()
        {
            FootballTeam team2 = new FootballTeam("International", 15);

            team2.AddNewPlayer(new FootballPlayer("Name1", 1, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name2", 2, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name3", 3, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name4", 4, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name5", 5, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name6", 6, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name7", 7, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name8", 8, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name9", 9, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name10", 10, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name11", 11, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name12", 12, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name13", 13, "Forward"));
            team2.AddNewPlayer(new FootballPlayer("Name14", 14, "Forward"));
            //team2.AddNewPlayer(new FootballPlayer("Name15", 15, "Forward"));
            //team2.AddNewPlayer(new FootballPlayer("Name16", 16, "Forward"));

            
            Assert.AreEqual(
                team2.AddNewPlayer(new FootballPlayer("Name15", 15, "Forward"))
                , "Added player Name15 in position Forward with number 15");
            
            Assert.AreEqual(
                team2.AddNewPlayer(new FootballPlayer("Name16", 16, "Forward"))
                , "No more positions available!");

        }

    }
}