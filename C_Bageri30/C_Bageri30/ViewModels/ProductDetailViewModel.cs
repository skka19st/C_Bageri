﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Bageri30.Models;

namespace C_Bageri30.ViewModels
{
    public class ProductDetailViewModel
    {
        public Product ProductDetail { get; set; }

        // behöver skapa <List> av kommentarerna för att kunna 
        // kontrollera antalet kommentarer i html-koden
        public List<Commentary> CommentaryList { get; set; }

        // genomsnittsbetyg beräknas och formatteras 
        // innan det skickas till webben
        public string GradeAverage { get; set; }
    }
}
