using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_OOP_eshop
{
    public class Clothing
    {
        public float Id;
        public string Name = "";
        public int PiecesOnStock;
        public double PriceSell;
        public double PriceBuy;
        public bool Discount = false;
        public string Size = "";
        public string ColorMain = "";
        public string Material = "";
        public double TotalPrice = 0;
        
        public Clothing(float id, string name, int piecesOnStock, double priceSell, double priceBuy, bool discount, string size, string colorMain, string material)
        {
            Id = id;
            Name = name;
            PiecesOnStock = piecesOnStock;
            PriceSell = priceSell;
            PriceBuy = priceBuy;
            Discount = discount;
            Size = size;
            ColorMain = colorMain;
            Material = material;
                                  
        }
        //public void AddToFile (string pathToFile)
        //{
        //    Console.WriteLine("Kterou položku:\n" +
        //        "0 - Tričko pod košili\n" +
        //        "1 - Košili\n" +
        //        "2 - Příslušenství");
        //    int.TryParse(Console.ReadLine(), out int choosenNumberItem);
        //    Console.WriteLine("ID number: ");
        //    int.TryParse(Console.ReadLine(), out int iDNumber);
        //    Console.WriteLine("Nazev polozky");
        //    string nameInput = Console.ReadLine();
        //    Console.WriteLine("Pocet kusu: ");
        //    int.TryParse(Console.ReadLine(), out int piecesToStorage);
        //    Console.WriteLine("Kupni cena: ");
        //    double.TryParse(Console.ReadLine(), out double priceBuy);
        //    Console.WriteLine($"Prodejni cena ({priceBuy * 1.81}): ");
        //    double.TryParse(Console.ReadLine(), out double priceSell);
        //    Console.WriteLine("Velikost");
        //    string size = Console.ReadLine();
        //    Console.WriteLine("Barva");
        //    string color = Console.ReadLine();
        //    Console.WriteLine("Material");
        //    string material = Console.ReadLine();

        //    switch (choosenNumberItem)
        //    {
        //        case 0:
        //            skrin.Add(new Tshirt(iDNumber, nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 95, "V shape", true));
        //            break;
        //        case 1:
        //            skrin.Add(new Shirt(iDNumber, nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 105, true));
        //            break;
        //        case 2:
        //            skrin.Add(new Accessories(iDNumber, nameInput, piecesToStorage, priceSell, priceBuy, false, size, color, material, "Tie"));
        //            break;
        //    }
        //}


        public double Sell (float id, int piecesToSell)
        {
            Id = id;
            TotalPrice += piecesToSell * PriceSell;
            PiecesOnStock -= piecesToSell;
            return TotalPrice;
        }

        public void ToStock(float id, int piecesToStock)
        {
            PiecesOnStock += piecesToStock;

        }

    }
}
