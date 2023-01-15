using EMarket.Data;
using EMarket.Models;
using EMarket.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EMarket.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository(new EMarketDbContext());
        }

        public CategoryController(ICategoryRepository _ctgRepo)
        {
            categoryRepository = _ctgRepo;
        }

        public ActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll();
            return View(categories);
        }

        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Create(category);
                TempData["CreateAlert"] = "Category Created Successeully";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int id)
        {
            Category category = categoryRepository.GetById(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Edit(id, category);
                TempData["EditAlert"] = "Category Edited Successeully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            Category category = categoryRepository.GetById(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categoryRepository.Delete(id);
            TempData["DeleteAlert"] = "Category Deleted Successeully";
            return RedirectToAction("Index");
        }
    }
}