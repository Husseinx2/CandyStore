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
        private decimal SubTotal { get; set; } = 0.0m;

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
        public List<Candy> ShowInventory()
        {
            return candies;
        }
        public void GetInventory()
        {
            candies = filehandler.ReadInventory();
        }

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
    }
}

