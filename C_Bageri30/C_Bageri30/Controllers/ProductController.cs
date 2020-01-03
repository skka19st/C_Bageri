﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri30.Models;
using C_Bageri30.ViewModels;

namespace C_Bageri30.Controllers
{
    //produkt-lista / detaljsida för produkt

    /* 
    IActionResult är en superklass, med underliggande klasser ViewResult och RedirectToAction

     metoden 'ViewResult List' samlar ihop och skickar data till view 
     metoden 'RedirectToActionResult("Index", "Home", new { id="1", Text="kommentar" })' 
          "Index" = actionmetod, "Home" = Controller(default är nuvarande), 
          "new...." = variabler som skickas med till anropad funktion/metod

     'return view' skickar data till vy med samma namn som metoden
          vyn ligger under mapp med samma namn som controllern som skickar data
     'return ActionResult' ??? 
    */

    public class ProductController : Controller
    {
        // access till klasser via interface
        private readonly IProduct accessProdukt;
        private readonly ICommentary accessCommentary;
        private readonly IGrades accessGrades;

        // constructor, indata är av typ interface 
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        public ProductController(IProduct inAccessProdukt,
                                ICommentary inAccessCommentary,
                                IGrades inAccessGrades)
        {
            accessProdukt = inAccessProdukt;
            accessCommentary = inAccessCommentary;
            accessGrades = inAccessGrades;
        }

        // action-metod List returnerar till view List
        public ViewResult List()
        {
            // skickar med fliknamnet till webben
            ViewBag.Title = "Product List 3.0";

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
        public ViewResult Detail(int id)  
        {

            // skickar med fliknamnet till webben
            ViewBag.Title = "Product Detail 3.0";

            // rubrik till webbsidan
            ViewBag.Rubrik = "Produktdetalj";

            // information som ska till webbsidan:
            // info om vald produkt + produktens samtliga kommentarer
            // även betygsgenomsnitt ska beräknas och skickas med

            // en <List> måste initieras (med new) innan den kan användas
            // även om den ska tilldelas värde med direkt
            ProductDetailViewModel localProductViewModel = new ProductDetailViewModel();
            localProductViewModel.CommentaryList = new List<Commentary>();


            // hämta önskad produkt
            Product produkt = accessProdukt.GetProductById(id);
            localProductViewModel.ProductDetail = produkt;

            // hämta kommentarer för produkten
            IEnumerable<Commentary> localCommentary;
            localCommentary = accessCommentary.GetCommentaryByProduct(id);
            localProductViewModel.CommentaryList = localCommentary.ToList();

            // hämta produktens samtliga betyg
            IEnumerable<Grades> localGradesIENum;
            localGradesIENum = accessGrades.GetGradesByProduct(id);

            // betygen måste vara av typen List<int> för att beräknas
            // en <List> måste initieras (med new) innan den kan användas
            // även om den ska tilldelas värde med direkt
            List<int> gradeList = new List<int>();
            foreach(Grades rad in localGradesIENum)
            {
                gradeList.Add(rad.Grade);
            }

            // beräkna genomsnittet för betygen
            // avrundat resultat omvandlas till string
            if (gradeList.Count > 0)
            {
                double gradeNum = gradeList.Average();
                localProductViewModel.GradeAverage = Math.Round(gradeNum).ToString();
            } else
            {
                localProductViewModel.GradeAverage = "inget betyg angivet";
            }

            // ???
            //List<int> test = new List<int>();
            //test.Add(18);
            //test.Add(20);
            //test.Add(30);

            //double svar = test.Average();
            //double svarAvrundat = Math.Round(svar);
            //string svarstring = svarAvrundat.ToString();


            // skickar data till vyn Detail
            return View(localProductViewModel);
            //return ActionResult()
        }

        // action-metod AddCommentaryController returnerar vidare till 
        // action-metod Detail
        public RedirectToActionResult AddCommentaryController(int id, string text)
        {
            // en kommentar ska läggas till, behöver en mall
            Commentary localCommentar = new Commentary();

            // generera id till Commentary-klassen
            localCommentar.Id = Guid.NewGuid().ToString();

            // lägg in produktid och text som kommer från webbsidan
            localCommentar.ProductId = id;
            localCommentar.Text = text;

            // lägg till ny kommentar i databasen
            accessCommentary.AddCommentary(localCommentar);

            // action-metod AddCommentaryController returnerar vidare till 
            // actionmetod 'Detail' i Controller 'Product' med värdet id
            return RedirectToAction("Detail","Product", new { id = id });
        }

        // action-metod AddGradeController returnerar vidare till 
        // action-metod Detail
        public RedirectToActionResult AddGradeController(int id, string grade)
        {
            // ett betyg ska läggas till, behöver en mall
            Grades localGrade = new Grades();

            // generera id till Grades-klassen
            localGrade.Id = Guid.NewGuid().ToString();

            // lägg in produktid och betyg som kommer från webbsidan
            localGrade.ProductId = id;
            localGrade.Grade = Convert.ToInt32(grade);

            // lägg till nytt betyg i databasen
            accessGrades.AddGrades(localGrade);

            // action-metod AddGradesController returnerar vidare till 
            // actionmetod 'Detail' i Controller 'Product' med värdet id
            return RedirectToAction("Detail", "Product", new { id = id });
        }
    }
}