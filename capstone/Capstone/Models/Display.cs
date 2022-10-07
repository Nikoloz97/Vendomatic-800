﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
/*using System.Linq.Expressions;
*/
/*using System.Reflection.PortableExecutable;
*/
namespace Capstone.Models
{
    public class Display
    {
        public Inventory CurrentInventory = new Inventory();

        private Payment CurrentPayment = new Payment();

        string choiceFromMainMenu = "";

        string upperUserInput = null;



        public void Start() //; pick item; pay item 
        {
            CurrentInventory.LoadInventory();
            MainMenu();




        }


        public void Exit()
        {
            //Clears previous data on the console
            Console.Clear();
            string message = ("Thank you for using Vend-O-Matic 800!");
            // Centers the message
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);

            Console.WriteLine(message);
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        public void MainMenu()
        {
            DisplayMainMenu();
            
            
            


            choiceFromMainMenu = (Console.ReadLine());
            if (choiceFromMainMenu == "1")
            {
                DisplayTempList();
            }
            if (choiceFromMainMenu == "2")
            {
                PurchaseMenu();
            }
            if (choiceFromMainMenu == "3")
            {
                Exit();//call exit method
            }
            
           
        }

        private void DisplayTempList()
        {
            Console.Clear();
            // Value = amount of characters space takes up (+ = start from right, - = start from left)
            Console.WriteLine($"{"Location",-10}{"Item",-20}{"Price",-8}{"Amount",-8}{"Type",-8}");
            foreach (var item in CurrentInventory.InventoryItems)
            {
                string SoldOut = (item.Value.Count == 0) ? "SoldOut" : "";
                Console.WriteLine($"{item.Key,-10}{item.Value.Name,-20}{item.Value.Price,-8:C}{item.Value.Count,-8}{item.Value.ItemType,-8}{SoldOut,-8}");
            }

            Console.WriteLine("\n \n Select item location (or 00 to go to the Main Menu:)");
            string userInout = Console.ReadLine();
            switch (userInout)
            {
                case "00":
                    MainMenu();
                    break;
                default:
                    break;
            }
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("***   Vend-O-Matic   ***");
            Console.WriteLine("***                  ***");
            Console.WriteLine("Welcome To The Main Menu");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
        }

        private void DisplayList()
        {
            Console.Clear();
            // Value = amount of characters space takes up (+ = start from right, - = start from left)
            Console.WriteLine($"{"Location",-10}{"Item",-20}{"Price",-8}{"Amount",-8}{"Type",-8}");
            foreach (var item in CurrentInventory.InventoryItems)
            {
                string SoldOut = (item.Value.Count == 0) ? "SoldOut" : "";
                Console.WriteLine($"{item.Key,-10}{item.Value.Name,-20}{item.Value.Price,-8:C}{item.Value.Count,-8}{item.Value.ItemType,-8}{SoldOut,-8}");
            }

            Console.WriteLine("\n \n Select item location (or 00 to go to the Main Menu:)");
             



        }

        public void PurchaseMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Purchase Menu");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Current Money Provided: {CurrentPayment.AmountPaid:C}");
            Console.WriteLine();

            if (upperUserInput != null)
            {
                DisplayMessage(CurrentInventory.InventoryItems[upperUserInput.ToUpper()]);
            }
            Console.WriteLine();

            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("(00) Return to Main Menu");

            
          
           string userInput = Console.ReadLine();



            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case "1":
                    {
                        CurrentPayment.IncreaseFeedMoney();
                        Log.WriteToLog($"{DateTime.Now } FEED MONEY {CurrentPayment.AmountPaid - 1,-6:C} {CurrentPayment.AmountPaid,-6:C} ");
                        PurchaseMenu();
                    }
                    break;
                case "2":
                    DisplayList();
                    upperUserInput = Console.ReadLine();
                    //verify choice is valid
                   if (Verify(upperUserInput.ToUpper())) 
                    {
                    
                    CurrentInventory.Dispense(upperUserInput.ToUpper());
                    DisplayMessage(CurrentInventory.InventoryItems[upperUserInput.ToUpper()]);
                        Log.WriteToLog($"{DateTime.Now }" +
                            $" {CurrentInventory.InventoryItems[upperUserInput.ToUpper()].Name}" +
                            $"{upperUserInput.ToUpper()} " +
                              $" {CurrentInventory.InventoryItems[upperUserInput.ToUpper()].Price,-6:C}" +
                            $" {CurrentPayment.AmountPaid,-6:C} ");
                        PurchaseMenu();
                    
                    }
                    else
                    {
                        Console.WriteLine($"\n oops,{CurrentInventory.InventoryItems[upperUserInput.ToUpper()].Name}  is sold out. Please select another item.");
                        Thread.Sleep(3000);
                        PurchaseMenu();
                    }
                    break;
                case "3":
                    break;
                case "00":
                    MainMenu();
                    break;
                default:
               //     throw new ArgumentException();
                    break;
            }
        }

        private bool Verify(string userInput)
        {
            if(CurrentInventory.InventoryItems.ContainsKey(userInput))
            {
                if (CurrentInventory.InventoryItems[userInput].Count > 0)
                {
                    UpdatingRemainingMoney(userInput);
                    return true;
                }
                else
                {
               
                    return false;

                }
            }
            else
            {
                return false;
            }
        }

        public void UpdatingRemainingMoney(string userInput)
        {
            if (CurrentPayment.ValidTransaction(CurrentPayment.AmountPaid, CurrentInventory.InventoryItems[userInput].Price))
            {
                CurrentPayment.DecreaseMoney(CurrentInventory.InventoryItems[userInput].Price);
            }
        }

        public void DisplayMessage(Item _item)
        {
            switch (_item.ItemType)
            {
                case "Chip":
                    Console.WriteLine($"{_item.Name } {_item.Price } Crunch Crunch, Yum!");
                    break;
                case "Candy":
                    Console.WriteLine($"{_item.Name } {_item.Price } Munch Munch, Yum!");
                    break;
                case "Drink":
                    Console.WriteLine($"{_item.Name } {_item.Price } Glug Glug, Yum!");
                    break;
                case "Gum":
                    Console.WriteLine($"{_item.Name } {_item.Price } Chew Chew, Yum!");
                    break;
                default:
                    break;

            }
            

        }

    }
}
