using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DishwCount : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    private GameObject dish_layer; // under dish layer, we have select_layer and dish_image_layer
    private GameObject count_layer; // under count_layer, we have count_bk, minus, add(plus), and count


    // set the dish name and dish image first
    private string dish_name;
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

    // Start is called before the first frame update
    void Start()
    {
        dish_layer = transform.GetChild(0).gameObject;
        count_layer = transform.GetChild(1).gameObject;

        // we should have the previous day's dish_count copied                 X-X-X-X-X-X-X-X-X-X-X
        dish_count = 2;
        select_layer = dish_layer.transform.GetChild(0).gameObject;
        is_selecting = false;
        select_layer.SetActive(false);

        dish_image_layer = dish_layer.transform.GetChild(1).gameObject;
        minus = count_layer.transform.GetChild(1).gameObject.GetComponent<Button>();
        plus = count_layer.transform.GetChild(2).gameObject.GetComponent<Button>();

        input_field = count_layer.transform.GetChild(3).gameObject;
        input_field.GetComponent<TMP_InputField>().text = dish_count.ToString();
    }

    public void OnValueChanged()
    {
        dish_count = int.Parse(input_field.GetComponent<TMP_InputField>().text.Trim());
        Debug.Log(dish_name + ": " + dish_count);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string clicked_object_name = eventData.pointerCurrentRaycast.gameObject.name;

        // dish is selected, this is when we change the dish detail page in the middle
        if (clicked_object_name.Equals("dish"))
        {
            is_selecting = !is_selecting;
            select_layer.SetActive(is_selecting);
            // change the dish detail
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // dish is selected, this is when we change the dish detail page in the middle
        is_selecting = !is_selecting;
        select_layer.SetActive(is_selecting);

    }

    public void Plus()
    {
        dish_count++;
        input_field.GetComponent<TMP_InputField>().text = dish_count.ToString();
    }

    public void Minus()
    {
        if (dish_count > 0) dish_count--;
        input_field.GetComponent<TMP_InputField>().text = dish_count.ToString();
    }
}
