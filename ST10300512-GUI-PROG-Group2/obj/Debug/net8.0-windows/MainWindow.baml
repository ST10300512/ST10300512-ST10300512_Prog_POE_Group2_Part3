   M S B A M L   `   `   `  ����  ST10300512-GUI-PROG-Group2+    %ST10300512_GUI_PROG_Group2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Recipe Manager��5   	   $	��600��6    $	��800��6-   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Add New Recipe��6   $��0��6+   .��5      �� $
��Auto=�6   .��5      �� .+�5      �� -   5         ��Name$ txtRecipeName��5      $��Recipe Name��65   $��5q�6H   �� 5      -   5        $ txtIngredientName��5      $��Ingredient Name��69   $��5q�6P   �� 5      -   5        $ txtQuantity��5      $��Quantity��63   $��5q�6C   �� 5      -   5        $ txtUnit��5      $
��Unit��6/   $��5q�6;   �� 5      -   5        $ txtCalories��5      $��Calories��63   $��5q�6C   �� 5      -   5        $ txtFoodGroup��5      $��
Food Group��64   $��5q�6F   �� 5      -   5        $��Add Ingredient��5      $��5q�6U   �� 5      -   5        $ txtStep��5      $
��Step��6/   $��5q�6;   �� 5      -	   5        $��Add Step��5      $��5q�6I   �� 5!      -
   5        $��Save Recipe��5!      $��5q�6O   5"      5#      5$      �� 5'   
   $��Recipe List��6   $��1��6(   $��0,10,0,0q�65   .��5(      �� $
��Auto=�6   .��5)      �� .+�5*      �� -   5        $ 	txtFilter��5*      $��Filter by Ingredient Name��61   $��5q�6R   �� 5+      -   5        $��Filter Recipes��5+      $��5q�6N   �� 5,      -   5         ��Name$ 
lstRecipes��5,      $��5q�62   $	��300��6=   6J   5-      5.      5/      �� 52   
   $��Recipe Details��6   $��2��6+   $��0,10,0,0q�68   .��53      �� $
��Auto=�6   .��54      �� .+�55      �� -   5         ��Name$ txtRecipeDetails��55       $��5q�6:   $
��Wrap=�6E   �� 56      -   5        $��Display Full Recipe��56      $��5q�6^   57      58      59      5:      5;      