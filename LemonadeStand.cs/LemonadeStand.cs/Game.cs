using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Game
    {
        Player player;
        Random random;
        Day day;
        int businessPeriod;
        int daysOpen;
        Location location;

        public Game()
        {
            random = new Random();
            player = new Player(random);
            businessPeriod = 0;
            daysOpen = 0;
            //location = new Location();
            location = SetLocation();
            day = new Day(random, location);
        }

        public void RunGame()
        {
            StartUpGame();
            for (int i = 0; i < businessPeriod; i++)
            {
                day.RunDailyCycle(player);
                daysOpen += 1;
            }
            DisplayPerformanceEvaluation();
            Console.ReadLine();
        }
        public void StartUpGame()
        {
            DisplayStartUpInfo();
            SetUpBasics();
            TellPlayerWhatsComing();
        }
        public void DisplayStartUpInfo()
        {
            DisplayGameWelcome();
            DisplayStartupCapital();
        }
        public void DisplayGameWelcome()
        {
            Console.WriteLine("Welcome to Lemonade Stand. Get ready to start your lemonade empire.");
        }
        public void DisplayStartupCapital()
        {
            Console.WriteLine("\nSTARTUP CAPITAL:  $" + player.startupCapital / 100 + "\n");
        }

        public void SetUpBasics()
        {
            SetBusinessPeriod();
            //SetLocation();                Commenting out for now while running SetLocation in Game class constructor day instantiation
        }
        public void SetBusinessPeriod()
        {
            Console.WriteLine("For how many days would you like to run your lemonade stand?");
            try
            {
                businessPeriod = int.Parse(Console.ReadLine().Trim());
            }
            catch (Exception)                                                   //DOES NOT CATCH NEGATIVE NUMBERS
            {
                Console.WriteLine("Invalid entry.");
                SetBusinessPeriod();
            }
        }
        public Location SetLocation()
        {
            Console.WriteLine("Where would you like to set your location?"+
                "Your options are San Diego, Alaska, Kuwait, and the Nevada. \n"
                + "Enter 'SD' for San Diego, 'AK' for Alaska, 'KW' for Kuwait or 'NV' for Nevada");     
            string locationChosen = Console.ReadLine().Trim().ToLower();
            if (locationChosen == "sd"||locationChosen=="sandiego")
            {
                return location = new SanDiego();
            }
            else if (locationChosen == "ak"||locationChosen=="alaska")
            {
                return location = new Alaska();
            }
            else if (locationChosen == "nv"||locationChosen=="nevada")
            {
                return location = new Nevada();
            }
            else if (locationChosen == "kw"||locationChosen=="kuwait")
            {
                return location = new Kuwait();
            }
            else
            {
                Console.WriteLine("Invalid entry. Try again");
                return SetLocation();
            }
        }

        public void TellPlayerWhatsComing()
        {
            Console.WriteLine("Hit 'enter' to see the weather forecast and cost of your" 
                +" inputs (e.g. sugar). This is the information you use to make your business"+
                " decisions. Each day will begin with this process.");
            Console.ReadLine();
        }

        public void DisplayPerformanceEvaluation()
        {
            DisplayFinalProfitWithMessage();
            GradeProfitByLocation();
            DisplayGrade();

        }
        public void DisplayFinalProfitWithMessage()
        {
            Console.WriteLine("After " + businessPeriod + " days in business,"
    + " your total profit is $" + player.profitSinceStart);
        }
        public void GradeProfitByLocation()
        {
            if ((player.profitSinceStart > 50) && (location.maximumTemperature < 110))
            {
                player.finalGrade = "EXCELLENT!";
            }
            else if ((player.profitSinceStart < 10) && (location.minimumTemperature > 70))
            {
                player.finalGrade = "PATHETIC!";
            }
            else
            {
                player.finalGrade = "okay.";
            }
        }
        public void DisplayGrade()
        {
            Console.WriteLine("\nConsidering the conditions you played with, your performance was " +
               player.finalGrade);
        }
        
       }
   }

