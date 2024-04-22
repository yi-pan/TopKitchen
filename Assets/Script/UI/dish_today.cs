using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DishToday : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public DishGroup dishGroup;

    public bool is_locked = false; // true -> activate lock
    public bool is_selected = false; // true -> activate layer_bk, layer_dish
    public bool is_selecting = false; // true -> active layer_select

    public GameObject layer_add, layer_lock, layer_bk, layer_select, layer_dish;
    public Image img_dish;
    [SerializeField] private Sprite[] dishSprite;
    public string dish_name;
    private Sprite dish_image;

    public void OnPointerClick(PointerEventData eventData)
    {
        dishGroup.OnDishSelected(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("mouse down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dishGroup.OnDishEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dishGroup.OnDishExit(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("mouse up");
    }

    void Start()
    {
        dishGroup.Subscribe(this);
        layer_add = transform.GetChild(0).gameObject;
        layer_lock = transform.GetChild(1).gameObject;
        layer_bk = transform.GetChild(2).gameObject;
        layer_select = transform.GetChild(3).gameObject;
        layer_dish = transform.GetChild(4).gameObject;

        layer_add.SetActive(true);
        layer_lock.SetActive(is_locked);
        layer_select.SetActive(is_selecting);
        layer_bk.SetActive(is_selected);
        layer_dish.SetActive(is_selected);

        img_dish = layer_dish.GetComponent<Image>();
    }

    public void SetDishImage()
    {
        layer_bk.SetActive(is_selected);
        layer_dish.SetActive(is_selected);
        if (dish_name == "dudu_soup") dish_image = dishSprite[0];
        if (dish_name == "omurice") dish_image = dishSprite[1];
        if (dish_name == "sashimi") dish_image = dishSprite[2];
        if (dish_name == "fried_lumin_egg") dish_image = dishSprite[3];
        if (dish_name == "seaweed_jelly") dish_image = dishSprite[4];
        if (dish_name == "berry_juice") dish_image = dishSprite[5];
        img_dish.sprite = dish_image;
    }

    void Update()
    {
        layer_select.SetActive(is_selecting);
    }
}
