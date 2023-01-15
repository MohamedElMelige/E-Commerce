using EMarket.Data;
using EMarket.Models;
using EMarket.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductController()
        {
            productRepository = new ProductRepository(new EMarketDbContext());
            categoryRepository = new CategoryRepository(new EMarketDbContext());
        }

        public ProductController(IProductRepository _prodRepo, ICategoryRepository _ctgRepo)
        {
            productRepository = _prodRepo;
            categoryRepository = _ctgRepo;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            List<Product> products = productRepository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = productRepository.Search(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products.OrderByDescending(p => p.Category);
                    break;
            }

            return View(products);
        }

        public ActionResult Details(int id)
        {
            Product product = productRepository.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "Id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                string path = "";

                if (imgFile.FileName.Length > 0)
                {
                    path = "~/images/" + Path.GetFileName(imgFile.FileName);
                    imgFile.SaveAs(Server.MapPath(path));
                }

                product.Image = path;
                productRepository.Create(product);
                TempData["CreateAlert"] = "Product Created Successeully";
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "Id", "name", product.CategoryId);
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            Product product = productRepository.GetById(id);

            TempData["imgpath"] = product.Image;

            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "Id", "name", product.CategoryId);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string path = "";

                    if (imgFile.FileName.Length > 0)
                    {
                        path = "~/images/" + Path.GetFileName(imgFile.FileName);
                        imgFile.SaveAs(Server.MapPath(path));
                    }

                    product.Image = path;
                    productRepository.Edit(id, product);
                    return RedirectToAction("Index");
                }
                else
                {
                    product.Image = TempData["imgpath"].ToString();
                    productRepository.Edit(id, product);
                    TempData["EditAlert"] = "Product Edited Successeully";
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "Id", "Category Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            Product product = productRepository.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productRepository.Delete(id);
            TempData["DeleteAlert"] = "Product Deleted Successeully";
            return RedirectToAction("Index");
        }
    }
}