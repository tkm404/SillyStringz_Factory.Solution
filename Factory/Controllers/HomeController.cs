using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {

    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
			Engineer[] engs = _db.Engineers.ToArray();
			Machine[] machs = _db.Machines.ToArray();
			Dictionary<string, object[]> model = new Dictionary<string, object[]>();
			model.Add("engineers", engs);
			model.Add("machines", machs);
      return View(model);
    }
  }
}