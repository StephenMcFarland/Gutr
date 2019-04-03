using Gutr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutr.Controllers
{
    public class FavoriteController : Controller
    {
        // GET: Favorite
        public ActionResult Index()
        {
            return View();
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(FavoriteCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    //var service = CreateNoteService();

        //    if (service.CreateNote(model))
        //    {
        //        TempData["SaveResult"] = "Your note was created.";
        //        return RedirectToAction("Index");
        //    };

        //    ModelState.AddModelError("", "Note could not be created.");

        //    return View(model);
        //}
    }
}