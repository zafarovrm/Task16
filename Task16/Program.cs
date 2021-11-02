using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task16
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializerOptions option = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            string path = (@"C:\Users\in-user\Desktop\Products.JSON");
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                Product products = new Product();

                for (int i = 0; i < 5; i++)
                {                    
                    Console.WriteLine("Код товара {0}:", i + 1);
                    products.ProductCode = Convert.ToInt32(Console.ReadLine());                    
                    Console.WriteLine("Название товара {0}:", i + 1);
                    products.ProductName = Console.ReadLine();                    
                    Console.WriteLine("Цена товара {0}:", i + 1);
                    products.ProductCost = Convert.ToDouble(Console.ReadLine());                    
                    string json = JsonSerializer.Serialize<Product>(products,option);
                    sw.WriteLine(json);
                }
                Console.ReadKey();
            }           
        }
    }
    class Product
    {
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