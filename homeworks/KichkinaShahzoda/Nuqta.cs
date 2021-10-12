using System;
namespace KichkinaShahzoda
{
    public class Nuqta
    {
        private int X { get; set; }
        private int Y { get; set; }
        [Obsolete("int X and int Y should be passed as a parameter")]
        public Nuqta() { }

        public Nuqta(int x, int y)
        {
            X = x;
            Y = y;
        }

        public float GachaMasofa(Nuqta nuqta)
        {
            return (float)Math.Sqrt(Math.Pow(this.X - nuqta.X, 2) + Math.Pow(this.X - nuqta.Y, 2));
        }
    }
}