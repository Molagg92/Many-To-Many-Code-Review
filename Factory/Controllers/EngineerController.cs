using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;


namespace Factory.Controllers
{
    public class FactoryController : Controller
    { 
        private readonly FactoryContext _db;
        public FactoryController(FactoryContext db)
        {
            _db = db;
        }
    public ActionResult Index()
        {
        List<Engineer> model = _db.Engineers.ToList();
        return View(model);
        }

    }
}
