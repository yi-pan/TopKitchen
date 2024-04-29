using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{

    public GameObject[] main;
    public GameObject[] side;
    public GameObject[] dessert;
    public GameObject[] drink;

    public GameObject mainPos;
    public GameObject sidePos;
    public GameObject dessertPos;
    public GameObject drinkPos;

    // Start is called before the first frame update
    void Start()
    {
        int main_i = Random.Range(0, main.Length);
        int side_i = Random.Range(0, side.Length);
        GameObject main_dish = Instantiate(main[main_i], mainPos.transform);
        main_dish.name = main[main_i].name;
        //main_dish.transform.position = mainPos.transform.position;
        GameObject side_dish = Instantiate(side[side_i], sidePos.transform);
        side_dish.name = side[side_i].name;
        //side_dish.transform.position = sidePos.transform.position;
        GameObject dessert_dish = Instantiate(dessert[0], dessertPos.transform);
        dessert_dish.name = dessert[0].name;
        //dessert_dish.transform.position = dessertPos.transform.position;
        GameObject drink_dish = Instantiate(drink[0], drinkPos.transform);
        drink_dish.name = drink[0].name;
        //drink_dish.transform.position = drinkPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: if finished, disppear
    }
}
