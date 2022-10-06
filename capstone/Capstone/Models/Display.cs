using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Display
    {
        //create a "main menu" method
        //create a "purchase menu" method
        //create text scripting for each choice
        Attribute 
        int choiceFromMainMenu = 0;
        public string SelectedItem { get; private set; }


        public string Start() //read file; display all items; pick item; pay item 
        {
            //read the inventory text file:
            // set choiceFromMainMenu to 0
            //call MainMenu()

        }

        public string Update()
        {

        }

        public string Exit()
        {

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
            choiceFromMainMenu = int.Parse(Console.ReadLine());
            // here the readline will create a variable that parses to be our choice
            //1 dispaly items
            //2 make purchase
            //3 exit
        }

    }
}
