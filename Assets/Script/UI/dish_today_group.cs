using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DishGroup : MonoBehaviour
{
    public List<DishToday> dishes;

    public List<DishToday> dishesInOrder;

    public DishToday dish_selected;
    public DishToday dish_next;

    public bool is_full = false;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //foreach (var dishToday in dishesInOrder)
            //{
            //    Debug.Log(dishToday.transform.parent.name + " " + dishToday.name);
            //    Debug.Log("-------------------------");
            //}
            //Debug.Log(dishesInOrder[0].transform.parent.name + " " + dishesInOrder[0].name);
            //Debug.Log(dishesInOrder[1].transform.parent.name + " " + dishesInOrder[1].name);
        }
        
    }

    private void Start()
    {
        // set a list of dishes in order
        GameObject main = transform.GetChild(0).gameObject; 
        GameObject side = transform.GetChild(1).gameObject;
        GameObject dessert = transform.GetChild(2).gameObject;
        GameObject beverage = transform.GetChild(3).gameObject;

        for(int i = 0; i < main.transform.childCount; i++)
        {
            GameObject d = main.transform.GetChild(i).gameObject;
            if (d.activeSelf & !d.GetComponent<DishToday>().is_locked)
            {
               AddDishInOrder(d.GetComponent<DishToday>());
            }
        }
        for (int i = 0; i < side.transform.childCount; i++)
        {
            GameObject d = side.transform.GetChild(i).gameObject;
            if (d.activeSelf & !d.GetComponent<DishToday>().is_locked)
            {
                AddDishInOrder(d.GetComponent<DishToday>());
            }
        }
        for (int i = 0; i < dessert.transform.childCount; i++)
        {
            GameObject d = dessert.transform.GetChild(i).gameObject;
            if (d.activeSelf & !d.GetComponent<DishToday>().is_locked)
            {
                AddDishInOrder(d.GetComponent<DishToday>());
            }
        }
        for (int i = 0; i < beverage.transform.childCount; i++)
        {
            GameObject d = beverage.transform.GetChild(i).gameObject;
            if (d.activeSelf & !d.GetComponent<DishToday>().is_locked)
            {
                AddDishInOrder(d.GetComponent<DishToday>());
            }
        }

        dish_selected = dishesInOrder[0];
        dish_next = dishesInOrder[1];
    }

   
    public void AddDishInOrder(DishToday dish)
    {
        if(dishesInOrder == null) dishesInOrder = new List<DishToday>();
        dishesInOrder.Add(dish);
    }

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

    public int nextEmptyIndex = -1;
    public void OnDishSelected(DishToday dish)
    {
        if (!dish.is_locked)
        {
            if (dish_selected)
            {
                dish_selected.layer_select.SetActive(false);
                dish_selected.is_selecting = false;
                
                // click on selected ones we unselect the dish
                // Debug.Log(dish.dish_name);
            }
            dish_selected = dish;
            dish.layer_bk.SetActive(dish.is_selected);
            dish.layer_select.SetActive(true);
            dish.is_selecting = true;
            if (is_full) nextEmptyIndex = dishesInOrder.IndexOf(dish_selected);
            if (!is_full) FindNextEmptyIndex();
            if(nextEmptyIndex >= 0) dish_next = dishesInOrder[nextEmptyIndex];
        }
    }

    public void FindNextEmptyIndex()
    {
        if(!is_full) nextEmptyIndex = -1;
        int index = 0;
        foreach (DishToday d in dishesInOrder)
        {
            if (nextEmptyIndex <= 0 && d.dish_name == "")
            {
                nextEmptyIndex = index;
                //Debug.Log(nextEmptyIndex);
                break;
            }
            index++;
            
        }
        if (nextEmptyIndex < 0)
        {
            is_full = true;
            nextEmptyIndex = dishesInOrder.Count-1;
        }
    }

    public void SetDish(string name)
    {
        dish_selected.dish_name = name;
        
        dish_selected.is_selected = true;
        dish_selected.is_selecting = false;
        dish_selected.SetDishImage();
        // set up dish_next
        if(is_full) nextEmptyIndex = dishesInOrder.IndexOf(dish_selected);
        if(!is_full)FindNextEmptyIndex();
        dish_next = dishesInOrder[nextEmptyIndex];
        dish_next.is_selecting = true;
        dish_selected = dish_next; 
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
