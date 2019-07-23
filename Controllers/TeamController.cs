
using fyp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fyp.Controllers
{
    public class TeamController : Controller
    {
        TournamentEntities db = new TournamentEntities();
        public ActionResult Team(string searching)
        {

            return View(db.Players.Where(x => x.Role.Contains(searching) || searching == null).ToList());
        }

    }
}