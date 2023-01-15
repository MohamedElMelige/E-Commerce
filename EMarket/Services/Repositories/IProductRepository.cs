using EMarket.Models;
using System.Collections.Generic;

namespace EMarket.Services
{
    public interface IProductRepository
    {
        int Create(Product prod);
        int Delete(int id);
        int Edit(int id, Product prod);
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> Search(string SearchString);
    }
}