using EMarket.Data;
using EMarket.Models;
using System.Collections.Generic;
using System.Linq;

namespace EMarket.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly EMarketDbContext context;

        public ProductRepository(EMarketDbContext _context)
        {
            context = _context;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> Search(string SearchString)
        {
            return context.Products.Where(p => p.Category.Name.Contains(SearchString) || SearchString == null).ToList();
        }

        public int Create(Product prod)
        {
            context.Products.Add(prod);

            int rawData = context.SaveChanges();
            return rawData;
        }

        public int Edit(int id, Product prod)
        {
            Product product = context.Products.Find(id);

            product.Name = prod.Name;
            product.Price = prod.Price;
            product.Image = prod.Image;
            product.Description = prod.Description;
            product.CategoryId = prod.CategoryId;

            int rawData = context.SaveChanges();
            return rawData;
        }

        public int Delete(int id)
        {
            Product product = context.Products.Find(id);

            context.Products.Remove(product);

            int rawData = context.SaveChanges();
            return rawData;
        }
    }
}