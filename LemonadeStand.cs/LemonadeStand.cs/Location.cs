using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Location
    {
       public int maximumTemperature;
       public int minimumTemperature;
       public int temperatureDailyRange;
       public int sunnySkyThreshold; // if 50, any number above 50 --> sunny (if int=40, 60% chance of sunny)
       public int cloudySkyThreshold; 
       public int showersSkyThreshold;
       public int populationDensityIndex;
       public int wealthOfPopulation;

        public Location()
        {

        }


    }
}
