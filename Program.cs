using HW_OOP_eshop;

string pathStorage = "C:\\Users\\marketa.zemlova\\Visual Studio 2023\\C sharp 2\\HW_OOP_eshop\\Storage.txt";


List<Clothing> skrin = new List<Clothing>();

bool isOver = false;

while (!isOver)
{
    //Menu
    Console.WriteLine("Menu:\n" +
        "0 - Konec\n" +
        "1 - Pridej položku\n" +
        "2 - Naskladni polozky \n" +
        "3 - Prodej položek\n" +
        "4 - Vymaž položku ze souborů\n" +
        "5 - Zapis do souboru\n" +
        "6 - Inventura");
    int.TryParse(Console.ReadLine(), out int choosenNumberMenu);

    switch (choosenNumberMenu)
    {
        //End
        case 0:
            isOver = true;
            break;
        //Pridani polozky
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
            bool discount = false;
            
            string textFromFile = File.ReadAllText(pathStorage);
            string[] lines = textFromFile.Split('\n');
            int i = lines.Length;

            switch (choosenNumberItem)
            {
                case 0:
                    //skrin.Add(new Tshirt("Tshirt",nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 95, "V shape", true));
                    File.AppendAllText(pathStorage, $"\n{"Tshirt"},{i},{nameInput},{piecesToStorage},{priceSell},{priceBuy},{discount},{size},{color},{material}");
                    break;
                case 1:
                    //skrin.Add(new Shirt("Shirt",nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 105, true));
                    File.AppendAllText(pathStorage, $"\n{"Tshirt"},{i},{nameInput},{piecesToStorage},{priceSell},{priceBuy},{discount},{size},{color},{material}");
                    break;
                case 2:
                    //skrin.Add(new Accessories("Accessories",nameInput, piecesToStorage, priceSell, priceBuy,  size, color, material,false, "Tie"));                    
                    File.AppendAllText(pathStorage, $"\n{"Accessories"},{i},{nameInput},{piecesToStorage},{priceSell},{priceBuy},{discount},{size},{color},{material}");
                    break;
            }

            break;
        //Naskladneni polozky
        case 2:
            Console.WriteLine("Id polozky pro pridani: ");
            int.TryParse(Console.ReadLine(), out int idToStorage);
            Console.WriteLine("Pocet polozek pro naskladneni: ");
            int.TryParse(Console.ReadLine(), out int toStorage);
            skrin[idToStorage].ToStock(pathStorage, idToStorage, toStorage);
            break;
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

        //        break;
        
        // Zapis do souboru
        case 5:
            i = 0;
            File.Delete(pathStorage);

            foreach (var item in skrin)
            {
                switch (item.ClassIdentify)
                {
                    case "Tshirt":
                        if (!File.Exists(pathStorage))
                        {
                            File.AppendAllText(pathStorage, $"{"Tshirt"},{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
                        }
                        else
                        {
                            File.AppendAllText(pathStorage, $"\n{"Tshirt"},{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
                        }                        
                        break;
                    case "Shirt":
                        if (!File.Exists(pathStorage))
                        {
                            File.AppendAllText(pathStorage, $"{"Shirt"},{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
                        }
                        else
                        {
                            File.AppendAllText(pathStorage, $"\n{"Shirt"},{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
                        }
                        break;
                    case "Accessories":
                        if (!File.Exists(pathStorage))
                        {
                            File.AppendAllText(pathStorage, $"{"Accessories"},{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
                        }
                        else
                        {
                            File.AppendAllText(pathStorage, $"\n{"Accessories"},{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
                        }
                        break;
                }
                i++;
            }
            break;
        // Inventura
        case 6:
            //nacteni ze souboru
            textFromFile = File.ReadAllText(pathStorage);
            lines = textFromFile.Split('\n');

            foreach (var line in lines)
            {
                string[] oneItem = line.Split(',');

                id = int.Parse(oneItem[1]);
                nameInput = oneItem[2];
                piecesToStorage = int.Parse(oneItem[3]);
                priceSell = double.Parse(oneItem[4]);
                priceBuy = double.Parse(oneItem[5]);
                discount = bool.Parse(oneItem[6]);
                size = oneItem[7];
                color = oneItem[8];
                material = oneItem[9];

                switch (oneItem[0])
                {
                    case "Tshirt":
                        skrin.Add(new Tshirt("Tshirt", nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 95, "V shape", true));
                        break;
                    case "Shirt":
                        skrin.Add(new Shirt("Shirt", nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 105, true));
                        break;
                    case "Accessories":
                        skrin.Add(new Accessories("Accessories", nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, false, "Tie"));
                        break;
                }
            }

            // Vypis do konzole
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
