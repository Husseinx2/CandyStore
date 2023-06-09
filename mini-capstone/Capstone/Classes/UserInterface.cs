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
            store.GetInventory();
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
                        AddMoney();
                        break;
                    case "2":
                        SelectProducts();
                        break;
                    case "3":
                        CompleteSale();
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Choose a valid option.");
                        break;
                }
            }
        }
        private void CompleteSale()
        {

            decimal change = store.GetMoney();
            string denominationsToGive = store.CompleteSale();
            List<Candy> candiesPurchased = store.GetShoppingCart();

            foreach (Candy candy in candiesPurchased)
            {
                string type = "";
                switch (candy.Id.Substring(0, 1))
                {
                    case "C":
                        type = "Chocolate Confectionery";
                        break;
                    case "L":
                        type = "Licorice";
                        break;
                    case "S":
                        type = "Sour Flavored Candies";
                        break;
                    case "H":
                        type = "Hard Tact Confectionery";
                        break;
                }
                Console.WriteLine($"{candy.Qty} {candy.Name} {type} {candy.Price:C2} {candy.Price * candy.Qty:C2}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total: {store.SubTotal:C2}");
            Console.WriteLine();
            Console.WriteLine($"Change: {change:C2}");
            Console.WriteLine(denominationsToGive);
        }

        private void SelectProducts()
        {
            ShowInventory();
            Console.Write("Enter Product Id: ");
            string productId = Console.ReadLine();
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine()); // Can't parse empty string
            bool isValid = store.SelectProducts(productId, quantity);
            if (!isValid)
            {
                Console.WriteLine(store.SelectProductFailMessage(productId, quantity));
            }
        }

        private void AddMoney()
        {
            Console.WriteLine("Enter Amount to Add");
            int money = int.Parse(Console.ReadLine());
            bool result = store.AddMoney(money);
            if (!result)
            {
                Console.WriteLine("Invalid entry, enter an Amount between 1 and 100");
            }

        }

        private void ShowInventory()
        {
            Console.WriteLine($"Id Name Wrapper Qty Price");
            List<Candy> candies = store.ShowInventory();
            foreach (Candy candy in candies)
            {
                string wrapper = "Y";
                if (!candy.Wrapper)
                {
                    wrapper = "N";
                }
                string quantity = $"{candy.Qty}";
                if (candy.Qty == 0)
                {
                    quantity = "SOLD OUT";
                }    
                Console.WriteLine($"{candy.Id} {candy.Name} {wrapper} {quantity} {candy.Price:C2}");
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("(1) Show Inventory\n(2) Make Sale\n(3) Quit");
        }

        public void DisplaySubMenu()
        {
            Console.WriteLine("(1) Take Money\n(2) Select Products\n(3) Complete Sale");
            Console.WriteLine($"Current Customer Balance: {store.GetMoney():C2}");
        }
    }
}
