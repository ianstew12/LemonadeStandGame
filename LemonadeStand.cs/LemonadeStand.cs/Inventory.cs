using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Inventory
    {

        public List<Ice> iceInventory;
        public List<Sugar> sugarInventory;
        public List<Lemon> lemonInventory;
        public List<Cups> cupsInventory;


        public Inventory()
        {
            iceInventory = new List<Ice>();
            sugarInventory = new List<Sugar>();
            lemonInventory = new List<Lemon>();
           cupsInventory = new List<Cups>();
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\nYour current inventory: \nLemon Count: " + lemonInventory.Count +
                "\nSugar Units: " + sugarInventory.Count +
                "\nCups: " + cupsInventory.Count +
                "\nIce: " + iceInventory.Count+"\n");
        }


    }
}
