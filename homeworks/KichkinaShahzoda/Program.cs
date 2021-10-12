using System;
using static System.Console;
using System.Linq;

namespace KichkinaShahzoda
{
    class Program
    {
        static void Main(string[] args)
        {
            int testcase = int.Parse(ReadLine());
            while(testcase > 0)
            {
                int sanoq = 0;
                var PrinceCoordinates = ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
                int startx = PrinceCoordinates[0], starty = PrinceCoordinates[1],
                endx = PrinceCoordinates[2], endy = PrinceCoordinates[3];
                Shahzoda shahzoda = new Shahzoda(new Nuqta(startx, starty), new Nuqta(endx, endy));
                var planetCount = int.Parse(Console.ReadLine());
                while(planetCount > 0)
                {
                    var planetCoordinates = ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                    int cx = planetCoordinates[0], cy = planetCoordinates[1], 
                    radius = planetCoordinates[2];
                    if(shahzoda.KesibUtadimi(new Aylana(new Nuqta(cx, cy), radius)))
                    {
                        sanoq++;
                    }
                    planetCount--;
                }
                WriteLine($"{sanoq}");
                testcase--;
            }
        }
    }
}
