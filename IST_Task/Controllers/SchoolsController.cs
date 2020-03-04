using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IST_Task.DAL;
using IST_Task.Models;
using IST_Task.ViewModels;

namespace IST_Task.Controllers
{
    public class SchoolsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Schools
        public ActionResult Index()
        {
            return View(db.Schools.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] SchoolVM schoolVm)
        {
            if (ModelState.IsValid)
            {
                var school = new School
                {
                    Name = schoolVm.Name
                };

                db.Schools.Add(school);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return View(schoolVm);
                }
                return RedirectToAction("Index");
            }

            return View(schoolVm);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }

            var schoolVm = new SchoolVM {Id = school.Id, Name = school.Name};
            return View(schoolVm);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SchoolVM schoolVm)
        {
            if (ModelState.IsValid)
            {
             
                School school = db.Schools.Find(schoolVm.Id);
                if (school == null)
                {
                    return HttpNotFound();
                }

                school.Name = schoolVm.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schoolVm);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            School school = db.Schools.Find(id);
            db.Schools.Remove(school);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
