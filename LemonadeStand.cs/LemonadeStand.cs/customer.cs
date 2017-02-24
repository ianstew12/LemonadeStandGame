using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Customer
    {
        public int thirst;
        decimal maxPrice;       //in max heat, no rain
        decimal rainDeterrent;
        decimal temperatureDeterrent;
        decimal iceFondness;
        decimal sugarFondness;
        decimal lemonFondness;
        decimal demand;      
        Random randomNumber;

        public Customer(Random random, Location location)
        {
           randomNumber = random;
           thirst= randomNumber.Next(0, 101);
           maxPrice = randomNumber.Next(25, 201)+(20*location.wealthOfPopulation);
           rainDeterrent = randomNumber.Next(0,51);
           temperatureDeterrent = randomNumber.Next(0, 3);     
           iceFondness = randomNumber.Next(0, 2);
           sugarFondness = randomNumber.Next(0, 2);
           lemonFondness = randomNumber.Next(0, 2);
        }

        public decimal GetDemand(Weather weather)          //finds the max price a customer will pay given the conditions 
        {
            if (weather.raining)
            {
                demand = maxPrice - rainDeterrent - (temperatureDeterrent * weather.temperature);
                return demand;
            }
            else
            {
                demand = maxPrice - (temperatureDeterrent * weather.temperature);
                return demand;
            }   
        }

        public void TakeDrink()
        {
            thirst -= 20;
        }
    }
}
