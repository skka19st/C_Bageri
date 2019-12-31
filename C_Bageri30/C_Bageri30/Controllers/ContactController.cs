using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bager30.Models;
using C_Bager30.ViewModels;

namespace C_Bager30.Controllers
{
    // kontaktinfo
    public class ContactController : Controller
    {
        // access till klass Contact via interfacet
        private readonly IContact accessKontakt;

        // constructor, indata är av typ interface 
        // accessKontakt = lokal variabel
        // inAccessKontakt = inkommande data
        public ContactController(IContact inAccessKontakt)
        {
            accessKontakt = inAccessKontakt;
        }

        // action-metod Detail returnerar till view Detail
        // finns enbart en kontakt, men Id=1 används vid 
        // databas-anrop med hänsyn till primaryKey
        public IActionResult Detail(int inId)
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Contact Detail 3.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Kontakta oss";

            // för att säkerställa värdet på id
            inId = 1;
            Contact kontakt = accessKontakt.GetContactById(inId);
            if (kontakt == null)
            {
                // 404 - not found
                return NotFound();
            }

            // skickar data till vyn Detail
            return View(kontakt);
        }
    }
}
