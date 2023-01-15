using EMarket.Data;
using EMarket.Models;
using EMarket.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;

        public CartController()
        {
            cartRepository = new CartRepository(new EMarketDbContext());
        }

        public CartController(ICartRepository _cartRepo)
        {
            cartRepository = _cartRepo;
        }

        public ActionResult Index()
        {
            List<Cart> carts = cartRepository.GetAll();
            return View(carts);
        }

        public ActionResult AddToCart(int id)
        {
            Cart cart = cartRepository.GetById(id);

            if (cart != null)
            {
                TempData["CartAlert"] = "Product already in The Cart";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                cartRepository.AddToCart(id);
                TempData["AddToCartAlert"] = "Product Added to Cart Successeully";
                return RedirectToAction("Index", "Product");
            }
        }

        public ActionResult Remove(int id)
        {
            Cart cart = cartRepository.GetById(id);

            if (cart != null)
            {
                cartRepository.Delete(id);
            }
            TempData["RemoveAlert"] = "Product Removed from Cart Successeully";
            return RedirectToAction("Index", "Product");
        }
    }
}