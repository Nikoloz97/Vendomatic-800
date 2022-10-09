using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Schema;

namespace Capstone.Models
{
    public  class SalesReport
    {
        public static string  FileName { get; private set; }
        public static decimal TotalSales { get; set; }
        public static Dictionary<string,int> SalesReportItem { get; private set; } = new Dictionary<string, int>();
        public void  CreatSalesReport()
        {
            CreateSalesDirectory();
            string directory = Environment.CurrentDirectory;
            string sales = "Sales";
            string filename = DateTime.Now.ToString("MM-dd-yyyy  hh mm ss tt")+".txt";
            string Filepath = Path.Combine(directory, sales, filename);
            FileName = Filepath;
        }
        public void LoadItemsName( string _names)
        {
                SalesReportItem[_names] = 0;
        }
        public static void WriteItemsToSalesReport()
        {
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                foreach (var _item in SalesReportItem)
                {
                    sw.WriteLine($"{_item.Key}|{_item.Value}");
                }
                sw.WriteLine();
                sw.WriteLine();

                sw.WriteLine($" ** TotalSales ** {TotalSales}");

            }


        }
        public void AddSoldItem(string _name,decimal _price)
        {
            SalesReportItem[_name] += 1;
            TotalSales += _price;
        }
        /// <summary>
        /// Check if Sales Directory exists, and create it if not
        /// </summary>
        private void CreateSalesDirectory()
        {
            string currentDir = Environment.CurrentDirectory;
            string salesDir = Path.Combine(currentDir, "Sales");

            if (!Directory.Exists(salesDir))
            {
                Directory.CreateDirectory(salesDir);
            }

        }
    }
}
