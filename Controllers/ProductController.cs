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
        [HttpGet]
        public ViewResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public IActionResult Create(Category request)
        {
            if (!ModelState.IsValid)
            {
                return View( request);
            }
            var ExistName = context.Categories.Any(c => c.Name == request.Name);
            if (ExistName)
            {
                ModelState.AddModelError("Name","Category name is exists");
                return View("Create", request);
            }

            context.Categories.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        
           
            

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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Categories.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Category request)

        {
            if (!ModelState.IsValid)
            {

                    return View(request);
            }
            var ExistName = context.Categories.Any(c => c.Name == request.Name && c.Id !=request.Id);
            if (ExistName)
            {
                ModelState.AddModelError("Name", "Category name is exists");

                return View( request);
            }
            
            context.Categories.Update(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}
