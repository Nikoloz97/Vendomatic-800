using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Item
    {
        public string Name { get;private set; }
        public decimal Price { get; private set; }
        public ItemType ItemType { get; set; }



    }
}
