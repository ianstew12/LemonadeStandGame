using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Day
    {
        Weather weather;
        Forecast forecast;
        Customer customer;
        int passersBy;      
        public double dailyRevenue;
        Random random;
        Distributor distributor;
        double dailyProfit;
        Location location;
        

        public Day(Random random, Location location)
        {
            this.location = location;
            dailyRevenue = 0;
            this.random = random;
            forecast = new Forecast(random, location);
            weather = new Weather(forecast, random);
            distributor = new Distributor();
        }

        public void RunDailyCycle(Player player)
        {
            DisplayNewDayBoldly();
            SetDailyConditions();
            DisplayDailyConditions(player);
            MakeAdjustments(player, distributor);
            RunStandForDay(player);
            RecapDay(player);
            ResetAppropriateFields(player);
        }
        public void DisplayNewDayBoldly()
        {
            Console.WriteLine("                        ***NEW DAY***\n");
        }
        
        public void SetDailyConditions()
        {
            forecast.SetForecast();
            weather.setWeather(forecast);
            distributor.changeDailyItemPrices(random);
            SetPassersBy(random);
        }

        public int SetPassersBy(Random randomNumber)
        {
            if (weather.temperature > 100 && weather.raining)   //hot and raining
                {
                return passersBy = randomNumber.Next(30, 60)*location.populationDensityIndex;
                }
            else if (weather.temperature>100 && !weather.raining)   //hot and dry
            {
                return passersBy = randomNumber.Next(50, 90) * location.populationDensityIndex;
            }
            else if (weather.temperature > 70 && weather.temperature <= 100 && weather.raining)
            {
                return passersBy = randomNumber.Next(40, 60) * location.populationDensityIndex;
            }
            else if (weather.temperature > 70 && weather.temperature <= 100 && !weather.raining)
            {
                return passersBy = randomNumber.Next(70, 101) * location.populationDensityIndex;
            }
            else if (weather.temperature > 50 && weather.temperature <= 70 && weather.raining)
            {
                return passersBy = randomNumber.Next(0, 30) * location.populationDensityIndex;
            }
            else if (weather.temperature > 50 && weather.temperature <= 70 && !weather.raining)
            {
                return passersBy = randomNumber.Next(10, 40) * location.populationDensityIndex;
            }
            else { return passersBy = 10; }
        }

        public void DisplayDailyConditions(Player player)
        {
            forecast.DisplayForecast();
            distributor.DisplayPrices();
            player.inventory.DisplayInventory();
        }

        public void MakeAdjustments(Player player, Distributor distributor)
        {
            distributor.OfferItemsToPlayer(player);
            player.SetServingPrice();
            player.recipe.SetRecipe();
            player.MakeSpecifiedPitchers();
        }

        public void RunStandForDay(Player player)
        {
            NotifyOfStandOpening();
            for (int i = 0; i < passersBy; i++)
            {
                customer = new Customer(random, location);                
                if (CheckSaleCriteria(customer, player))
                {
                    AffirmativelyTransact(player);
                    PotentiallySellSecondCup(player);
                }
            }
        }

        public void NotifyOfStandOpening()
        {
            Console.WriteLine("\nOPEN FOR BUSINESS: \nWith your adjustments made, it's time to open for" +
                " business. Let's see how much money you make today");
        }

        public bool CheckSaleCriteria(Customer customer, Player player)
        {
            if (CheckPriceCriterion(customer, player) && CheckInventoryCriterion(customer, player))
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public bool CheckPriceCriterion(Customer customer, Player player)
        {
            decimal willingToPay = customer.GetDemand(weather);
            if (willingToPay >= player.chosenPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckInventoryCriterion(Customer customer, Player player)
        {
            if (player.checkRequiredInventory())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AffirmativelyTransact(Player player)
        {
            {
                player.SellServing();
                customer.TakeDrink();
                dailyRevenue += player.chosenPrice;
            }
        }

        public void PotentiallySellSecondCup(Player player)
        {
            if ((customer.thirst > 50)&&CheckSaleCriteria(customer,player))
            {
                player.SellServing();
                dailyRevenue += player.chosenPrice;
                PotentiallySellSecondCup(player);
            }
        }

        public void RecapDay(Player player)
        {
            Console.WriteLine("\nDAILY RECAP:");
            DisplayDailyFinances(player);
            Console.WriteLine("Think for a second about what today's conditions were and how things went," +
                " then hit enter to continue.\n");
            Console.ReadLine();
        }

        public void DisplayDailyFinances(Player player)
        {
            DisplayDailyRevenue();
            DisplayDailyCosts(player);
            AddDailyToRunningProfit(player);
            DisplayDailyProfit(player);
            DisplayProfitSinceStart(player);
        }

        public void DisplayDailyRevenue()
        {
            Console.WriteLine("Your revenue today was $" + (dailyRevenue / 100));
        }

        public void DisplayDailyCosts(Player player)
        {
            Console.WriteLine("You spent $" + (player.dailyCosts / 100) + " on inputs");
        }

        public void DisplayDailyProfit(Player player)
        {
           
            Console.WriteLine("Your daily profit was $" + dailyProfit);
        }
        public void DisplayProfitSinceStart(Player player)
        {
            Console.WriteLine("Total profit so far:  $" + player.profitSinceStart);
        }

        public void CalculateDailyProfit(Player player)
        {
            dailyProfit = (dailyRevenue - player.dailyCosts) / 100;
        }

        public void ResetAppropriateFields(Player player)
        {
            ResetDailyTrackers(player);
            DumpLeftoverLemonade(player);
            if (!player.boughtRefrigeration)
            { PerishableInventorySpoils(player); }
        }

        public void ResetDailyTrackers(Player player)
        {
            ResetDailyProfit(player);
            ResetDailyCosts(player);
            ResetDailyRevenue();
        }

        public void ResetDailyCosts(Player player)
        {
            player.dailyCosts = 0;
        }

        public void ResetDailyRevenue()
        {
            dailyRevenue = 0;
        }

        public void AddThenResetProfit(Player player)
        {
            CalculateDailyProfit(player);
            AddDailyToRunningProfit(player);
            ResetDailyProfit(player);
        }

        public void AddDailyToRunningProfit(Player player)
        {
            CalculateDailyProfit(player);
            player.profitSinceStart += dailyProfit;
        }

        public void ResetDailyProfit(Player player)
        {
            dailyProfit = 0;
        }

        public void DumpLeftoverLemonade(Player player)
        {
            player.pitchersAvailable = 0;
        }

        public void PerishableInventorySpoils(Player player)
        {
            IceMelts(player);
            LemonsSpoil(player);
        }

        public void IceMelts(Player player)
        {
            player.inventory.iceInventory.Clear();
        }

        public void LemonsSpoil(Player player)
        {
            player.inventory.lemonInventory.Clear();
        }
    }
}