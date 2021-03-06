﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri202.Models;
using C_Bageri202.ViewModels;

namespace C_Bageri202.Controllers
{
    // hemsida/huvudsida
    public class HomeController : Controller
    {
        // access till klass Product via interfacet
        //private readonly IProduct accessProdukt;

        // constructor, indata är av typ interface 
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        //public HomeController(IProduct inAccessProdukt)
        //{
        //    accessProdukt = inAccessProdukt;
        //}

        // action-metod Index returnerar till view Index
        public IActionResult Index(int inId)
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Home Index 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Välkommen till ditt bageri på nätet!";

            // skickar rubrik till vyn Index
            return View(ViewBag);
        }
    }
}
