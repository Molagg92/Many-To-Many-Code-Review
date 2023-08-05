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

    }
}
