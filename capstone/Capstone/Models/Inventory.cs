using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Capstone.Models
{
   public class Inventory
    {
        public SalesReport Report = new SalesReport();//
        public Dictionary<string, Item> InventoryItems = new Dictionary<string, Item>();
        public void LoadInventory()
        {
Report.CreatSalesReport();
            string fileName = @"C:\Users\Student\git\c-sharp-minicapstonemodule1-team0\capstone\vendingmachine.csv";
            using (StreamReader sr = new StreamReader(fileName))
            {
                try
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
                        Report.LoadItemsName(item.Name);
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Oops, Something Wrong happened, Loading Inventory Item failed");
                }

            }
        }
        public bool IsKeyExists( string _itemKey)
        {
           return InventoryItems.ContainsKey(_itemKey);
        }
        public void Dispense(string itemsKey)
        {
            Report.AddSoldItem(InventoryItems[itemsKey].Name, InventoryItems[itemsKey].Price);

            InventoryItems[itemsKey].Count--;
        }

    }
}
