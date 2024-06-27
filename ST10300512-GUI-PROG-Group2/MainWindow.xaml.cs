// Bradley Bensch
// St10300512
// Group 2
/* References used: https://learn.microsoft.com/en-us/dotnet/api/system.array.clone?view=net-8.0 
 https://www.programiz.com/csharp-programming/switch-statement */

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Text;
using System.Windows.Controls;
using ST10300512_Prog_POE_Group2;

namespace ST10300512_GUI_PROG_Group2
{
    public partial class MainWindow : Window
    {
        private List<Recipes> recipes = new List<Recipes>();

        public MainWindow()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Add ingredient to the current recipe being edited
            if (recipes.Count > 0)
            {
                recipes.Last().Ingredients.Add(new Ingredients(
                    txtIngredientName.Text,
                    txtQuantity.Text,
                    txtUnit.Text,
                    double.Parse(txtCalories.Text),
                    txtFoodGroup.Text
                ));
                UpdateRecipeList();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            // Add step to the current recipe being edited
            if (recipes.Count > 0)
            {
                recipes.Last().Steps.Add(txtStep.Text);
                UpdateRecipeList();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Save current recipe to the list
            recipes.Add(new Recipes(txtRecipeName.Text));
            ClearRecipeFields();
            UpdateRecipeList();
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            // Filter recipes by ingredient name
            string filterText = txtFilter.Text.ToLower();
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(filterText))).ToList();

            UpdateRecipeListBox(filteredRecipes);
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void UpdateRecipeList()
        {
            // Update the ListBox with recipe names
            UpdateRecipeListBox(recipes);
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void UpdateRecipeListBox(List<Recipes> recipesToUpdate)
        {
            lstRecipes.Items.Clear();
            foreach (var recipe in recipesToUpdate)
            {
                lstRecipes.Items.Add(recipe.Name);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void ClearRecipeFields()
        {
            // Clear all recipe input fields
            txtRecipeName.Clear();
            txtIngredientName.Clear();
            txtQuantity.Clear();
            txtUnit.Clear();
            txtCalories.Clear();
            txtFoodGroup.Clear();
            txtStep.Clear();
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void lstRecipes_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Handle selection change in the recipe list
            if (lstRecipes.SelectedItem != null)
            {
                string selectedRecipeName = lstRecipes.SelectedItem.ToString();
                var recipe = recipes.FirstOrDefault(r => r.Name.Equals(selectedRecipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe != null)
                {
                    // Display basic recipe details
                    txtRecipeDetails.Text = $"Recipe: {recipe.Name}\n\n";

                    // Display ingredients
                    txtRecipeDetails.Text += "Ingredients:\n";
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        txtRecipeDetails.Text += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.FoodGroup}) - {ingredient.Calories} calories\n";
                    }

                    // Display steps
                    txtRecipeDetails.Text += "\nSteps:\n";
                    for (int i = 0; i < recipe.Steps.Count; i++)
                    {
                        txtRecipeDetails.Text += $"Step {i + 1}: {recipe.Steps[i]}\n";
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------//
        private void btnDisplayFullRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Display full recipe details for the selected recipe
            if (lstRecipes.SelectedItem != null)
            {
                string selectedRecipeName = lstRecipes.SelectedItem.ToString();
                var recipe = recipes.FirstOrDefault(r => r.Name.Equals(selectedRecipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe != null)
                {
                    // Clear previous details
                    txtRecipeDetails.Text = "";

                    // Display full recipe details
                    txtRecipeDetails.Text += $"Recipe: {recipe.Name}\n\n";

                    // Display ingredients
                    txtRecipeDetails.Text += "Ingredients:\n";
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        txtRecipeDetails.Text += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.FoodGroup}) - {ingredient.Calories} calories\n";
                    }

                    // Display steps
                    txtRecipeDetails.Text += "\nSteps:\n";
                    for (int i = 0; i < recipe.Steps.Count; i++)
                    {
                        txtRecipeDetails.Text += $"Step {i + 1}: {recipe.Steps[i]}\n";
                    }
                }
            }
        }
    }
}
//----------------------------------------------------------End of File------------------------------------------------//