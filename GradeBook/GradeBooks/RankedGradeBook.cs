﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            List<double> GradeStudentList = new List<double>();
            var studentSize = Students.Count;
            if (studentSize < 5)
            {
                throw new InvalidOperationException();
            }

            foreach (var student in Students)
            {
                GradeStudentList.Add(student.AverageGrade);
            }

            GradeStudentList.Sort();
            GradeStudentList.Reverse();

            int position = 0;
            foreach (var grade in GradeStudentList)
            {
                if (averageGrade <= grade)
                {
                    position++;
                }
                else
                {
                    break;
                }
            }

            var top20 = (int)Math.Ceiling((0.2 * studentSize));
            var top20Plus = top20;
            if(position <= top20)
            {
                return 'A';
            }
            else
            {
                top20Plus += top20;
                if(position <= top20Plus)
                {
                    return 'B';
                }
                else
                {
                    top20Plus += top20;
                    if (position <= top20Plus)
                    {
                        return 'C';
                    }
                    else
                    {

                        top20Plus += top20;
                        if (position <= top20Plus)
                        {
                            return 'D';
                        }
                        else
                        {
                            return 'F';
                        }
                     
                        
                    }
                }
            }
            //return 'F';
            
        }
    }
}
