// Bradley Bensch
// St10300512
// Group 2
/* References used: https://learn.microsoft.com/en-us/dotnet/api/system.array.clone?view=net-8.0 
 https://www.programiz.com/csharp-programming/switch-statement */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10300512_Prog_POE_Group2
{
    public class Recipes
    {
        // Gets and sets the Recipe name, steps and Arrays
        public string Name { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        // Constructor for the Recipe
        public Recipes(string name)
        {
            Name = name;
            Ingredients = new List<Ingredients>();
            Steps = new List<string>();
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Adds up the total calories
        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }
    }
}
//----------------------------------------------------------End of File------------------------------------------------//
