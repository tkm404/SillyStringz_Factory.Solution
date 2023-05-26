using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
    public class MachinesController : Controller
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
      Machine thisMachine = _db.Machines
                                  .Include()...

      return View(thisMachine);
    }

//READ ^^^^
//----------------------------------------------------------------
// CREATE vvvv

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
    }

// CREATE ^^^^
//----------------------------------------------------------------

}
}