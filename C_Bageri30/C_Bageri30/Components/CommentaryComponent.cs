using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri30.Models;
using Microsoft.AspNetCore.Mvc;

namespace C_Bageri30.Components
{
    // klassen måste vara public, non-abstract och non-nested
    // Components är som en mini-controller
    // har stöd av inpendency injection

    // en view components är tillägg till annan kod, ej självständig

    // hämtar data till ViewComponent för Commentary
    public class CommentaryComponent : ViewComponent
    {
        // access till klass Commentary via interfacet
        private readonly ICommentary accessCommentary;

        // constructor, indata är av typ interface 
        // accessCommentary = lokal variabel
        // inAccessCommentary = inkommande data
        public CommentaryComponent(ICommentary inAccessCommentary)
        {
            accessCommentary = inAccessCommentary;
        }

        // en tom Commentary skickas till webbsidan
        // som mall när html-koden byggs
        // skickar till ViewComponents/CommentaryComponent/Default.cshtml
        // måste heta Invoke eller InvokeAsync
        public IViewComponentResult Invoke()
        {
            Commentary localCommentary = new Commentary();
            localCommentary.Id = "";
            localCommentary.ProductId = 0;
            localCommentary.Text = "";

            return View(localCommentary);
        }
    }
}
