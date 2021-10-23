using System;
using System.Collections.Generic;
using System.Globalization;
using lesson10;
namespace Namozga_bot
{
    public class Settings
    {
        public static void SetDateAndPlace(List<int> hijriDate, double longitude, double latitude)
        {
            Program.prayerTimeApi = $"http://api.aladhan.com/v1/hijriCalendar?latitude={latitude}&longitude={longitude}&method=2&month={hijriDate[1]}&year={hijriDate[0]}";
        }
        public static IEnumerable<int> DisplayValues( Calendar myCal, DateTime myDT )
        {
            yield return myCal.GetYear( myDT );
            yield return myCal.GetMonth( myDT );
            yield return myCal.GetDayOfMonth( myDT );
        }
        public static IEnumerable<int> ConverttoHijri(DateTime dateTime)
        {
            DateTime myDT = dateTime;
            HijriCalendar myCal = new HijriCalendar();
            UmAlQuraCalendar hijri = new UmAlQuraCalendar();
            GregorianCalendar cal = new GregorianCalendar();

            DateTime result = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hijri);

            yield return result.Year;
            yield return result.Month;
        }
    }
}