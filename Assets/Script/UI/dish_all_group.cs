using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class DishAllGroup : MonoBehaviour
{
    public List<DishAll> dishes;
    public DishDetail dish_detail;
    public DishAll dish_selected;
    public DishGroup dishes_today;
    
    public void Subscribe(DishAll dish)
    {
        if (dishes == null) dishes = new List<DishAll>();
        dishes.Add(dish);
    }

    public void OnDishEnter(DishAll dish)
    {
        dish.is_selecting = true;
        dish.layer_select.SetActive(true);
        dish_detail.SetDishDetail(dish.dish_name);
    }

    public void OnDishExit(DishAll dish)
    {
        dish.is_selecting = false;
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

        // put the selected dish into the selected slot in dish_today_group
        DishToday selected_box = dishes_today.dish_selected;
        string box_type = selected_box.transform.parent.name;
        // Debug.Log(box_type);
        // if types are the same, selected
        if(box_type.Equals(dish.transform.parent.name) && !dish.is_selected)
        {
            if (dishes_today.dish_selected.dish_name != null)
            {
                UnselectDish(dishes_today.dish_selected.dish_name);
            }

            dishes_today.SetDish(dish.dish_name);
            //dishes_today.dish_selected.dish_name = dish.dish_name;
            //dishes_today.dish_selected.is_selected = true;
            //dishes_today.dish_selected.is_selecting = false;
            //dishes_today.dish_next.is_selecting = true;
            //dishes_today.dish_selected.SetDishImage();
            
            dish.is_selected = true;
        }
    }

    private void UnselectDish(string name)
    {
        foreach(DishAll d in dishes)
        {
            if(d.dish_name.Equals(name))
            {
                d.is_selected = false;
            }
        }
    }
}
