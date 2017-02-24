using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Weather
    {
        public int temperature;     
        public bool raining;
        Random randomNumber;
        
        public Weather(Forecast forecast, Random random)        
        {
          randomNumber = random;
        }
     
       public void setWeather(Forecast forecast){
              setTemperature(forecast);
              setPrecipitation(forecast);
              }

        public void setTemperature(Forecast forecast)
        {

        int temperatureProbability = randomNumber.Next(0,101);
        if (temperatureProbability < 80){
                temperature = randomNumber.Next(forecast.forecastLow, forecast.forecastHigh);
                    }
        else {
        temperature = randomNumber.Next(50,121);
        }
        }

        public void setPrecipitation(Forecast forecast)
        {
        int precipitationProbabilityCutoff;
        int precipitationProbabilityGenerated = randomNumber.Next(0, 101);
        switch (forecast.skyConditions)
        {
        case "sunny":
           precipitationProbabilityCutoff = 80;
            break;
         case "cloudy":
         precipitationProbabilityCutoff = 60;
            break;
         case "showers":
           precipitationProbabilityCutoff = 20;
             break;
        default:
            Console.WriteLine("something went wrong. I'll make it up to you by giving you a sunny day");             //TODO (error handling)
            precipitationProbabilityCutoff = 100;
            break;
        }
        if (precipitationProbabilityGenerated < precipitationProbabilityCutoff)
            { raining = false; }
        else if (precipitationProbabilityGenerated >= precipitationProbabilityCutoff)
            { raining = true; }
        }

        public void DisplayWeather()    
        {
            if (raining)
            {
                Console.WriteLine("Today's weather: \nNo rain, and the temperature is " + temperature);
            }
            else if (!raining)
            {
                Console.WriteLine("Today's weather: \nRaining and the temperature is " + temperature);
            }
            else
            {
                Console.WriteLine("something with the weather is messed up"); //}todo
            }
        }
    }
}

