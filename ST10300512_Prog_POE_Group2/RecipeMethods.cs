// Bradley Bensch
// St10300512
// Group 2
/* References used: https://learn.microsoft.com/en-us/dotnet/api/system.array.clone?view=net-8.0 
 https://www.programiz.com/csharp-programming/switch-statement */

using ST10300512_Prog_POE_Group2;
using System;
using System.Collections.Generic;

namespace RecipeMethod
{
    public class RecipeMethods
    {   // Scales the recipe
        public string Scaler(string userScale, List<Ingredients> ingredients)
        {
            string msg;
            if (double.TryParse(userScale, out double scale))
            {
                if (scale == 0.5 || scale == 2 || scale == 3)
                {
                    msg = $"You have chosen to scale the recipe by {scale} times.";
                    foreach (var ingredient in ingredients)
                    {
                        if (double.TryParse(ingredient.Quantity, out double quantity))
                        {
                            quantity *= scale;
                            ingredient.Quantity = quantity.ToString();
                        }
                        ingredient.Calories *= scale;
                    }
                }
                else
                {
                    msg = "Invalid input. Please enter 0.5, 2, or 3.";
                }
            }
            else
            {
                msg = "Invalid input. Please enter a valid number.";
            }
            return msg;
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Resets the scaling
        public bool ResetQuantity(List<string> originalQuantities, List<double> originalCalories, List<Ingredients> ingredients, bool resetRequested)
        {
            if (resetRequested)
            {
                if (originalQuantities.Count != ingredients.Count || originalCalories.Count != ingredients.Count)
                {
                    return false;
                }

                for (int i = 0; i < originalQuantities.Count; i++)
                {
                    if (double.TryParse(originalQuantities[i], out double originalQuantity))
                    {
                        double scaleFactor = originalQuantity / double.Parse(ingredients[i].Quantity);
                        ingredients[i].Quantity = originalQuantities[i];
                        ingredients[i].Calories = originalCalories[i];
                    }
                }
                return true;
            }
            return false;
        }
    }
}
//----------------------------------------------------------End of File------------------------------------------------//
