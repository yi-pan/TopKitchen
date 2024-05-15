using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{

    public GameObject main;
    public GameObject side;
    public GameObject dessert;
    public GameObject drink;

    public GameObject mainPos;
    public GameObject sidePos;
    public GameObject dessertPos;
    public GameObject drinkPos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject main_dish = Instantiate(main, mainPos.transform);
        main_dish.name = main.name;
        GameObject side_dish = Instantiate(side, sidePos.transform);
        side_dish.name = side.name;
        //side_dish.transform.position = sidePos.transform.position;
        GameObject dessert_dish = Instantiate(dessert, dessertPos.transform);
        dessert_dish.name = dessert.name;
        //dessert_dish.transform.position = dessertPos.transform.position;
        GameObject drink_dish = Instantiate(drink, drinkPos.transform);
        drink_dish.name = drink.name;
        //drink_dish.transform.position = drinkPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: if finished, disppear
    }
}
