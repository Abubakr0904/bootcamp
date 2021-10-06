using System;
using System.Linq;

namespace bootcamp.solutions
{
    class Lab4
    {
        public void Problem1()
        {
            var input = int.Parse(Console.ReadLine());
            var s = input.ToString("D5");
            foreach (var item in s)
            {
                if(s.IndexOf(item) != s.Length-1)
                {
                    System.Console.Write(item + "!");
                }
                else
                {
                    System.Console.Write(item);
                }
            }
            System.Console.WriteLine();
        }
        public void Problem2()
        {
            var input = int.Parse(Console.ReadLine());
            var hours = input/3600;
            var minutes = input%3600/60;
            var seconds = input%60;
            System.Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
        public void Problem3()
        {
            System.Console.WriteLine(Console.ReadLine()[2]);
        }
        public void Problem4()
        {
            var input = int.Parse(Console.ReadLine());
            System.Console.WriteLine(input / 100 % 10 >= 5 ? (input/1000 + 1)*1000 : (input/1000)*1000);

        }
        public void Problem5()
        {
            var input = float.Parse(Console.ReadLine());
            var radius = input/2/3.14;
            System.Console.WriteLine("{0:F0}", radius*radius*3.14);
        }
        public void Problem6()
        {
            var input = int.Parse(Console.ReadLine());
            System.Console.WriteLine(input>=20 && input <= 30 ? '1' : '0');
        }
        public void Problem7()
        {
            var input = char.Parse(Console.ReadLine());
            var ascii = (int)input;
            if((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
            {
                System.Console.WriteLine('1');
            }
            else
            {
                System.Console.WriteLine('0');
            }
        }
        public void Problem8()
        {
            var input = int.Parse(Console.ReadLine());
            if(input % 2 == 1)
            {
                System.Console.WriteLine("odd");
            }
            else
            {
                System.Console.WriteLine("even");
            }
        }
        public void Problem9()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            System.Console.WriteLine(ints[0] > ints[1] ? ints[0] : ints[1]);
        }
        public void Problem10()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            var remainder = ints[0] > ints[1] ? ints[0] % ints[1] : ints[1] % ints[0];
            var quotient = ints[0] > ints[1] ? ints[0] / ints[1] : ints[1] / ints[0];
            System.Console.WriteLine(quotient);
            System.Console.WriteLine(remainder);
        }
    }
}