using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Models
{
   public class Inventory
    {
        public Dictionary<string, Item> InventoryItems = new Dictionary<string, Item>();
        
        
        public string Location { get; private set; }


        public void LoadInventory()
        {
            
            string fileName = @"C: \Users\Student\git\c - sharp - minicapstonemodule1 - team0\capstone\vendingmachine.csv";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    
                    string[] itemArray = line.Split("|");

                    Item item = new Item();

                    item.Name = itemArray[1];
                    item.Price = decimal.Parse(itemArray[2]);
                    item.ItemType = itemArray[3];
                    InventoryItems.Add(itemArray[0], item);
                    item.Count = 5;
                }

                
            }
        }

        public bool  Check (Item item)
        {
            //return IsSoldOut;
        }
        public void Dispense(Item item)
        {

            //Count -= 1;
         
        }




    }
}
