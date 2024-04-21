using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishUI : MonoBehaviour
{
    public string name;
    public string type;
    public float level;
    public float hardness;
    public float workload;
    public float avg_price;
    public List<IngredientUI> ingredientList;
    public List<string> cookingList;
}
