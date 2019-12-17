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

        public IActionResult Result(string searchType, string searchTerm)
        {
            // making a new list of dictionarys for results of the search
            List<Dictionary<string, string>> jobsResults = new List<Dictionary<string, string>>();

            // conditional statement to differentiate the need for find by column or find by value to create list of dictionaries with results
            if (searchType != "all")
            {
                jobsResults = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            else
            {
                jobsResults = JobData.FindByValue(searchTerm);
            }

            // so i've created this dictionary of results -- now WTF do I do with it

            return View("Index");

        }
            // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
