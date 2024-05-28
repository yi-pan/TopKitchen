using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

/*
 * whole chef selection group: 
 * track the @latest_selected_spot (main/side/dessert/beverage/shopping)
 * track which chef is at which position @chefsInOrder List
 * check if @is_full
*/
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

    public bool is_full;


    // Start is called before the first frame update
    void Start()
    {
        main_chef = chefsInOrder[0];
        side_chef = chefsInOrder[1];
        dessert_chef = chefsInOrder[2];
        beverage_chef = chefsInOrder[3];
        shopping_chef = chefsInOrder[4];

        // check if chef is locked
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

        latest_selected_spot.GetComponent<ChefSelectedUI>().is_selecting = true;
        latest_selected_spot.GetComponent<ChefSelectedUI>().is_selected = true;
    }

    // Set the clicked spot as @latest_selected_spot, reset the latest_selected_spot
    public void SelectSpot(GameObject s)
    {
        ChefSelectedUI spot = s.GetComponent<ChefSelectedUI>();

        if (!spot.is_selected)
        {
            // spot is now selected
            spot.is_selected = true;
            if (latest_selected_spot != null)
            {
                latest_selected_spot.GetComponent<ChefSelectedUI>().is_selected = false;
                latest_selected_spot.GetComponent<ChefSelectedUI>().is_selecting = false;
            }
            latest_selected_spot = s;
        }
        else
        {
            //spot.is_selected = false;
            is_full = false;
            if (spot.last_selected)
            {
                spot.last_selected.Reset();
                spot.last_selected = null;
                HideChef();
            }
        }
    }

    

    // Set the latest_selected_spot as the ChefUI being clicked
    public void SelectChef(ChefUI chef)
    {
        // if a spot is being selected
        if (latest_selected_spot)
        {
            // Update selected_spot 
            GetSelectedSpot();

            // if selected_spot was not empty, get its last_selected ChefUI and reset it
            if (selected_spot.last_selected != null)
            {
                selected_spot.last_selected.Reset();
            }

            // set its last_selected ChefUI as current selected
            selected_spot.last_selected = chef;
            selected_spot.SetChef(chef);
        }
        CheckFullList(); // check if is_full
        if (!is_full) MoveToNextEmptySpot(); // move to next empty spot
    }

    

    // move to the next empty spot
    public void MoveToNextEmptySpot()
    {
        // reset current selected 
        selected_spot.is_selecting = false;
        selected_spot.is_selected = false;

        // Find the next empty unlocked spot and set it as latest_selected_spot
        foreach (var c in chefsInOrder)
        {
            if (c.last_selected == null & !c.is_locked)
            {
                //Debug.Log(c.gameObject.name);
                if (c.gameObject.name.Equals("main")) latest_selected_spot = main_chef.gameObject;
                if (c.gameObject.name.Equals("side")) latest_selected_spot = side_chef.gameObject;
                if (c.gameObject.name.Equals("dessert")) latest_selected_spot = dessert_chef.gameObject;
                if (c.gameObject.name.Equals("beverage")) latest_selected_spot = beverage_chef.gameObject;
                if (c.gameObject.name.Equals("shopping")) latest_selected_spot = shopping_chef.gameObject;
                break;
            }
        }
        // set its is_selecting and is_selected as true
        latest_selected_spot.GetComponent<ChefSelectedUI>().is_selecting = true;
        latest_selected_spot.GetComponent<ChefSelectedUI>().is_selected = true;
    }

    // Check if all open spots are occupied
    void CheckFullList()
    {
        int empty_count = 0;
        foreach (var c in chefsInOrder)
        {
            if (c.last_selected == null & !c.is_locked)
            {
                empty_count++;
            }
        }
        if (empty_count == 0) is_full = true;
    }

    void GetSelectedSpot()
    {
        if (latest_selected_spot.name.Equals("main")) selected_spot = main_chef;
        if (latest_selected_spot.name.Equals("side")) selected_spot = side_chef;
        if (latest_selected_spot.name.Equals("dessert")) selected_spot = dessert_chef;
        if (latest_selected_spot.name.Equals("beverage")) selected_spot = beverage_chef;
        if (latest_selected_spot.name.Equals("shopping")) selected_spot = shopping_chef; 
    }

    // show chef detail of hovering ChefUI
    public void ShowChef(ChefUI chef)
    {
        if (latest_selected_spot)
        {
            GetSelectedSpot();
            selected_spot.SetChef(chef);
        }
    }

    // hide chef detail of ChefUI that was being hovered
    public void HideChef()
    {
        if (latest_selected_spot)
        {
            GetSelectedSpot();
            if (selected_spot.last_selected != null)
            {
                selected_spot.SetChef(selected_spot.last_selected);
            }
            else
            {
                selected_spot.is_empty = true;
                selected_spot.ShowChef();
            }
        }
    }
}
