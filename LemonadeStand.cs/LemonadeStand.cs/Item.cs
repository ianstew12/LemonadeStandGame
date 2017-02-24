using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public abstract class Item
    {
        public int price;           
        public int minimumPrice;
        public int maximumPrice;
        public string itemName;


        public Item()
        {
            
        }

        public void ChangeMinPrice(Item item, int newPrice)
        {
            item.minimumPrice=newPrice;
        }

        public void ChangeMaxPrice(Item item, int newPrice)
        {
            item.maximumPrice = newPrice;
        }

        public void ChangePrice(Item item, int newPrice)
        {
            item.price = newPrice;
        }
    }
}