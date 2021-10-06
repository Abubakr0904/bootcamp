using System;

namespace bootcamp.solutions
{
    class Lab3
    {
        public void Problem1()
        {
            var input = int.Parse(Console.ReadLine());
            System.Console.WriteLine("{0}", input);
            char c = (char)input;
            System.Console.WriteLine("{0}", c);
        }
        public void Problem2()
        {
            System.Console.WriteLine("Int");
            System.Console.Write("Width: ");
            var a = int.Parse(Console.ReadLine());
            System.Console.Write("Length: ");
            var b = int.Parse(Console.ReadLine());
            System.Console.WriteLine("{0}", a*b);

            System.Console.WriteLine("Decimal");
            System.Console.Write("Width: ");
            var c = float.Parse(Console.ReadLine());
            System.Console.Write("Length: ");
            var d = float.Parse(Console.ReadLine());
            System.Console.WriteLine("{0}", c*d);
        }
        public void Problem3()
        {
            System.Console.Write("Input (Real number): ");
            var a = float.Parse(Console.ReadLine());
            System.Console.WriteLine("Round off (Integer)-> " + Math.Round(a).ToString());
        }
        public void Problem4()
        {
            System.Console.Write("Input(lower case): ");
            var c = Console.ReadLine();
            System.Console.WriteLine("Output (upper case) -> " + c.ToUpper());

            System.Console.Write("Input (upper case) -> ");
            c = Console.ReadLine();
            System.Console.WriteLine("Output(lower case): " + c.ToLower());
        }
    }
}