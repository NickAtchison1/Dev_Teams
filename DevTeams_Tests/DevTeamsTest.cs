using DevTeams_POCOs;
using DevTeams_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{

    [TestClass]
    public class DevTeamsTest
    {

        private IDeveloperRepository _devRepo;
        private DeveloperTeamRepository _teamRepo;
        

        [TestInitialize]
        public void Arrange(IDeveloperRepository devRepo)
        {
            _devRepo = devRepo;
            _teamRepo = new DeveloperTeamRepository();
            Developer developer = new Developer()
            {
                ID = 1,
                FirstName = "Nick",
                LastName  = "Atchison",
                HasPluralsight = true
            };

            Developer developer2= new Developer()
            {
                ID = 2,
                FirstName = "Martin",
                LastName = "Fowler",
                HasPluralsight = false
            };

            Developer developer3= new Developer()
            {
                ID = 3,
                FirstName = "Tim",
                LastName = "Corey",
                HasPluralsight = true
            };

            Developer developer4 =  new Developer()
            {
                ID = 4,
                FirstName = "Derek",
                LastName = "Comartin",
                HasPluralsight = true
            };
            DevTeam team = new DevTeam()
            {
                TeamID = 1,
                TeamName = "First Team",
                Members = new List<Developer> { developer, developer2 }

            };

            DevTeam team2= new DevTeam()
            {
                TeamID = 2,
                TeamName = "Second Team",
                Members = new List<Developer> { developer, developer3, developer4 }

            };

            DevTeam team3 = new DevTeam()
            {
                TeamID = 3,
                TeamName = "First Team",
                Members = new List<Developer> { developer2 , developer4 }

            };

            DevTeam team4 = new DevTeam()
            {
                TeamID = 4,
                TeamName = "First Team",
                Members = new List<Developer> { developer, developer2,developer3,developer4 }

            };
            _devRepo.InsertDeveloper(developer);
            _devRepo.InsertDeveloper(developer2);
            _devRepo.InsertDeveloper(developer3);
            _devRepo.InsertDeveloper(developer4);

            _teamRepo.CreateNewTeam(team);
            _teamRepo.CreateNewTeam(team2);
            _teamRepo.CreateNewTeam(team3);
            _teamRepo.CreateNewTeam(team4);
        }

        [TestMethod]
        public void GetAllDevelopersWithPlurasightSubsriptionTest()
        {
            List<Developer> devsWithPluralsightSub = _devRepo.GetAllDevelopersWithPlurasightSubsription();
            int expected = 3;
            int actual = devsWithPluralsightSub.Count;
            Assert.AreEqual(expected, actual);

        }

        //[TestMethod]
        //public void DevTeamShouldShowCorrectMembersTest()
        //{
        //    List<DevTeam> devTeamMembers = _teamRepo.
        //}
    }
}
