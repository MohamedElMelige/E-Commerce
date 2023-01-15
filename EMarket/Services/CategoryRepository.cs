using EMarket.Data;
using EMarket.Models;
using System.Collections.Generic;
using System.Linq;

namespace EMarket.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EMarketDbContext context;

        public CategoryRepository(EMarketDbContext _context)
        {
            context = _context;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public int Create(Category ctg)
        {
            context.Categories.Add(ctg);

            int rawData = context.SaveChanges();
            return rawData;
        }

        public int Edit(int id, Category ctg)
        {
            Category category = context.Categories.Find(id);

            category.Name = ctg.Name;
            category.NumberOfProducts = ctg.NumberOfProducts;

            int rawData = context.SaveChanges();
            return rawData;
        }

        public int Delete(int id)
        {
            Category category = context.Categories.Find(id);

            context.Categories.Remove(category);

            int rawData = context.SaveChanges();
            return rawData;
        }
    }
}