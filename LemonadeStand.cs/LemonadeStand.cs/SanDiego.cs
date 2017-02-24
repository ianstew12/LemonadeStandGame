using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    class SanDiego:Location
    {

        public SanDiego()
        {
            maximumTemperature=95;
            minimumTemperature=70;
            temperatureDailyRange=10;
            sunnySkyThreshold=40;
            cloudySkyThreshold=20;
            showersSkyThreshold=10;
            populationDensityIndex = 4;
            wealthOfPopulation = 3;
        }
    }
}
