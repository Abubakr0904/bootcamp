using System;
using System.Linq;
using System.Collections.Generic;

namespace bootcamp.solutions
{
    public class Lab6
    {
        public void Problem1()
        {
            int a = int.Parse(Console.ReadLine());
            int i = 1;
            while(i <= a)
            {
                if(a % i == 0)
                {
                    System.Console.Write(i + " ");
                }
                i++;
            }
            System.Console.WriteLine();
        }
        public void Problem2()
        {
            int javob = int.Parse(Console.ReadLine());
            int count = 1;
            while(true)
            {
                var tahmin = int.Parse(Console.ReadLine());
                if(tahmin == javob)
                {
                    System.Console.WriteLine(count);
                    break;
                }
                else if(tahmin < javob)
                {
                    System.Console.WriteLine(tahmin + "<");
                }
                else
                {
                    System.Console.WriteLine(tahmin + ">");
                }
                count++;
            }
        }
        public void Problem3()
        {
            int sum = 0;
            int i = 0;
            var inputs = new List<int>();
            inputs = Console.ReadLine().Split().Select(int.Parse).ToList();
            do
            {
                sum += inputs[i] != 0 ? inputs[i] : 0;
                i++;                
            } while (inputs[i] != 0);
            System.Console.WriteLine(sum);
        }
        public void Problem4()
        {
            for(int i = 2; i <= 10; i++)
            {
                int fact = 1;
                System.Console.Write($"{i}!=");
                for(int j = 1; j < i; j++)
                {
                    System.Console.Write($"{j}*");
                    fact *= j;
                }
                fact *= i;
                System.Console.WriteLine($"{i}={fact}");
            }
        }
        public static int gcd(int a, int b)
        {
            if(a == 0)
            {
                return b;
            }

            return gcd(b % a, a);
        }
        public void Problem5()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int a = ints[0], b = ints[1];
            while(a != 0)
            {
                int temp = a;
                a = b % a;
                b = temp;
            }
            System.Console.WriteLine(b);
        }
        public void Problem6()
        {
            int a = int.Parse(Console.ReadLine());
            for(int i = 1; i <= a; i++)
            {
                var space = a - i;
                while(space != 0)
                {
                    Console.Write(" ");
                    space--;
                }
                var stars = i * 2 - 1;
                while (stars != 0)
                {
                    Console.Write("*");
                    stars--;
                }
                System.Console.WriteLine();
            }
            for(int i = a - 1; i >= 1; i--)
            {
                var space = a - i;
                while(space != 0)
                {
                    Console.Write(" ");
                    space--;
                }
                var stars = i * 2 - 1;
                while (stars != 0)
                {
                     Console.Write("*");
                     stars--;
                }
                System.Console.WriteLine();
            }
        }
        public void Problem7()
        {
            for(int i = 1; i <= 10; i++)
            {
                int j = i;
                while (j < 10 + i)
                {
                     System.Console.Write($"{j%10} ");
                     j++;
                }
                System.Console.WriteLine();
            }
        }
        public void Problem8()
        {
            var a = int.Parse(Console.ReadLine());
            int count = 0;
            for(int i = 3; i <= a; i++)
            {
                int j = i;
                while (j != 0)
                {
                     if(j % 10 == 3)
                     {
                         count++;
                     }
                     j /= 10;
                }
            }
            System.Console.WriteLine(count);
        }
        public void Problem9()
        {
            var a = int.Parse(Console.ReadLine());
            int num = 1;
            for(int i = 1; i <= a; i++)
            {
                var space = a - i;
                while(space != 0)
                {
                    System.Console.Write(" ");
                    space--;
                }
                var temp = i;
                while(temp != 0)
                {
                    System.Console.Write($"{num++ % 10} ");
                    temp--;
                }
                System.Console.WriteLine();
            }
        }
        public void Problem10()
        {
            var a = int.Parse(Console.ReadLine());
            int res = 0;
            while (a != 0)
            {
                 res += a % 10;
                 a /= 10;
                 if(a == 0 && res > 9)
                 {
                     a = res;
                     res = 0;
                 }
            }
            System.Console.WriteLine(res);
        }
        public void Problem11()
        {
            for(int i = 1; i <= 6; i++)
            {
                for(int j = 1; j <= 6; j++)
                {
                    for(int k = 1; k <= 6; k++)
                    {
                        if(i + j + k == 10)
                        {
                            System.Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
        public void Problem12()
        {
            var a = int.Parse(Console.ReadLine());
            int sum = 0;
            
            for(int i = 1; ;i++)
            {
                 sum += i;
                 if(i == a)
                 {
                     break;
                 }
            }
            System.Console.WriteLine(sum);
        }
        public void Problem13()
        {
            int sum = 0;
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int i = 0;
            while (true)
            {
                if(ints[i] <= 0)
                {
                    break;
                }
                else
                {
                    sum += ints[i];
                }
                i++;
            }
            float sumRes = (float)sum;
            System.Console.WriteLine($"{sum} " + (sumRes/i).ToString("0.00") + $" {i}");
        }
        public void Problem14()
        {
            var num = int.Parse(Console.ReadLine());
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int a = ints[0], b = ints[1], c = ints[2];
            var result = Math.Pow(a, 3) + Math.Pow(b, 3) + Math.Pow(c, 3);
            System.Console.WriteLine($"{result}");
        }
        public void Problem15()
        {
            int a = int.Parse(Console.ReadLine());
            bool flag = true;
            int fact = 1;
            for(int i = 1; i < 14; i++)
            {
                fact *= i;
                if(fact == a)
                {
                    System.Console.WriteLine("true");
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                System.Console.WriteLine("false");
            }
        }
        public void Problem16()
        {
            int a = int.Parse(Console.ReadLine());
            while (a != 0)
            {
                bool tubmi = true;
                if(a % 2 == 0)
                {
                    a++;
                    tubmi = false;
                    continue;
                }
                for(int i = 3; i <= Math.Sqrt(a); i += 2)
                {
                    if(a % i == 0)
                    {
                        a++;
                        tubmi = false;
                        continue;
                    }
                }
                if(tubmi)
                {
                    System.Console.WriteLine(a);
                    break;
                }
            }
        }
        public void Problem17()
        {
            int x = 0, y = 0;
            var a = int.Parse(Console.ReadLine());
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            for(int i = 0; i < ints.Count; i++)
            {
                int j = i + 1;
                var checker = j % 4;
                switch (checker)
                {
                    case 1: y += ints[i]; break;
                    case 2: x += ints[i]; break;
                    case 3: y -= ints[i]; break;
                    case 0: x -= ints[i]; break;
                }
            }
            System.Console.WriteLine($"{x} {y}");
        }
        public void Problem18()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            long N = ints[0], M = ints[1];
            int i = 0;
            while(N > 1 && M > 1)
            {
                if(N % 2 == 0)
                {
                    N /= 2;
                }
                else
                {
                    N = N * 3 + 1;
                }

                if(M % 2 == 0)
                {
                    M /= 2;
                }
                else
                {
                    M = M * 3 + 1;
                }
                i++;
            }
            if(N == 1)
            {
                System.Console.WriteLine($"{ints[0]} {i}");
            }
            else if(M == 1)
            {
                System.Console.WriteLine($"{ints[1]} {i}");                
            }
        }
        public void Problem19()
        {
            var num = int.Parse(Console.ReadLine());
            long a = 0, b = 1, c = a + b;
            for(int i = 3; i < num; i++)
            {
                a = b;
                b = c;
                c = a + b;
            }
            System.Console.WriteLine(c);
        }
        public void Problem20()
        {
            var son = int.Parse(Console.ReadLine());
            int count = 0;
            int a = son, b = -1;

            while(b != a)
            {
                int son1 = son % 10;
                int son2 = son / 10;
                son = (son1 + son2) % 10;
                int newson = son1 * 10 + son;
                count++;
                son = newson;
                b = newson;
            }
            System.Console.WriteLine(count);
        }
        public static string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }
        public void Problem21()
        {
            int count = 0;
            long a = long.Parse(Console.ReadLine());
            while (a != long.Parse(Reverse(a.ToString())))
            {
                a = a + long.Parse(Reverse(a.ToString()));
                count++;
            }
            System.Console.WriteLine($"{count} {a}");
        }
        public void Problem22()
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i <= n; i++)
            {
                int power = 0;
                int temp = i;
                do
                {
                    temp /= 10;
                    power++;
                }
                while(temp != 0);

                temp = i;
                int sum = 0;
                while(temp != 0)
                {
                    sum += (int)(Math.Pow((temp % 10), power));
                    temp /= 10;
                }

                if(sum == i)
                {
                    System.Console.Write($"{i} ");
                }
            }
            System.Console.WriteLine();
        }
        public void Problem23()
        {
            var a = Console.ReadLine();
            System.Console.WriteLine(a.Length);
        }
        public void Problem24()
        {
            var a = int.Parse(Console.ReadLine());
            for(int i = 1; i <= a; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    System.Console.Write("*");
                }
                System.Console.WriteLine();
            }
        }
    }
}