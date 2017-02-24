using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    class Nevada:Location
    {
        public Nevada()
        {
            maximumTemperature = 130;
            minimumTemperature = 80;
            temperatureDailyRange = 20;
            sunnySkyThreshold = 50;
            cloudySkyThreshold = 30;
            showersSkyThreshold = 10;
            populationDensityIndex = 2;
            wealthOfPopulation = 1;
        }
    }
}
