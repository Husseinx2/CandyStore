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
        private decimal Money { get; set; } = 0.0M;

        public bool AddMoney(int money)
        {
            bool result = false;
            if (money > 0 && money <= 100)
            {
                if ((Money + money) < 1000 )
                Money += money;
                result = true;
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
          candies =  filehandler.ReadInventory();
        }
    }
}
