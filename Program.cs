using HW_OOP_eshop;

string pathStorage = "C:\\Users\\marketa.zemlova\\Visual Studio 2023\\C sharp 2\\HW_OOP_eshop\\Storage.txt";
//string pathDescription = "C:\\Users\\marketa.zemlova\\Visual Studio 2023\\C sharp 2\\HW_OOP_eshop\\Description.txt";

Clothing kabatXL = new Clothing (00015, "Coat", 0, 8999.99, 6000, false, "XL", "black", "polyester");

Tshirt trikoS = new Tshirt(00022,"Tricko telove",0, 999.9, 700 ,"S", "beige", "cotton", 95, "V shape", true);

List<Clothing> skrin = new List<Clothing>();
skrin.Add(kabatXL);
skrin.Add(trikoS);
skrin.Add(new Shirt(00023,"Kosile bila", 0, 899.9, 600, "XL", "white", "cotton", 105, true));
skrin.Add(new Shirt(00024, "Kosile ivory",0, 919.9, 800, "XL", "ivory", "cotton", 110, true));

bool isOver = false;

while (!isOver)
{
    //Menu
    Console.WriteLine("Menu:\n" +
        "0 - Konec\n" +
        "1 - Pridej položku\n" +
        "2 - Prodej položek\n" +
        "3 - Vymaž položku ze souborů\n" +
        "4 - Naskladni polozku\n" +
        "5 - Inventura");
    int.TryParse(Console.ReadLine(), out int choosenNumberMenu);

    switch (choosenNumberMenu)
    {
        //End
        case 0:
            isOver = true;
            break;
        //Dictionary to console
        case 1:
            Console.WriteLine("Kterou položku:\n" +
                 "0 - Tričko pod košili\n" +
                 "1 - Košili\n" +
                 "2 - Příslušenství");
            int.TryParse(Console.ReadLine(), out int choosenNumberItem);
            Console.WriteLine("ID number: ");
            int.TryParse(Console.ReadLine(), out int iDNumber);
            Console.WriteLine("Nazev polozky");
            string nameInput = Console.ReadLine();
            Console.WriteLine("Pocet kusu: ");
            int.TryParse(Console.ReadLine(), out int piecesToStorage);
            Console.WriteLine("Kupni cena: ");
            double.TryParse(Console.ReadLine(), out double priceBuy);
            Console.WriteLine($"Prodejni cena ({priceBuy * 1.81}): ");
            double.TryParse(Console.ReadLine(), out double priceSell);
            Console.WriteLine("Velikost");
            string size = Console.ReadLine();
            Console.WriteLine("Barva");
            string color = Console.ReadLine();
            Console.WriteLine("Material");
            string material = Console.ReadLine();

            switch (choosenNumberItem)
            {
                case 0:
                    skrin.Add(new Tshirt(iDNumber, nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 95, "V shape", true));
                    
                    break;
                case 1:
                    skrin.Add(new Shirt(iDNumber, nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 105, true));
                    break;
                case 2:
                    skrin.Add(new Accessories(iDNumber, nameInput, piecesToStorage, priceSell, priceBuy, false, size, color, material, "Tie"));
                    break;
            }
            foreach (var item in skrin)
            {
                File.AppendAllLines(pathStorage,skrin.item.Id);
            }
            break;
            //Naskladneni polozky
            //    case 2:
            //        Console.WriteLine("Napiš anglický výraz:");
            //        string addKey = Console.ReadLine();
            //        Console.WriteLine("Napiš význam:");
            //        string addValue = Console.ReadLine();
            //        if ((addKey != null) && (addValue != null))
            //        {
            //            realDictionary.Add(addKey, addValue);
            //        }
            //        break;
            //    //Prodej polozek
            //    case 3:
            //        Console.WriteLine("Napiš anglický výraz pro vymazání:");
            //        string removeKey = Console.ReadLine();
            //        realDictionary.Remove(removeKey);
            //        break;


            //    // Vymazani polozky ze souboru
            //    case 4:
            //        string output = JsonConvert.SerializeObject(realDictionary);
            //        File.WriteAllText(pathJson, output);
            //        break;

            //    // Inventura
            //    case 5:
            //        //input = File.ReadAllText(pathJson);
            //        realDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);



            //        break;
            //}
    }


    foreach (var clothing in skrin)
    {
        Console.WriteLine(clothing.Name);
        Console.WriteLine(clothing.PriceSell);
    }

    Console.ReadLine();
}
