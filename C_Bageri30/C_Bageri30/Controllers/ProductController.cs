using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Bageri30.Models;
using C_Bageri30.ViewModels;

namespace C_Bageri30.Controllers
{
    // produkt-lista / detaljsida för produkt
    public class ProductController : Controller
    {
        // access till klass Product via interfacet
        private readonly IProduct accessProdukt;
        private readonly ICommentary accessCommentary;

        // constructor, indata är av typ interface 
        // accessProdukt = lokal variabel
        // inAccessProdukt = inkommande data
        public ProductController(IProduct inAccessProdukt,
                                ICommentary inAccessCommentary)
        {
            accessProdukt = inAccessProdukt;
            accessCommentary = inAccessCommentary;
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
        public IActionResult Detail(int id)
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
            if (produkt == null)
            {
                // 404 - not found
                return NotFound();
            }
            localProductView.ProductDetail = produkt;

            // hämta kommentarer för produkten
            IEnumerable<Commentary> localCommentary;
            localCommentary = accessCommentary.GetCommentaryByProduct(id);
            localProductView.CommentaryList = localCommentary.ToList();

            //Commentary localCommentary = new Commentary();
            //Commentary localCommentary2 = new Commentary();
            //Commentary localCommentary3 = new Commentary();

            //// generera id till Commentary-klassen
            //string testaId = Guid.NewGuid().ToString();
            //localCommentary.Id = "1";
            //localCommentary.ProductId = 1;
            //localCommentary.Text = testaId;
            //localProductView.CommentaryList.Add(localCommentary);

            //testaId = Guid.NewGuid().ToString();
            //localCommentary2.Id = "2";
            //localCommentary2.ProductId = 1;
            //localCommentary2.Text = testaId;
            //localProductView.CommentaryList.Add(localCommentary2);

            //testaId = Guid.NewGuid().ToString();
            //localCommentary3.Id = "3";
            //localCommentary3.ProductId = 1;
            //localCommentary3.Text = testaId;
            //localProductView.CommentaryList.Add(localCommentary3);

            // skickar data till vyn Detail
            return View(localProductView);
        }
    }
}