using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DishwCount : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public dish_list_shop dish_list;
    public IngredListShop shopped_ingred_list;

    private GameObject dish_layer; // under dish layer, we have select_layer and dish_image_layer
    private GameObject count_layer; // under count_layer, we have count_bk, minus, add(plus), and count

    // set the dish name and dish image first
    public string dish_name;
    private GameObject dish_image_layer;


    // set select_layer active if the dish's is_slecting is true. show selected dish detail.
    public bool is_selecting;
    private GameObject select_layer;

    // change the count.text if minus/plus is clicked
    public int dish_count;
    private Button minus;
    private Button plus;

    // set input field layer
    private GameObject input_field;

    // ingredient list of this dish
    public List<IngredientUI> ingredients;

    void Start()
    {
        dish_layer = transform.GetChild(0).gameObject;
        count_layer = transform.GetChild(1).gameObject;

        // we should have the previous day's dish_count copied                 X-X-X-X-X-X-X-X-X-X-X
        dish_count = 0;
        select_layer = dish_layer.transform.GetChild(0).gameObject;
        is_selecting = false;
        select_layer.SetActive(false);

        dish_image_layer = dish_layer.transform.GetChild(1).gameObject;
        minus = count_layer.transform.GetChild(1).gameObject.GetComponent<Button>();
        plus = count_layer.transform.GetChild(2).gameObject.GetComponent<Button>();

        input_field = count_layer.transform.GetChild(3).gameObject;
        input_field.GetComponent<TMP_InputField>().text = dish_count.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!is_selecting)
        {
            // select this 
            is_selecting = !is_selecting;
            select_layer.SetActive(is_selecting);
            // unselect last_selected
            if (dish_list.last_selected)
            {
                dish_list.last_selected.is_selecting = false;
                dish_list.last_selected.select_layer.SetActive(false);
            }
            dish_list.last_selected = this;

            // change the dish detail
            dish_list.ChangeDishDetail(dish_name);

            // highlight the ingredients on the left side
            List<string> ingred_list = new List<string>();
            foreach(IngredientUI ingred in ingredients)
            {
                ingred_list.Add(ingred.ingred_name);
            }
            shopped_ingred_list.HighlightIngred(ingred_list);
        }
    }

    // input field value changed
    public void OnValueChanged()
    {
        // input_count is the different between input field num and current dish_count
        int input_count = int.Parse(input_field.GetComponent<TMP_InputField>().text.Trim()) - dish_count;
        int final_count = input_count;
        // check each ingredient of this dish, and get the feasible count
        foreach (IngredientUI ingred in ingredients)
        {
            int feasible_count = shopped_ingred_list.CheckIngredCount(ingred.ingred_name, input_count, ingred.count);
            if (feasible_count < final_count) { final_count = feasible_count; }
        }

        // if final count > 0, it means we can change the dish count
        if (final_count != 0)
        {
            // update dish_count
            dish_count += final_count;
            
            // update left side
            foreach (IngredientUI ingred in ingredients)
            {
                shopped_ingred_list.UpdateIngredCount(ingred.ingred_name, final_count, ingred.count);
            }
        }

        // update input field text
        input_field.GetComponent<TMP_InputField>().text = dish_count.ToString();

        // check if there are dishes selected
        dish_list.CheckAllCount();
    }

    public void Plus()
    {
        int input_count = 1;
        int final_count = input_count;
        // check each ingredient of this dish, and get the feasible count
        foreach (IngredientUI ingred in ingredients)
        {
            int feasible_count = shopped_ingred_list.CheckIngredCount(ingred.ingred_name, input_count, ingred.count);
            if(feasible_count < final_count) { final_count = feasible_count; }
        }
        // if final count > 0, it means we have enough ingredients to add one dish
        if(final_count > 0)
        {
            // update right side
            dish_count++;
            input_field.GetComponent<TMP_InputField>().text = dish_count.ToString();
            // update left side
            foreach(IngredientUI ingred in ingredients)
            {
                shopped_ingred_list.UpdateIngredCount(ingred.ingred_name, final_count, ingred.count);
            }
        }
        // check if there are dishes selected
        dish_list.CheckAllCount();
    }

    public void Minus()
    {
        if (dish_count > 0)
        {
            dish_count--;
            input_field.GetComponent<TMP_InputField>().text = dish_count.ToString();
            // update left side
            foreach (IngredientUI ingred in ingredients)
            {
                shopped_ingred_list.UpdateIngredCount(ingred.ingred_name, -1, ingred.count);
            }
        }
        // check if there are dishes selected
        dish_list.CheckAllCount();
    }



    // on click 
    public void OnPointerClick(PointerEventData eventData)
    {
        //string clicked_object_name = eventData.pointerCurrentRaycast.gameObject.name;
        //if (!is_selecting)
        //{
        //    // select this 
        //    is_selecting = !is_selecting;
        //    select_layer.SetActive(is_selecting);
        //    // unselect last_selected
        //    if (dish_list.last_selected)
        //    {
        //        dish_list.last_selected.is_selecting = false;
        //        dish_list.last_selected.select_layer.SetActive(false);
        //    }
        //    dish_list.last_selected = this;

        //    // change the dish detail
        //    dish_list.ChangeDishDetail(dish_name);
        //}
    }
}
