using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dish : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public string type;
    public float hardness;
    public float workload;
    public float avg_price;
    public string[] materialList;
    public string[] cookingList;
    public Sprite cooked;
    public bool cooked_status;
    public bool inSlot;

    //drag and drop ui
    Image thisImage;
    public Vector3 startPosition;

    private void Start()
    {
        thisImage = GetComponent<Image>();
        startPosition = transform.localPosition;
        cooked_status = false;
        inSlot = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.raycastTarget = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //Debug.Log("dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("end drag");
        transform.position = startPosition;
        thisImage.raycastTarget = true;
    }

    private void Update()
    {
        if (cooked_status)
        {
            gameObject.GetComponent<Image>().sprite = cooked;
        }
    }
    /*
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("collide");
        if (eventData.pointerDrag.transform.tag == "Dish_bg")
        {
            Dish draggable = eventData.pointerDrag.GetComponent<Dish>();
            if (draggable != null)
            {
                //Debug.Log("collide");
                draggable.startPosition = transform.position;
            }
        }
    }
    */
}
