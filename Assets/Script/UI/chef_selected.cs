using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChefSelected : MonoBehaviour
{
    private ChefSelectedUI main_chef;
    private ChefSelectedUI side_chef;
    private ChefSelectedUI dessert_chef;
    private ChefSelectedUI beverage_chef;
    private ChefSelectedUI shopping_chef;

    private ChefSelectedUI selected_spot;

    public List<ChefSelectedUI> chefsInOrder;

    public GameObject latest_selected_spot;

    // Start is called before the first frame update
    void Start()
    {
        main_chef = chefsInOrder[0];
        side_chef = chefsInOrder[1];
        dessert_chef = chefsInOrder[2];
        beverage_chef = chefsInOrder[3];
        shopping_chef = chefsInOrder[4];

        //main_chef.is_locked = false;
        //side_chef.is_locked = false;
        //dessert_chef.is_locked = false;
        //beverage_chef.is_locked = false;
        //shopping_chef.is_locked = true;

        main_chef.transform.gameObject.SetActive(!main_chef.is_locked);
        side_chef.transform.gameObject.SetActive(!side_chef.is_locked);
        dessert_chef.transform.gameObject.SetActive(!dessert_chef.is_locked);
        beverage_chef.transform.gameObject.SetActive(!beverage_chef.is_locked);
        shopping_chef.transform.gameObject.SetActive(!shopping_chef.is_locked);
    }

    public void SelectChef(ChefUI chef)
    {
        if (latest_selected_spot)
        {
            if (latest_selected_spot.name.Equals("main")) selected_spot = main_chef;
            if (latest_selected_spot.name.Equals("side")) selected_spot = side_chef;
            if (latest_selected_spot.name.Equals("dessert")) selected_spot = dessert_chef;
            if (latest_selected_spot.name.Equals("beverage")) selected_spot = beverage_chef;
            if (latest_selected_spot.name.Equals("shopping")) selected_spot = shopping_chef;
            selected_spot.SetChef(chef);
        }
        
    }

    public void SelectSpot(GameObject spot)
    {
        ChefSelectedUI chef = spot.GetComponent<ChefSelectedUI>();
        Debug.Log(spot.name + chef.name.GetComponent<TMP_Text>().text);
        if (!chef.is_selected)
        {
            //if (chef.is_empty)
            //{
            //    chef.is_empty = false;
            //    chef.ShowChef();
            //}
            chef.is_selected = true;
            if (latest_selected_spot != null)
            {
                latest_selected_spot.GetComponent<ChefSelectedUI>().is_selected = false;
                latest_selected_spot.GetComponent<ChefSelectedUI>().is_selecting = false;
            }
            latest_selected_spot = spot;
        }
        
    }
}
