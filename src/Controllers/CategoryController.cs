using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

public class CategoryController : Controller
{
    // GET: CategoryController
    public ActionResult Index()
    {
        return View();
    }
}
