using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileHandler
    {
        private string inventoryPath = "C://Store//inventory.csv";
        private string logPath = "C://Store//Log.txt";
        private string totalSalesReportPath = "C://Store//TotalSales.rpt";
        public List<Candy> ReadInventory()
        {
            List<Candy> candies = new List<Candy>();
            try
            {
                using (StreamReader sr = new StreamReader(inventoryPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] temp = line.Split("|");
                        bool wrapper = false;
                        if (temp[4] == "T")
                        {
                            wrapper = true;
                        }
                        Candy candy = new Candy(temp[0], temp[1], temp[2], decimal.Parse(temp[3]), wrapper);
                        candies.Add(candy);
                    }
                }
            }
            catch (IOException)
            {
                return new List<Candy>();
            }
            return candies;
        }

        public void Log(string message)
        {

            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{DateTime.Now} {message}");
                }
            }
            catch (IOException)
            {

            }
        }

        // Total sales report
        public void TotalSalesReport(List<Candy> purchasedCandies)
        {
            List<Candy> candies = new List<Candy>();
            try
            {
                // Reading report
                using (StreamReader sr = new StreamReader(totalSalesReportPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("|"))
                        {
                            string[] temp = line.Split("|");
                            Candy candy = new Candy("",temp[0], temp[1], decimal.Parse(temp[3].Substring(1))/ int.Parse(temp[2]), false);
                            candy.Qty = int.Parse(temp[2]);                
                            candies.Add(candy);
                        }
                    }
                }
            }
            catch (IOException)
            {

            }
            // Writing report
            try
            {
                using (StreamWriter sw = new StreamWriter(totalSalesReportPath, false))
                {
                   
                    foreach (Candy purchasedCandy in purchasedCandies)
                    {
                        bool isNotThere = false;
                        if (candies.Count != 0)
                        {
                            foreach (Candy reportedCandy in candies)
                            {
                                if (purchasedCandy.Id == reportedCandy.Id)
                                {
                                    reportedCandy.Qty += purchasedCandy.Qty;
                                }
                                else
                                {
                                    isNotThere = true;
                                }
                               
                            }
                            if (isNotThere)
                            {
                                candies.Add(purchasedCandy);
                            }
                        }
                        else
                        {
                            candies.Add(purchasedCandy);
                        }

                    }

                    decimal total = 0;
                    foreach (Candy candy in candies)
                    {
                        total += (candy.Price * candy.Qty);
                        sw.WriteLine($"{candy.Id}|{candy.Name}|{candy.Qty}|{candy.Price * candy.Qty:C2}");
                    }
                    sw.WriteLine();
                    sw.WriteLine($"**TOTAL SALES**  {total:C2}");
                }
            }
            catch (IOException)
            {

            }


        }
    }
}
