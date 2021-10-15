
using ConsoleTables;
using ConsoleProgram.Infrastructure.Models;
using ConsoleProgram.Infrastructure.Services;
using System;

namespace ConsoleProgram

{
    class Program
    {
        private static InformationService _informationService = new InformationService();
        static void Main(string[] args)
        {
            int select;

            do
            {

                Console.WriteLine("=====    =========    = = = =      = = = =    = = = =                     ");
                Console.WriteLine("=            =       =       =     =     =    =                         ");
                Console.WriteLine("=====        =       =       =     = =  =     = = = =                               ");
                Console.WriteLine("    =        =       =       =     =  =       =                                              ");
                Console.WriteLine("=====        =        = = = =      =     =    = = = =                        ");


                Console.WriteLine("===============Information System=======================");
                Console.WriteLine("                                                       ");
                Console.WriteLine("==========================MENU==========================");
                Console.WriteLine("1. Carry out operations on products");
                Console.WriteLine("2. Carry out operations on category");
                Console.WriteLine("3. Leave out");

                Console.WriteLine("========================================================");
                Console.Write("Make your choose : ");

                string choose = Console.ReadLine();


                while (!int.TryParse(choose, out select))
                {

                    Console.WriteLine("Enter a digit");

                    choose = Console.ReadLine();

                }

                switch (select)
                {
                    case 1:


                        Console.WriteLine("0. Back to MENU");
                        Console.WriteLine("1. Add new product");
                        Console.WriteLine("2. Carry out edit on products");
                        Console.WriteLine("3. Remove product");
                        Console.WriteLine("4. Show all products");
                        Console.WriteLine("5. Show products by Id");
                        Console.WriteLine("6. Search by name among products");
                        FirstCase();



                        break;
                    case 2:


                        Console.WriteLine("0. Back to MENU");
                        Console.WriteLine("1. Add new category");
                        Console.WriteLine("2. Carry out edit on categories");
                        Console.WriteLine("3. Remove category");
                        Console.WriteLine("4. Show all categories");
                        Console.WriteLine("5. Show category by Id");
                        Console.WriteLine("6. Search by name among category");
                        SecondCase();



                        break;


                    case 3:
                        Console.WriteLine("=============THANK YOU FOR USED THE SYSTEM=============");

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("You made wrong choise,you should choose 1-3 ");
                        Console.WriteLine("--------------------------------");
                        Console.Beep();
                        break;

                }
            } while (select != 3);




            Console.WriteLine("=====================================================================");
        }
        static void FirstCase()
        {

            int FirstSelect;
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Which operations you wanna make?");
            Console.WriteLine("=====================================================================");

            do
            {



                string Choose1 = Console.ReadLine();



                while (!int.TryParse(Choose1, out FirstSelect))
                {

                    Console.WriteLine("You should enter digit!");

                    Choose1 = Console.ReadLine();
                }

                switch (FirstSelect)
                {
                    case 0:
                        Console.Clear();
                        continue;


                    case 1:

                        Console.WriteLine("1. Add new product");
                        Console.WriteLine("============================================================");
                        AddNewProduct();

                        break;
                    case 2:

                        Console.WriteLine("2. Carry out edit on products");
                        Console.WriteLine("============================================================");
                        EditOnProduct();
                        break;

                    case 3:

                        Console.WriteLine("3. Remove product ");
                        Console.WriteLine("=============================================================");
                        RemoveProduct();
                        break;

                    case 4:

                        Console.WriteLine("4. Show all products");
                        Console.WriteLine("=============================================================");
                        ShowAllProducts();
                        break;

                    case 5:
                        Console.WriteLine("5. Show products by Id");
                        Console.WriteLine("=============================================================");
                        ShowProductById();
                        break;



                    case 6:
                        Console.WriteLine("6. Search by name among products");
                        Console.WriteLine("=============================================================");
                        SearchByName();
                        break;

                    default:

                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("You made wrong choise,you should choose 1-6");
                        Console.WriteLine("-------------------------------------------");
                        break;


                }


            } while (FirstSelect != 0);
        }

        static void AddNewProduct()
        {
            Product product = new Product();



            Console.WriteLine("Enter the name of the product:");

            string name = Console.ReadLine();

            product.Name = name;



            Console.WriteLine("Enter a price of product");

            string Input = Console.ReadLine();

            double Price;

            while (!double.TryParse(Input, out Price))
            {
                Console.WriteLine("Your should enter a digit!");

                Input = Console.ReadLine();
            }
            product.Price = Price;

            Console.WriteLine("Enter a quantity of product");

            string Input1 = Console.ReadLine();

            double Quantity;

            while (!double.TryParse(Input1, out Quantity))
            {
                Console.WriteLine("Your should enter a digit!");

                Input1 = Console.ReadLine();
            }
            product.Quantity = Quantity;

        l:

            Console.WriteLine("Enter the category Id  of the product :");

            _informationService.ReadAllCategories();
            if (!int.TryParse(Console.ReadLine(), out int catId))
                goto l;

            var selected = _informationService.Categories.Find((a) => a.Id == catId);
            if (selected == null)
            {
                Console.WriteLine("Has not found this category");
                Console.Beep();
                goto l;
            }



            product.Category = selected;


            Console.WriteLine("Product is added");

            product.Date = DateTime.Now;

            _informationService.AddProduct(product);

        }

        static void EditOnProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter Id of product for edit");

            string Input = Console.ReadLine();

            int id;

            while (!int.TryParse(Input, out id))
            {
                Console.WriteLine("Your should enter a digit!");

                Input = Console.ReadLine();
            }

            product.Id = id;

            _informationService.EditProduct(id);

        }

        static void RemoveProduct()
        {
            Console.WriteLine("Enter Id of product for remove");

            Product product = new Product();


            string Input = Console.ReadLine();

            int id;

            while (!int.TryParse(Input, out id))
            {
                Console.WriteLine("Your should enter a digit!");

                Input = Console.ReadLine();
            }

            product.Id = id;

            _informationService.RemoveProduct(id);

        }

        static void ShowAllProducts()
        {

            Console.WriteLine("--------------------------- CURRENT PRODUCTS --------------------------");


            var table = new ConsoleTable("#", "Id", "Category", "Name", "Price", "Quantity", "Date");

            int i = 1;
            foreach (var item in _informationService.Products)
            {

                table.AddRow(i, item.Id, item.Category, item.Name, item.Price, item.Quantity, item.Date);
                i++;

            }
            table.Write();

            _informationService.ShowAllProduct();
        }

        static void ShowProductById()
        {
            Console.WriteLine("Enter Id of search product");

            Product product = new Product();


            string Input = Console.ReadLine();

            int id;

            while (!int.TryParse(Input, out id))
            {
                Console.WriteLine("Your should enter a digit!");

                Input = Console.ReadLine();
            }

            product.Id = id;

            _informationService.ShowProductById(id);

        }

        static void SearchByName()
        {
            Console.WriteLine("Enter full or part text of what you search ");

            string topic = Console.ReadLine();

            _informationService.SeacrhProductByName(topic);


        }

        static void SecondCase()
        {

            int SecondSelect;
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Which operations you wanna make?");
            Console.WriteLine("=====================================================================");

            do
            {



                string Choose1 = Console.ReadLine();



                while (!int.TryParse(Choose1, out SecondSelect))
                {

                    Console.WriteLine("You should enter digit!");

                    Choose1 = Console.ReadLine();
                }

                switch (SecondSelect)
                {
                    case 0:
                        Console.Clear();
                        continue;


                    case 1:

                        Console.WriteLine("1. Add new category");
                        Console.WriteLine("============================================================");
                        AddNewCategory();

                        break;
                    case 2:

                        Console.WriteLine("2. Carry out edit on categories");
                        Console.WriteLine("============================================================");
                        EditOnCategory();
                        break;

                    case 3:

                        Console.WriteLine("3. Remove category ");
                        Console.WriteLine("=============================================================");
                        RemoveCategory();
                        break;

                    case 4:

                        Console.WriteLine("4. Show all categories");
                        Console.WriteLine("=============================================================");
                        ShowAllCategories();
                        break;

                    case 5:
                        Console.WriteLine("5. Show categories by Id");
                        Console.WriteLine("=============================================================");
                        ShowCategoriesById();
                        break;



                    case 6:
                        Console.WriteLine("6. Search by name among categories");
                        Console.WriteLine("=============================================================");
                        SearchCategoryByName();
                        break;

                    default:

                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("You made wrong choise,you should choose 1-6");
                        Console.WriteLine("-------------------------------------------");
                        break;


                }


            } while (SecondSelect != 0);
        }

        static void AddNewCategory()
        {
            Category category = new Category();

            Console.WriteLine("Enter the name of the category:");

            string name = Console.ReadLine();

            category.Name = name;


            _informationService.AddCategory(category);
            Console.WriteLine("Category is added");


        }

        static void EditOnCategory()
        {
            Category category = new Category();
            Console.WriteLine("Enter Id of category for edit");

            string Input = Console.ReadLine();

            int id;

            while (!int.TryParse(Input, out id))
            {
                Console.WriteLine("Your should enter a digit!");

                Input = Console.ReadLine();
            }

            category.Id = id;

            _informationService.EditCategory(id);

        }

        static void RemoveCategory()
        {
            Console.WriteLine("Enter Id of category for remove");

            Category category = new Category();


            string Input = Console.ReadLine();

            int id;

            while (!int.TryParse(Input, out id))
            {
                Console.WriteLine("Your should enter a digit!");

                Input = Console.ReadLine();
            }

            category.Id = id;

            _informationService.RemoveCategory(id);

        }

        static void ShowAllCategories()
        {

            Console.WriteLine("----- CURRENT CATEGORIES -----");

            var table = new ConsoleTable("#", "Id", "Name");

            int i = 1;
            foreach (var item in _informationService.Categories)
            {

                table.AddRow(i, item.Id, item.Name);
                i++;

            }
            table.Write();

            _informationService.ShowAllCategory();
        }

        static void ShowCategoriesById()
        {
            Console.WriteLine("Enter Id of search category");

            Category category = new Category();


            string Input = Console.ReadLine();

            int id;

            while (!int.TryParse(Input, out id))
            {
                Console.WriteLine("Your should enter a digit!");

                Input = Console.ReadLine();
            }

            category.Id = id;

            _informationService.ShowCategoryById(id);

        }

        static void SearchCategoryByName()
        {
            Console.WriteLine("Enter full or part text of what you search ");

            string topic = Console.ReadLine();

            _informationService.SeacrhCategoryByName(topic);


        }
    }
}
