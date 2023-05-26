using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Factory.Controllers
{
    public class MachinesController : Controller
{
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

   //READ vvvv

    public ActionResult Index()
    {
        return View(_db.Machines.ToList());
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
                                .Include(machine => machine.JoinEntities)
                                .ThenInclude(join => join.Engineer)
                                .FirstOrDefault(machine => machine.MachineId == id);
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
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }
    
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
      #nullable disable
      if (joinEntity == null && engineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = machine.MachineId });
    }

// CREATE ^^^^
//----------------------------------------------------------------
// UPDATE vvvv

    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Machines.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
}
}