using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            // making a new list of dictionarys for results of the search
            List<Dictionary<string, string>> jobsResults = new List<Dictionary<string, string>>();

            // conditional statement to differentiate the need for find by column or find by value to create list of dictionaries with results
            if (searchType != "all")
            {
                jobsResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobsResults = jobsResults;
            }
            else
            {
                jobsResults = JobData.FindByValue(searchTerm);
                ViewBag.jobsResults = jobsResults;
            }

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Results";
            return View("Views/Search/Index.cshtml");


        }
            // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
