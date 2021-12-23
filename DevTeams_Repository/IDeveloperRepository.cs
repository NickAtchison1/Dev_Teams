using DevTeams_POCOs;
using System.Collections.Generic;

namespace DevTeams_Repository
{
    public interface IDeveloperRepository
    {
        void DeleteDeveloper(int developerID);
        List<Developer> GetAllDevelopers();
        List<Developer> GetAllDevelopersWithPlurasightSubsription();
        Developer GetDeveloperByID(int id);
        void InsertDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
    }
}