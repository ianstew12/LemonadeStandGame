using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    class Alaska:Location
    {
        public Alaska()
        {
            maximumTemperature = 65;
            minimumTemperature = -30;
            temperatureDailyRange = 40;
            sunnySkyThreshold = 70;
            cloudySkyThreshold = 50;
            showersSkyThreshold = 40;
            populationDensityIndex = 1;
            wealthOfPopulation = 2;
        }
    }
}
