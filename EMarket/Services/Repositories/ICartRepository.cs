using EMarket.Models;
using System.Collections.Generic;

namespace EMarket.Services
{
    public interface ICartRepository
    {
        int AddToCart(int id);
        int Delete(int id);
        List<Cart> GetAll();
        Cart GetById(int id);
    }
}