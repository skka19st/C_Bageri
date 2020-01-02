using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri30.Models;
using C_Bageri30.ViewModels;

namespace C_Bageri30.Controllers
{
    // kommentarlista per produkt / tillägg av kommentar
    public class CommentaryController : Controller
    {
        //// access till klass Commentary via interfacet
        //private readonly ICommentary accessCommentary;

        //// constructor, indata är av typ interface 
        //// accessCommentary = lokal variabel
        //// inAccessCommentary = inkommande data
        //public CommentaryController(ICommentary inAccessCommentary)
        //{
        //    accessCommentary = inAccessCommentary;
        //}

        //// action-metod List returnerar till view List
        //public ViewResult List()
        //{
        //    // skickar med fliknamnet till webben
        //    ViewBag.Title = "Product List 3.0";

        //    // rubrik till webbsidan
        //    ViewBag.Rubrik = "Produktlista";
        //    //ViewBag.Message = "Welcome to Pie shop";

        //    // skapar en instans av klassen ProductListViewModel
        //    // urval: alla produkter
        //    ProductListViewModel ProduktLista = new ProductListViewModel();
        //    ProduktLista.Lista = accessProdukt.AllProducts;

        //    // skickar data till vyn List
        //    return View(ProduktLista);
        //}
    }
}
