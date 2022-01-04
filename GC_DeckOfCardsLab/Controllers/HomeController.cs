using GC_DeckOfCardsLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GC_DeckOfCardsLab.Controllers
{
    public class HomeController : Controller
    {
        CardDeckDAL db = new CardDeckDAL();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Draw()
        {
            Cards c = db.DrawCards();
            return View(c);
        }

        public IActionResult AddToHand(string[] cards)
        {
            db.AddToHand(cards);
            return RedirectToAction("ViewHand");
        }

        public IActionResult ViewHand()
        {
            CurrentHand c = db.ViewHand();
            return View(c);
        }

        public IActionResult ReturnAndShuffle()
        {
            db.ReturnAndShuffle();
            return RedirectToAction("Draw");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
