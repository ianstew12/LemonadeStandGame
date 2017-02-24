using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    class Kuwait:Location
    {
        public Kuwait()
        {
            maximumTemperature = 130;
            minimumTemperature = 110;
            temperatureDailyRange = 10;
            sunnySkyThreshold = 20;
            cloudySkyThreshold = 10;
            showersSkyThreshold = 5;
            populationDensityIndex = 6;
            wealthOfPopulation = 10;
        }
    }
}
