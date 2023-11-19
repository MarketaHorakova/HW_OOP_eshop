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

            foreach (var line in lines)
            {
                string[] oneItem = line.Split(',');

                int idToFind = int.Parse(oneItem[1]);
                int piecesToStorage = int.Parse(oneItem[3])+piecesToStock;
          
                if (id == idToFind)
                {
                    oneItem[3] = piecesToStorage.ToString();
                }
                
            }
            //PiecesOnStock += piecesToStock;
        }

    }
}
