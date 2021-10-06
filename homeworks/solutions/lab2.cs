using System;
using System.Linq;

namespace bootcamp.solutions
{
    class Lab2
    {
        public void Problem1()
        {
            System.Console.WriteLine("222222");
            System.Console.WriteLine("2    2");
            System.Console.WriteLine("2    2");
            System.Console.WriteLine("222222");
        }
        public void Problem2()
        {
            System.Console.WriteLine("   A");
            System.Console.WriteLine("  A A");
            System.Console.WriteLine(" A   A");
            System.Console.WriteLine("A A A A");
        }
        public void Problem3()
        {
            System.Console.WriteLine("Birthdate");
            Console.Write("Enter Month: ");
            var month = Console.ReadLine();
            Console.Write("Enter Date: ");
            var date = Console.ReadLine();
            System.Console.WriteLine("Birthdate is " + int.Parse(month).ToString("00") + "-" + int.Parse(date).ToString("00") + " (mm-dd)");
        }
        public void Problem4()
        {
            System.Console.WriteLine("Birthdate");
            Console.Write("Enter Month and Date: ");
            var inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var date = inputs.Select(i => int.Parse(i)).ToList();
            System.Console.WriteLine("Birthdate is " + date[0].ToString("D2") + "-" + date[1].ToString("D2") + " (mm-dd ).");
        }
        public void Problem5()
        {
            var input = Console.ReadLine();
            for(int i = 0; i < 6; i++)
            {
                System.Console.Write(input);
            }
            System.Console.WriteLine();
            System.Console.WriteLine(input + "    " + input);
            System.Console.WriteLine(input + "    " + input);
            for(int i = 0; i < 6; i++)
            {
                System.Console.Write(input);
            }
            System.Console.WriteLine();
        }
        public void Problem6()
        {
            System.Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");
            System.Console.WriteLine(" 4   5   6   7   8   9   10");
        }
        public void Problem7()
        {
            System.Console.WriteLine("Enter Integer: ");
            var input = int.Parse(Console.ReadLine());
            for(int i = 1; i < 10; i++)
            {
                System.Console.WriteLine("{0}*{1}={2}", input, i, input*i);
            }
        }
        public void Problem8()
        {
            var fact = 1;
            for(int i = 1; i < 6; i++)
            {
                fact *= i;
                System.Console.WriteLine("{0}!={1}", i, fact);
            }
        }
        public void Problem9()
        {
            int a = 1;
            int b = 1;
            System.Console.WriteLine(a);
            System.Console.WriteLine(b);
            for(int i = 3; i <= 6; i++)
            {
                int c = a + b;
                System.Console.WriteLine(c);
                a = b;
                b = c;
            }
            // Console.Write(a + " ");
            // Console.Write(b + " ");
            // int c = a + b;
            // a = b;
            // b = c;
            // System.Console.Write(c + " ");
            // c = a + b;
            // a = b;
            // b = c;
            // System.Console.Write(c + " ");
            // c = a + b;
            // a = b;
            // b = c;
            // System.Console.Write(c + " ");
            // c = a + b;
            // a = b;
            // b = c;
            // System.Console.Write(c + " ");
            // c = a + b;
            // a = b;
            // b = c;
            // System.Console.Write(c + " ");
            // c = a + b;
            // a = b;
            // b = c;
            // System.Console.Write(c + " ");
            // System.Console.WriteLine();
        }
    }

}