using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase01
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Your name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Hellow, " + name);


            //GradeBook book = new GradeBook();
            //ThrowAwayGradeBook book = new ThrowAwayGradeBook();
            //GradeTracker book = new GradeTracker();
            //AddGrades(book);
            //SaveGrades(book);
            //WriteResults1(book);

            //GradeTracker book = CreateGradeBook();
            IGradeTracker book = CreateGradeBook();
            
            AddGrades(book);
            SaveGrades(book);
            WriteResults1(book);

            //book.NameChanged += new NameChangeDelegate(OnNameChanged);
            //book.NameChanged += new NameChangeDelegate(OnNameChanged2);

            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;

            //book.AddGrade(91);
            //book.AddGrade(89.5f);

            //GradeStatistics stats = book.ComputeStatistics();

            //GradeBook book2 = book;
            //book2.AddGrade(75);

            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.HighestGrade);
            //Console.WriteLine(stats.LowestGrade);
            //Console.WriteLine(GradeBook.MaxinumGrade);
            //Console.ReadKey();

            //GradeBook g1 = new GradeBook();
            //GradeBook g2 = g1;
            //g1 = new GradeBook();
            //g1.Name = "Joe";
            //Console.WriteLine(g2.Name);

            //book.Name = "Renato Book";
            //book.Name = null;
            //book.Name = "Book";

            //GradeStatistics stats = book.ComputeStatistics();

            //Console.WriteLine(book.Name);

            //WriteResult("Average", stats.AverageGrade);
            //WriteResult("Highest", stats.HighestGrade);
            //WriteResult("Lowest", stats.LowestGrade);
            //WriteResult(stats.Description, stats.LetterGrade);


            Console.ReadKey();
        }

        private static void WriteResults1(IGradeTracker book)
        {

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        private static GradeBook CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }


        public static void WriteResults1(GradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            //WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
          
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.75f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        //private static void SaveGrades(GradeBook book)
        //{
        //    using (StreamWriter outputFile = File.CreateText("grades.txt"))
        //    {
        //        book.WriteGrades(outputFile);
        //    }
        //    book.WriteGrades(Console.Out);
        //}

        //private static void AddGrades(GradeBook book)
        //{
        //    book.AddGrade(91);
        //    book.AddGrade(89.75f);
        //    book.AddGrade(75);
        //}

        //private static void GetBookName(GradeBook book)
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter a name");
        //        book.Name = Console.ReadLine();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch (NullReferenceException)
        //    {
        //        Console.WriteLine("Something went wrong!");
        //    }
        //}

        //private static void NewMethod(GradeBook book)
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter a name");
        //        book.Name = Console.ReadLine();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    catch (NullReferenceException)
        //    {
        //        Console.WriteLine("Something went wrong!");
        //    }
        //}

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        }

        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***");
        }


        public static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }


        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result:F2}", description, result);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F}", description, result);
        }

        
       
    }
}
