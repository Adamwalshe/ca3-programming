using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ca3_programming
{
    internal class Menu //allows the user to select an option from a list of options.
    {
        public string[] Options { get; set; }
        
        public Menu(string[] options)       //a constructor that takes an array of strings as input, representing the available options.
        {
            Options = options;
        }
        public int GetChoice()  //The GetChoice method is called to display the list of options and prompt the user for their selection.
        {
            int choice;
            string input;
            do
            {
                for (int i = 0; i < Options.Length; i++)
                {
                    Console.WriteLine($"{i + 1} for {Options[i]}");
                }
                input = Console.ReadLine();
            }

            while (!(int.TryParse(input, out choice) && choice > 0 && choice <= Options.Length));
            return choice;
        }
    }
}
