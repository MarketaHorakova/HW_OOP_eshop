using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_OOP_eshop
{
    public class Tshirt : Clothing
    {
        public int Length;
        public string TypeOfBowTie = "Circle shape"; //V shape
        public bool IsWithoutSleave = false;

        public Tshirt(string name, int piecesOnStock, double priceSell, double priceBuy, string size, string colorMain, string material, int length, string typeOfBowTie, bool isWithoutSleave) : base(name, piecesOnStock, priceSell, priceBuy, false, size, colorMain, material)
        {
            Length = length;
            TypeOfBowTie = typeOfBowTie;
            IsWithoutSleave = isWithoutSleave;
        }
    }
}
