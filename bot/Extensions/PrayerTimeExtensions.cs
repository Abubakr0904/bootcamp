using System;
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
                CalculationMethod = dto.Data.Meta.Method.Name,
                Timezone = dto.Data.Meta.Timezone
            };
        }

        public static string TimeToString(this bot.Models.PrayerTime json, string language)
        {
            if(language == "En")
                return $@"*Prayer Times*: {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}
*Fajr*:               {json.Fajr}
*Sunrise*:        {json.Sunrise}
*Dhuhr*:           {json.Dhuhr}
*Asr*:                {json.Asr}
*Maghrib*:       {json.Maghrib}
*Isha*:              {json.Isha}

*Source*: {json.Source}
*Method*: {json.CalculationMethod}";
            if(language == "Ru")
                return $@"*Время молитвы*: {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}
*Фаджр*:               {json.Fajr}
*Восход*:        {json.Sunrise}
*Зухр*:           {json.Dhuhr}
*Аср*:                {json.Asr}
*Магриб*:       {json.Maghrib}
*Иша*:              {json.Isha}

*Источник*: {json.Source}
*Метод*: Духовное управление мусульман России";
            if(language == "Ru")
                return $@"*Namoz vaqtlari*: {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}
*Tong*:               {json.Fajr}
*Quyosh*:        {json.Sunrise}
*Peshin*:           {json.Dhuhr}
*Asr*:                {json.Asr}
*Shom*:       {json.Maghrib}
*Xufton*:              {json.Isha}

*Manba*: {json.Source}
*Usul*: Rossiya musulmonlar diniy boshqarmasi";
            return "Error, please restart the bot";
        }
    }
}