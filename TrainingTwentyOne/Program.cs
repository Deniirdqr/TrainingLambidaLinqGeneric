using System;
using System.IO;
using System.Linq;
using System.Globalization;
using TrainingTwentyOne.Entities;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Product> product = new List<Product>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    product.Add(new Product (name, price));
                }
            }
            var avg = product.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Average Prices: " + avg.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine("Products below media:");
            var names = product.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);           
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}







//C:\Users\cliente\Desktop\c++\Products.txt