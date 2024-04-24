using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.UI;

public class data_collector : MonoBehaviour
{
    public ChefSelected selected_chef_group;
    public DishGroup selected_dish_group;

    public DishListUI dishList;

    public List<string> opened_chef_position;
    public List<ChefUI> selected_chefs;

    public List<DishUI> selected_dishes;

    public GameObject btn_shopping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected_chef_group.is_full & selected_dish_group.is_full)
        {
            btn_shopping.transform.GetChild(1).gameObject.SetActive(true);
            btn_shopping.GetComponent<Button>().interactable = true;
            btn_shopping.SetActive(true);
        }
    }

    
    public void CollectChefData()
    {
        foreach(ChefSelectedUI c in selected_chef_group.chefsInOrder)
        {
            if (!c.is_locked)
            {
                opened_chef_position.Add(c.gameObject.name);
                selected_chefs.Add(c.last_selected);
            }
        }
        Debug.Log("collect chef data");
        foreach(ChefUI c in selected_chefs)
        {
            c.printChefDetail();
        }
    }

    public void CollectDishData()
    {
        foreach (DishToday d in selected_dish_group.dishesInOrder)
        {
            selected_dishes.Add(dishList.GetDishDetail(d.dish_name));
        }
        Debug.Log("collect dish data");
        PrintDishDetails();
    }

    void PrintDishDetails()
    { 
        foreach(DishUI dish in selected_dishes)
        {
            string detail = "";
            string ingred_string = "";
            string cook_string = "";
            foreach(IngredientUI ingred in dish.ingredientList)
            {
                ingred_string += ingred.name + ingred.type + ingred.count + "  ";
            }
            foreach(string c in dish.cookingList)
            {
                cook_string += c;
            }
            detail = dish.name + " " + dish.type + " " + dish.level + " " + dish.hardness + " " + dish.workload + " " + dish.avg_price + " " + ingred_string + " " + cook_string;
            Debug.Log(detail);
        }
    }
}
