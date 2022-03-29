using Bowler_MySQL.Models;
using Microsoft.AspNetCore.Mvc;
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
        private IBowlersRepository _repo { get; set; }

        //Contructor
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Bowlers
                .ToList();

            return View(blah);
            //List<Team> teams = _repo.Teams.ToList();

            //List<Bowler> bowlers = _repo.Bowlers
            //    .Include(x)
            //    .OrderBy(x => x.TeamID)
            //    .ToList();

            //return View(bowlers);
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Bowler b)
        {
            return View("Confirmation", b);
        }
    }
}


//public IActionResult Index()
//{
//    var blah = _repo.Bowlers
//        .ToList();

//    return View(blah);
//}