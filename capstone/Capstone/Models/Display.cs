using ConsoleAppUI;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;

namespace Capstone.Models
{
    public class Display
    {
        public Inventory CurrentInventory = new Inventory();
        private Payment CurrentPayment = new Payment();
        string choiceFromMainMenu = "";
        string upperUserInput = null;
        private bool _displayMsg = false;
        public void Start()
        {
            CurrentInventory.LoadInventory();
            MainMenu();
        }
        public void Exit()
        {
            //Clears previous data on the console
            Console.Clear();

            string[] Messeages = new string[] {
            "╔══════════════════════════════════════════════════════════════════════════╗",
            "║                                                                          ║",
            "║        ░▒▓█  ☺   Thank you for using Vend-O-Matic 800    ☺  █▓▒░         ║",
            "║                                                                          ║",
            "╚══════════════════════════════════════════════════════════════════════════╝"
            };
            Colored_Console.PrintCenter(Messeages);
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        public void MainMenu()
        {
        startOver:
            DisplayMainMenu();

            choiceFromMainMenu = (Console.ReadLine());
            switch (choiceFromMainMenu)
            {
                case "1": DisplayTempList(); break;
                case "2": PurchaseMenu(); break;
                case "3": WriteSalesReport();Exit();    break;
                default:
                    Console.Clear();
                    goto startOver;
            }
        }
        private void WriteSalesReport()
        {
            
            SalesReport.WriteItemsToSalesReport();
        }
        private void DisplayTempList()
        {
            Console.Clear();
             
            Console.WriteLine("\t╔═══════════════════════════════════════════════╗");
            Console.WriteLine("\t║        ►   Items in Vend-O-Matic   ◄          ║");
            Console.WriteLine("\t╚═══════════════════════════════════════════════╝\n");

            // Value = amount of characters space takes up (+ = start from right, - = start from left)
            string _header = $"\t{"Location",-10}{"Item",-20}{"Price",-8}{"Amount",-8}{"Type",-8}\n";
                              
            Colored_Console.PrintLine(_header, ConsoleColor.Yellow);
             
            foreach (var item in CurrentInventory.InventoryItems)
            {
                string SoldOut = (item.Value.Count == 0) ? "SoldOut" : "";
                if (SoldOut == "")
                {
                Console.WriteLine($"\t{item.Key,-10}{item.Value.Name,-20}{item.Value.Price,-8:C}{item.Value.Count,-8}{item.Value.ItemType,-8}{SoldOut,-8}");
                }
                else
                {
                Colored_Console.PrintLine($"\t{item.Key,-10}{item.Value.Name,-20}{item.Value.Price,-8:C}{item.Value.Count,-8}{item.Value.ItemType,-8}{SoldOut,-8}", ConsoleColor.Red);
                }
            }

            Colored_Console.PrintColoredList("\n\n press ESC key for main menu", ConsoleColor.Green, new int[] {9,10,11});

            ConsoleKeyInfo userInout = Console.ReadKey();
            Console.WriteLine(userInout);
            switch (userInout.KeyChar)
            {
                case (char)27:
                    Console.Clear();
                    MainMenu();
                    break;
                default:
                    DisplayTempList();
                    break;
            }
        }
        private void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║    ░▒▓    ►      Vend-O-Matic     ◄  ▓▒░      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("             Welcome To The Main Menu \n\n");
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine();
            Colored_Console.PrintColoredList("    (1) Display Vending Machine Items \n",ConsoleColor.Green,5);
            Colored_Console.PrintColoredList("    (2) Purchases \n", ConsoleColor.Green,5);
            Colored_Console.PrintColoredList("    (3) Exit \n", ConsoleColor.Green,5);
        }
        private void DisplayList()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║        ►   Items in Vend-O-Matic   ◄          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n \n");
            // Value = amount of characters space takes up (+ = start from right, - = start from left)
           
            string _header = $"\t{"Location",-10}{"Item",-20}{"Price",-8}{"Amount",-8}{"Type",-8}\n";

            Colored_Console.PrintLine(_header, ConsoleColor.Yellow);

            foreach (var item in CurrentInventory.InventoryItems)
            {
                string SoldOut = (item.Value.Count == 0) ? "SoldOut" : "";
                if (SoldOut == "")
                {
                    Console.WriteLine($"\t{item.Key,-10}{item.Value.Name,-20}{item.Value.Price,-8:C}{item.Value.Count,-8}{item.Value.ItemType,-8}{SoldOut,-8}");

                }
                else
                {

                    Colored_Console.PrintLine($"\t{item.Key,-10}{item.Value.Name,-20}{item.Value.Price,-8:C}{item.Value.Count,-8}{item.Value.ItemType,-8}{SoldOut,-8}", ConsoleColor.Red);
                }
            }

            Console.WriteLine("\n \n Select  item location (or 00 to go to the Main Menu:)");

        }
        public void PurchaseMenu()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║        ►       Purchase Menu       ◄          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");

            Console.Write($"\n\n Current Money Provided: ");
                Colored_Console.PrintLine($"{CurrentPayment.AmountPaid:C} \n\n",ConsoleColor.DarkYellow);
            
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("-----------------------------------------\n");

            if (_displayMsg)
            {
                DisplayYumMessage(CurrentInventory.InventoryItems[upperUserInput.ToUpper()]);
            }
           
            Console.WriteLine();

            Colored_Console.PrintColoredList(" (1) Feed Money\n", ConsoleColor.Green, 2);
            Colored_Console.PrintColoredList(" (2) Select Product\n", ConsoleColor.Green, 2);
            Colored_Console.PrintColoredList(" (3) Finish Transaction\n", ConsoleColor.Green, 2);
            Colored_Console.PrintColoredList(" (00) Return to Main Menu\n", ConsoleColor.Green, new int[] { 2, 3 });

            string userInput = Console.ReadLine();

            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case "1":
                    {
                        CurrentPayment.IncreaseFeedMoney();
                        Logger.WriteToLog($"{DateTime.Now} FEED MONEY {CurrentPayment.AmountPaid - 1,-6:C} {CurrentPayment.AmountPaid,-6:C} ");
                        PurchaseMenu();
                    }
                    break;
                case "2":
                    DisplayList();
                    upperUserInput =  Console.ReadLine();
                     
                    if(string.IsNullOrEmpty(upperUserInput))
                    {
                        goto case "2";
                    }
                    else if(!CurrentInventory.IsKeyExists(upperUserInput.ToUpper()))
                    {
                        goto case "2";

                    }

                    //verify choice is valid
                    if (Verify(upperUserInput.ToUpper()) && _displayMsg)
                    {
                        CurrentInventory.Dispense(upperUserInput.ToUpper());
                        DisplayYumMessage(CurrentInventory.InventoryItems[upperUserInput.ToUpper()]);
                        Logger.WriteToLog($"{DateTime.Now}" +
                            $" {CurrentInventory.InventoryItems[upperUserInput.ToUpper()].Name}" +
                            $"{upperUserInput.ToUpper()} " +
                              $" {CurrentInventory.InventoryItems[upperUserInput.ToUpper()].Price,-6:C}" +
                            $" {CurrentPayment.AmountPaid,-6:C} ");
                        PurchaseMenu();
                    }
                    else
                    {
                        Console.WriteLine($"\n oops, You can't purchase {CurrentInventory.InventoryItems[upperUserInput.ToUpper()].Name} Please select another item.");
                        Thread.Sleep(3000);
                        PurchaseMenu();
                    }
                    break;
                case "3":
                    Console.WriteLine("Dispensing Change");
                    Console.WriteLine(CurrentPayment.SmallestChange((int)((CurrentPayment.AmountPaid * 100))));
                    SalesReport.WriteItemsToSalesReport();
                    Thread.Sleep(3000);
                    
                    Exit();
                    break;
                case "00":
                    Console.Clear();
                    MainMenu();
                    break;
                default:
                    PurchaseMenu();
                    break;
            }
        }
        private bool Verify(string _userInput)
        {
            if (CurrentInventory.InventoryItems.ContainsKey(_userInput))
            {
                if (CurrentInventory.InventoryItems[_userInput].Count > 0)
                {
                    _displayMsg = true;
                    UpdatingRemainingMoney(_userInput);
                    return true;
                }
                else
                {
                    _displayMsg = false;
                    return false;
                }
            }
            else
            {
                _displayMsg = false;
                return false;
            }
        }
        public void UpdatingRemainingMoney(string userInput)
        {
            if (CurrentPayment.ValidTransaction(CurrentPayment.AmountPaid, CurrentInventory.InventoryItems[userInput].Price))
            {
                _displayMsg = true;
                CurrentPayment.DecreaseMoney(CurrentInventory.InventoryItems[userInput].Price);
            }
            else
            {
                _displayMsg = false;
            }
        }
        public void DisplayYumMessage(Item _item)
        {
            switch (_item.ItemType)
            {
                case "Chip": Console.WriteLine($"{_item.Name} {_item.Price} Crunch Crunch, Yum!"); break;
                case "Candy": Console.WriteLine($"{_item.Name} {_item.Price} Munch Munch, Yum!"); break;
                case "Drink": Console.WriteLine($"{_item.Name} {_item.Price} Glug Glug, Yum!"); break;
                case "Gum": Console.WriteLine($"{_item.Name} {_item.Price} Chew Chew, Yum!");  break;
                default: break;
            }
        }
    }
}
