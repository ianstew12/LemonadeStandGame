using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Distributor
    {
        Lemon lemon;
        Ice ice;
        Sugar sugar;
        Cups cups;
        Icebox icebox;


        public Distributor()
        {
            lemon = new Lemon();
            ice = new Ice();
            sugar = new Sugar();
            cups = new Cups();
            icebox = new Icebox(); 
        }

        public void ChangeItemPriceRandomly(Item item, Random randomNumber)
        {
            item.price = randomNumber.Next(item.minimumPrice, item.maximumPrice + 1);
        }

        public void changeDailyItemPrices(Random randomNumber)
        {
            ChangeItemPriceRandomly(lemon, randomNumber);
            ChangeItemPriceRandomly(ice, randomNumber);
            ChangeItemPriceRandomly(sugar, randomNumber);
            ChangeItemPriceRandomly(cups, randomNumber);
            ChangeItemPriceRandomly(icebox, randomNumber);
        }

        public void OfferItemsToPlayer(Player player)
        {
            DisplayShoppingInfo(player);
            SellItems(player);
        }
        public void DisplayShoppingInfo(Player player)
        {
            TellHowSellingWorks();
            DisplayPrices();
        }

        public void DisplayPrices()
        {
            Console.WriteLine("\nToday's Prices: \nLemon: " + lemon.price + "\nice: " + ice.price + "\nsugar: " + sugar.price
                + "\ncups: " + cups.price + "\n");
        }

        public void TellHowSellingWorks()
        {
            Console.WriteLine("BUY INVENTORY:\nTime to go to the distributor to stock up before the business day" +
                " (if necessary). You will see each input item's price and your quantity, and be asked" +
                " how many you want to buy. \nPress 'enter' to continue.");
            Console.ReadLine();
        }

        public void SellItems(Player player)
        {
            SellLemons(player);
            SellIce(player);
            SellCups(player);
            SellSugar(player);
            OfferRefrigeration(player);
        }

        public void SellLemons(Player player)
        {
            ProposeLemonsWithInfo(player);
            string replyAsString = Console.ReadLine();
            int quantitySold = int.Parse(replyAsString);
            int transactionAmount = quantitySold * lemon.price;
            if (transactionAmount <= player.wallet.balance)
            {
                player.wallet.balance -= transactionAmount;
                player.dailyCosts += transactionAmount;
               
                for (int i = 0; i < quantitySold; i++)
                {
                    Lemon lemonSold = new Lemon();
                    player.inventory.lemonInventory.Add(lemonSold);
                }
            }
            else {
                Console.WriteLine("Insufficient funds for lemon purchase");
                   }
         }
        public void ProposeLemonsWithInfo(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nLemon Price:" + lemon.price + "\nYour Lemon Quanity: "
           + player.inventory.lemonInventory.Count + "\nHow many lemons would you like to buy?");
        }

        public void SellIce(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nIce Price:" + ice.price + "\nYour Ice Quanity: "
                + player.inventory.iceInventory.Count +"\nHow many ice units would you like to buy?");
            int quantitySold = int.Parse(Console.ReadLine());
            int transactionAmount = quantitySold * ice.price;
            if (transactionAmount <= player.wallet.balance)
            {
                player.wallet.balance -= transactionAmount;
                player.dailyCosts += transactionAmount;
                for (int i = 0; i < quantitySold; i++)
                {
                    Ice iceSold = new Ice();
                    player.inventory.iceInventory.Add(iceSold);
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds for ice purchase");
            }
        }

        public void SellCups(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nCups Price:" + cups.price + "\nYour Cups Quanity: "
                + player.inventory.cupsInventory.Count + "\nHow many cups would you like to buy? (Reminder:"
                + " 10 per pitcher)");
            int quantitySold = int.Parse(Console.ReadLine());
            int transactionAmount = quantitySold * cups.price;
            if (transactionAmount <= player.wallet.balance)
            {
                player.wallet.balance -= transactionAmount;
                player.dailyCosts += transactionAmount;
                for (int i = 0; i < quantitySold; i++)
                {
                    Cups cupsSold = new Cups();
                    player.inventory.cupsInventory.Add(cupsSold);
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds for cups purchase");
            }
        }

        public void SellSugar(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nSugar Price:" + sugar.price + "\nYour sugar Quanity: "
                + player.inventory.sugarInventory.Count + "\nHow many sugar units would you like to buy?");


            int quantitySold = int.Parse(Console.ReadLine());
            int transactionAmount = quantitySold * sugar.price;
            if (transactionAmount <= player.wallet.balance)
            {
                player.wallet.balance -= transactionAmount;
                player.dailyCosts += transactionAmount;
                for (int i = 0; i < quantitySold; i++)
                {
                    Sugar sugarSold = new Sugar();
                    player.inventory.sugarInventory.Add(sugarSold);        
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds for sugar purchase");
            }
        }

        public void OfferRefrigeration(Player player)
        {
            if (!player.boughtRefrigeration)
            {
                MakeFridgeProposal();
                HandleFridgeResponse(player);
            }
        }
        public void MakeFridgeProposal()
        {
            Console.WriteLine("\nIf you don't get an icebox, you'll lose all your ice and lemons after each day."
                + "Would you like to buy one for $" + icebox.price / 100 + "?" +
                "\n Enter 'yes' or 'no'");
        }
        public void HandleFridgeResponse(Player player)
        {
            string fridgeResponse = Console.ReadLine();
            if (ValidateYesOrNo(fridgeResponse))
            {
                Console.WriteLine("\nInvalid response. Please enter 'yes' or 'no'");
                HandleFridgeResponse(player);
            }
            else if (fridgeResponse == "yes")
            {
                TransactFridge(player);
            }
        }

        public bool ValidateYesOrNo(string responseString)
        {
            responseString.Trim().ToLower();
            if (responseString == "yes" || responseString == "no")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void TransactFridge(Player player)
        {
            player.boughtRefrigeration = true;
            player.dailyCosts += icebox.price;
            player.wallet.balance -= icebox.price;
        }
    }
}
