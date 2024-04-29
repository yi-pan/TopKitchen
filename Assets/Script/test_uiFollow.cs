using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test_uiFollow : MonoBehaviour
{
    public GameObject following;
    private string start;

    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<TextMeshPro>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (following.GetComponent<CookTable>().currentDish != null)
        {
            gameObject.GetComponent<TextMeshPro>().text = following.GetComponent<CookTable>().currentDish.name;
            //gameObject.GetComponent<TextMeshPro>().color = new Color(255, 0, 0, following.GetComponent<CookTable>().workload.Remap();
        } else
        {
            gameObject.GetComponent<TextMeshPro>().text = start;
        }
    }
}
