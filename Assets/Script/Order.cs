using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn;

public class Order : MonoBehaviour
{

    public GameObject main;
    public GameObject side;
    /*
    public GameObject dessert;
    public GameObject drink;
    */

    public GameObject mainPos;
    public GameObject sidePos;
    public GameObject dessertPos;
    public GameObject drinkPos;

    public GameObject GameManager;

    float timer = 0.0f;

    Slider waiting;

    // Start is called before the first frame update
    void Start()
    {
        waiting = this.transform.Find("Slider").GetComponent<Slider>();

        GameManager = GameObject.Find("Game Manager");
        GameObject main_dish = Instantiate(main, mainPos.transform);
        main_dish.name = main.name;
        GameObject side_dish = Instantiate(side, sidePos.transform);
        side_dish.name = side.name;
        //side_dish.transform.position = sidePos.transform.position;
        /*
        GameObject dessert_dish = Instantiate(dessert, dessertPos.transform);
        dessert_dish.name = dessert.name;
        //dessert_dish.transform.position = dessertPos.transform.position;
        GameObject drink_dish = Instantiate(drink, drinkPos.transform);
        drink_dish.name = drink.name;
        //drink_dish.transform.position = drinkPos.transform.position;
        */
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        waiting.value = timer / 30;
        //TODO: if finished, disppear
        if (timer >= 30f || (main.GetComponent<Dish>().cooked_status && side.GetComponent<Dish>().cooked_status))
        {
            if (main.GetComponent<Dish>().cooked_status && side.GetComponent<Dish>().cooked_status) GameManager.GetComponent<GameManager>().total_price += main.GetComponent<Dish>().avg_price + side.GetComponent<Dish>().avg_price;
            GameManager.GetComponent<GameManager>().orderList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
