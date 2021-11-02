using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;


namespace Task16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = (@"C:\Users\in-user\Desktop\Products.JSON");
            string currStr = null;
            int[] array = new int[5];
            double max = array[0];
            string name = null;
            using (StreamReader sr = new StreamReader(path, true))
                for (int i = 0; i < 5; i++)
                {
                    currStr = sr.ReadLine();                    
                    Product products = JsonSerializer.Deserialize<Product>(currStr);
                    Console.WriteLine(currStr);
                    Convert.ToDouble(products.productCost);
                    if (products.productCost > max)
                    {
                        max = products.productCost;
                        name = products.ProductName;
                    }

                }            
            Console.WriteLine("Название самого дорогого товара: {0}", name); 
            Console.ReadKey();
        }
    }
    class Product
    {
        [JsonIgnore]
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double productCost;
        public double ProductCost
        {
            set
            {
                if (value >= 0)
                {
                    productCost = value;
                }
                else
                {
                    Console.WriteLine("Цена не может быть отрицательной");
                }
            }
            get
            {
                return productCost;
            }
        }
    }
}
