using ConsoleProgram.Infrastructure.Models;
using System;


namespace ConsoleProgram.Infrastructure.Services
{
    public class Product
    {
        static int counter = 1;
        public Product()
        {
            Id = counter++;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }



    }
}
