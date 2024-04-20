using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishGroup : MonoBehaviour
{
    public List<DishToday> dishes;
    
    public void Subscribe(DishToday dish)
    {
        if (dishes == null) dishes = new List<DishToday>();
        dishes.Add(dish);
    }

    public void OnDishEnter(DishToday dish)
    {
        dish.is_selecting = true;
    }

    public void OnDishExit(DishToday dish)
    {
        dish.is_selecting = false;
    }

    public void OnDishSelected(DishToday dish)
    {
        dish.is_selected = true;
    }
}
