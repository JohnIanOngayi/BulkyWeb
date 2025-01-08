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
        if (newObj.Name == newObj.DisplayOrder.ToString())
            ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name");
        if (ModelState.IsValid)
        {
            _db.Categories?.Add(newObj);
            _db.SaveChanges();
            TempData["Success"] = "Category created successfully";

            return RedirectToAction("Index", "Category");
        }
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        Category? categoryFromDB = _db.Categories?.FirstOrDefault(category => category.Id == id);

        if (categoryFromDB is null)
            return NotFound();

        return View(categoryFromDB);
    }

    [HttpPost]
    public IActionResult Edit(Category Obj)
    {
        if (Obj.Name == Obj.DisplayOrder.ToString())
            ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name");
        if (ModelState.IsValid)
        {
            _db.Categories?.Update(Obj);
            _db.SaveChanges();
            TempData["Success"] = "Category updated successfully";
            return RedirectToAction("Index", "Category");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        Category? categoryFromDB = _db.Categories?.FirstOrDefault(category => category.Id == id);

        if (categoryFromDB is null)
            return NotFound();

        return View(categoryFromDB);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        Category? categoryFromDB = _db.Categories?.FirstOrDefault(category => category.Id == id);

        if (categoryFromDB is null)
            return NotFound();

        _db.Categories?.Remove(categoryFromDB);
        _db.SaveChanges();
        TempData["Success"] = "Category deleted successfully";

        return RedirectToAction("Index", "Category");
    }
}
