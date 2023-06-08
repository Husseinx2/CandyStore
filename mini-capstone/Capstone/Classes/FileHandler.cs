using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileHandler
    {
        private string path = "C://Store//inventory.csv";
        public List<Candy> ReadInventory()
        {
            List<Candy> candies = new List<Candy>();
            try
            {           
                using(StreamReader sr = new StreamReader(path))
                {
                    while(!sr.EndOfStream)
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
    }
}
