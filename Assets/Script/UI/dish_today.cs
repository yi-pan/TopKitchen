using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;



public class DishToday : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public DishGroup dishGroup;

    public bool is_locked = false; // true -> activate lock
    public bool is_selected = false; // true -> activate layer_bk, layer_dish
    public bool is_selecting = false; // true -> active layer_select

    public GameObject layer_add, layer_lock, layer_bk, layer_select, layer_dish;

    public void OnPointerClick(PointerEventData eventData)
    {
        dishGroup.OnDishSelected(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("mouse down");
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
        Debug.Log("mouse up");
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
    }

    void Update()
    {
        //if (is_locked)
        //{
        //    is_selecting = false;
        //    is_selected = false;
        //}
        //layer_lock.SetActive(is_locked);
        //layer_select.SetActive(is_selecting);
        //layer_bk.SetActive(is_selected);
        //layer_dish.SetActive(is_selected);

    }
}
