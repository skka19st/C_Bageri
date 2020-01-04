using NUnit.Framework;
using System;
using System.Collections.Generic;
using C_Bageri30.Models;

using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;


namespace C_Bageri30_Test
{
    public class TestCountAverage
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRoundupOK()
        {
            // Arrange 
            List<Grades> gradesList = new List<Grades>();
            Grades gradeSingle = new Grades();
            Grades gradeSingle2 = new Grades();
            Grades gradeSingle3 = new Grades();

            gradeSingle.Id = "1";
            gradeSingle.ProductId = 1;
            gradeSingle.Grade = 1;
            gradesList.Add(gradeSingle);

            gradeSingle2.Id = "3";
            gradeSingle2.ProductId = 1;
            gradeSingle2.Grade = 3;
            gradesList.Add(gradeSingle2);

            gradeSingle3.Id = "4";
            gradeSingle3.ProductId = 1;
            gradeSingle3.Grade = 4;
            gradesList.Add(gradeSingle3);

            // Act
            List<int> gradeListInt = new List<int>();
            foreach (Grades rad in gradesList)
            {
                gradeListInt.Add(rad.Grade);
            }

            double gradeNum = gradeListInt.Average();
            string roundNo1 = gradeNum.ToString();
            string roundNo = roundNo1.Substring(0,1);
            string roundYes = Math.Round(gradeNum).ToString();

            // Assert          
            Assert.That(roundNo == "2", "oförväntad avrundning");
            Assert.That(roundYes == "3", "oförväntad avrundning");
        }

        [Test]
        public void TestRoundupNotOK()
        {
            // Arrange 
            List<Grades> gradesList = new List<Grades>();
            Grades gradeSingle = new Grades();
            Grades gradeSingle2 = new Grades();
            Grades gradeSingle3 = new Grades();

            gradeSingle.Id = "1";
            gradeSingle.ProductId = 1;
            gradeSingle.Grade = 1;
            gradesList.Add(gradeSingle);

            gradeSingle2.Id = "3";
            gradeSingle2.ProductId = 1;
            gradeSingle2.Grade = 3;
            gradesList.Add(gradeSingle2);

            gradeSingle3.Id = "4";
            gradeSingle3.ProductId = 1;
            gradeSingle3.Grade = 4;
            gradesList.Add(gradeSingle3);

            // Act
            List<int> gradeListInt = new List<int>();
            foreach (Grades rad in gradesList)
            {
                gradeListInt.Add(rad.Grade);
            }

            double gradeNum = gradeListInt.Average();
            string roundNo1 = gradeNum.ToString();
            string roundNo = roundNo1.Substring(0, 1);
            string roundYes = Math.Round(gradeNum).ToString();

            // Assert          
            Assert.That(roundNo != "3", "oförväntad avrundning");
            Assert.That(roundYes != "2", "oförväntad avrundning");
        }
    }
}
