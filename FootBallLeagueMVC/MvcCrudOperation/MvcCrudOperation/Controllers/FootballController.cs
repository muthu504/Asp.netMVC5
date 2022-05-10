using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrudOperation.Context;

namespace MvcCrudOperation.Controllers
{
    public class FootballController : Controller
    {
        // GET: Football
        TestEntities dbobj=new TestEntities();
        public ActionResult Football()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFootball(FootBallLeague model)
        {
            if (ModelState.IsValid) {
                FootBallLeague footBallLeague = new FootBallLeague();
                footBallLeague.MatchId = model.MatchId;
                footBallLeague.TeamName1 = model.TeamName1;
                footBallLeague.TeamName2 = model.TeamName2;
                footBallLeague.MatchStatus = model.MatchStatus;
                footBallLeague.WinningTeam = model.WinningTeam;
                footBallLeague.Points = model.Points;
                dbobj.FootBallLeagues.Add(footBallLeague);
                dbobj.SaveChanges();
            }
            ModelState.Clear();


            return View("Football");
        }
    }
}