using System;
namespace KichkinaShahzoda
{
    public class Shahzoda
    {
        private Nuqta Start { get; set; }
        private Nuqta End { get; set; }

        [Obsolete("Nuqta Start and Nuqta End should be passed as a parameter")]
        public Shahzoda() { }

        public Shahzoda(Nuqta start, Nuqta end)
        {
            Start = start;
            End = end;
        }

        public bool KesibUtadimi(Aylana aylana)
        {
            if(!aylana.Ichidami(Start) && aylana.Ichidami(End)) return true;
            if(aylana.Ichidami(Start) && !aylana.Ichidami(End)) return true;
            return false;
        }
    }
}