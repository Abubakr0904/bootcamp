using System.Security.AccessControl;
using System;
using System.Linq;

namespace classwork
{
    public static class Masalalar
    {
        public static void Classes()
        {
            public string Name { get; set; }
            
            
        }
        public static void ReadArrayInLine2()
        {
            Console.Write("Enter the number of rows: ");
            var rows = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns: ");
            var columns = int.Parse(Console.ReadLine());
            
            var arr2d = new int[rows][];
            
            for(int i = 0; i < rows; i++)
            {
                arr2d[i] = new int[columns];
                arr2d[i] = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i))
                .ToArray();
            }
        }
        public static void KeyingiTub()
        {
            bool tubmi = true;
            int a = int.Parse(Console.ReadLine());
            while(tubmi)
            {
                if(a == 2)
                {
                    Console.WriteLine($"{a}");
                    break;                    
                }
                else if(a % 2 == 0)
                {
                    tubmi = false;
                }
                else
                {
                    for(int i = 3; i <= Math.Sqrt(a); i += 2)
                    {
                        if(a % i == 0)
                        {
                            tubmi = false;
                            break;
                        }
                    }
                }
                if(tubmi)
                {
                    Console.WriteLine($"{a}");
                    break;
                }
                else
                {
                    a++;
                    tubmi = true;
                }
            }
        }

        // public static void ArrayInLine()
        // {
        //     int qator = 3, ustun = 2;

        //     // a x b hajmli array o'qish
        //     int[,] arr2d = new int[qator, ustun];
            
        //     //O'qish
        //     var ints = Console.ReadLine()
        //     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        //     .Select(son => 
        //         int.Parse(son),
        //         for(int i = 0; i < qator; i++)
        //         {
        //             for(int j = 0; j < ustun; j++)
        //             {
        //                 arr2d[i, j] = son;
        //             }
        //         },
        //     );

        //     // Chop etish
        //     for(int i = 0; i < qator; i++)
        //     {
        //         for(int j = 0; j < ustun; j++)
        //         {
        //             Console.Write($"{arr[i, j]}");
        //         }
        //         Console.WriteLine();
        //     }
        // }
    }
}