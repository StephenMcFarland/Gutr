﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using Gutr.Data;
using Gutr.Services;
using Microsoft.AspNet.Identity;

namespace Gutr.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: Profiles
        public ActionResult Index()
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());

            //var profile = from m in db.Profiles
            //             where m.OwnerId == OwnerId
            //             select m;
            var profile = from m in db.Profiles
                              //where m.Name == "name 2"
                          where m.OwnerId == _userId
                          select m;
            //var ProfileStr = profile.ToList();

            //if (ProfileStr == null)
            //{
            //    ViewBag.hasProfile = false;
            //}
            //else { ViewBag.hasProfile = ProfileStr; }// true; }

            Profile pf = db.Profiles.Find(_userId);
            if (pf != null)
            {
                ViewBag.hasProfile = true;
            }
            else { ViewBag.hasProfile = false; }

            return View(profile);//.ToList());// db.Profiles.ToList());

            //var service = CreateProfileService();

            //var model = service.GetProfile();

            //return View(model);
        }

        public ActionResult UserProfile(string userName)
        {
            //var _userId = Guid.Parse(User.Identity.GetUserId());

            //var profile = from m in db.Profiles
            //             where m.OwnerId == OwnerId
            //             select m;
            //var profile = from m in db.Profiles
            //                  //where m.Name == "name 2"
            //              where m.OwnerId == _userId
            //              select m;
           

            var service = CreateProfileService();

            var model = service.GetUserProfile(userName);

            return View(model);
            //return View();
        }

        public ActionResult UP(string userName)
        {
            //var _userId = Guid.Parse(User.Identity.GetUserId());

            //var profile = from m in db.Profiles
            //             where m.OwnerId == OwnerId
            //             select m;
            //var profile = from m in db.Profiles
            //                  //where m.Name == "name 2"
            //              where m.OwnerId == _userId
            //              select m;


            var service = CreateProfileService();

            var model = service.GetUserProfile(userName);

            return View(model);
            //return View();
        }

        // GET: Profiles/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Profile profile = db.Profiles.Find(id);
        //    if (profile == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(profile);
        //}

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        private ProfilesService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfilesService(userId);
            return service;
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerId,Name,Summary,Url,ImageUrl")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                var checkHttp = profile.Url.Substring(0, 8);
                if (checkHttp != "https://")
                {
                    profile.Url = "https://" + profile.Url;
                }
                profile.OwnerId = Guid.Parse(User.Identity.GetUserId());
                profile.Email = User.Identity.Name;
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);

            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerId,Name,Summary,Url,ImageUrl")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                var checkHttp = profile.Url.Substring(0, 8);
                if (checkHttp != "https://")
                {
                    profile.Url = "https://" + profile.Url;
                }
                profile.Email = User.Identity.Name;
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Profile profile = db.Profiles.Find(id);
        //    if (profile == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(profile);
        //}

        // POST: Profiles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Profile profile = db.Profiles.Find(id);
        //    db.Profiles.Remove(profile);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
