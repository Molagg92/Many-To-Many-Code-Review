using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;

namespace Factory.Controllers
{
    public class MachineController : Controller
    {
       private readonly FactoryContext _db;
        public MachineController(FactoryContext db)
        {
          _db = db;
        }
    public ActionResult Index()
        {
        List<Machine> model = _db.Machines.ToList();
        return View(model);
        }

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
				public ActionResult Details(int id)
        {
        	Machine thisMachine = _db.Machines
                                      .Include(machine => machine.EngineerMachineEntities)
                                      .ThenInclude(join => join.Engineer)
                                      .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
        }
        public ActionResult Edit(int id)
        {
        	Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
        	return View(thisMachine);
        }
        [HttpPost]
        public ActionResult Edit(Machine machine)
        {
					_db.Machines.Update(machine);
					_db.SaveChanges();
					return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
          Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
          return View(thisMachine);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
          Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
          _db.Machines.Remove(thisMachine);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
				        public ActionResult AddEngineer(int id)
        {
          Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
          ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
          return View(thisMachine);
        }
        [HttpPost]
        public ActionResult AddEngineer(Machine machine, int engineerId)
        {
          #nullable enable
          EngineerMachineEntity? joinEntity = _db.EngineerMachineEntities.FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
          #nullable disable
          if (joinEntity == null && engineerId != 0)
          {
            _db.EngineerMachineEntities.Add(new EngineerMachineEntity() {EngineerId = engineerId, MachineId = machine.MachineId });
            _db.SaveChanges();
          }
          return RedirectToAction("Details", new { id = machine.MachineId });
        } 
        [HttpPost]
        public ActionResult DeleteJoin(int joinId)
        {
          EngineerMachineEntity joinEntry = _db.EngineerMachineEntities.FirstOrDefault(entry => entry.EngineerMachineEntityId == joinId);
          _db.EngineerMachineEntities.Remove(joinEntry);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
    }
}
