using System;

namespace _12_10
{
    /// <summary>
    /// 
    /// </summary>

    public class WeatherObservation
    {
        public DateTime RecordedAt { get; init; }
        public decimal TemperatureInCelsius { get; init; }
        public decimal PressureInMillibars { get; init; }
        public string Name { get; init; }
        
        

        public override string ToString() =>
            $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
            $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var now = new WeatherObservation();
            Console.WriteLine($"{now}");
        }
    }
}
