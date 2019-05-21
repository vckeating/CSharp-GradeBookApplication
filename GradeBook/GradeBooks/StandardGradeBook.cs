﻿using GradeBook.Enums;

namespace GradeBook.GradeBooks  
{
    public class StandardGradeBook : BaseGradeBook
    {

        public StandardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }

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

        public override char GetLetterGrade(double averageGrade)
        {
            return base.GetLetterGrade(averageGrade);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
