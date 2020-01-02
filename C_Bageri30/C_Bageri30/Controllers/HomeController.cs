using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri30.Models;
using C_Bageri30.ViewModels;

namespace C_Bageri30.Controllers
{
    // hemsida/huvudsida
    public class HomeController : Controller
    {
        // action-metod Index returnerar till view Index
        public IActionResult Index(int inId)
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Home Index 3.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Välkommen till ditt bageri på nätet!";

            // skickar rubrik till vyn Index
            return View(ViewBag);
        }
    }
}
