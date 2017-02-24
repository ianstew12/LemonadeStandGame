using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LemonadeStand.cs
{
    public class Cups:Item
    {
        public Cups()
        {
            minimumPrice = 2;
            maximumPrice = 5;
            itemName = "cups";
            
        }
    }
}