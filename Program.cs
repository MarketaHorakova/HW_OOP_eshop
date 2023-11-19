using HW_OOP_eshop;

string pathStorage = "C:\\Users\\marketa.zemlova\\Visual Studio 2023\\C sharp 2\\HW_OOP_eshop\\Storage.txt";


List<Clothing> skrin = new List<Clothing>();
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1350, 700, "S", "beige", "cotton", 95, "circle shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1350, 700, "M", "beige", "cotton", 98, "circle shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1350, 700, "L", "beige", "cotton", 102, "circle shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1350, 700, "XL", "beige", "cotton", 105, "circle shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1350, 700, "2XL", "beige", "cotton", 108, "circle shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1350, 700, "3XL", "beige", "cotton", 112, "circle shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1350, 700, "4XL", "beige", "cotton", 116, "circle shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1650, 900, "S", "beige", "polyester", 100, "V shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1650, 900, "M", "beige", "polyester", 100, "V shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1650, 900, "L", "beige", "polyester", 105, "V shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1650, 900, "XL", "beige", "polyester", 105, "V shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1650, 900, "2XL", "beige", "polyester", 110, "V shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1650, 900, "3XL", "beige", "polyester", 110, "V shape", true));
skrin.Add(new Tshirt("Tshirt", "Tricko telove", 0, 1650, 900, "4XL", "beige", "polyester", 110, "V shape", true));
skrin.Add(new Shirt("Shirt", "Kosile bila", 0, 1090, 600, "XL", "white", "cotton", 105, true));
skrin.Add(new Shirt("Shirt", "Kosile ivory",0, 1450, 800, "XL", "ivory", "cotton", 110, true));

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
            bool discount = false;
            

            switch (choosenNumberItem)
            {
                case 0:
                    skrin.Add(new Tshirt("Tshirt",nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 95, "V shape", true));                   
                    break;
                case 1:
                    skrin.Add(new Shirt("Shirt",nameInput, piecesToStorage, priceSell, priceBuy, size, color, material, 105, true));                    
                    break;
                case 2:
                    skrin.Add(new Accessories("Accessories",nameInput, piecesToStorage, priceSell, priceBuy,  size, color, material,false, "Tie"));                    
                    break;
            }

            break;
        //Naskladneni polozky
        //    case 2:

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

        //        break;
        
        // Zapis do souboru
        case 5:
            int i = 0;
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
        // Nacteni ze souboru
        case 6:
            string textFromFile = File.ReadAllText(pathStorage);
            string[] lines = textFromFile.Split('\n');
                       
            foreach (var line in lines)
            {
                string[] oneItem = line.Split(',');

                Console.WriteLine($"index 0: {oneItem[0]}");
                Console.WriteLine($"index 1: {oneItem[1]}");
                Console.WriteLine($"index 2: {oneItem[2]}");
                Console.WriteLine($"index 3: {oneItem[3]}");
                Console.WriteLine($"index 4: {oneItem[4]}");
                Console.WriteLine($"index 5: {oneItem[5]}");
                Console.WriteLine($"index 6: {oneItem[6]}");
                Console.WriteLine($"index 7: {oneItem[7]}");
                Console.WriteLine($"index 8: {oneItem[8]}");
                Console.WriteLine($"index 9: {oneItem[9]}");

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

            i = 0;
            Console.WriteLine("ID, Nazev, Na sklade, Kupni cena, Prodejni cena, Sleva, Velikost, Hlavni barva, Material");
            foreach (var item in skrin)
            {
                Console.WriteLine($"{i},{skrin[i].Name},{skrin[i].PiecesOnStock},{skrin[i].PriceSell},{skrin[i].PriceBuy},{skrin[i].Discount},{skrin[i].Size},{skrin[i].ColorMain},{skrin[i].Material}");
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
