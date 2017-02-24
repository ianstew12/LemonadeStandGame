using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Player
    {
        public string name;
        public Wallet wallet;
        public Inventory inventory;
        public Recipe recipe;
        public double pitchersAvailable;
        public int chosenPrice;
        public decimal startupCapital;
        public double profitSinceStart;
        public double dailyCosts;
        public bool boughtRefrigeration;
        public string finalGrade;

        public Player(Random random)
        {
            wallet = new Wallet();
            recipe = new Recipe();
            inventory = new Inventory();
            profitSinceStart = 0;
            startupCapital = random.Next(1000, 5000);
            wallet.balance = startupCapital;
            pitchersAvailable = 0;
            boughtRefrigeration = false;
        }

        public void MakePitcher()
        {
            if ((inventory.iceInventory.Count >= recipe.iceUnits) &&
                (inventory.sugarInventory.Count >= recipe.sugarUnits) &&
                (inventory.lemonInventory.Count >= recipe.lemons))
            {
                for (int i = 0; i < recipe.iceUnits; i++)
                {
                    inventory.iceInventory.RemoveAt(0);
                }

                for (int i = 0; i < recipe.sugarUnits; i++)
                {
                    inventory.sugarInventory.RemoveAt(0);
                }
                for (int i = 0; i < recipe.lemons; i++)
                {
                    inventory.lemonInventory.RemoveAt(0);
                }
                pitchersAvailable += 1;
            }
            else
            {
                Console.WriteLine("You don't have enough inventory to make pitcher");
            }
        }

        public void MakeSpecifiedPitchers()
        {
            Console.WriteLine("\nPITCHER QUANTITY:\nHow many pitchers would you like to make?"+
                "\nReminder: The Health Department requires you dump remaining pitchers after each business day.");
            int pitcherCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < pitcherCount; i++)
            {
                MakePitcher();
            }
        }

        public void SellServing()
        {
            {
                pitchersAvailable -= 0.1;
                inventory.cupsInventory.RemoveAt(0);
                wallet.balance += chosenPrice;
            }
        }

        public bool checkRequiredInventory()
        {
            if (checkCupsInventory() && checkPitcherStatus())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkCupsInventory()
        {
            int cupsInStock = inventory.cupsInventory.Count;
            if (cupsInStock > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkPitcherStatus()
        {
            if (pitchersAvailable >= 0.1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LoseIce()
        {
            inventory.iceInventory.Clear();
        }
        public void LoseLeftoverLemonade()
        {
            pitchersAvailable = 0;
        }
        public void LoseToDailyWaste()
        {
            LoseIce();
            LoseLeftoverLemonade();
        }

        public void SetServingPrice()
        {
            Console.WriteLine("\nSET YOUR PRICE:\nHow many cents do you want to charge per serving today?");
            chosenPrice = int.Parse(Console.ReadLine());
        }

    }
}