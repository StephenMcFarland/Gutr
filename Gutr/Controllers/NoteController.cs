﻿using Gutr.Models;
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
        public ActionResult Index()
        {
            var model = new NoteListItem[0];
            return View();
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }
    }
}