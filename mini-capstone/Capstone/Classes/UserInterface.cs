using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Capstone.Classes
{
    class UserInterface
    {
        private Store store = new Store();

        /// <summary>
        /// Provides all communication with human user.
        /// 
        /// All Console.Readline() and Console.WriteLine() statements belong 
        /// in this class.
        /// 
        /// NO Console.Readline() and Console.WriteLine() statements should be 
        /// in any other class
        /// 
        /// </summary>
        public void Run()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Welcome to Silver Shamrock Candy Company");
                DisplayMainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowInventory();
                        break;
                    case "2":
                        MakeSale();
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Choose a valid option.");
                        break;
                }
            }
        }

        private void MakeSale()
        {
            bool done = false;

            while (!done)
            {
                DisplaySubMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Choose a valid option.");
                        break;
                }
            }
        }

        private void ShowInventory()
        {
            Console.WriteLine($"Id Name Wrapper Qty Price");
            List<Candy> candies = store.ShowInventory();
            foreach (Candy candy in candies)
            {
                Console.WriteLine($"{candy.Id} {candy.Name} {candy.Wrapper} {candy.Qty} {candy.Price:C2}");
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("(1) Show Inventory\n(2) Make Sale\n(3) Quit");
        }

        public void DisplaySubMenu()
        {
            Console.WriteLine("(1) Take Money\n(2) Select Products\n(3) Complete Sale");
            Console.WriteLine("Current Customer Balance: $0.00");
        }
    }
}
