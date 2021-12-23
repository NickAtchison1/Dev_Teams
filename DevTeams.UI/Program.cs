using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            DeveloperRepository developerRepository = new DeveloperRepository();
            DeveloperTeamRepository developerTeamRepository = new DeveloperTeamRepository();
            ProgramUI ui = new ProgramUI(developerRepository, developerTeamRepository);
            ui.Run();
        }
    }
}
