
using fyp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fyp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(fyp.Model.Player PlayerModel)


        {
            using (TournamentEntities db = new TournamentEntities())
            {
                var playerDetails = db.Players.Where(x => x.Username == PlayerModel.Username && x.Password == PlayerModel.Password).FirstOrDefault();
                if (playerDetails == null)
                {
                    PlayerModel.LoginError = "Your Username And Password Do Not Match";
                    return View("Index", PlayerModel);
                }
                else
                {
                    Session["PlayerID"] = playerDetails.PlayerID;
                    return RedirectToAction("Team", "Team");
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}