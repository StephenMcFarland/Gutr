using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gutr.Models;

namespace Gutr.Controllers
{
    public class MultiDataController : Controller
    {
        // GET: MultiData
        public ActionResult MultiData()
        {
            //pubsEntities obj = new pubsEntities();
            //var myModel = new MultiData();
            //myModel.Notes = obj.Note.ToList();
            //myModel.Profiles = obj.Profile.ToList();
            return View();
        }
    }
}