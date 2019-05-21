﻿using GradeBook.Enums;
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
            else if (((grades[threshold * 2]) - 1) <= averageGrade)
                return 'B';
            else if (((grades[threshold * 3]) - 1) <= averageGrade)
                return 'C';
            else if (((grades[threshold * 4] ) - 1) <= averageGrade)
                return 'D';
            else
                return 'F';
        }
        /**
         In the RankedGradeBook class create an override for the GetLetterGrade method.
        The GetLetterGrade method returns a char and accepts a double named "averageGrade".
        If there are less than 5 students throw an InvalidOperationException.
        (Ranked-grading requires a minimum of 5 students to work)
        Return 'F' at the end of the method.
         * **/

        public override void CalculateStatistics()
        {
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
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
