using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DishDrop : MonoBehaviour, IDropHandler
{
    public GameObject cookTable;
    public GameObject free_dish;
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
                        //Vector3 newPos = new Vector3(transform.position.x - 1055f, transform.position.y - 623f, 0);
                        draggable.startPosition = transform.position;
                        eventData.pointerDrag.transform.SetParent(free_dish.transform);
                        free_dish.transform.SetAsLastSibling();
                        cookTable.GetComponent<CookTable>().currentDish = eventData.pointerDrag.gameObject;
                } else if (this.gameObject.tag == "Slot")
                {
                    if (string.Compare(draggable.type, "main") == 0)
                    {
                        this.transform.parent.GetComponent<Order>().main = eventData.pointerDrag.gameObject;
                        eventData.pointerDrag.transform.SetParent(this.transform.parent);
                    } else if (string.Compare(draggable.type, "side") == 0)
                    {
                        this.transform.parent.GetComponent<Order>().side = eventData.pointerDrag.gameObject;
                        eventData.pointerDrag.transform.SetParent(this.transform.parent);
                    }

                    draggable.startPosition = transform.position;
                }
                
                
            }
        }
    }
}
