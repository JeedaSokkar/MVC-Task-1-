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
            return View();
        }
        public RedirectToActionResult Add(Category request)
        {
            context.Categories.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            Console.WriteLine(id);

    var product = context.Categories.Find(id);


    return View(product);
        }
    }
}
