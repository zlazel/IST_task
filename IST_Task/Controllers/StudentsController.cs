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
    public class StudentsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.School);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NID,FullName,Birthdate,SchoolId")] StudentVM studentVm)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    NID = studentVm.NID,
                    FullName = studentVm.FullName,
                    Birthdate = studentVm.Birthdate,
                    SchoolId = studentVm.SchoolId
                };

                db.Students.Add(student);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return RedirectToAction("Index");
            }

            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Name", studentVm.SchoolId);
            return View(studentVm);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var studentVm = new StudentVM
            {
                Id =  student.Id,
                NID =  student.NID,
                FullName = student.FullName,
                Birthdate = student.Birthdate,
                SchoolId= student.SchoolId
            };
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Name", student.SchoolId);
            return View(studentVm);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NID,FullName,Birthdate,SchoolId")] StudentVM studentVm)
        {
            if (ModelState.IsValid)
            {
                var student = db.Students.Find(studentVm.Id);
                if (student == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                student.NID = studentVm.NID;
                student.FullName = studentVm.FullName;
                student.Birthdate = studentVm.Birthdate;
                student.SchoolId= studentVm.SchoolId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Name", studentVm.SchoolId);
            return View(studentVm);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
