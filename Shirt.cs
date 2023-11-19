using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_OOP_eshop
{
    public class Shirt : Clothing 
    {
        public int Length;
        public bool IsClassicCollar = true;
        public bool IslongSleave = true;

        public Shirt(string classIdentify, string name, int piecesOnStock, double priceSell, double priceBuy, string size, string colorMain, string material, int length, bool typeOfCollar) : base ("Shirt", name, piecesOnStock, priceSell, priceBuy, false, size, colorMain, material)
        {
            Length = length;
            IsClassicCollar = typeOfCollar;
            
        }
    }
}
