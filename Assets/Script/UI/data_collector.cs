using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class data_collector : MonoBehaviour
{
    public ChefSelected selected_chef_group;
    public DishGroup selected_dish_group;

    public GameObject btn_shopping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected_chef_group.is_full & selected_dish_group.is_full)
        {
            btn_shopping.transform.GetChild(1).gameObject.SetActive(true);
            btn_shopping.GetComponent<Button>().interactable = true;
            btn_shopping.SetActive(true);
        }
    }

    
    public void CollectChefData()
    {
        Debug.Log("collect chef data");
    }

    public void CollectDishData()
    {
        Debug.Log("collect dish data");
    }
}
