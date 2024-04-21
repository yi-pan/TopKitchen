using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishAllGroup : MonoBehaviour
{
    public List<DishAll> dishes;
    public DishDetail dish_detail;
    public DishAll dish_selected;

    
    public void Subscribe(DishAll dish)
    {
        if (dishes == null) dishes = new List<DishAll>();
        dishes.Add(dish);
    }

    public void OnDishEnter(DishAll dish)
    {
        dish.layer_select.SetActive(true);
        dish_detail.SetDishDetail(dish.dish_name);
    }

    public void OnDishExit(DishAll dish)
    {
        if (!dish.is_selecting)
        {
            dish.layer_select.SetActive(false);
        }
        dish_detail.SetDishDetail(dish_selected.dish_name);
    }

    
    public void OnDishSelected(DishAll dish)
    {
        if (dish_selected)
        {
            dish_selected.img_bk.color = new Color(1f, 1f, 1f, 0.5f);
            dish_selected.layer_select.SetActive(false);
            dish_selected.is_selecting = false;
        }
        dish_selected = dish;
        dish.img_bk.color = new Color(1f, 1f, 1f, 1f);
        dish.layer_select.SetActive(true);
        dish.is_selecting = true;
        dish_detail.SetDishDetail(dish.dish_name);
    }
}
