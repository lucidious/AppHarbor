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
        public ActionResult Create(WorkoutSetModel ws)
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

        public ActionResult Delete(string id)
        {
            return View(_db.GetWorkoutSetItem(id));
        }

        //
        // POST: /JsonCouchDB/Delete/5

        [HttpPost]
        public ActionResult Delete(WorkoutSetModel ws)
        {
            try
            {
                // TODO: Add delete logic here
                _db.DeleteWorkoutSetItem(ws);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
