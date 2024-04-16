using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dish : MonoBehaviour, IDragHandler
{
    public string type;
    public float hardness;
    public float workload;
    public float avg_price;
    public string[] materialList;
    public string[] cookingList;
    public Texture uncooked;
    public Texture cooked;

    //drag and drop ui
    public RawImage thisImage;
    public Vector3 startPosition;

    private void Start()
    {
        thisImage = GetComponent<RawImage>();
        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.raycastTarget = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        thisImage.raycastTarget = true;
    }

}
