using System;
using System.Collections.Generic;
using System.Text;

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









        public bool  Check (Item item)
        {
            return IsSoldOut;
        }
        public void dispense(Item item)
        {

        }



    }
}
