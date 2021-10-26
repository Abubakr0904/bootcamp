using bot.Models;

namespace bot.Extensions
{
    public static class PrayerTimeExtensions
    {
        public static PrayerTime ToPrayerTimeModel(this Dto.Aladhan.PrayerTimeDto dto)
        {
            return new PrayerTime()
            {
                Fajr = dto.Data.Timings.Fajr,
                Sunrise = dto.Data.Timings.Sunrise,
                Dhuhr = dto.Data.Timings.Dhuhr,
                Asr = dto.Data.Timings.Asr,
                Maghrib = dto.Data.Timings.Maghrib,
                Isha = dto.Data.Timings.Isha,
                Midnight = dto.Data.Timings.Midnight,
                Sunset = dto.Data.Timings.Sunset,
                Source = "aladhan.com",
                CalculationMethod = dto.Data.Meta.Method.Name
            };
        }
    }
}