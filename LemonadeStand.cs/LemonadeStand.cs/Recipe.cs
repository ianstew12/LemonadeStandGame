using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand.cs
{
    public class Recipe
    {
       public int lemons;          
       public int sugarUnits;
       public int iceUnits;
        
     
        public Recipe()      
        {                      
            lemons = 1;
            sugarUnits = 1;
            iceUnits = 1;
        }
            
        public void SetRecipe()
        {
            ExplainRecipeAdjustments();
            SetRecipeLemons();
            SetRecipeSugar();
            SetRecipeIce();
        }
        public void ExplainRecipeAdjustments()
        {
            Console.WriteLine("\nSET YOUR RECIPE:\nAdjust your recipe based on your inventory, prices and"
                + " predicted customer preferences.\n");
        }

        public void SetRecipeLemons()
        {
            int playersLemonInput = -1;
            while (playersLemonInput < 0)
            {
                try
                {
                    Console.WriteLine("how many lemons per pitcher?");
                    playersLemonInput = int.Parse(Console.ReadLine());
                    lemons = playersLemonInput;
                }
                catch (Exception)
                {
                    AlertInputMustBeNonnegativeInteger();
                }
            }
        }
        public void SetRecipeSugar()
        {
            int playersSugarInput = -1;
            while (playersSugarInput < 0)
            {
                try
                {
                    Console.WriteLine("how many sugar units per pitcher?");
                    playersSugarInput = int.Parse(Console.ReadLine());
                    sugarUnits = playersSugarInput;
                }
                catch (Exception)
                {
                    AlertInputMustBeNonnegativeInteger();
                }
            }
        }
        public void SetRecipeIce()
        {
            int playersIceInput = -1;
            while (playersIceInput < 0)
            {
                try
                {
                    Console.WriteLine("how many ice cubes per pitcher?");
                    playersIceInput = int.Parse(Console.ReadLine());
                    iceUnits = playersIceInput;
                }
                catch (Exception)
                {
                    AlertInputMustBeNonnegativeInteger();
                }
            }
        }


        public void SetRecipeItem(Item item)
        {
            //I have tried to find a way to write a method that sets the recipe for all items, taking
            //in item as a parameter, but I can't get it to work because when Item item is a parameter,
            //I can't pass in e.g. Lemon lemon  (this might be a case to use generics?)\
        }
        public int ValidateIntegerEntry(string userEntry)
        {
            int userEntryParsed = -2;
            userEntry.Trim();
            while (userEntryParsed < 0)
            {
                try
                {
                    return userEntryParsed = int.Parse(userEntry);
                }
                catch (Exception)
                {
                   AlertInputMustBeNonnegativeInteger();
                }
            }
                return userEntryParsed;
        }
        public bool ValidateNonNegativeInteger(int userEntryParsed)
        {
            if (userEntryParsed >= 0)
            {
                return true;
            }
            else {
                Console.WriteLine("Entry must be non-negative\n");
                return false;
            }
        }
        public void AlertInputMustBeNonnegativeInteger()
        {
            Console.WriteLine("Invalid quantity. Must enter a nonnegative integer.");
        }
    }
}
