using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dish_list_shop : MonoBehaviour
{
    public DataCollector dataCollector;
    private List<DishUI> selected_dishes;

    private List<DishUI> main_dishes;
    private List<DishUI> side_dishes;
    private List<DishUI> desserts;
    private List<DishUI> beverages;

    private GameObject main_dish_group;
    private GameObject side_dish_group;
    private GameObject desserts_group;
    private GameObject beverages_group;

    // Start is called before the first frame update
    void Start()
    {
        selected_dishes = dataCollector.selected_dishes;
        // set up each dish group
        foreach (DishUI dish in selected_dishes)
        {
            if (dish.type.Equals("main")) main_dishes.Add(dish);
            else if (dish.type.Equals("side")) side_dishes.Add(dish);
            else if (dish.type.Equals("dessert")) desserts.Add(dish);
            else beverages.Add(dish);
        }
        // set up dish group
        main_dish_group = transform.GetChild(0).gameObject;
        side_dish_group = transform.GetChild(1).gameObject;
        desserts_group = transform.GetChild(2).gameObject;
        beverages_group = transform.GetChild(3).gameObject;
        // hide every dishwcount
        HideDishes(main_dish_group);
        HideDishes(side_dish_group);
        HideDishes(desserts_group);
        HideDishes(beverages_group);
        // show selected dishes
        ShowDishes(main_dish_group, main_dishes);
        ShowDishes(side_dish_group, side_dishes);
        ShowDishes(desserts_group, desserts);
        ShowDishes(beverages_group, beverages);
    }

    void HideDishes(GameObject dish_group)
    {
        for(int i = 1; i<dish_group.transform.childCount; i++)
        {
            dish_group.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void ShowDishes(GameObject dish_group, List<DishUI> dishes)
    {
        for(int i = 1; i<dishes.Count; i++)
        {
            // show it
            dish_group.transform.GetChild(i).gameObject.SetActive(true);

            DishwCount dish_w_count = dish_group.transform.GetChild(i).gameObject.GetComponent<DishwCount>();
            

        }
    }
}
