using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_And_Event
{
    public delegate double MyCalculDelegate(double x1, double y1);
    public delegate double MyCalculDelegate1(int x1, int y1);
    public delegate double MyCalculDelegate2(int x1, double y1);

    //first of all delegate is class with safety and it link to object
    //that correspond with given signal, with these help of delegate we can call the method
    //Doing a Generic delegate - we don't know which type variable does our delegate take
    public delegate T MyMyCalculDelegate3<T>(T x1, T y1);
    public class MyCalcul
    {

        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Add(int x, double y)
        {
            return x + y;
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
        public double Add(double x, int y)
        {
            return x + y;
        }

        public static double Mult(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            if (x != 0)
            { return (x / y); }
            throw new DivideByZeroException();
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
    }
    class Program
    {
        //Delegate- it a link to some certain object

        static void Main(string[] args)
        {

            //create object of calculator
            //MyCalcul c1 = new MyCalcul();
            //MyCalculDelegate d1 = new MyCalculDelegate(c1.Sub);


            //// Calling our delegate
            //Console.WriteLine($"{d1(2.5, 8.5)}");

            //Using switch statement

            //char key;
            // key = Convert.ToChar(Console.ReadLine());
            //MyCalcul c1 = new MyCalcul();
            //MyCalculDelegate d1 = null;
            //MyCalculDelegate1 d2 = null;
            //int n;
            //n = Convert.ToInt32(Console.ReadLine());

            //switch (n)
            //{
            //    case 1: d1 = new MyCalculDelegate(c1.Add); break;
            //    case 2: d1 = new MyCalculDelegate(c1.Sub); break;
            //    case 3: d1 = new MyCalculDelegate(c1.Div); break;
            //    case 4: d1 = new MyCalculDelegate(c1.Mult); break;
            //    default:
            //        throw new InvalidOperationException();

            //}
            //Console.WriteLine($"{d1(2.5, 8.5)}");

            Console.WriteLine("MultiCastingDelegate");
            MyCalcul c1 = new MyCalcul();
            MyCalculDelegate d = null;

            d += c1.Add;
            d += c1.Sub;
            d += c1.Div;
            d += MyCalcul.Mult;

            //GetInvocationList help us to get список лист
            foreach (MyCalculDelegate item in d.GetInvocationList()) { Console.WriteLine(item(2.5, 9.5)); }

            MyCalcul c3 = new MyCalcul();
            MyMyCalculDelegate3<double> d_double = c3.Add;
            Console.WriteLine($"{d_double(2.5, 4)}");

            MyMyCalculDelegate3<int> d_int = c3.Add;
            Console.WriteLine($"{d_int(2, 5)}");
        }
    }

}
