using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplyLearnCrud.Controllers
{
	public class HomeController : Controller
	{
		MVCCRUDDBContext _context = new MVCCRUDDBContext();
		public ActionResult Index()
		{
			var listOfData = _context.Students.ToList();
			return View(listOfData);
		}
		[HttpGet]
		public ActionResult Create()
		{ 
			return View();
		}
		[HttpPost]
		public ActionResult Create(Student model)
		{
			_context.Students.Add(model);
			_context.SaveChanges();
			ViewBag.Message = "Data insert successfully";
			return View();
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var data = _context.Students.Where(x =>x.StudentId == id).FirstOrDefault();
			return View(data);
		}
		[HttpPost]
		public ActionResult Edit(Student Model)
		{
			var data=_context.Students.Where(x=>x.StudentId==Model.StudentId).FirstOrDefault();
			if(data!=null)
			{
				data.StudentCity = Model.StudentCity;
				data.StudentName = Model.StudentName;
				data.StudentFees = Model.StudentFees;
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		public ActionResult Detail(int id)
		{
			var data=_context.Students.Where(x=>x.StudentId==id).FirstOrDefault();
			return View(data);
		}
		public ActionResult Delete(int? id)
		{
			var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
			_context.Students.Remove(data);
			_context.SaveChanges();
			ViewBag.Message = "Record delete successfully";
			return RedirectToAction("index");
		}

	
	}
}