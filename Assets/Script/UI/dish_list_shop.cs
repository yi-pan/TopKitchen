using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dish_list_shop : MonoBehaviour
{
    public GameObject selected_dish_detail;
    public DataCollector dataCollector;
    private List<DishUI> selected_dishes;

    public DishwCount last_selected;

    public List<DishwCount> dish_w_count_list;

    public List<DishUI> main_dishes;
    public List<DishUI> side_dishes;
    public List<DishUI> desserts;
    public List<DishUI> beverages;

    public GameObject main_dish_group;
    public GameObject side_dish_group;
    public GameObject desserts_group;
    public GameObject beverages_group;

    [SerializeField] Sprite[] dishSprite;
    // Start is called before the first frame update
    void Start()
    {
        selected_dishes = dataCollector.selected_dishes;
        // set up each dish group
        foreach (DishUI dish in selected_dishes)
        {
            // Debug.Log(dish.name + " " + dish.type);
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
        // set fish detail first_dish string
        selected_dish_detail.GetComponent<DishDetail>().first_dish = main_dishes[0].dish_name;

        //Debug.Log("dish with count list count: " + dish_w_count_list.Count);
    }

    void HideDishes(GameObject dish_group)
    {
        for(int i = 1; i<dish_group.transform.childCount; i++)
        {
            dish_group.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public Sprite dish_img;
    void ShowDishes(GameObject dish_group, List<DishUI> dishes)
    {
        
        for (int i = 1; i<dishes.Count+1; i++)
        {
            // show it
            dish_group.transform.GetChild(i).gameObject.SetActive(true);

            DishwCount dish_w_count = dish_group.transform.GetChild(i).gameObject.GetComponent<DishwCount>();
            dish_w_count_list.Add(dish_w_count);

            DishUI cur_dish = dishes[i-1];

            // set up dish name
            dish_w_count.dish_name = cur_dish.dish_name;

            foreach (IngredientUI ingred in cur_dish.ingredientList)
            {
                dish_w_count.ingredients.Add(ingred);
            }

            if (cur_dish.dish_name == "dudu_soup") dish_img = dishSprite[0];
            else if (cur_dish.dish_name == "omurice") dish_img = dishSprite[1];
            else if (cur_dish.dish_name == "sashimi") dish_img = dishSprite[2];
            else if (cur_dish.dish_name == "fried_lumin_egg") dish_img = dishSprite[3];
            else if (cur_dish.dish_name == "seaweed_jelly") dish_img = dishSprite[4];
            else if (cur_dish.dish_name == "berry_juice") dish_img = dishSprite[5];
            else dish_img = dishSprite[0];
            //dish_w_count.SetImage(dish_img);
            dish_group.transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<Image>().sprite = dish_img;
        }
    }

    public void CheckAllCount()
    {
        int shopped_dish_count = 0;
        foreach(DishwCount dish in dish_w_count_list)
        {
            if(dish.dish_count > 0)
            {
                shopped_dish_count++;
            }
        }
        if(shopped_dish_count != 0)
        {
            dataCollector.shopping_done = true;
        }
        else
        {
            dataCollector.shopping_done = false;
        }
    }

    public void ChangeDishDetail(string dish_name)
    {
        selected_dish_detail.GetComponent<DishDetail>().SetDishDetail(dish_name);
    }

    public void UploadDishCountList()
    {
        //Debug.Log("dish w count: " + dish_w_count_list.Count);
        dataCollector.dish_w_count_list.Clear();
        foreach(DishwCount dish in dish_w_count_list)
        {
            dataCollector.dish_w_count_list.Add(dish);
        }
    }
}
