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
    public class Ingredients
    {    
       //get and sets for Ingredients,quantity ,calories, unit and Foodgroup
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        //------------------------------------------------------------------------------------------------------------------------//
        //Constructor for Ingredients
        public Ingredients(string name, string quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}
//----------------------------------------------------------End of File------------------------------------------------//

