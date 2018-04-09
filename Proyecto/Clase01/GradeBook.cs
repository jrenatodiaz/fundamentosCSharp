using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase01
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        //public string Name
        //{
        //    get
        //    {
        //        return _name;
        //    }
        //    set
        //    {
        //        if (!String.IsNullOrEmpty(value))
        //        {
        //            if (_name != value)
        //            {
        //                NameChangedEventArgs args = new NameChangedEventArgs();
        //                args.ExistingName = _name;
        //                args.NewName = value;
        //                NameChanged(this, args);
        //            }
        //            _name = value;
        //        }
        //    }
        //}

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;
                    NameChanged(this, args);
                }
                _name = value;
            }
        }


        //public void AddGrade(float grade)
        //{
        //    grades.Add(grade);
        //}

        public event NameChangeDelegate NameChanged;
        private string _name;
        //private List<float> grades;
        protected List<float> grades;

        //public virtual GradeStatistics ComputeStatistics()
        //{
        //    Console.WriteLine("GradeBook::ComputeStatistics");
        //    GradeStatistics stats = new GradeStatistics();

        //    float sum = 0;
        //    foreach(float grade in grades)
        //    {
        //        stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
        //        stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
        //        sum += grade;   
        //     }
        //    stats.AverageGrade = sum / grades.Count;
        //    return stats;
        //}

        //internal void WriteGrades(TextWriter destination)
        //{
        //    for (int i = grades.Count; i > 0; i--)
        //    {
        //        destination.WriteLine(grades[i - 1]);
        //    }
        //}

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public override IEnumerator GetEnumerator()
        {
           return grades.GetEnumerator();
        }

        public static float MininumGrade = 0;
        public static float MaxinumGrade = 100;

    }
}
