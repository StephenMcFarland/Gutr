using Gutr.Models;
using Gutr.Services;
using Microsoft.AspNet.Identity;
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
            var service = CreateFavoriteService();

            var model = service.SetFavorite();
            return View();
        }

        
        public ActionResult Favorite()
        {
            //if (!ModelState.IsValid) return View(model);

            var service = CreateFavoriteService();

            var model = service.SetFavorite();

            //if (service.SetFavorite(model))
            //{
            //    TempData["SaveResult"] = "Your note was created.";
                //return RedirectToAction("Favorite");
            //};

            //ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        private FavoriteService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteService(userId);
            return service;
        }
    }
}