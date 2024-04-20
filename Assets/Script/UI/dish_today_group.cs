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
        if (!dish.is_locked)
        {
            dish.layer_select.SetActive(true);
        }
    }

    public void OnDishExit(DishToday dish)
    {
        if (!dish.is_selecting)
        {
            dish.layer_select.SetActive(false);
        }
    }

    public DishToday dish_selected;
    public void OnDishSelected(DishToday dish)
    {
        if (dish_selected) dish_selected.layer_select.SetActive(false);
        dish_selected = dish;
        dish.layer_bk.SetActive(dish.is_selected);
        dish.layer_select.SetActive(true);
        dish.is_selecting = true;
    }

    //public void ResetDish()
    //{
    //    foreach(DishToday dish in dishes)
    //    {
    //        dish.layer_select.SetActive(false);
    //        dish.layer_lock.SetActive(dish.is_locked);
    //        dish.layer_bk.SetActive(false);
    //    }
    //}
}
