using CommentProj.Models;
using CommentProj.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CommentProj.Controllers
{
    public class CommentsController : Controller
    {
        public IRepository Repository;

        public CommentsController()
        {
            this.Repository = new CommentRepository(new Infrastracture.CommentContext());
        }

        public ActionResult Index()
        {
            return View(Repository.GetAll());
        }

        private List<SelectListItem> CountryChoice(string selectedValue = "")
        {
            List<string> values = new List<string>() { "Ukraine", "Russia", "EU", "USA" };

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in values)
            {
                list.Add(new SelectListItem
                {
                    Text = e,
                    Value = e,
                    Selected = e == selectedValue
                });
            }
            return list;
        }

        private List<SelectListItem> IsPositiveChoice(string selectedValue = "")
        {
            List<string> values = new List<string>() { "Positive", "Negative" };

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in values)
            {
                list.Add(new SelectListItem
                {
                    Text = e,
                    Value = e,
                    Selected = e == selectedValue
                });
            }
            return list;
        }
        public ActionResult DisplayListOfComments(int id)
        {
            return View(Repository.GetAllSubComments(id));
        }

        public ActionResult Create()
        {
            ViewBag.IsPositive = IsPositiveChoice();
            ViewBag.Country = CountryChoice();
            ViewBag.TimeOfCreation = DateTime.Now;
            return View(new Comment());
        }

        [HttpPost]
        public ActionResult Create(Comment model)
        {
            model.TimeOfCreation = DateTime.Now;
            Repository.Create(model);
            return RedirectToAction("Index");
        }

        public ActionResult CreateSubComment(int id)
        {
            Comment subComment = new Comment();
            subComment.MainCommentId = id;
            ViewBag.IsPositive = IsPositiveChoice();
            ViewBag.Country = CountryChoice();
            ViewBag.TimeOfCreation = DateTime.Now;
            return View(subComment);
        }

        [HttpPost]
        public ActionResult CreateSubComment(Comment model)
        {
            model.TimeOfCreation = DateTime.Now;
            Repository.Create(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Comment entityObject = Repository.GetId(id);
            ViewBag.IsPositive = IsPositiveChoice();
            ViewBag.Country = CountryChoice();
            return View(entityObject);
        }

        [HttpPost]
        public ActionResult Edit(Comment model)
        {
            Repository.Update(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Comment entityObject = Repository.GetId(id);
            return View(entityObject);
        }

        [HttpPost]
        public ActionResult Delete(Comment model)
        {
            Comment entityObject = Repository.GetId(model.Id);
            Repository.Delete(entityObject);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Comment entityObject = Repository.GetId(id);
            return View(entityObject);
        }

        List<SelectListItem> CreateParentNamesSelectList(string selectedValue = "")
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (string e in Repository.GetAllByName())
            {
                list.Add(new SelectListItem
                {
                    Text = e,
                    Value = e,
                    Selected = e == selectedValue
                });
            }
            return list;
        }
    }
}