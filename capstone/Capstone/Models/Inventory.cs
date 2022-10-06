using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Models
{
   public class Inventory
    {
        public Item Items { get; set; }
        public int Count { get; set; }
        bool IsSoldOut { 
            get {
                return !(Count > 0); 
            } 
        }
        public string Location { get; private set; }


        public void ReadLine()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            using (StreamReader sr = new StreamReader(Path.Combine(directory, fileName)))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Dictionary lineArray = line.Split("|");
                    for (int i = 0; i < lineArray.Length; i++)
                    {
                        // Is location assignment correct?
                        Location = lineArray[0];
                        Items.Name = lineArray[1];
                        decimal.Parse(lineArray[2]) = decimal itemPrice;
                        itemPrice = Items.Price;
                        // ??
                        lineArray[3] = Items.ItemType;
                    }

                }


            }
        }

        public 


        public bool  Check (Item item)
        {
            return IsSoldOut;
        }
        public void Dispense(Item item)
        {

            Count -= 1;
         
        }




    }
}
