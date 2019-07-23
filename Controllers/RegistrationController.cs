using fyp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace fyp.Controllers
{
    public class RegistrationController : Controller
    {
       
        [HttpGet]
        public ActionResult Registration(int id = 0)
        {
            Player playerModel = new Player();
            return View(playerModel);
        }
        [HttpPost]
        public ActionResult Registration(Player playerModel)
        {
            using (TournamentEntities PlayerModel = new TournamentEntities())
            {
                if (PlayerModel.Players.Any(x => x.Username == playerModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already in use";
                    return View("Registration", playerModel);
                }
                if (PlayerModel.Players.Any(x => x.IGN == playerModel.IGN))
                {
                    ViewBag.DuplicateMessage = "IGN already in use";
                    return View("Registration", playerModel);
                }

                PlayerModel.Players.Add(playerModel);
                PlayerModel.SaveChanges();


            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("Registration", new Player());

        }
    }
}