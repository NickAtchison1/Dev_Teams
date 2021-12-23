using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_POCOs
{
    public class Developer
    {
        /*
     * Developers have names and ID numbers;
     * we need to be able to identify one developer without mistaking them for another. 
     * We also need to know whether or not they have access to the online learning tool: Pluralsight.
     */

        static int _developerId = 1;
        public Developer()
        {
            DeveloperID = _developerId++;
        }

        public Developer(string firstName, string lastname, bool hasPluralsight)
        {
           
            FirstName = firstName;
            LastName = lastname;
            HasPluralsight = hasPluralsight;

            
        }
        public int DeveloperID { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public String FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public bool HasPluralsight { get; set; }
    }
}
