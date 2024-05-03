using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class DataCollector : MonoBehaviour
{
    //[SerializeField] private TextAsset _collected_data_file;

    public ChefSelected selected_chef_group;
    public DishGroup selected_dish_group;

    public DishListUI dishList;

    public List<string> opened_chef_position;
    public List<ChefUI> selected_chefs;

    public List<DishUI> selected_dishes;

    public GameObject btn_shopping;
    public GameObject btn_open;

    private string path;
    private StreamWriter sw;

    private StreamReader sr;

    public List<IngredientUI> ingredients_today;

    public List<DishwCount> dish_w_count_list;

    public GameObject summary;

    public bool shopping_done = false;
    // Start is called before the first frame update
    void Start()
    {
        path = "Assets/Text/CollectedData.txt";
        // clear the textfile
        File.WriteAllText(path, "");

        //btn_open.transform.GetChild(1).gameObject.SetActive(true);
        //btn_open.GetComponent<Button>().interactable = true;
        //btn_open.SetActive(true);
    }

    void Update()
    {
        if (selected_chef_group.is_full & selected_dish_group.is_full)
        {
            btn_shopping.transform.GetChild(1).gameObject.SetActive(true);
            btn_shopping.GetComponent<Button>().interactable = true;
        }

        if (shopping_done)
        {
            btn_open.transform.GetChild(1).gameObject.SetActive(true);
            btn_open.GetComponent<Button>().interactable = true;
        }
        else
        {
            btn_open.transform.GetChild(1).gameObject.SetActive(false);
            btn_open.GetComponent<Button>().interactable = false;
        }
    }


    public void CollectChefData()
    {
        sw = new StreamWriter(path, true);
        sw.WriteLine("***");
        sw.WriteLine("Chef:");
        foreach (ChefSelectedUI c in selected_chef_group.chefsInOrder)
        {
            if (!c.is_locked)
            {
                opened_chef_position.Add(c.gameObject.name);
                selected_chefs.Add(c.last_selected);
            }
        }
        foreach(ChefUI c in selected_chefs)
        {
            string chef_position = opened_chef_position[selected_chefs.IndexOf(c)];
            chef_position = chef_position.Replace(" ", "");
            string chef_detail = c.printChefDetail();
            chef_detail = chef_detail.Substring(0, chef_detail.Length - 1);
            //Debug.Log(chef_detail);
            sw.Write(chef_position + "; " + chef_detail + "\n");
        }
        sw.Close();
    }

    public void CollectDishData()
    {
        sw = new StreamWriter(path, true);
        foreach (DishToday d in selected_dish_group.dishesInOrder)
        {
            selected_dishes.Add(dishList.GetDishDetail(d.dish_name));
        }
        string dish_detail = PrintDishDetails();
        sw.WriteLine(dish_detail);
        sw.Close();
    }

    public string PrintDishDetails()
    {
        string detail = "\nDish:\n";
        foreach (DishUI dish in selected_dishes)
        {
            string ingred_string = "";
            string cook_string = "";
            foreach(IngredientUI ingred in dish.ingredientList)
            {
                ingredients_today.Add(ingred);
                ingred_string += ingred.ingred_name + " " + ingred.type + " " + ingred.count + ", ";
            }
            ingred_string = ingred_string.Substring(0, ingred_string.Length - 2);
            foreach(string c in dish.cookingList)
            {
                cook_string += " " + c;
            }
            string d = dish.dish_name + "; " + dish.type + "; " + dish.level + "; " + dish.hardness + "; " + dish.workload + "; " + dish.avg_price + "; " + ingred_string + ";" + cook_string;
            detail +=  d + "\n";
        }
        return detail;
    }

    public void CollectDishCount()
    {
        sw = new StreamWriter(path, true);
        string dish_count = "Dish Count:\n";
        foreach(DishwCount dish in dish_w_count_list)
        {
            dish_count += dish.dish_name + " " + dish.dish_count + "\n";
        }
        sw.WriteLine(dish_count);
        sw.Close();
    }

    public void PrintAllInfo()
    {
        sr = new StreamReader(path, true);
        TMP_Text summary_text = summary.transform.GetComponent<TMP_Text>();
        summary_text.text = sr.ReadToEnd();
        sr.Close();
    }
}
