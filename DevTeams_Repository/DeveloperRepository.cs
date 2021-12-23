using DevTeams_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly List<Developer> _repo;

        public DeveloperRepository()
        {
            _repo =  new List<Developer>();
        }

        public void InsertDeveloper(Developer developer)
        {
            _repo.Add(developer);
        }
        
        public List<Developer> GetAllDevelopers()
        {
            return _repo;
        }

        public List<Developer> GetAllDevelopersWithPlurasightSubsription()
        {
            var devsWithPluralsightSub = _repo.Where(d => d.HasPluralsight == true).ToList();
            return devsWithPluralsightSub;
        }

        public Developer GetDeveloperByID(int id)
        {
            var dev = _repo.FirstOrDefault(d => d.DeveloperID == id);
            return dev;
        }

        public void UpdateDeveloper(Developer developer)
        {
            var dev = _repo.Where(d => d.DeveloperID == developer.DeveloperID).FirstOrDefault();
            if (dev != null)
            {
                
                dev.FirstName = developer.FirstName;
                dev.LastName = developer.LastName;
                dev.HasPluralsight = developer.HasPluralsight;

            }


        }

        public void DeleteDeveloper(int developerID)
        {
            Developer developer = GetDeveloperByID(developerID);
            if (developer != null)
            {
                _repo.Remove(developer);
            }
            
           
        }
    }
}
