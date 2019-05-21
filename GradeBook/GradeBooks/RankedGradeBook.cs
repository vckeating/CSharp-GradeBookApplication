using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5) {
                throw new InvalidOperationException("Ranked Grading requires 5 or more students.");
            }

            //Create the threshold to determine a drop in grade
            var threshold = (int) Math.Ceiling(Students.Count * 0.2);

            //Order the students by the Average grade in DESC order
            //Select only the AverageGrade for each Student
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            //Determine what grades the students will have
            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[((threshold * 2) - 1)] <= averageGrade)
                return 'B';
            else if (grades[((threshold * 3) - 1)] <= averageGrade)
                return 'C';
            else if (grades[((threshold * 4) - 1)] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count > 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count > 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override double GetGPA(char letterGrade, StudentType studentType)
        {
            return base.GetGPA(letterGrade, studentType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
