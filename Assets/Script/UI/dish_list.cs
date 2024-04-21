using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DishListUI : MonoBehaviour
{
    [SerializeField] private TextAsset _file;

    public List<DishUI> dishList;

    void Start()
    {
        var content = _file.text;
        var words = content.Split("\n");
        var list = new List<string>(words);
        foreach (var line in list)
        {
            var variables = new List<string>(line.Split("; "));
            DishUI dish = gameObject.AddComponent<DishUI>();
            dish.name = variables[0];
            dish.type = variables[1];
            dish.level = float.Parse(variables[2]);
            dish.hardness = float.Parse(variables[3]);
            dish.workload = float.Parse(variables[4]);
            dish.avg_price = float.Parse(variables[5]);
            var tmp_ingred = new List<string>(variables[6].Split(", "));

            foreach (var i in tmp_ingred)
            {
                IngredientUI ingred = gameObject.AddComponent<IngredientUI>();
                var word = new List<string>(i.Split(" "));
                ingred.name = word[0];
                ingred.type = word[1];
                ingred.count = float.Parse(word[2]);
                if (dish.ingredientList == null) dish.ingredientList = new List<IngredientUI>();
                dish.ingredientList.Add(ingred);
            }

            dish.cookingList = new List<string>(variables[7].Split(", "));
            dishList.Add(dish);
        }
        //printDishList();
    }

    public DishUI GetDishDetail(string name)
    {
        foreach (var dish in dishList)
        {
            if (dish.name == name) return dish;
        }
        return null;
    }

    void printDishList()
    {
        Debug.Log(dishList.Count);
        foreach (var dish in dishList)
        {
            Debug.Log(dish.name + " " + dish.type + " " + dish.level + " " + dish.hardness + " " + dish.workload + " " + dish.avg_price);
            foreach(var ingred in dish.ingredientList)
            {
                Debug.Log(ingred.name + " " + ingred.type + " " + ingred.count);
            }
            foreach(var method in dish.cookingList)
            {
                Debug.Log(method);
            }
        }
    }
}
