using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ViewResult Index()
        {
            var products = context.Categories.ToList();
            return View(products);
        }
        public ViewResult Create()
        {
            return View(new Category());
        }
        public IActionResult Add(Category request)
        {
            if (ModelState.IsValid)
            {
            context.Categories.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return View("Create" , request);

            }
           
           
        }
        public ViewResult Details(int id)
        {

             var product = context.Categories.Find(id);
             return View(product);
        }
        public IActionResult Delete(int id)
        {
            var product = context.Categories.Find(id);
            if(product is null)
            {
                return View("NotFound");
            }
            context.Categories.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
