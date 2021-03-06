﻿using Gutr.Models;
using Gutr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutr.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        [Authorize]
        //[ActionName("myPosts")]
        public ActionResult Index()
        {
            var service = CreateNoteService();

            var model = service.GetNotes();

            return View(model);
        }

        // GET: Profile
        //[Authorize]
        //public ActionResult Profile()
        //{
        //    var service = CreateNoteService();

        //    var model = service.GetProfile();

        //    return View(model);
        //}

        // GET: Note
        [Authorize]
        //[ActionName("posts")]
        public ActionResult AllPosts()
        {
            var service = CreateNoteService();

            var model = service.GetAllPosts();

            return View(model);
        }

    

        // GET: Favorites
        [Authorize]
        //[ActionName("favorites")]
        public ActionResult AllFavorites()
        {
            var service = CreateNoteService();

            var model = service.GetAllFavorites();

            return View(model);
        }

        // GET: My Favorites
        [Authorize]
        //[ActionName("favorited")]
        public ActionResult MyFavorites()
        {
            var service = CreateFavoriteService();

            var model = service.GetMyFavorites();

            return View(model);
        }

        // GET
        //[ActionName("newPost")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ActionName("newPost")]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNoteService();

            string userName = User.Identity.Name;

            //if (service.CreateNote(model, userName))
                if (service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        // GET
        //public ActionResult CreateFavorite()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateFavorite(FavoriteCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var service = CreateFavoriteService();

        //    if (service.CreateFavorite(model))
        //    {
        //        TempData["SaveResult"] = "Your favorite was created.";
        //        return RedirectToAction("Index");
        //    };

        //    ModelState.AddModelError("", "Favorite could not be created.");

        //    return View(model);
        //}

       

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var username = User.Identity.GetUserName();
            var service = new NoteService(userId, username);
            return service;
        }

        private FavoriteService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateNoteService();
            var model = svc.GetNoteById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateNoteService();
            var detail = service.GetNoteById(id);
            var model =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NoteEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNoteService();

            if (service.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNoteService();
            var model = svc.GetNoteById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNoteService();

            service.DeleteNote(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}