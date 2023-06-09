using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Most of the "work" (the data and the methods) of dealing with inventory and money 
    /// should be created or controlled from this class
    /// </summary>
    public class Store
    {
        private FileHandler filehandler = new FileHandler();
        List<Candy> candies = new List<Candy>();
        List<Candy> shoppingCart = new List<Candy>();
        private decimal Money { get; set; } = 0.0M;
        public decimal SubTotal { get; private set; } = 0.0m;


        // Money handling
        public bool AddMoney(int money)
        {
            bool result = false;
            if (money > 0 && money <= 100)
            {
                if ((Money + money) < 1000)
                {
                    Money += money;
                    result = true;
                    filehandler.Log($"MONEY RECEIVED: {money:C2} {Money:C2}");
                }
            }
            return result;
        }
        public decimal GetMoney()
        {
            return Money;
        }

        // Inventory
        public List<Candy> ShowInventory()
        {
            return candies;
        }
        public void GetInventory()
        {
            candies = filehandler.ReadInventory();
        }

        // Product selection and management
        public bool SelectProducts(string selection, int quantity)
        {
            bool result = false;
            foreach (Candy candy in candies)
            {
                if (candy.Id == selection.ToUpper())
                {
                    if (Money >= (candy.Price * quantity) && quantity <= candy.Qty)
                    {
                        Candy selectedCandy = new Candy(candy.Type, candy.Id, candy.Name, candy.Price, candy.Wrapper);
                        selectedCandy.Qty = quantity;
                        candy.Qty -= quantity;
                        shoppingCart.Add(selectedCandy);
                        SubTotal = (candy.Price * quantity);
                        Money -= (candy.Price * quantity);
                        result = true;
                        filehandler.Log($"{quantity} {selectedCandy.Name} {selection} {candy.Price * quantity:C2} {Money:C2}");
                    }
                }
            }

            return result;
        }
        public string SelectProductFailMessage(string productId, int quantity)
        {
           
            foreach (Candy candy in candies)
            {
                if (candy.Id == productId.ToUpper())
                {
                    
                     if (candy.Qty == 0)
                    {
                        return "Item out of stock";
                    }
                    else if (quantity >= candy.Qty)
                    {
                        return "Insufficent stock";
                    }
                    else if (Money < (candy.Price * quantity))
                    {
                        return "Insufficent funds";
                    }

                }
            }
            return "ID not Found";
        }

        // Sale completion
        public string CompleteSale()
        {
            const decimal Twenty = 20.00M;
            const decimal Ten = 10.00M;
            const decimal Five = 5.00M;
            const decimal One = 1.00M;
            const decimal Quarter = 0.25M;
            const decimal Dime = 0.10M;
            const decimal Nickel = 0.05M;

            string result = "";

            while (Money > 0.00M)
            {
                if (Money >= Twenty)
                {
                    int numberOf = (int)(Money / Twenty);
                    Money -= numberOf * Twenty;
                    result += "(" + numberOf + ")" + "Twent" + (numberOf == 1 ? "y" : "ies") + " ";
                }
                else if (Money >= Ten)
                {
                    int numberOf = (int)(Money / Ten);
                    Money -= numberOf * Ten;
                    result += "(" + numberOf + ")" + "Ten" + (numberOf == 1 ? "" : "s") + " ";
                }
                else if (Money >= Five)
                {
                    int numberOf = (int)(Money / Five);
                    Money -= numberOf * Five;
                    result += "(" + numberOf + ")" + "Five" + (numberOf == 1 ? "" : "s") + " ";
                }
                else if (Money >= One)
                {
                    int numberOf = (int)(Money / One);
                    Money -= numberOf * One;
                    result += "(" + numberOf + ")" + "One" + (numberOf == 1 ? "" : "s") + " ";
                }
                else if (Money >= Quarter)
                {
                    int numberOf = (int)(Money / Quarter);
                    Money -= numberOf * Quarter;
                    result += "(" + numberOf + ")" + "Quarter" + (numberOf == 1 ? "" : "s") + " ";
                }
                else if (Money >= Dime)
                {
                    int numberOf = (int)(Money / Dime);
                    Money -= numberOf * Dime;
                    result += "(" + numberOf + ")" + "Dime" + (numberOf == 1 ? "" : "s") + " ";
                }
                else if (Money >= Nickel)
                {
                    int numberOf = (int)(Money / Nickel);
                    Money -= numberOf * Nickel;
                    result += "(" + numberOf + ")" + "Nickel" + (numberOf == 1 ? "" : "s") + " ";
                }
            }
            return result;
        }

        public List<Candy> GetShoppingCart()
        {
            return shoppingCart;
        }
    }
}

