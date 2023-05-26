using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
    public class EngineersController : Controller
{
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

//READ vvvv

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
                                  .Include()...

      return View(thisEngineer);
    }

//READ ^^^^
//----------------------------------------------------------------
// CREATE vvvv

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
    }

// CREATE ^^^^
//----------------------------------------------------------------

}
}