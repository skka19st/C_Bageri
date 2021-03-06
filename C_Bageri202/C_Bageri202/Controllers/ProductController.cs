﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri202.Models;
using C_Bageri202.ViewModels;

namespace C_Bageri202.Controllers
{
    // produkt-lista / detaljsida för produkt
    public class ProductController : Controller
    {
        // access till klass Product via interfacet
        private readonly IProduct accessProdukt;

        // constructor, indata är av typ interface 
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        public ProductController(IProduct inAccessProdukt)
        {
            accessProdukt = inAccessProdukt;
        }

        // action-metod List returnerar till view List
        public ViewResult List()
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Product List 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Produktlista";
            //ViewBag.Message = "Welcome to Pie shop";

            // skapar en instans av klassen ProductListViewModel
            // urval: alla produkter
            ProductListViewModel ProduktLista = new ProductListViewModel();
            ProduktLista.Lista = accessProdukt.AllProducts;

            // skickar data till vyn List
            return View(ProduktLista);
        }

        // action-metod Detail returnerar till view Detail
        public IActionResult Detail(int id)
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Product Detail 2.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Produktdetalj";

            Product produkt = accessProdukt.GetProductById(id);
            if (produkt == null)
            {
                // 404 - not found
                return NotFound();
            }

            // skickar data till vyn Detail
            return View(produkt);
        }
    }
}
