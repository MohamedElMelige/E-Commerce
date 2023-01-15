using EMarket.Data;
using EMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMarket.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly EMarketDbContext context;

        public CartRepository(EMarketDbContext _context)
        {
            context = _context;
        }

        public List<Cart> GetAll()
        {
            return context.Carts.ToList();
        }

        public Cart GetById(int id)
        {
            return context.Carts.Find(id);
        }

        public int AddToCart(int id)
        {
            DateTime localDate = DateTime.Now;

            Cart cart = new Cart
            {
                ProductId = id,
                AddedAt = localDate
            };

            context.Carts.Add(cart);

            int rawData = context.SaveChanges();
            return rawData;
        }

        public int Delete(int id)
        {
            Cart cart = context.Carts.Find(id);

            context.Carts.Remove(cart);

            int rawData = context.SaveChanges();
            return rawData;
        }
    }
}