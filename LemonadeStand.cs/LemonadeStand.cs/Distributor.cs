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
            SellIcebox(player);//name not perfect but whatever for now
        }


        public void SellLemons(Player player)
        {
            int quantitySold = GetLemonQuantity(player);
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
                SellLemons(player);
                   }
         }


        public int GetLemonQuantity(Player player)
        {
            int quantitySold = -2;
            while (quantitySold < 0)
            {
                try
                {
                    ProposeLemonsWithInfo(player);
                    quantitySold = int.Parse(Console.ReadLine().Trim());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nYOU MUST ENTER A POSITIVE INTEGER. TRY AGAIN.");
                }
            }
            return quantitySold;
        }

        public void ProposeLemonsWithInfo(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nLemon Price:" + lemon.price + "\nYour Lemon Quanity: "
           + player.inventory.lemonInventory.Count + "\nHow many lemons would you like to buy?");
        }
        public bool LemonFundsAvailable(Player player, int purschaseQuantity, int itemPrice)
        {
            itemPrice = lemon.price;
            if (player.wallet.balance >= (lemon.price * purschaseQuantity))
                return true;
            else { return false; }
        }//I never actually use this



        public void SellIce(Player player)       //rename to noun
        {

            int quantitySold = GetIceQuantity(player);
            int transactionAmount = CalculateTransactionAmount(quantitySold, ice.price);
            if (FundsAvailable(player,transactionAmount))
            {
                TransactIcePurchase(player, transactionAmount, quantitySold);
            }
            else
            {
                Console.WriteLine("Insufficient funds for ice purchase");
                SellIce(player);
            }
        }

        public int GetIceQuantity(Player player)
        {
            int quantitySold = -2;
            while (quantitySold < 0)
            {
                try
                {
                    ProposeIceWithInfo(player);
                    quantitySold = int.Parse(Console.ReadLine().Trim());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nYOU MUST ENTER A POSITIVE INTEGER. TRY AGAIN.");
                }
            }
            return quantitySold;
        }

        public void ProposeIceWithInfo(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nIce Price:" + ice.price + "\nYour Ice Quanity: "
                + player.inventory.iceInventory.Count + "\nHow many ice units would you like to buy?");
        }
        public int CalculateTransactionAmount(int quantitySold, int itemPrice)
        {
            int transactionAmount;
            return transactionAmount = quantitySold*itemPrice;
        }
        public bool FundsAvailable(Player player, int transactionAmount)
        {
                if (player.wallet.balance >= transactionAmount)
                    return true;
                else { return false; }
            }
        public void TransactIcePurchase(Player player, int transactionAmount, int quantitySold)
        {
            player.wallet.balance -= transactionAmount;
            player.dailyCosts += transactionAmount;
            for (int i = 0; i < quantitySold; i++)
            {
                Ice iceSold = new Ice();
                player.inventory.iceInventory.Add(iceSold);
            }
        }

        public void SellCups(Player player)
        {

            int quantitySold = GetCupsQuantity(player);
            int transactionAmount = quantitySold * cups.price;
            if (FundsAvailable(player,transactionAmount))
            {
                TransactCupsPurchase(player, transactionAmount, quantitySold);
            }
            else
            {
                Console.WriteLine("Insufficient funds for cups purchase");
                SellCups(player);
            }
        }

        public int GetCupsQuantity(Player player)
        {
            int quantitySold = -2;
            while (quantitySold < 0)
            {
                try
                {
                    ProposeCupsWithInfo(player);
                    quantitySold = int.Parse(Console.ReadLine().Trim());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nYOU MUST ENTER A POSITIVE INTEGER. TRY AGAIN.");
                }
            }
            return quantitySold;
        }

        public void ProposeCupsWithInfo(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nCups Price:" + cups.price + "\nYour Cups Quanity: "
           + player.inventory.cupsInventory.Count + "\nHow many cups would you like to buy? (Reminder:"
            + " 10 per pitcher)");
        }

        public void TransactCupsPurchase(Player player, int transactionAmount, int quantitySold)
        {
            player.wallet.balance -= transactionAmount;
            player.dailyCosts += transactionAmount;
            for (int i = 0; i < quantitySold; i++)
            {
                Cups cupsSold = new Cups();
                player.inventory.cupsInventory.Add(cupsSold);
            }
        }

        public void SellSugar(Player player)
        {
            int quantitySold = GetSugarQuantity(player);
            int transactionAmount = quantitySold * sugar.price;
            if (FundsAvailable(player, transactionAmount))
            {
                TransactSugarPurchase(player, transactionAmount, quantitySold);
            }
            else
            {
                Console.WriteLine("Insufficient funds for sugar purchase");
                SellSugar(player);
            }
        }

        public void OfferSugarWithInfo(Player player)
        {
            player.wallet.DisplayBalance();
            Console.WriteLine("\nSugar Price:" + sugar.price + "\nYour sugar Quanity: "
            + player.inventory.sugarInventory.Count + "\nHow many sugar units would you like to buy?");
        }
        public int GetSugarQuantity(Player player)
        {
            int quantitySold = -2;
            while (quantitySold < 0)
            {
                try
                {
                    OfferSugarWithInfo(player);
                    quantitySold = int.Parse(Console.ReadLine().Trim());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nYOU MUST ENTER A POSITIVE INTEGER. TRY AGAIN.");
                }
            }
            return quantitySold;
        }
        public void TransactSugarPurchase(Player player, int transactionAmount, int quantitySold)
        {
            player.wallet.balance -= transactionAmount;
            player.dailyCosts += transactionAmount;
            for (int i = 0; i < quantitySold; i++)
            {
                Sugar sugarSold = new Sugar();
                player.inventory.sugarInventory.Add(sugarSold);
            }
        }

        public void SellIcebox(Player player)
        {
            if (!player.boughtIcebox)
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
            else if (fridgeResponse == "yes"&&FundsAvailable(player, icebox.price))
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
            player.boughtIcebox = true;
            player.dailyCosts += icebox.price;
            player.wallet.balance -= icebox.price;
        }
    }
}

