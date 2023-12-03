﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collect_Delegate
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BD { get; set; }
        public override string ToString()
        {
            return $"{FirstName,15} {LastName,15} {BD.ToShortDateString(),17} ";
        }
    }

    class Programm
    {
        static string myFunc(Student st)
        {
            return $"{st.FirstName,15} {st.LastName,15}";
        }

        static void myFunc1(Student st)
        {
            Console.WriteLine( $"{st.FirstName,15} {st.LastName,15}");
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
               {
                    new Student{FirstName="Ivan", LastName="Ivanov", BD=new DateTime(2000,1,1)},
                    new Student{FirstName="Petr", LastName="Petrov", BD=new DateTime(2014,3,10)},
                    new Student{FirstName="Sergey", LastName="Surikov", BD=new DateTime(1999,4,23)},
                    new Student{FirstName="Nicole", LastName="Kirova", BD=new DateTime(2010,8,13)},
                    new Student{FirstName="Andre", LastName="Simonov", BD=new DateTime(2003,7,19) }
                };


            //Func<TResult> - This accept on 16 parameter (16 param) and type - T
            //this function is always use in the IEnumerable interface and usually use class of SELECT

            //Func<TResult> - (16 param), type - T Select<TSource, TResult>

            IEnumerable<string> group = students.Select( myFunc);
            foreach (string item in group)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("++++++++++++++++++");

            ////Action<T> -16 param void - System List<T> ForEach() //Action also work like Func<TResult> only different is the Select and ForEach
            //And different it Action doesn't return a function it void 
            students.ForEach(myFunc1);
        }
    }
}
