using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Forecast
    {
        public int forecastLow;
        public int forecastHigh;
        public string skyConditions;
        Random randomNumber;
        Location location;

        public Forecast(Random random, Location location)
        {
            randomNumber = random;
            this.location = location;
        }

        public void SetForecast()
        {
            SetForecastTemperature();
            SetForecastSky();
        }

        public void SetForecastTemperature()    
        {
            forecastLow = randomNumber.Next(location.minimumTemperature, (location.maximumTemperature-location.temperatureDailyRange));  
            forecastHigh = forecastLow + location.temperatureDailyRange;
        }

        public void SetForecastSky()
        {
            int skyProbabilityGenerated = randomNumber.Next(0, 101);
            if (skyProbabilityGenerated > location.sunnySkyThreshold)   
            {
                skyConditions = "sunny";
            }
            else if (skyProbabilityGenerated<=location.sunnySkyThreshold && 
                skyProbabilityGenerated > location.cloudySkyThreshold)
            {
                skyConditions = "cloudy";
            }
            else if (skyProbabilityGenerated<=location.cloudySkyThreshold)
            {
                skyConditions = "showers";
            }
            else
            {
                Console.WriteLine("The weatherman is on drugs again. Sorry.");
            }
        }

        public void DisplayForecast()
        {
            Console.WriteLine("Weather Forecast: \nSkies: " + skyConditions + "\nTemperature low: " + forecastLow
                + "\nTemperature high: " + forecastHigh);
        }
    }
}
