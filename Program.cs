using HW_OOP_eshop;

string pathStorage = "C:\\Users\\marketa.zemlova\\Visual Studio 2023\\C sharp 2\\HW_OOP_eshop\\Storage.txt";


List<Clothing> skrin = new List<Clothing>();
skrin.Add(new Tshirt("Tricko telove", 0, 1350, 700, "S", "beige", "cotton", 95, "circle shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1350, 700, "M", "beige", "cotton", 98, "circle shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1350, 700, "L", "beige", "cotton", 102, "circle shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1350, 700, "XL", "beige", "cotton", 105, "circle shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1350, 700, "2XL", "beige", "cotton", 108, "circle shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1350, 700, "3XL", "beige", "cotton", 112, "circle shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1350, 700, "4XL", "beige", "cotton", 116, "circle shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1650, 900, "S", "beige", "polyester", 100, "V shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1650, 900, "M", "beige", "polyester", 100, "V shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1650, 900, "L", "beige", "polyester", 105, "V shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1650, 900, "XL", "beige", "polyester", 105, "V shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1650, 900, "2XL", "beige", "polyester", 110, "V shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1650, 900, "3XL", "beige", "polyester", 110, "V shape", true));
skrin.Add(new Tshirt("Tricko telove", 0, 1650, 900, "4XL", "beige", "polyester", 110, "V shape", true));
skrin.Add(new Shirt("Kosile bila", 0, 1090, 600, "XL", "white", "cotton", 105, true));
skrin.Add(new Shirt("Kosile ivory",0, 1450, 800, "XL", "ivory", "cotton", 110, true));

bool isOver = false;

while (!isOver)
{
    //Menu
    Console.WriteLine("Menu:\n" +
        "0 - Konec\n" +
        "1 - Pridej položku\n" +
        "2 - Vymaž položku ze souborů\n" +
        "3 - Prodej položek\n" +
        "4 - Naskladni polozky\n" +
        "5 - Zapis do souboru\n" +
        "6 - Nacteni ze souboru\n" +
        "7 - Inventura");
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
            Console.WriteLine("Zadej nazev polozky: ");
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
                    skrin.Add(new Tshirt(nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 95, "V shape", true));
                    
                    break;
                case 1:
                    skrin.Add(new Shirt(nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 105, true));
                    break;
                case 2:
                    skrin.Add(new Accessories(nameInput, piecesToStorage, priceSell, priceBuy, false, size, color, material, "Tie"));
                    break;
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
        //Prodej polozek
        case 3:
            Console.WriteLine("Zadej ID polozky:");
            int.TryParse(Console.ReadLine(), out int id);
            Console.WriteLine("Zadej pocet prodanych kusu:");
            int.TryParse(Console.ReadLine(), out int quantity);

            Console.WriteLine(skrin[id].Sell(id, quantity));
            break;


        //    // Vymazani polozky ze souboru
        //    case 4:
        //        string output = JsonConvert.SerializeObject(realDictionary);
        //        File.WriteAllText(pathJson, output);
        //        break;
        
        // Zapis do souboru
        case 5:
            int i = 0;
            foreach (var item in skrin)
            {
                File.AppendAllText(pathStorage,$"{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}\n");
                i++;
            }
            break;
        // Nacteni ze souboru
        case 6:
            i = 0;
            string textFromFile = File.ReadAllText(pathStorage);
            string[] lines = textFromFile.Split('\n');
                       
            foreach (var line in lines)
            {
                string[] oneItem = line.Split(',');
                id = int.Parse(oneItem[0]);
                 //////

                i++;
            }
            
            break;
        // Inventura
        case 7:
            i = 0;
            Console.WriteLine("ID, Nazev, Na sklade, Kupni cena, Prodejni cena, Sleva, Velikost, Hlavni barva, Material");
            foreach (var item in skrin)
            {
                Console.WriteLine($"{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
                i++;
            }

            break;
    }

}
