using System;
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
            // en <List> måste initieras (med new) innan den kan användas
            // även om den ska tilldelas värde med direkt
            ProductDetailViewModel localProductView = new ProductDetailViewModel();
            localProductView.CommentaryList = new List<Commentary>();

            // hämta önskad produkt
            Product produkt = accessProdukt.GetProductById(id);
            localProductView.ProductDetail = produkt;

            // hämta kommentarer för produkten
            IEnumerable<Commentary> localCommentary;
            localCommentary = accessCommentary.GetCommentaryByProduct(id);
            localProductView.CommentaryList = localCommentary.ToList();

            // hämta beräkna genomsnitt för produktens betyg
            IEnumerable<Grades> localGradesIENum;
            localGradesIENum = accessGrades.GetGradesByProduct(id);

            localProductView.CommentaryList = localCommentary.ToList();

            // ???
            //List<int> test = new List<int>();
            //test.Add(11);
            //test.Add(20);
            //test.Add(30);

            //double svar = test.Average();
            //string svarstring = svar.ToString();
            //double svar2 = svar(rou)

            // skickar data till vyn Detail
            return View(localProductView);
            //return ActionResult()

            //return RedirectToAction("Index", "Home", "new ");
            //return RedirectToAction("Index", "Home", new { id="1", Text="kommentar" });
            //return View(localProductView);   //return RedirectToAction("Index","Home","1")  actionmetod/controller/fragment
        }

        // action-metod AddCommentary returnerar vidare till 
        // action-metod Detail
        public RedirectToActionResult AddCommentary(int id, string text)
        {
            // en kommentar ska läggas till
            Commentary localCommentar = new Commentary();

            // generera id till Commentary-klassen
            localCommentar.Id = Guid.NewGuid().ToString();

            // lägg in produktid och text som kommer från webbsidan
            localCommentar.ProductId = id;
            localCommentar.Text = text;

            // lägg till ny kommentar i databasen
            accessCommentary.AddCommentary(localCommentar);

            // action-metod AddCommentary returnerar vidare till 
            // actionmetod 'Detail' i Controller 'Product' med värdet id
            return RedirectToAction("Detail","Product", new { id = id });
        }
    }
}