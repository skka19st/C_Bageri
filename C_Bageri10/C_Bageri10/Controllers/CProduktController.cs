using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri_10.Models;
using C_Bageri_10.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace C_Bageri_10.Controllers
{
    // koppling till model-klasserna
    public class CProduktController : Controller
    {
        // access till klass CProdukt via interfacet
        private readonly IProdukt accessProdukt;

        // constructor, indata är av typ interface 
        // interfacen är implementerade i (kopplade mot) 
        // mockdata (testdata)
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        public CProduktController(IProdukt inAccessProdukt)
        {
            accessProdukt = inAccessProdukt;
        }

        // action-metod List returnerar en vy
        // innehållet i vyn kommer från produkt-interfacet
        public ViewResult List()
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Bageri 1.0";
            ViewBag.Rubrik = "Produktlista";
            //ViewBag.Message = "Welcome to Pie shop";
            //ViewBag.CurrentCategory = "Cheese cakes";

            // skapar en instans av vy-modellen ProduktListaViewModel
            // hämtar data via interfacet för CProdukt 
            ProduktListaViewModel ProduktLista = new ProduktListaViewModel();
            ProduktLista.Lista = accessProdukt.AllaProdukter;

            // skickar data från vyn till webben
            return View(ProduktLista);
        }
    }
}