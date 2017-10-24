using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dentist;

namespace Dentist.Controllers
{
    public class CUSTOMERController : Controller
    {
        private Dentist_Entities db = new Dentist_Entities();

        public ActionResult Index()
        {
            if (Session["AdminID"] != null)
            {
                var customer = db.CUSTOMERS.Include(c => c.DOCTOR);
                return View(customer.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }


        public ActionResult Create()
        {
            ViewBag.DOCTORID = new SelectList(db.DOCTORS, "DOCTOID", "NAME");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUSTOMERID,NAME,SURNAME,DOB,ADDRESS,STREET,POSTCODE,MOBILE,DOCTORID")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERS.Add(cUSTOMER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOCTORID = new SelectList(db.DOCTORS, "DOCTOID", "NAME", cUSTOMER.DOCTORID);
            return View(cUSTOMER);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOCTORID = new SelectList(db.DOCTORS, "DOCTOID", "NAME", cUSTOMER.DOCTORID);
            return View(cUSTOMER);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CUSTOMERID,NAME,SURNAME,DOB,ADDRESS,STREET,POSTCODE,MOBILE,DOCTORID")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOCTORID = new SelectList(db.DOCTORS, "DOCTOID", "NAME", cUSTOMER.DOCTORID);
            return View(cUSTOMER);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER customer = db.CUSTOMERS.Find(id);
            //CUSTOMER customer = db.CUSTOMERS.Include(c => c.DOCTOR)
            //.Where(i => i.DOCTORID == id)
            //.Single();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER customer = db.CUSTOMERS.Find(id);
            //CUSTOMER customer = db.CUSTOMERS.Include(i => i.DOCTORID).Where(i => i.DOCTORID == id).Single();
            db.CUSTOMERS.Remove(customer);
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
