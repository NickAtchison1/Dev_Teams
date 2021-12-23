using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_POCOs
{
    public class DevTeam
    {
        static int _devTeamID = 1;
        public DevTeam()
        {
            TeamID = _devTeamID++;
        }

        public DevTeam(string teamName, List<Developer>members)
        {
            
            TeamName = teamName;
            Members = members;
        }
        public int TeamID { get; private set; }
        public string TeamName { get; set; }

        public List<Developer> Members { get; set; } = new List<Developer> { };
    }
}
