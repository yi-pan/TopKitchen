using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DishDrop : MonoBehaviour, IDropHandler
{
    public GameObject cookTable;
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("collide");
        if (eventData.pointerDrag.transform.tag == "Dish")
        {
            Dish draggable = eventData.pointerDrag.GetComponent<Dish>();
            if (draggable != null)
            {
                //Debug.Log("collide");
                if (this.gameObject.tag == "Table" && cookTable.GetComponent<CookTable>().dishes.Contains(draggable.gameObject.name))
                {
                        draggable.startPosition = transform.position;
                        cookTable.GetComponent<CookTable>().currentDish = eventData.pointerDrag.gameObject;
                } else if (this.gameObject.tag == "Slot")
                {
                    draggable.startPosition = transform.position;
                }
                
                
            }
        }
    }
}
