using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DishAll : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public DishAllGroup dishAllGroup;

    [SerializeField] private Sprite[] dishSprite;
    public string dish_name;
    private Sprite dish_image;

    public bool is_selected = false; // true -> activate layer_bk, layer_dish
    public bool is_selecting = false; // true -> active layer_select

    public GameObject layer_select, layer_selected;
    public Image img_bk, img_dish;

    

    public void OnPointerClick(PointerEventData eventData)
    {
        dishAllGroup.OnDishSelected(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("mouse down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dishAllGroup.OnDishEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dishAllGroup.OnDishExit(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("mouse up");
    }


    public void SetDishImage()
    {
        if (dish_name == "dudu_soup") dish_image = dishSprite[0];
        if (dish_name == "omurice") dish_image = dishSprite[1];
        if (dish_name == "sashimi") dish_image = dishSprite[2];
        if (dish_name == "fried_lumin_egg") dish_image = dishSprite[3];
        if (dish_name == "seaweed_jelly") dish_image = dishSprite[4];
        if (dish_name == "berry_juice") dish_image = dishSprite[5];
        img_dish.sprite = dish_image;
    }

    void Start()
    {
        //
        img_bk = transform.GetComponent<Image>();
        layer_select = transform.GetChild(0).gameObject;
        img_dish = transform.GetChild(1).GetComponent<Image>();
        layer_selected = transform.GetChild(2).gameObject;
        
        layer_select.SetActive(is_selecting);
        layer_selected.SetActive(is_selected);
        img_bk.color = new Color(1f, 1f, 1f, 0.5f);
        SetDishImage();
        dishAllGroup.Subscribe(this);

        if (is_selecting)
        {
            dishAllGroup.OnDishEnter(this);
        }
        
    }

    void Update()
    {
        layer_select.SetActive(is_selecting);
        layer_selected.SetActive(is_selected);
    }
}
