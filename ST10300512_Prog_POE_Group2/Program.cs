// Bradley Bensch
// St10300512
// Group 2
/* References used: https://learn.microsoft.com/en-us/dotnet/api/system.array.clone?view=net-8.0 
 https://www.programiz.com/csharp-programming/switch-statement */

using RecipeMethod;
using ST10300512_Prog_POE_Group2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            List<Recipes> recipes = new List<Recipes>();
            //Swapped previous Display with a Switch statement 
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select a recipe to display");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                // Adds any number of recipe
                    case "1":
                        AddNewRecipe(recipes);
                        break;
                // Displays all inputed recipes
                    case "2":
                        DisplayAllRecipes(recipes);
                        break;
                // Shows steps and ingredients of inserted recipe
                    case "3":
                        SelectAndDisplayRecipe(recipes);
                        break;
                // Closes the application
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        //This adds a new recipe to the list
        static void AddNewRecipe(List<Recipes> recipes)
        {
            Console.WriteLine("What is your recipe's name: ");
            string recipeName = Console.ReadLine();
            Recipes recipe = new Recipes(recipeName);

            int numIngredients = GetNumber("How many ingredients are in the recipe: ");
            // for loop which will run until receahed number of ingredients
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1}: ");
                string ingredientName = Console.ReadLine();
                Console.Write("How much of the ingredient: ");
                string quantity = Console.ReadLine();
                Console.Write("What is the Unit of Measurement for this ingredient: ");
                string unit = Console.ReadLine();
                double calories = GetCalories("Enter the number of calories for this ingredient: ");
                Console.Write("Enter the food group for this ingredient: ");
                string foodGroup = Console.ReadLine();

                Ingredients ingredient = new Ingredients(ingredientName, quantity, unit, calories, foodGroup);
                recipe.Ingredients.Add(ingredient);
            }

            int numSteps = GetNumber("How many steps are in the recipe?");
            // for loop which will run until receahed number of steps
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"What is step {i + 1}'s instruction:");
                recipe.Steps.Add(Console.ReadLine());
            }
            // Adds the recipe to the array
            recipes.Add(recipe);
            Console.WriteLine("Recipe added successfully.");
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Gets number of ingredients and steps from user
        static int GetNumber(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Gets the amount of calories from the user
        static double GetCalories(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Displays all Recipes
        static void DisplayAllRecipes(List<Recipes> recipes)
        {
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            Console.WriteLine("List of all recipes:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Gets the steps, ingredients, measurements and Name of the selected Recipe
        static void SelectAndDisplayRecipe(List<Recipes> recipes)
        {
            Console.WriteLine("Enter the name of the recipe you want to display: ");
            string recipeName = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                PrintRecipe(recipe);
                ManageRecipe(recipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Prints the steps, ingredients, measurements and Name of the selected Recipe
        static void PrintRecipe(Recipes recipe)
        {
            Console.WriteLine($"\nRecipe for: {recipe.Name}");
            Console.WriteLine("\n************************\n");
            Console.WriteLine("List of Ingredients:\n");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.FoodGroup}) - {ingredient.Calories} calories");
            }
            double totalCalories = recipe.CalculateTotalCalories();
            Console.WriteLine($"\nTotal Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300!");
            }
            Console.WriteLine("\n************************\n");
            Console.WriteLine("\nList of Steps\n");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {recipe.Steps[i]}");
            }
            Console.WriteLine("\n************************\n");
        }
        //------------------------------------------------------------------------------------------------------------------------//
        // Scales thre recipe and offers a reset for it
        static void ManageRecipe(Recipes recipe)
        {
            List<string> originalQuantities = recipe.Ingredients.Select(i => i.Quantity).ToList();
            List<double> originalCalories = recipe.Ingredients.Select(i => i.Calories).ToList();
            while (true)
            {
                Console.WriteLine("Do you want to scale the ingredients? Enter 0.5, 2, or 3 for scaling, or 0 to skip: ");
                string userScale = Console.ReadLine();

                if (userScale == "0")
                {
                    break;
                }

                RecipeMethods recipeScaler = new RecipeMethods();
                string scaleMessage = recipeScaler.Scaler(userScale, recipe.Ingredients);
                Console.WriteLine(scaleMessage);

                PrintRecipe(recipe);

                Console.WriteLine("Do you want to reset the scaling? (yes/no)");
                string resetChoice = Console.ReadLine();

                if (resetChoice.ToLower() == "yes")
                {
                    bool resetSuccess = recipeScaler.ResetQuantity(originalQuantities, originalCalories, recipe.Ingredients, true);
                    if (resetSuccess)
                    {
                        Console.WriteLine("Reset successful!");
                        PrintRecipe(recipe);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
//----------------------------------------------------------End of File------------------------------------------------//