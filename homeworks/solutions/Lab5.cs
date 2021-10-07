using System;
using System.Linq;

namespace bootcamp.solutions
{
    class Lab5
    {
        public void Problem1()
        {
            var a = int.Parse(Console.ReadLine());
            if(a >= 0 && a < 40)
            {
                System.Console.WriteLine("tashqarida o'yna");
            }
            else
            {
                System.Console.WriteLine("ichkarida o'yna");
            }
        }
        public void Problem2()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int a = ints[0], b = ints[1];
            if(a * a == b)
            {
                System.Console.WriteLine($"{a}*{a}={b}");
            }
            else
            {
                System.Console.WriteLine($"{b}*{b}={a}");
            }
        }
        public void Problem3()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            System.Console.WriteLine(ints[0] > ints[1] ? ints[0] : ints[1]);
        }
        public void Problem4()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int a = ints[0], b = ints[1], c = ints[2];
            if(a > b && a > c)
            {
                System.Console.Write(a + " ");
            }
            else if(b > a && b > c)
            {
                System.Console.Write(b + " ");
            }
            else if(c > b && c > a)
            {
                System.Console.Write(c + " ");
            }
            if(a < b && a < c)
            {
                System.Console.Write(a + " ");
            }
            else if(b < a && b < c)
            {
                System.Console.Write(b + " ");
            }
            else if(c < b && c < a)
            {
                System.Console.Write(c + " ");
            }
            System.Console.WriteLine();
        }
        public void Problem5()
        {
            var a = int.Parse(Console.ReadLine());
            if(a % 2 == 0 && a % 3 == 0 && a % 5 == 0)
            {
                System.Console.WriteLine("A");
            }
            else if(a % 2 == 0 && a % 3 == 0)
            {
                System.Console.WriteLine("B");
            }
            else if(a % 2 == 0 && a % 5 == 0)
            {
                System.Console.WriteLine("C");
            }
            else if(a % 3 == 0 && a % 5 == 0)
            {
                System.Console.WriteLine("D");
            }
            else if(a % 2 == 0 || a % 3 == 0 || a % 5 == 0)
            {
                System.Console.WriteLine("E");
            }
            else
            {
                System.Console.WriteLine("N");
            }
        }
        public void Problem6()
        {
            var a = int.Parse(Console.ReadLine());
            if((a % 4 == 0 && a % 100 != 0) || a % 400 == 0)
            {
                System.Console.WriteLine("leap year");
            }
            else
            {
                System.Console.WriteLine("normal year");
            }
        }
        public void Problem7()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            if(M == N)
            {
                System.Console.WriteLine("Correct");
            }
            else if(M < N)
            {
                System.Console.WriteLine("UP");
            }
            else
            {
                System.Console.WriteLine("DOWN");
            }
            if(M != N)
            {
                M = int.Parse(Console.ReadLine());
                if(M == N)
                {
                    System.Console.WriteLine("Correct");
                }
                else if(M < N)
                {
                    System.Console.WriteLine("UP");
                }
                else
                {
                    System.Console.WriteLine("DOWN");
                }
            }
        }
        public void Problem8()
        {
            char c = (char)Console.Read();
            if(char.IsLetter(c))
            {
                if(char.IsLower(c))
                {
                    System.Console.WriteLine(char.ToUpper(c));
                }
                else
                {
                    System.Console.WriteLine(char.ToLower(c));
                }
            }
            else
            {
                System.Console.WriteLine("none");
            }
        }
        public void Problem9()
        {
            int a, b, c;
            int a1, b1, c1;
            int s = 0, d = 0;
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            (a, b, c) = (ints[0], ints[1], ints[2]);

            ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            (a1, b1, c1) = (ints[0], ints[1], ints[2]);
            if(a1 == a)
            {
                s++;
            }
            if(b1 == b)
            {
                s++;
            }
            if(c1 == c)
            {
                s++;
            }
            if(a1 == b || a1 == c)
            {
                d++;
            }
            if(b1 == a || b1 == c)
            {
                d++;
            }
            if(c1 == b || c1 == a)
            {
                d++;
            }
        }
        public void Problem10()
        {
            var a = Console.ReadLine();
            System.Data.DataTable table = new System.Data.DataTable();
            var result = Convert.ToInt32(table.Compute(a, String.Empty));
            System.Console.WriteLine(result.ToString());
        }
        public void Problem11()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            if(N == 1)
            {
                System.Console.WriteLine("Americano");
                System.Console.Write(((M-500) / 500).ToString() + " ");
                System.Console.Write(((M-500) % 500 / 100).ToString());
            }
            else if(N == 2)
            {
                System.Console.WriteLine("Caffe Latte");
                System.Console.Write(((M-400) / 500).ToString() + " ");
                System.Console.Write(((M-400) % 500 / 100).ToString());
            }
            else if(N == 3)
            {
                System.Console.WriteLine("Lemon Tea");
                System.Console.Write(((M-300) / 500).ToString() + " ");
                System.Console.Write(((M-300) % 500 / 100).ToString());
            }
            System.Console.WriteLine();
        }
        public void Problem12()
        {
            var a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1: Problem1(); break;
                case 2: Problem2(); break;
                case 3: Problem3(); break;
                case 4: Problem4(); break;
                case 5: Problem5(); break;
                case 6: Problem6(); break;
                case 7: Problem7(); break;
                case 8: Problem8(); break;
                case 9: Problem9(); break;
                case 10: Problem10(); break;
                case 11: Problem11(); break;                
                default: System.Console.WriteLine("Invalid number!"); break;
            }
        }
        public void Problem13()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            if(ints.Sum() > 100)
            {
                    System.Console.WriteLine(true);
            }
            else
            {
                System.Console.WriteLine(false);
            }
        }
        public void Problem14()
        {
            // int sum = 0;
            // int n = int.Parse(Console.ReadLine());
            // var list = Enumerable.Range(1, n).ToList();
            // foreach (var item in list)
            // {
            //     sum += item;
            // }
            // System.Console.WriteLine(sum.ToString());
         
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int a = ints[0], b = ints[1], c = ints[2];
            if(a*a + b*b == c*c)
            {
                System.Console.WriteLine(true);
            }
            else if(a*a + c*c == b*b)
            {
                System.Console.WriteLine(true);
            }
            else if(b*b + c*c == a*a)
            {
                System.Console.WriteLine(true);
            }
            else
            {
                System.Console.WriteLine(false);
            }
        }
        public void Problem15()
        {
            var a = Console.ReadLine();
            var b = a switch
            {
                "/" => "true",
                "*" => "true",
                "+" => "true",
                "-" => "true",
                "%" => "true",
                _ => "false",
            };
            System.Console.WriteLine(b);
        }
        public void Problem16()
        {
            var a = int.Parse(Console.ReadLine());
            var b = a switch
            {
                0 => "nol",
                1 => "bir",
                2 => "ikki",
                3 => "uch",
                4 => "to'rt",
                5 => "besh",
                6 => "olti",
                7 => "yetti",
                8 => "sakkiz",
                9 => "to'qqiz",
                _ => "boshqa",
            };
            System.Console.WriteLine(b);
        }
        public void Problem17()
        {
            var ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            var s = ints[0];
            var m = ints[1];
            if(m >= 45)
            {
                m -= 45;
            }
            else
            {
                m = 60 -45 + m;
                if(s!=0)
                {
                    s -= 1;
                }
                else
                {
                    s = 23;
                }
            }
            System.Console.WriteLine($"{s} {m}");
        }
        public void Problem18()
        {
            var a = int.Parse(Console.ReadLine());
            if(a >= 90)
            {
                System.Console.WriteLine("A");
            }
            else if(a >= 80)
            {
                System.Console.WriteLine("B");
            }
            else if(a >= 70)
            {
                System.Console.WriteLine("C");
            }
            else if(a >= 60)
            {
                System.Console.WriteLine("D");
            }
            else
            {
                System.Console.WriteLine("F");
            }
        }
        public void Problem19()
        {
            var a = int.Parse(Console.ReadLine());
            var s = a/100%10;
            if(s >= 5)
            {
                System.Console.WriteLine((a/1000 + 1)*1000);
            }
            else
            {
                System.Console.WriteLine(a/1000*1000);
            }
        }
        public void Problem20()
        {
            var c = Console.Read();
            if(char.IsLetter((char)c))
            {
                System.Console.WriteLine('1');
            }
            else
            {
                System.Console.WriteLine('0');
            }
        }
        public void Problem21()
        {
            var a = int.Parse(Console.ReadLine());
            if(a % 2 == 0)
            {
                System.Console.WriteLine("even");
            }
            else
            {
                System.Console.WriteLine("odd");
            }
        }
        
    }
}