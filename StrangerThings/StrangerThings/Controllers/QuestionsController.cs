using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StrangerThings.DAL;
using StrangerThings.Models;

namespace StrangerThings.Controllers
{
    public class QuestionsController : Controller
    {
        private StrangerThingsContext db = new StrangerThingsContext();

        // GET: Questions
        //Passing in an id so the index will only show question related with the character.
        public ActionResult Index(int? id)
        {
            //If no ID is passed, a bad request page is shown
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Create a new list of questions to pass into the index view 
            var questions = new List<Question>();

            //Go through all the questions in the database and only add questions related to the character
            foreach(var q in db.Questions)
            {
                if(q.CharacterID == id)
                {
                    questions.Add(q);
                }
            }

            //Add the character to the viewbag and the character full name to the viewbag
            ViewBag.Character = db.Characters.Find(id);
            ViewBag.CharacterFullName = ViewBag.Character.CharacterFirstName + " " + ViewBag.Character.CharacterLastName;

            return View(questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create(int? id)
        {
            //If no ID is passed, a bad request page is shown
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Find the character and add it to the viewbag
            ViewBag.Character = db.Characters.Find(id);
            ViewBag.CharacterFullName = ViewBag.Character.CharacterFirstName + " " + ViewBag.Character.CharacterLastName;

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = question.CharacterID });
            }

            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterFirstName", question.CharacterID);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterFirstName", question.CharacterID);
            return View(question);
        }

        // GET: Questions/EditAnswer/5
        public ActionResult EditAnswer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }

            //Find the character and add it to the viewbag
            ViewBag.Character = db.Characters.Find(question.CharacterID);
            ViewBag.CharacterFullName = ViewBag.Character.CharacterFirstName + " " + ViewBag.Character.CharacterLastName;

            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,UserID,CharacterID,QuestionDescription,Answer")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterFirstName", question.CharacterID);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnswer(int id, string answer)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Find(id).Answer = answer;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = db.Questions.Find(id).CharacterID });
            }

            return View(db.Questions.Find(id));
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = question.CharacterID });
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
