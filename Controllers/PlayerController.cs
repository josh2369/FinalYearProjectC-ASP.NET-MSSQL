using fyp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fyp.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            using (TournamentEntities PlayerModel = new TournamentEntities())
            {
                return View(PlayerModel.Players.ToList());
            }
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            using (TournamentEntities PlayerModel = new TournamentEntities())
            {
                return View(PlayerModel.Players.Where(x => x.PlayerID == id).FirstOrDefault());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                using (TournamentEntities PlayerModel = new TournamentEntities())
                {
                    PlayerModel.Players.Add(player);
                    PlayerModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Player/Edit/5
        public ActionResult Edit(int id, Player player)
        {
            try
            {
                using (TournamentEntities PlayerModel = new TournamentEntities())
                {
                    PlayerModel.Entry(player).State = EntityState.Modified;
                    PlayerModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            using (TournamentEntities PlayerModel = new TournamentEntities())
            {
                return View(PlayerModel.Players.Where(x => x.PlayerID == id).FirstOrDefault());
            }
        }
        // POST: Player/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                {
                    using (TournamentEntities PlayerModel = new TournamentEntities())
                    {
                        Player player = PlayerModel.Players.Where(x => x.PlayerID == id).FirstOrDefault();
                        PlayerModel.Players.Remove(player);
                        PlayerModel.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
