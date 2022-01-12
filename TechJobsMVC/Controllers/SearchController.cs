using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        //[HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            
            if (String.IsNullOrEmpty(searchTerm))
            { 
                jobs = JobData.FindAll();
                ViewBag.title = "All Available Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.jobs = jobs;
            ViewBag.title = "Jobs with  ' " + searchTerm+ " ' ";
            ViewBag.columns = ListController.ColumnChoices;
            return View("Index");
        }
    }
}

