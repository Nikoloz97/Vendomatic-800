using System;
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
        //create a "main menu" method
        //create a "purchase menu" method
        //create text scripting for each choice
        // Attribute 
        //int choiceFromMainMenu = 0;
        //   public string SelectedItem { get; private set; }

        public Inventory CurrentInventory = new Inventory();

        private Payment CurrentPayment = new Payment();

        string choiceFromMainMenu = "";
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
                DisplayList();
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
            Console.WriteLine($"{"Location", -10}{"Item", -20}{"Price", -8}{"Amount", -8}{"Type", -8}");
            
            foreach (var item in CurrentInventory.InventoryItems)
            {
                string SoldOut = (item.Value.Count == 0) ? "SoldOut" : "";
                Console.WriteLine($"{item.Key, -10}{item.Value.Name, -20}{item.Value.Price, -8:C}{item.Value.Count, -8}{item.Value.ItemType, -8}{SoldOut, -8}");
            }

            Console.WriteLine("\n \n Select item location (or 00 to go to the Main Menu:)");
            string userInput = Console.ReadLine();
            if (userInput == "00")
            {
                MainMenu();
            }



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
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("(00) Return to Main Menu");

            string userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "1":
                    CurrentPayment.IncreaseFeedMoney();PurchaseMenu();
                    break;
                case "2":
                    DisplayList();
                    userInput = Console.ReadLine();
                    //verify choice is valid
                    Verify(userInput);
                    break;
                case "3":
                    break;
                case "00":
                    MainMenu();
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
            
            
            

        }

        private void Verify(string userInput)
        {
            if(CurrentInventory.InventoryItems.ContainsKey(userInput))
            {
                if (CurrentInventory.InventoryItems[userInput].Count > 0)
                {
                    UpdatingRemainingMoney();
                }
            }
        }

        public void UpdatingRemainingMoney()
        {
            CurrentPayment.AmountPaid -= 
        }

        


    }
}
