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
            Console.WriteLine("how many lemons per pitcher?");
            lemons = int.Parse(Console.ReadLine());
        }

        public void SetRecipeSugar()
        {
            Console.WriteLine("\nhow many sugar units per pitcher?");
            sugarUnits = int.Parse(Console.ReadLine());
        }

        public void SetRecipeIce()
        {
            Console.WriteLine("\nhow many ice units per pitcher?");
            iceUnits = int.Parse(Console.ReadLine());
        }
    }
}
