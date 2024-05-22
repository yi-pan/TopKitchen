using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Btn : MonoBehaviour, IPointerClickHandler
{
    public DataCollector collector;
    public GameObject canvas_selection;
    public GameObject canvas_shopping;
    public ShoppingManager shopping_manager;

    public dish_list_shop dish_List_Shop;
    public SceneManagement scene_Management;
    public void OnPointerClick(PointerEventData eventData)
    {
        string name = eventData.pointerCurrentRaycast.gameObject.name;
        Debug.Log(name);
        if (name.Equals("btn_shopping"))
        {
            
            collector.CollectChefData();

            shopping_manager.Shopping();

            canvas_selection.SetActive(false);
            canvas_shopping.SetActive(true);
        }
        if (name.Equals("btn_open"))
        {
            dish_List_Shop.UploadDishCountList();
            collector.CollectDishCount();
            scene_Management.SwitchScene("test_kitchen");
        }
    }

}
