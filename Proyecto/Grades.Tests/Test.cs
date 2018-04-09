using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clase01;

namespace Grades.Tests
{
   
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];
            AddGrades(grades);
        }

        public void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UpperCaseString()
        {
            string name = "Joe";
            name = name.ToUpper();
            Assert.AreEqual("JOE", name);
        }

        [TestMethod]
        public void addDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);
            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypePassByValue()
        {
            int x = 46;
            IncrementNumber(x);
            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypePassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);
        }

        private void GiveBookName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparaciones()
        {
            string name1 = "Renato";
            string name2 = "Renato";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesGuardanValor()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariableDeReferencia()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Renato";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
