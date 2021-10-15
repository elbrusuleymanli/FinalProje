
using ConsoleProgram.Infrastructure.Models;
using ConsoleProgram.Infrastructure.Services;
using System.Collections.Generic;


namespace ConsoleProgram.Infrastructure.Interfaces
{
    public interface Iinformation
    {
        #region Product 

        List<Product> Products { get; }
        List<Product> ShowAllProduct();
        List<Product> ShowProductById(int id);
        void AddProduct(Product product);
        List<Product> EditProduct(int id);
        void RemoveProduct(int id);
        List<Product> SeacrhProductByName(string name);
        #endregion

        #region Category

        List<Category> Categories { get; }

        List<Category> ShowAllCategory();
        List<Category> ShowCategoryById(int id);
        void AddCategory(Category category);
        List<Category> EditCategory(int id);
        void RemoveCategory(int id);
        List<Category> SeacrhCategoryByName(string name);


        #endregion


    }
}
