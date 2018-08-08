using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iBlog.Models;

namespace iBlog.Controllers
{
    public class BlogMenusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BlogMenus
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Index()
        {
            return View(db.BlogMenus.ToList());
        }

        // GET: BlogMenus/Details/5
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogMenu blogMenu = db.BlogMenus.Find(id);
            if (blogMenu == null)
            {
                return HttpNotFound();
            }
            return View(blogMenu);
        }

        // GET: BlogMenus/Create
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Create([Bind(Include = "id,title,content,privatePost")] BlogMenu blogMenu)
        {
            if (ModelState.IsValid)
            {
                db.BlogMenus.Add(blogMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogMenu);
        }

        // GET: BlogMenus/Edit/5
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogMenu blogMenu = db.BlogMenus.Find(id);
            if (blogMenu == null)
            {
                return HttpNotFound();
            }
            return View(blogMenu);
        }

        // POST: BlogMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Edit([Bind(Include = "id,title,content,privatePost")] BlogMenu blogMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogMenu);
        }

        // GET: BlogMenus/Delete/5
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogMenu blogMenu = db.BlogMenus.Find(id);
            if (blogMenu == null)
            {
                return HttpNotFound();
            }
            return View(blogMenu);
        }

        // POST: BlogMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogMenu blogMenu = db.BlogMenus.Find(id);
            db.BlogMenus.Remove(blogMenu);
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
