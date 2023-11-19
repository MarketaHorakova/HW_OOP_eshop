using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_OOP_eshop
{
    public class Accessories : Clothing
    {
        public string TypeOfAccessories = ""; //Tie, BowTie, Handkerchief

        public Accessories (string classIdentify,string name, int piecesOnStock, double priceSell, double priceBuy,  string size, string colorMain, string material,bool discount,string typeOfAccessories) : base ("Accessories", name, piecesOnStock, priceSell, priceBuy, discount, size, colorMain, material)
        {
            TypeOfAccessories = typeOfAccessories;
        }
    }
}
