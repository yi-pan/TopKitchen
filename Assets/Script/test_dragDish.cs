using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_dragDish : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        Vector3 currentPos = transform.position;
        Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).x, currentPos.y, Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).z);
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        transform.position = startPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Table")
        {
            collision.gameObject.GetComponent<CookTable>().currentDish = gameObject;
            
        }
    }
}
