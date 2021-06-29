using DeveloperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperLibrary_Console
{
    class ProgramUI
    {
        private DeveloperRepository _developerRepo = new DeveloperRepository();

        private DevTeamRepository _teamRepo = new DevTeamRepository();

        //Method that runs/starts the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Dispaly our options to the user
                DevTeamRepository devTeam = new DevTeamRepository();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developr by Id Number\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developer\n" +
                    "6. Add New Team\n" +
                    "7. Add Developer To Team\n" +
                    "8. Remove Developer From Team\n" +
                    "9. View All Teams\n" +
                    "10. Update Existing Teams\n" +
                    "11. Delete Existing Teams\n" +
                    "12. Exit");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new developer
                        AddNewDeveloper();
                        break;
                    case "2":
                        //View All developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        //View Developer by Id Number
                        DispalyDeveloperByIdNumber();
                        break;
                    case "4":
                        //Update Existing Developers
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        //Delete Existing Developers
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        //Add new team
                        AddNewTeam();
                        break;
                    case "7":
                        //Add developer to team
                        AddDeveloperToTeam();
                        break;
                    case "8":
                        //Remove developer from team
                        RemoveDeveloperFromTeam();
                        break;
                    case "9":
                        //View all teams
                        DisplayAllTeams();
                        break;
                    case "10":
                        //Update Existing Teams
                        UpdateExistingTeams();
                        break;
                    case "11":
                        //Delete Existing Teams
                        DeleteExistingTeams();
                        break;                    
                    case "12":
                        //Exit
                        Console.WriteLine("goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //DEVELOPERS
        //Create new Developer
        private void AddNewDeveloper()
        {
            DeveloperContent newContent = new DeveloperContent();

            //Name
            Console.WriteLine("Enter the Developers Name:");
            newContent.Name = Console.ReadLine();

            //Id Number
            Console.WriteLine("Enter the Developers Id Number");
            string idAsString = Console.ReadLine();
            newContent.IdNumber = int.Parse(idAsString);
            //int idNumber = int.Parse(Console.ReadLine());

            //Pluralsight Access
            Console.WriteLine("Dose the developer have access to Pluralsight? y/n ");
            string accessString = Console.ReadLine().ToLower();

            if (accessString == "y")
            {
                newContent.PluralsightAccess = true;
            }
            else
            {
                newContent.PluralsightAccess = false;
            }

            _developerRepo.AddDeveloperToList(newContent);

        }

        //View current Developrs that are saved
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<DeveloperContent> listofContent = _developerRepo.GetDeveloperList();

            foreach(DeveloperContent content in listofContent)
            {
                Console.WriteLine($"Name: {content.Name}\n" +
                    $"Id Number: {content.IdNumber}\n" +
                    $"Has access to Pluralsight: {content.PluralsightAccess}");
            }
        }

        //View existing Developer by Id Number
        private void DispalyDeveloperByIdNumber()
        {
            Console.Clear();
            //Prompt user to give me a id number
            Console.WriteLine("Enter the Id Number of the developer you would like to see: ");

            //Get the user's input
            int idNumber = int.Parse(Console.ReadLine());

            //Find the developer by id number
            DeveloperContent content = _developerRepo.GetContentByIdNumber(idNumber);


            //Display said content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"Name: {content.Name}\n" +
                    $"Id Number: {content.IdNumber}\n" +
                    $"Has access to Pluralsight: {content.PluralsightAccess}");
            }
            else
            {
                Console.WriteLine("No developer by that number found.");
            }
        }

        //Update Existing Developer
        private void UpdateExistingDeveloper()
        {
            //Display all content
            DisplayAllDevelopers();

            //Ask for the developer content to update
            Console.WriteLine("Enter the Id Number of the developer you would like to update.");

            //Get the developer
            int oldDeveloper = int.Parse(Console.ReadLine());


            //We will build a new object
            DeveloperContent newContent = new DeveloperContent();

            //Name
            Console.WriteLine("Enter the Developers Name:");
            newContent.Name = Console.ReadLine();

            //Id Number
            Console.WriteLine("Enter the Developers Id Number");
            string idAsString = Console.ReadLine();
            newContent.IdNumber = int.Parse(idAsString);
            //int idNumber = int.Parse(Console.ReadLine());

            //Pluralsight Access
            Console.WriteLine("Dose the developer have access to Pluralsight?");
            string accessString = Console.ReadLine().ToLower();

            if (accessString == "y")
            {
                newContent.PluralsightAccess = true;
            }
            else
            {
                newContent.PluralsightAccess = false;
            }

            //Verify the update worked
            bool wasUpdated = _developerRepo.UpdateExistingContent(oldDeveloper, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update contnet.");
            }

        }

        //Delete Existing Developer
        private void DeleteExistingDeveloper()
        {


            DisplayAllDevelopers();
            Console.WriteLine("\nEnter the Id Number of the developer you would like to remove.");

            //Get the developer they want to delete
            int input = int.Parse(Console.ReadLine());

            //Call the delete method
            bool wasDeleted = _developerRepo.RemoveContentFromList(input);

            //If the developer was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }

            //otherwise state that it was not deleteed
        }

        //Seed method
        private void SeedContentList()
        {
            DeveloperContent mickeyMouse = new DeveloperContent("Mickey Mouse", 23, true);
            DeveloperContent minnieMouse = new DeveloperContent("Minnie Mouse", 35, true);
            DeveloperContent donaldDuck = new DeveloperContent("Donald Duck", 46, false);

            _developerRepo.AddDeveloperToList(mickeyMouse);
            _developerRepo.AddDeveloperToList(minnieMouse);
            _developerRepo.AddDeveloperToList(donaldDuck);

            DevTeamContent redTeam = new DevTeamContent(new List<DeveloperContent>() {mickeyMouse, minnieMouse }, "Red Team", 1);
            DevTeamContent blueTeam = new DevTeamContent(new List<DeveloperContent>() , "Blue Team", 2);
            blueTeam.AddDeveloperToTeam(donaldDuck);

            _teamRepo.AddTeamToList(redTeam);
            _teamRepo.AddTeamToList(blueTeam);
        }

        //DEVTEAM

        //Create new Team
        private void AddNewTeam()
        {
            DevTeamContent newContent = new DevTeamContent();

            //Name
            Console.WriteLine("Enter the DevTeam Name:");
            newContent.TeamName = Console.ReadLine();

            //Id Number
            Console.WriteLine("Enter the Team Id Number");
            string idAsString = Console.ReadLine();
            newContent.TeamId = int.Parse(idAsString);
            //int teamId = int.Parse(Console.ReadLine());

            _teamRepo.AddTeamToList(newContent);

        }

        //Add Developer To Team
        private void AddDeveloperToTeam()
        {
            DisplayAllTeams();
            
            Console.WriteLine("\nEnter the Team Id you want.");
            int input = int.Parse(Console.ReadLine());

            DevTeamContent devTeamContent = _teamRepo.GetContentByTeamId(input);

            DisplayAllDevelopers();
            Console.WriteLine("\nEnter the Developer Id you want to choose.");

            int number = int.Parse(Console.ReadLine());
            DeveloperContent developerContent = _developerRepo.GetContentByIdNumber(number);

            devTeamContent.AddDeveloperToTeam(developerContent);
        }

        //Remove Developer From Team
        private void RemoveDeveloperFromTeam()
        {
            DisplayAllTeams();

            Console.WriteLine("\nEnter the Team Id you want.");
            int input = int.Parse(Console.ReadLine());

            DevTeamContent devTeamContent = _teamRepo.GetContentByTeamId(input);

            DisplayAllDevelopers();
            Console.WriteLine("\nEnter the Developer Id you would like to remove.");

            int number = int.Parse(Console.ReadLine());
            DeveloperContent developerContent = _developerRepo.GetContentByIdNumber(number);

            devTeamContent.RemoveDeveloperFromTeam(developerContent);

            //Call the delete method
            bool wasDeleted = _developerRepo.RemoveContentFromList(input);

            //If the developer was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully removed from this team.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }

            //otherwise state that it was not deleteed
        }
        //View current Teams that are saved
        private void DisplayAllTeams()
        {
            Console.Clear();

            List<DevTeamContent> listofContent = _teamRepo.GetTeamList();
            List<DeveloperContent> developerContents = _developerRepo.GetDeveloperList();

            foreach (DevTeamContent content in listofContent)

            {
                Console.WriteLine($"\nTeam Name: {content.TeamName}\n" +
                    $"Team Id Number: {content.TeamId}");
                foreach(DeveloperContent dev in content.TeamMembers)
                {
                    Console.WriteLine(
                    $"Team Members: {dev.Name}");
                }
            }
        }
        //Update Existing Team
        private void UpdateExistingTeams()
        {
            //Display all teams
            DisplayAllTeams();

            //Ask for the team content to update
            Console.WriteLine("Enter the Id Number of the team you would like to update.");

            //Get the team
            int oldTeam = int.Parse(Console.ReadLine());


            //We will build a new object
            DevTeamContent newContent = new DevTeamContent();

            //Name
            Console.WriteLine("Enter the Team Name:");
            newContent.TeamName = Console.ReadLine();

            //Id Number
            Console.WriteLine("Enter the Team Id Number");
            string idAsString = Console.ReadLine();
            newContent.TeamId = int.Parse(idAsString);
            //int idNumber = int.Parse(Console.ReadLine());

            //Add Developers to the team
            Console.WriteLine("Add developers to team");
            string accessString = Console.ReadLine().ToLower();

            //Verify the update worked
            bool wasUpdated = _teamRepo.UpdateExistingTeam(oldTeam, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Team successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update team.");
            }

        }
        //Delete Existing Team
        private void DeleteExistingTeams()
        {


            DisplayAllTeams();
            Console.WriteLine("\nEnter the Id Number of the team you would like to remove.");

            //Get the team they want to delete
            int input = int.Parse(Console.ReadLine());

            //Call the delete method
            bool wasDeleted = _teamRepo.RemoveTeamFromList(input);

            //If the team was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }

            //otherwise state that it was not deleteed
        }
    }
}
