using DevTeams_POCOs;
using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams.UI
{
    public class ProgramUI
    {
        private readonly IDeveloperRepository _devRepo;
        private readonly IDeveloperTeamRepository _devTeamRepo;

        public ProgramUI(IDeveloperRepository devRepo, IDeveloperTeamRepository devTeamRepo)
        {
            _devRepo = devRepo;
            _devTeamRepo = devTeamRepo;
        }



        public void Run()
        {
            Seed();
            RunApplications();
        }



        private void RunApplications()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to dev Teams\n" +
                    "1. Add A Developer\n" +
                    "2. View All Existing Developers\n" +
                    "3. View An Existing Developer\n" +
                    "4. Update An Existing Developer\n" +
                    "5. Delete An Existng Developer\n" +
                    "6. Create A Team\n" +
                    "7. View All Teams\n" +
                    "8. View Team Detail\n" +
                    "9. Update Team\n" +
                    "10. Delete\n" +
                    "11. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        ViewAllExistingDevelopers();
                        break;
                    case "3":
                        ViewAnExistingDeveloper();
                        break;
                    case "4":
                        UpdateAnExistingDeveloper();
                        break;
                    case "5":
                        DeleteAnExistingDeveloper();
                        break;
                    case "6":
                        CreateTeam();
                        break;
                    case "7":
                        ViewAllTeams();
                        break;
                    case "8":
                        ViewTeamDetails();
                        break;
                    case "9":
                        UpdateTeam();
                        break;
                    case "10":
                        DeleteTeam();
                        break;
                    case "11":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;
                }
                Console.Clear();
            }
        }

        private void DeleteTeam()
        {
            throw new NotImplementedException();
        }

        private void UpdateTeam()
        {
            throw new NotImplementedException();
        }

        private void ViewTeamDetails()
        {
            Console.Clear();
            Console.WriteLine("View Team Detail\n" +
                "Please enter the ID number of the team you'd like to view\n");
            
            int userInput = Convert.ToInt32(Console.ReadLine());
            var teamToView = _devTeamRepo.GetDevTeamByID(userInput);
            if (teamToView != null)
            {

                Console.WriteLine($"ID: {teamToView.TeamID}\n" +
                    $"Name: {teamToView.TeamName}\n" +
                    $"Members: {String.Join(",", teamToView.Members.Select(i => i.FullName))}");
            }
            else
            {
                Console.WriteLine("Developer not found. Please try a different ID");
                WaitForKey();

            }

            WaitForKey();
        }

        private void ViewAllTeams()
        {
            Console.Clear();
            Console.WriteLine("Showing all Teams: ");
            var allTeams = _devTeamRepo.GetAllDevTeams();
            foreach (var team in allTeams)
            {
                Console.WriteLine($"ID: {team.TeamID}\n" +
                    $"Name: {team.TeamName}\n" +
                    $"Members: {String.Join("," , team.Members.Select(i => i.FullName))}");
            }
            WaitForKey();
        }

        private void CreateTeam()
        {
            Console.Clear();
            Console.WriteLine("Create Team View\n");
            Console.Write("Please Enter a Team Name: ");
           
            DevTeam devTeam = new DevTeam();


            
            devTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Add team members by entering the ID below, or create team without any members\n");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Add Team Member: (y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.Write("Developer ID? ");
                        int devId = Convert.ToInt32(Console.ReadLine());
                        var devToAdd   = _devRepo.GetDeveloperByID(devId);
                        devTeam.Members.Add(devToAdd);
                        break;
                    case "n":
                        Console.WriteLine("That's ok. You may add more later.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();

            }

            _devTeamRepo.CreateNewTeam(devTeam);
        }

        private void DeleteAnExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Delete an Existing Developer\n" +
                "Please enter the ID number of the developer you'd like to delete");
            string userInputString = Console.ReadLine();
            int userInput = Convert.ToInt32(userInputString);
            var devToView = _devRepo.GetDeveloperByID(userInput);
            if (devToView != null)
            {

                Console.WriteLine($"ID: {devToView.DeveloperID}\n" +
                    $"Name: {devToView.FullName}\n" +
                    $"Has Pluralsight: {devToView.HasPluralsight}\n");
            }
            else
            {
                Console.WriteLine("Developer not found. Please try a different ID");
                WaitForKey();

            }

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Do you want to delete this developer(y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        Console.WriteLine("Developer has been Deleted!\n");
                        _devRepo.DeleteDeveloper(userInput);
                        isRunning = false;
                        break;
                    case "n":
                        Console.WriteLine("Delete Cancelled. Returning to the Main Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();


            }
        }

        private void UpdateAnExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Update an Existing Developer\n" +
                "Please enter the ID number of the developer you'd like to update");

            int userInput = Convert.ToInt32(Console.ReadLine());
            var devToView = _devRepo.GetDeveloperByID(userInput);
            if (devToView != null)
            {

                Console.WriteLine($"ID: {devToView.DeveloperID}\n" +
                    $"Name: {devToView.FullName}\n" +
                    $"Has Pluralsight: {devToView.HasPluralsight}\n");
            }
            else
            {
                Console.WriteLine("Developer not found. Please try a different ID");
                WaitForKey();

            }

            WaitForKey();
            Console.WriteLine("Please make the required changes. " +
                "\n" +
                "Please fill in the original data on the field if no changes are needed\n");
            Console.Write("First Name? ");
            devToView.FirstName = Console.ReadLine();

            Console.Write("Last Name?: ");
            devToView.LastName = Console.ReadLine();

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Does developer have Pluralsight: (y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        devToView.HasPluralsight = true;
                        isRunning = false;
                        break;
                    case "n":
                        devToView.HasPluralsight = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
            }

            WaitForKey();
            bool isUpdating = true;
            while (isUpdating)
            {
                Console.WriteLine("Updates have been applied. Do you want to save your changes? (y/n)?\n");

                string choice = Console.ReadLine().ToLower(); ;
                switch (choice)
                {
                    case "y":
                        Console.WriteLine("Saving Changes!\n");
                        _devRepo.UpdateDeveloper(devToView);
                        isRunning = false;

                        break;
                    case "n":
                        Console.WriteLine("Update cancelled. Returning to the Gas Cars Menu.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();

            }
        }
            

        private void ViewAnExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("View an Existing Developer\n" +
                "Please enter the ID number of the developer you'd like to view");
            string userInputString = Console.ReadLine();
            int userInput = Convert.ToInt32(userInputString);
            var devToView = _devRepo.GetDeveloperByID(userInput);
            if (devToView != null)
            {

                Console.WriteLine($"ID: {devToView.DeveloperID}\n" +
                    $"Name: {devToView.FullName}\n" +
                    $"Has Pluralsight: {devToView.HasPluralsight}\n");
            }
            else
            {
                Console.WriteLine("Developer not found. Please try a different ID");
                WaitForKey();

            }

            WaitForKey();

        }

        private void ViewAllExistingDevelopers()
        {
            Console.Clear();
            Console.WriteLine("Showing all developers: ");
            var alldevs = _devRepo.GetAllDevelopers();
            foreach (var dev in alldevs)
            {
                Console.WriteLine($"ID: {dev.DeveloperID}\n" +
                    $"Name: {dev.FullName}\n" +
                    $"Has Pluralsight: {dev.HasPluralsight}\n");
            }
            WaitForKey();
        }

        private void AddDeveloper()
        {
            Console.Clear();
            Developer developer = new Developer();


            Console.Write("Please Enter a First Name: ");
            developer.FirstName = Console.ReadLine();

            Console.Write("Please Enter a Last Name: ");
            developer.LastName = Console.ReadLine();

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Does developer have Pluralsight: (y/n)?\n");

                string userChoice = Console.ReadLine().ToLower(); ;
                switch (userChoice)
                {
                    case "y":
                        developer.HasPluralsight = true;
                        isRunning = false;
                        break;
                    case "n":
                        developer.HasPluralsight = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        WaitForKey();
                        break;


                }
                WaitForKey();

            }

            _devRepo.InsertDeveloper(developer);
        }

 


        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void Seed()
        {
            Developer developer = new Developer()
            {
                FirstName = "Some",
                LastName = "Person",
                HasPluralsight = true
            };

            Developer developer2 = new Developer()
            {
                FirstName = "SomeOther",
                LastName = "Person",
                HasPluralsight = true
            };

            Developer developer3 = new Developer()
            {
                FirstName = "Another",
                LastName = "Person",
                HasPluralsight = false
            };

            DevTeam team1 = new DevTeam()
            {
                TeamName = "First Team",
                Members = { developer, developer2 }

            };

            DevTeam team2 = new DevTeam()
            {
                TeamName = "Team without any members yet",
                

            };
            _devRepo.InsertDeveloper(developer);
            _devRepo.InsertDeveloper(developer2);
            _devRepo.InsertDeveloper(developer3);
            _devTeamRepo.CreateNewTeam(team1);
            _devTeamRepo.CreateNewTeam(team2);
        }
    }
}
    
    
        


        
    

