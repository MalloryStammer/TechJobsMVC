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

        // TODO #3: Create an action method to process a search request and render the updated search view.
        //route search/results
        //HttpPost
        //radial button sets searchtype, input sets search term

        //actionmethod search(string searchtype string search term)

        //if searchterm="" (empty string), find all jobs,
        //otherwise set search term to jobdata.findbycolumnandvalue

        public IActionResult SearchJobs(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (String.IsNullOrEmpty(searchTerm))
            { 
                jobs = JobData.FindAll();
            }

            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.jobs = jobs;
            ViewBag.title = "Jobs with " + searchTerm;


            return View();
        }

    }

}

