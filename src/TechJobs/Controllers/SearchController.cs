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
            // needed for the top portion of the search bar to work
            ViewBag.columns = ListController.columnChoices;
            // changed the title of the page to results bc why not
            ViewBag.title = "Results";

            /* conditional statement to differentiate the need for find by column
             * or find by value to create list of dictionaries for search results */

            // if they pick a specific column to search by
            if (searchType != "all")
            {
                jobsResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                // creating my ViewBag for use in the cs.html
                ViewBag.jobsResults = jobsResults;
            }
            else // user wan'ts to search across all columns
            {
                jobsResults = JobData.FindByValue(searchTerm);
                // creating my ViewBag for use in the cs.html
                ViewBag.jobsResults = jobsResults;
            }

            // returning the correct view / html template
            return View("Views/Search/Index.cshtml");


        }
            // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
