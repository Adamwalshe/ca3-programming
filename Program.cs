using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Xml.Linq;

namespace ca3_programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../faminefile.csv";      //reading of the csv file
            string[] menuOptions = { "Ship Reports", "Occupation Reports", "Age Reports", "Exit" };     // This line creates an array of strings, which are the different menu options available to the user.
            Menu m = new Menu(menuOptions);         // This line creates a new Menu object using the menuOptions array that was created earlier.
            int userChoice = m.GetChoice();         // The Menu class is class that provides a user interface for selecting menu options.


            while (userChoice != menuOptions.Length)
            {
                switch (userChoice)
                {

                    case 1:
                        Console.WriteLine("SHIP REPORTS");  //calls ships method if user picks 1 
                        ships();
                        break;

                    case 2:
                        Console.WriteLine("OCCUPATION REPORTS");    //calls occupation method if user picks 2
                        occupation();
                        break;

                    case 3:
                        Console.WriteLine("AGE REPORTS");   //callsreadage method if user picks 3
                        readage();
                        break;

                    case 4:
                        Console.WriteLine("EXITING THE PROGRAMME"); //exits the programme if user picks 4
                        break;

                    default:
                        Console.WriteLine("INVALID CHOICE");  //if users choice is not 1-4 console will output invalid choice
                        break;

                }

                userChoice = m.GetChoice();

            }
        }
        static List<Passenger> readfiles()
        {
            try
            {
                string path = @"../../../faminefile.csv";   //reading of the csv file
                string occupation = "";
                List<Passenger> passengers = new List<Passenger>();
                using (StreamReader sr = File.OpenText(path))
                {
                    string? line = sr.ReadLine();   //skips the first line of data to not read in the headings 
                    while (line != null)
                    {
                        string[] split = line.Split(',');

                        Passenger passenger = new Passenger(split[1], split[0], split[2], split[3], split[4], split[5], split[6], split[7], split[8], split[9]); //The Passenger object is created using the values from the split array and added to the passengers list.
                        passengers.Add(passenger);
                        occupation = split[8];
                        line = sr.ReadLine();

                    }
                    return passengers;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file linked could not be found.");
                return new List<Passenger>();
            }

        }
        static void ships()     // This method displays a menu of ship options and reads the user's choice
        {
            string path = @"../../../faminefile.csv";   //reading of the csv file
            List<Passenger> passengers = readfiles();       // It then calls the `readfiles` method to read the passengers' data from a CSV file
            string[] shipOptions = { "Mary Harrington", "Lincoln", "Clare", "Dispatch" };
            Menu s = new Menu(shipOptions);
            int userChoice2 = s.GetChoice();
            if (userChoice2 == 1)
            {
                Console.WriteLine("MARY HARRINGTON  187  07-06-1848  102"); // Depending on the user's choice of ship, it displays the ship's name, year, date, and number of passengers
                displaynames("MARY HARRINGTON");    // It then calls the `displaynames` method to display the names of the passengers on that ship
            }
            else if (userChoice2 == 2)
            {
                Console.WriteLine("LINCOLN 187 02-05-1849 071");
                displaynames("LINCOLN");
            }
            else if (userChoice2 == 3)
            {
                Console.WriteLine("CLARE 187 06-06-1849 123");
                displaynames("CLARE");
            }
            else if (userChoice2 == 4)
            {
                Console.WriteLine("DISPATCH 187 06-26-1851 049");
                displaynames("DISPATCH");
            }
            else
            {
                Console.WriteLine("Invalid ship entered");  // If the user's choice is not one of the available ships, it displays an error message
            }

        }
        static void displaynames(string shipname)   //the function `displaynames` takes a `shipname` parameter as input and prints out the last name and first name of each passenger on that ship, as well as the total number of passengers on that ship.
        {
            int passengers = 0;
            try
            {
                string filePath = @"../../../faminefile.csv";   //reading of the csv file
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        string[] fields = line.Split(',');



                        if (fields[8].StartsWith(shipname))     //If the ship name matches, the function increments a `passengers` counter and prints out the first and last name of the passenger
                        {
                            passengers++;
                            string firstname = fields[0];
                            string lastname = fields[1];


                            Console.WriteLine("Last Name: " + lastname + " " + "First Name: " + firstname);
                        }
                    }
                    Console.WriteLine("Number of Passengers: " + passengers);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file linked could not be found.");
            }
        }
        static private void occupation()    // This method calls the method readingoccupation with several string arguments representing occupations.
        {
            readingoccupation("Spinster");
            readingoccupation("Cultivator or Farmer");
            readingoccupation("Matron");
            readingoccupation("Laborer (Ital. 'operaia') or Workman/Woman");
            readingoccupation("Child");
            readingoccupation("Dressmaker");
            readingoccupation("Fisher Man");
            readingoccupation("None");
            readingoccupation("Chamber Maid or Maid or Servant");
            readingoccupation("Smith");
            readingoccupation("Mason");
            readingoccupation("Baker or Macaroni Maker");
            readingoccupation("Tanner or Gerber");
            readingoccupation("Carpenter");
            readingoccupation("Infant");
            readingoccupation("Student");
            readingoccupation("Coachman/Coach Driver or Driver");
            readingoccupation("Saddler");
            readingoccupation("Clerk");
            readingoccupation("Immigrant");
            readingoccupation("Undefined Code");

        }
        // The 'readingoccupation' method reads the csv file and prints the names and number of passengers with the given occupation.
        static private void readingoccupation(string job)
        {
            int count = 0;
            try
            {
                string filePath = @"../../../faminefile.csv"; // specify the csv file path
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // loop through each line in the csv file
                    while (!sr.EndOfStream)
                    {
                        // read a line and split it into fields
                        string line = sr.ReadLine();
                        string[] fields = line.Split(',');

                        // check if the 'Occupation' field contains the given job
                        if (fields[4].Contains(job))
                        {
                            count++; // increment count
                        }
                    }
                    Console.WriteLine(job + ":" + count); // print the job and the count
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file linked could not be found.");
            }
        }

        // The 'readage' method reads the csv file and categorizes the passengers based on age, then prints the age categories and their counts.
        static private void readage()
        {
            try
            {
                string filePath = @"../../../faminefile.csv"; // specify the csv file path
                var ageCategories = new Dictionary<string, int>()
                {
                    {"Infants (<1 year)", 0},
                    {"Children (1-12)", 0},
                    {"Teenage (12-19)", 0},
                    {"Young Adult (20-29)", 0},
                    {"Adult (30+)", 0},
                    {"Older Adult (50+)", 0},
                    {"Unknown", 0}
                };

                using (StreamReader sr = new StreamReader(filePath))
                {
                    // loop through each line in the csv file
                    while (!sr.EndOfStream)
                    {
                        // read a line and split it into fields
                        string line = sr.ReadLine();
                        string[] fields = line.Split(',');

                        // check if the 'Age' field is valid
                        if (fields.Length >= 3)
                        {
                            string ageremove = fields[2].Trim().Substring(3);
                            if (ageremove.ToLower().Contains("months"))
                            {
                                ageCategories["Infants (<1 year)"]++;
                            }
                            else
                            {
                                int age;
                                bool isValid = int.TryParse(ageremove, out age);
                                if (isValid)
                                {
                                    if (age >= 1 && age < 12)
                                    {
                                        ageCategories["Children (1-12)"]++;
                                    }
                                    else if (age >= 13 && age <= 19)
                                    {
                                        ageCategories["Teenage (12-19)"]++;
                                    }
                                    else if (age >= 20 && age <= 29)
                                    {
                                        ageCategories["Young Adult (20-29)"]++;
                                    }
                                    else if (age >= 30 && age <= 49)
                                    {
                                        ageCategories["Adult (30+)"]++;
                                    }
                                    else if (age >= 50)
                                    {
                                        ageCategories["Older Adult (50+)"]++;
                                    }
                                }
                                else
                                {
                                    ageCategories["Unknown"]++;
                                }
                            }
                        }
                    }
                }

                // print the age categories and their counts
                Console.WriteLine("Age Reports");
                foreach (KeyValuePair<string, int> ageCategory in ageCategories)
                {
                    Console.WriteLine($"{ageCategory.Key} : {ageCategory.Value}");
                }

                Console.ReadKey(); // wait for a key press before exiting
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file linked could not be found.");
            }
        }

    }
}
