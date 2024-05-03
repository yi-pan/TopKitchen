using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    public DataCollector collected_data;

    public IngredListShop ingred_list;

    private List<IngredientUI> selected_dish_ingredients;

    private List<IngredientUI> shopped_ingredients;

    // shop ingredients 
    public void Shopping()
    {
        selected_dish_ingredients = collected_data.ingredients_today;
        shopped_ingredients = new List<IngredientUI>();
        //PrintIngred(selected_dish_ingredients);
        // [NOW, I shop 3 times ingredients for all dishes selected]
        foreach (IngredientUI ingred in selected_dish_ingredients)
        {
            //ingred.name = ingred.name.Replace(" ", string.Empty);
            bool is_shopped = false;
            foreach (IngredientUI shopped_ingred in shopped_ingredients)
            {
                //shopped_ingred.name = shopped_ingred.name.Replace(" ", string.Empty);
                
                // if the ingred is in the shopped_ingred
                if (shopped_ingred.ingred_name.Equals(ingred.ingred_name))
                {
                    //Debug.Log("!!!!!!!!!!!!!!!!!!!!" + ingred.name);
                    is_shopped = true;
                    shopped_ingred.count += ingred.count * 3;
                }
            }

            // if the ingred is not in the shopped_ingred
            if (!is_shopped)
            {
                IngredientUI i = new()
                {
                    ingred_name = ingred.ingred_name,
                    count = ingred.count,
                    type = ingred.type
                };

                i.count *= 3;
                shopped_ingredients.Add(i);
            }
        }
        PrintIngred(selected_dish_ingredients);

        // send the shopped_ingredients to IngredListShop, where all the shopped ingreds are shown
        ingred_list.CreateList(shopped_ingredients);
    }

    void PrintIngred(List<IngredientUI> ingreds)
    {
        string ingred_string = "";
        foreach (IngredientUI ingred in ingreds)
        {
            ingred_string += ingred.ingred_name + " " + ingred.type + " " + ingred.count;
            //Debug.Log(ingred_string);
        }
    }
}
