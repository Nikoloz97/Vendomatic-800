using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        string choiceFromMainMenu = "";
        public void Start() //; pick item; pay item 
        {
            Inventory inventory = new Inventory();
            inventory.LoadInventory();
            MainMenu();




        }

        //public string Update()
        //{
            
        //}

        public void Exit()
        {
            Console.WriteLine("Thank you for using Vend-O-Matic 800!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        public void MainMenu()
        {
            Console.WriteLine("***   Vend-O-Matic   ***");
            Console.WriteLine("***                  ***");
            Console.WriteLine("Welcome To The Main Menu");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Enter 1 to display available snacks");
            Console.WriteLine("Enter 2 to make a purchase");
            Console.WriteLine("Enter 3 to exit Vend-O-Matic");
            choiceFromMainMenu = (Console.ReadLine());
            if (choiceFromMainMenu == "1")
            {

            }
            if (choiceFromMainMenu == "2")
            {
                PurchaseMenu();
            }
            if (choiceFromMainMenu == "3")
            {
                Exit();//call exit method
            }
            
            //1 dispaly items
            //2 make purchase
            //3 exit
        }
        public void PurchaseMenu()
        {
            
        }
        //public void 
       // public void UpdateDisplay()


    }
}
