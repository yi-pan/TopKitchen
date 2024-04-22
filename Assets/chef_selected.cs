using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefSelected : MonoBehaviour
{
    public ChefSelectedUI main_chef;
    public ChefSelectedUI side_chef;
    public ChefSelectedUI dessert_chef;
    public ChefSelectedUI beverage_chef;
    public ChefSelectedUI shopping_chef;

    // Start is called before the first frame update
    void Start()
    {
        main_chef.is_locked = false;
        side_chef.is_locked = false;
        dessert_chef.is_locked = false;
        beverage_chef.is_locked = false;
        shopping_chef.is_locked = true;
        main_chef.transform.gameObject.SetActive(true);
        side_chef.transform.gameObject.SetActive(true);
        dessert_chef.transform.gameObject.SetActive(true);
        beverage_chef.transform.gameObject.SetActive(true);
        shopping_chef.transform.gameObject.SetActive(false);

        
    }

    public void SelectChef(ChefUI chef)
    {
        main_chef.SetChef(chef);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
