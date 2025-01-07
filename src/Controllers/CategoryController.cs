using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;

namespace src.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        // Retrieve all categories from the database as a list
        //     Do recall that Categories is a DbSet in ApplicationDbContext
        List<Category> objCategoryList = _db.Categories?.ToList() ?? new List<Category>();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category newObj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories?.Add(newObj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        return View();
    }
}
