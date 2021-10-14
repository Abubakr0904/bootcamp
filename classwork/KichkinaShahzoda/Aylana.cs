using System;
namespace KichkinaShahzoda
{
    public class Aylana
    {
        private Nuqta Markaz { get; set; }
        private int Radius { get; set; }        
        
        [Obsolete("Nuqta Markaz and int Radius should be passed as a parameter")]
        public Aylana( this(new Nuqta(), 0) { }

        public Aylana(Nuqta markaz, int radius)
        {
            Markaz = markaz;
            Radius = radius;
        }

        public bool Ichidami(Nuqta nuqta) => Markaz.GachaMasofa(nuqta) < Radius;
    }
}