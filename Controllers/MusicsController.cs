using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MusicsController : Controller
    {
        private ApplicationDbContext _context;

        public MusicsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Musics
        public ActionResult Index()
        {
     
            return RedirectToAction("List");
      
        }

        public ActionResult List()
        {
            var musics = _context.Musics.ToList();
            return View(musics);
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}