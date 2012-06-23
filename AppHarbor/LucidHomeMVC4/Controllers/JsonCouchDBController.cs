using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LucidHomeMVC4.Models;

namespace LucidHomeMVC4.Controllers
{
    [Authorize]
    public class JsonCouchDBController : Controller
    {

        WebAPICouchDBService _db = new WebAPICouchDBService();

        //
        // GET: /JsonCouchDB/

        public ActionResult Index()
        {
            return View(_db.GetWorkoutSetList());
        }

        //
        // GET: /JsonCouchDB/Details/5

        public ActionResult Details(string id)
        {
            return View(_db.GetWorkoutSetItem(id));
        }

        //
        // GET: /JsonCouchDB/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /JsonCouchDB/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /JsonCouchDB/Edit/5

        public ActionResult Edit(string id)
        {
            return View(_db.GetWorkoutSetItem(id));
        }

        //
        // POST: /JsonCouchDB/Edit/5

        [HttpPost]
        public ActionResult Edit(WorkoutSetModel ws)
        {
            try
            {
                _db.SaveWorkoutSetItem(ws);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /JsonCouchDB/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /JsonCouchDB/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
