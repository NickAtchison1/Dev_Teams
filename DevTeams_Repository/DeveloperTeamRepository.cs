using DevTeams_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperTeamRepository : IDeveloperTeamRepository
    {
        private readonly List<DevTeam> _teamRepo;
        private readonly List<Developer> _devRepo;



        public DeveloperTeamRepository()
        {
            _teamRepo = new List<DevTeam>();
            _devRepo = new List<Developer>();
        }


        public void CreateNewTeam(DevTeam devTeam)
        {
            _teamRepo.Add(devTeam);
        }

        public List<DevTeam> GetAllDevTeams()
        {
            return _teamRepo;
        }



        public DevTeam GetDevTeamByID(int id)
        {
            return _teamRepo.FirstOrDefault(x => x.TeamID == id);
        }




        public void UpdateDevTeam(DevTeam devTeam)
        {
            var teamToUpdate = GetDevTeamByID(devTeam.TeamID);
            if (teamToUpdate != null)
            {

                teamToUpdate.TeamName = devTeam.TeamName;
                teamToUpdate.Members = devTeam.Members;
            }
        }

        public void DeleteDeveloperTeam(int teamID)
        {
            var teamToDelete = GetDevTeamByID(teamID);
            _teamRepo.Remove(teamToDelete);




        }

        public void AddDeveloperToTeam(Developer developer, DevTeam devTeam)
        {
            var dev = _devRepo.Where(d => d.DeveloperID == developer.DeveloperID).FirstOrDefault();
            var team = _teamRepo.Where(t => t.TeamID == devTeam.TeamID).FirstOrDefault();
            if (team.Members.Contains(dev))
            {
                Console.WriteLine($"{dev.FullName} is already in {team.TeamName}");
            }
            else
            {
                team.Members.Add(dev);
            }
        }

        public void AddMultipleDevelopersAtOnce(DevTeam devTeam, Developer developer)
        {
            var listOfDevelopersToAdd = _devRepo.Where(dr => dr.DeveloperID == developer.DeveloperID).ToList();
            var teamToAddMembersTo = _teamRepo.Where(d => d.TeamID == devTeam.TeamID).FirstOrDefault();
            teamToAddMembersTo.Members.AddRange(listOfDevelopersToAdd);


        }



        public void RemoveDeveloperFromTeam(int devId, int devTeamId)
        {
            var devToRemove = _devRepo.Where(d => d.DeveloperID == devId).FirstOrDefault();
            var teamTheDeveloperIsOn = _teamRepo.Where(dt => dt.TeamID == devTeamId).FirstOrDefault();

            if (teamTheDeveloperIsOn.Members.Contains(devToRemove))
            {
                teamTheDeveloperIsOn.Members.Remove(devToRemove);
            }
            else
            {
                Console.WriteLine($"{devToRemove.FullName} does not appear to be on {teamTheDeveloperIsOn}. Please try another developer or team.");
            }

        }


    }
}
