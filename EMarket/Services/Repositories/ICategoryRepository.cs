using EMarket.Models;
using System.Collections.Generic;

namespace EMarket.Services
{
    public interface ICategoryRepository
    {
        int Create(Category ctg);
        int Delete(int id);
        int Edit(int id, Category ctg);
        List<Category> GetAll();
        Category GetById(int id);
    }
}