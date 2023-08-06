using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;

namespace Factory.Controllers
{
    public class EngineerController : Controller
    { 
        private readonly FactoryContext _db;
        public EngineerController(FactoryContext db)
        {
          _db = db;
        }
    public ActionResult Index()
        {
					List<Engineer> model = _db.Engineers.ToList();
					return View(model);
        }

        public ActionResult Create()
        {
        	return View();
        }

        [HttpPost]
        public ActionResult Create(Engineer engineer)
        {
					_db.Engineers.Add(engineer);
					_db.SaveChanges();
					return RedirectToAction("Index");
        }
       public ActionResult Details(int id)
        {
        	Engineer thisEngineer = _db.Engineers
																		.Include(engineer => engineer.EngineerMachineEntities)
																		.ThenInclude(join => join.Machine)
																		.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
        }
        public ActionResult Edit(int id)
        {
        	Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        	return View(thisEngineer);
        }
        [HttpPost]
        public ActionResult Edit(Engineer engineer)
        {
					_db.Engineers.Update(engineer);
					_db.SaveChanges();
					return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
          Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
          return View(thisEngineer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
          Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
          _db.Engineers.Remove(thisEngineer);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
    }
}
