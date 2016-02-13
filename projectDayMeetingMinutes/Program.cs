using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projectDayMeetingMinutes {
    class Program {
        static List<string> Teams = new List<string>() {
            {"Administration"},
            {"Marketing"},
            {"Accounting"}
        };
        static Dictionary<string, string> Names = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
            {"Randall Normon", "Administration"},
            {"Charlie Hamon", "Marketing"},
            {"Julia Grim", "Accounting"},
            {"Henry Barkley", "Administration"},
            {"George Ford", "Marketing"},
            {"Maria Orwell", "Accounting"},
            {"Rosalia Charron", "Administration"},
            {"Simona Addiks", "Marketing"},
            {"Shiva Vadas", "Accounting"}
        };

        static void Menu() {
            Console.Clear();
            Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");

            string[] menuItems = { "Create file", "View Teams", "Exit" };
            int counter = 1;
            foreach (string item in menuItems) { //Makes a menu for the user to take an action
                Console.WriteLine($"{counter}. {item}");
                counter++;
            }
            Console.Write("\nUse the numbers to select an option: ");
            string menuChoice = Console.ReadLine();
            switch(menuChoice){
                case "1":
                    Console.Clear();
                    CreateFile();
                    break;
                case "2":
                    Console.Clear();
                    ViewTeams();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    Console.WriteLine("Goodbye!");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid selection. Press any key to try again. . .");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }

        static void CreateFile() {
            //File contents to be written to file later
            List<string> fileContents = new List<string>(){
                "Chipotle Mexican Grill",
                "1401 Wynkoop St. Ste. 500 Denver, CO 80202",
                "Meeting Minutes",
                ""
            };

            while(true) {
                Console.Clear();
                Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                Console.WriteLine("Please enter the meeting timekeeper:");
                string timeKeeper = Console.ReadLine();
                if (Names.ContainsKey(timeKeeper)) {
                    fileContents.Add("Meeting Timekeeper: " + timeKeeper);
                    break;
                } else {
                    Console.WriteLine("Invalid selection. Please try again. . .");
                    Console.ReadKey();
                }
            }

            while (true) {
                Console.Clear();
                Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                Console.WriteLine("Please enter the leader of the meeting:");
                string meetingLead = Console.ReadLine();
                if (Names.ContainsKey(meetingLead)) {
                    fileContents.Add("Meeting Leader: " + meetingLead);
                    break;
                } else {
                    Console.WriteLine("Invalid selection. Please try again. . .");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
            Console.WriteLine("Please enter the date of the meeting in MMDDYY format:");
            string date = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
            int counter = 1;
            foreach (string team in Teams) {
                Console.WriteLine(counter + ". " + team);
                counter++;
            }

            Console.WriteLine("\nWhich team type is this meeting?");
            string teamChoice = Console.ReadLine();
            switch (teamChoice) {
                case "1":
                    fileContents.Add("Administration Meeting");
                    break;
                case "2":
                    fileContents.Add("Marketing Meeting");
                    break;
                case "3":
                    fileContents.Add("Accounting Meeting");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    Console.WriteLine("Invalid Selection. Please try again. . .");
                    Console.ReadKey();
                    ViewTeams();
                    break;
            }

            //Topics added to fileContents
            Console.Clear();
            Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
            Console.WriteLine("Enter a Topic:");
            string topic = Console.ReadLine();
            Console.WriteLine("Enter notes for your topic:");
            string notes = Console.ReadLine() + "\n";
            fileContents.Add(topic);
            fileContents.Add(notes);
            fileContents.Add("");
            while (true) {
                Console.Clear();
                Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                Console.WriteLine("Would you like to enter a new topic? (y/n)");
                string topicChoice = Console.ReadLine();
                if (topicChoice.ToLower() == "y") {
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    Console.WriteLine("Enter a Topic:");
                    topic = Console.ReadLine();
                    Console.WriteLine("Enter notes for your topic:");
                    notes = Console.ReadLine() + "\n";
                    fileContents.Add(topic);
                    fileContents.Add(notes);
                    fileContents.Add("");
                } else if (topicChoice.ToLower() == "n") {
                    break;
                } else {
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    Console.WriteLine("Invalid selection. Please try again. . .");
                    Console.ReadKey();
                }
            }

            string fileName = "Minutes" + date + ".txt";
            using (StreamWriter writer = new StreamWriter(fileName)) {
                foreach (string item in fileContents) {
                    writer.WriteLine(item);
                }
            }

            using (StreamReader reader = new StreamReader(fileName)) {
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("\nPress any key to continue. . .");
            Console.ReadKey();
            Menu();
        }

        static void ViewTeams() {
            Console.Clear();
            Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
            int counter = 1;
            foreach(string team in Teams) {
                Console.WriteLine(counter + ". " + team);
                counter++;
            }
            
            Console.WriteLine($"{counter}. All-Team\nWhich team would you like to view?:");
            string teamChoice = Console.ReadLine();
            switch (teamChoice) {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    foreach (KeyValuePair<string, string> pair in Names) {
                        if (pair.Value == "Administration")
                            Console.WriteLine(pair.Key);
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    foreach (KeyValuePair<string, string> pair in Names) {
                        if (pair.Value == "Marketing")
                            Console.WriteLine(pair.Key);
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    foreach (KeyValuePair<string, string> pair in Names) {
                        if (pair.Value == "Accounting")
                        Console.WriteLine(pair.Key);
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    foreach (KeyValuePair<string, string> pair in Names) {
                        Console.WriteLine(pair.Key + " (" + pair.Value + ")");
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Meeting Minutes Management Software\n-----------------------------------\n\n");
                    Console.WriteLine("Invalid Selection. Please try again. . .");
                    Console.ReadKey();
                    ViewTeams();
                    break;
            }
            Console.WriteLine("\nPress any key to continue. . .");
            Console.ReadKey();
            Menu();
        }

        static void Main(string[] args) {
            Menu();
        }
    }
}
