using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Entities;
using WebApplication1.Models.Services;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
     

        public PersonController()
        {
            _personService = new PersonService();
        }

       
        [HttpGet]
        public ActionResult Person(string sortOrder)
        {
            List<Person> newList = new List<Person>();
            PersonViewModel model = new PersonViewModel();
            model.People = _personService.GetList();
            if (model.People.Count == 0)
            {
                model.People = _personService.createStartList();
             
            }
           
            ViewBag.Name = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.City = sortOrder == "City" ? "City_desc" : "City";

            IEnumerable<Person> listCopy = new List<Person>();
            
            switch (sortOrder)
            {
                case "Name_desc":
                    listCopy = model.People.OrderByDescending(person => person.Name);
                    break;
                case "City":
                    listCopy = model.People.OrderBy(person => person.City);
                    break;
                case "City_desc": 
                    listCopy = model.People.OrderByDescending(person => person.City);
                    break;
                default:
                    listCopy = model.People.OrderBy(person => person.Name);
                    break;
            }

            foreach (var item in listCopy)
            {
                newList.Add(item); 
            }

            _personService.DeleteAll();
            foreach (var item in newList)
            {
                _personService.GetList().Add(item);
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Person(CreatePersonViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _personService.Add(createViewModel);

                if (person == null)
                {
                    ModelState.AddModelError("Storage", "Failed to save");
                }
            }
            PersonViewModel model = new PersonViewModel();

            model.CreateViewModel = createViewModel;
            model.People = _personService.GetList();

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            bool success = _personService.Delete(id);


            return RedirectToAction(nameof(Person));
        }

        
        [HttpPost]
        public ActionResult Search(PersonViewModel personViewModel)
        {
            string input;
            List<Person> result;
            var model = personViewModel.CreateViewModel;
            
            if (string.IsNullOrWhiteSpace(model.Name) && 
                string.IsNullOrWhiteSpace(model.City))
            {
                _personService.DeleteAll();
                foreach (var item in _personService.GetList2())
                {
                    _personService.GetList().Add(item);
                }
                return RedirectToAction("Person");
            }

            input = model.Name + model.City;
            
            result = _personService.Search(input);
            
            if (result.Count!=0)
                _personService.DeleteAll();

            foreach(var item in result)
            {
                _personService.GetList().Add(item);
            }
         
            return RedirectToAction("Person");
        }


        //Partial view action
        [HttpGet]
        public ActionResult PersonList()
        {
            List<Person> lst = _personService.GetList();
            if (lst.Count == 0)
                lst = _personService.createStartList();
            return PartialView("_partialIndex", lst);
        }

        //Partial view action
        [HttpPost]
        public ActionResult PersonDetails(int id)
        {
            Person person = _personService.GetById(id);
            List<Person> lst = new List<Person>();
            lst.Add(person);

            return PartialView("_partialIndex", lst);
        }

        //Partial view action
        [HttpPost]
        public ActionResult PersonDelete(string id)
        {
            bool success = _personService.Delete(Int32.Parse(id));
            try
            {
                if (success)
                    return Json(new
                    { 
                        msg = "Successfully removed person with id "+id
                    });
                else
                    return Json(new
                    {
                        msg = "Attempt to remove person with id "+id+" failed"
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
