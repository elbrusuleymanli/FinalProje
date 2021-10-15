using ConsoleProgram.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using ConsoleProgram.Infrastructure.Models;
using OpenQA.Selenium;

namespace ConsoleProgram.Infrastructure.Services
{
    class InformationService : Iinformation
    {
        private List<Category> _categories;
        public List<Category> Categories => _categories;

        private List<Product> _product;
        public List<Product> Products => _product;

        #region Default constructor
        // Created default constructor for NULL exception
        public InformationService()
        {

            _categories = new List<Category>()
            {
                new Category
                {
                    Name = "Beverage",

                },
                 new Category
                {
                    Name = "Sweet",

                },
                  new Category
                  {
                      Name = "Fruit",

                  }
            };
            _product = new List<Product>()
    {
        new Product
        {

            Name= "Chocolate",
            Price = 12,
            Quantity = 7.5,
            Date = DateTime.Now,



        },

};

        }
        #endregion

        #region Product


        public void AddProduct(Product product)
        {
            _product.Add(product);
        }

        public List<Product> EditProduct(int id)
        {
            bool check = _product.Exists(p => p.Id == id);

            if (check == true)
            {

                var code = _product.FindAll(p => p.Id == id);

                Console.WriteLine("Enter new name of the product");

                string name = Console.ReadLine();


                Console.WriteLine("Enter new category of the product");

                string Category = Console.ReadLine();

                Console.WriteLine("Enter a price of product");

                string Input = Console.ReadLine();

                double Price;

                while (!double.TryParse(Input, out Price))
                {
                    Console.WriteLine("Your should enter a digit!");

                    Input = Console.ReadLine();
                }
                Console.WriteLine("Enter a quantity of product");

                string Input1 = Console.ReadLine();

                double Quantity;

                while (!double.TryParse(Input1, out Quantity))
                {
                    Console.WriteLine("Your should enter a digit!");

                    Input = Console.ReadLine();
                }

                Console.WriteLine("Product has been edited");

                foreach (var prod in code)
                {
                    prod.Name = name;
                    prod.Price = Price;
                    prod.Quantity = Quantity;
                    prod.Date = DateTime.Now;
                }


            }

            else
            {

                Console.WriteLine("Product Id is wrong");
            }
            return _product;
        }

        public void RemoveProduct(int id)
        {
            bool delete = _product.Exists(r => r.Id == id);

            if (delete == true)
            {
                var del = _product.Find(p => p.Id == id);

                _product.Remove(del);

                Console.WriteLine(" By selected product has been deleted");
            }

            else
            {

                Console.WriteLine("Product has not found");
            }
        }

        public List<Product> SeacrhProductByName(string name)
        {
            bool Name = _product.Exists(p => p.Name == name || p.Name.Contains(name));

            if (Name == true)
            {

                var text = _product.FindAll(p => p.Name == name || p.Name.Contains(name));

                foreach (var item in text)
                {
                    var table = new ConsoleTable("#", "Id", "Category", "Name", "Price", "Quantity", "Date");

                    int i = 1;

                    table.AddRow(i, item.Id, item.Category, item.Name, item.Price, item.Quantity, item.Date);
                    i++;


                    table.Write();
                }
            }
            else
            {
                Console.WriteLine("Has not found the product with consist - " + name);
            }
            return _product;
        }

        public List<Product> ShowAllProduct()
        {
            return _product;
        }

        public List<Product> ShowProductById(int id)
        {
            bool show = _product.Exists(p => p.Id == id);

            if (show == true)
            {
                List<Product> product = _product.FindAll(p => p.Id == id);

                foreach (var item in product)
                {
                    var table = new ConsoleTable("#", "Id", "Category", "Name", "Price", "Quantity", "Date");

                    int i = 1;

                    table.AddRow(i, item.Id, item.Category, item.Name, item.Price, item.Quantity, item.Date);
                    i++;


                    table.Write();
                }
            }

            else
            {
                Console.WriteLine("Has not found any products by this category");
            }
            return _product;
        }


        public Category GetCategoryById(int id)
        {

            Category cat = Categories.FirstOrDefault(a => a.Id == id);

            return cat;
        }

        public void ReadAllCategories()
        {

            foreach (var item in Categories)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }
        #endregion

        #region Category


        public List<Category> ShowAllCategory()
        {
            return _categories;
        }

        public List<Category> ShowCategoryById(int id)
        {
            bool show = _categories.Exists(p => p.Id == id);

            if (show == true)
            {
                List<Category> category = _categories.FindAll(p => p.Id == id);

                foreach (var item in category)
                {
                    var table = new ConsoleTable("#", "Id", "Name");

                    int i = 1;

                    table.AddRow(i, item.Id, item.Name);
                    i++;


                    table.Write();
                }
            }

            else
            {
                Console.WriteLine("Has not found any category by this ID");
            }
            return _categories;
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public List<Category> EditCategory(int id)
        {
            bool check = _product.Exists(p => p.Id == id);

            if (check == true)
            {

                var code = _product.FindAll(p => p.Id == id);

                Console.WriteLine("Enter new name of the category");

                string name = Console.ReadLine();


                foreach (var prod in code)
                {
                    prod.Name = name;

                }
                Console.WriteLine("Category has been edited");
            }

            else
            {

                Console.WriteLine("Category Id is wrong");
            }


            return _categories;
        }

        public void RemoveCategory(int id)
        {
            bool delete = _categories.Exists(r => r.Id == id);

            if (delete == true)
            {
                var del = _categories.Find(p => p.Id == id);

                _categories.Remove(del);

                Console.WriteLine(" By selected category has been deleted");
            }

            else
            {
                Console.WriteLine("Category as {0} has not found", id);

                throw new NotFoundException(string.Format("Category has not found"));

            }
        }

        public List<Category> SeacrhCategoryByName(string name)
        {
            bool Name = _categories.Exists(p => p.Name == name || p.Name.Contains(name));

            if (Name == true)
            {

                var text = _categories.FindAll(p => p.Name == name || p.Name.Contains(name));

                foreach (var item in text)
                {
                    var table = new ConsoleTable("#", "Id", "Name");

                    int i = 1;

                    table.AddRow(i, item.Id, item.Name);
                    i++;


                    table.Write();
                }
            }
            else
            {
                Console.WriteLine("Has not found the product with consist - " + name);
            }
            return _categories;
        }

        #endregion
    }
}

