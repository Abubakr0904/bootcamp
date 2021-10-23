using System;

namespace lesson10
{
    public static class ExtensionMethods 
    {
        public static double ToTimestamp(this DateTime date)
        {
            DateTime origin = new DateTime(0, 0, 0, 0, 0, 0, 0);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}