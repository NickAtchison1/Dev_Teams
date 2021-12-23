using DevTeams_POCOs;
using System.Collections.Generic;

namespace DevTeams_Repository
{
    public interface IDeveloperTeamRepository
    {
        void AddDeveloperToTeam(Developer developer, DevTeam devTeam);
        void AddMultipleDevelopersAtOnce(DevTeam devTeam, Developer developer);
        void CreateNewTeam(DevTeam devTeam);
        void DeleteDeveloperTeam(int teamID);
        List<DevTeam> GetAllDevTeams();
        DevTeam GetDevTeamByID(int id);
        void RemoveDeveloperFromTeam(int devId, int devTeamId);
        void UpdateDevTeam(DevTeam devTeam);
    }
}