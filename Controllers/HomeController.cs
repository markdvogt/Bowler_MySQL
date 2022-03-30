using Bowler_MySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowler_MySQL.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }

        //Contructor
        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Teams = _context.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Form(Bowler b)
        {
            ViewBag.Teams = _context.Teams.ToList();

            _context.Add(b);
            _context.SaveChanges();

            return View("Confirmation", b);
        }

        [HttpGet]
        public IActionResult DataTable(string bowlerTeam) 
        {
            if (bowlerTeam is null)
            {
                ViewBag.Header = "Home";
            }
            else
            {
                ViewBag.Header = bowlerTeam;
            }
                

            var bowlerTable = _context.Bowlers
                .Where(x => x.Team.TeamName == bowlerTeam || bowlerTeam == null ) // Only get projects where they match the bowlerTeam selected or if none is selected show all 
                .Include(x => x.Team) //Inner join on Team model
                .OrderBy(x => x.BowlerFirstName)
                .ToList();

            return View(bowlerTable);
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid) //Put bowlerid as a parameter. This will recieve the specific formid when the user clicks on the edit button
        {
            ViewBag.Teams = _context.Teams.ToList(); //Need this line so that the form loads with the prepackaged list of Teams in the dropdown menu

            //The line below is going to fill the edit form with all of the information of the record that's already been entered intto the database.
            var response_to_edit = _context.Bowlers.Single(b => b.BowlerID == bowlerid);  //It's saying to go to blahContext, then to the Movies table in the database,
                                                                                        //then choose a single record in the table where the FormId is equal to the formid
                                                                                        //variable we made. This record is then packaged into a variable called "response_to_edit"

            return View("Form", response_to_edit); //You want to send them back to the Form.cshtml page WITH the data in the record you want to edit
        }

        [HttpPost]
        public IActionResult Edit(Bowler edited_record)
        {
            _context.Update(edited_record); //When the user clicks submit on the edited record, it will now update the context file and
                                               //database table with that edited record

            _context.SaveChanges(); //Save edits

            return RedirectToAction("DataTable");  //Use RedirectToAction instead of View because you've already set up a DataTable View in the
                                                   //HomeController that passes is all of the data. If you only used View("DataTable"); it would
                                                   //return an error because none of the data would be passed through
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var response_to_delete = _context.Bowlers.Single(b => b.BowlerID == bowlerid);

            return View(response_to_delete);
        }

        [HttpPost]
        public IActionResult Delete(Bowler del) //This loads the object you want to delete into the variable "del"
        {
            _context.Bowlers.Remove(del); //Go to blahContext, then the Movies table, then remove the record stored in the "del" variable
            _context.SaveChanges();

            return RedirectToAction("DataTable");
        }

    }
}