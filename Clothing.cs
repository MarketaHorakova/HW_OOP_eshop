using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_OOP_eshop
{
    public class Clothing
    {
        public int ID;
        public string ClassIdentify;
        public string Name = "";
        public int PiecesOnStock;
        public double PriceSell;
        public double PriceBuy;
        public bool Discount = false;
        public string Size = "";
        public string ColorMain = "";
        public string Material = "";
        public double TotalPrice = 0;
        
        public Clothing(string classIdentify, string name, int piecesOnStock, double priceSell, double priceBuy, bool discount, string size, string colorMain, string material)
        {
            ClassIdentify = classIdentify;
            Name = name;
            PiecesOnStock = piecesOnStock;
            PriceSell = priceSell;
            PriceBuy = priceBuy;
            Discount = discount;
            Size = size;
            ColorMain = colorMain;
            Material = material;
                                  
        }
        

        public double Sell (int id, int piecesToSell)
        {
            ID = id;
            TotalPrice += (piecesToSell * PriceSell);
            PiecesOnStock -= piecesToSell;
            return TotalPrice;
        }

        public void ToStock(string path, int id, int piecesToStock)
        {
            string textFromFile = File.ReadAllText(path);
            string[] lines = textFromFile.Split('\n');

            foreach (string line in lines)
            {
                string[] oneItem = line.Split(',');
             
                int idToFind = int.Parse(oneItem[1]);
                int piecesToStorage = int.Parse(oneItem[3])+piecesToStock;
                using (StreamWriter sw = File.AppendText(path))
                {
                    if (id == idToFind)
                    {
                        oneItem[3] = piecesToStorage.ToString();
                        string newLine = string.Join(',', oneItem[0], oneItem[1], oneItem[2], oneItem[3], oneItem[4], oneItem[5], oneItem[6], oneItem[7], oneItem[8], oneItem[9]);
                        Console.WriteLine(newLine);
                        sw.WriteLine(newLine);

                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                }
                
            }
    
            File.Delete(path);

            foreach (var line in lines)
            {
                if (!File.Exists(path))
                {
                    File.AppendAllText(path, line);
                }
                else
                {
                    File.AppendAllText(path, $"\n{line}");
                }

            }
        }             

    }
}
