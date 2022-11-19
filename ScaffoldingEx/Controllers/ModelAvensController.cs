using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScaffoldingEx.Models;

namespace ScaffoldingEx.Controllers
{
    public class ModelAvensController : Controller
    {
        private ModelAvenContext db = new ModelAvenContext();

        // GET: ModelAvens
        public ActionResult Index()
        {
            return View(db.modelAvens.ToList());
        }

        // GET: ModelAvens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelAven modelAven = db.modelAvens.Find(id);
            if (modelAven == null)
            {
                return HttpNotFound();
            }
            return View(modelAven);
        }

        // GET: ModelAvens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelAvens/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,HeroName,Age")] ModelAven modelAven)
        {
            if (ModelState.IsValid)
            {
                db.modelAvens.Add(modelAven);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelAven);
        }

        // GET: ModelAvens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelAven modelAven = db.modelAvens.Find(id);
            if (modelAven == null)
            {
                return HttpNotFound();
            }
            return View(modelAven);
        }

        // POST: ModelAvens/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,HeroName,Age")] ModelAven modelAven)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelAven).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelAven);
        }

        // GET: ModelAvens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelAven modelAven = db.modelAvens.Find(id);
            if (modelAven == null)
            {
                return HttpNotFound();
            }
            return View(modelAven);
        }

        // POST: ModelAvens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelAven modelAven = db.modelAvens.Find(id);
            db.modelAvens.Remove(modelAven);
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
