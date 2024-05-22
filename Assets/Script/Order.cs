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

    public GameObject[] content = new GameObject[4];

    float timer = 0.0f;

    Slider waiting;

    // Start is called before the first frame update
    void Start()
    {
        waiting = this.transform.Find("Slider").GetComponent<Slider>();

        GameManager = GameObject.Find("Game Manager");
        if (main != null)
        {
            GameObject main_dish = Instantiate(main, mainPos.transform);
            main_dish.name = main.name;
            main = main_dish;
            content[0] = main;
        }

        if (side != null)
        {
            GameObject side_dish = Instantiate(side, sidePos.transform);
            side_dish.name = side.name;
            side = side_dish;
            content[1] = side;
        }

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
        bool total_cooked = true;
        float add_price = 0f;
        for (var i = 0; i < content.Length; i++) 
        {
            GameObject child = content[i];
            if(content[i] != null)
            {
                total_cooked = total_cooked && child.GetComponent<Dish>().cooked_status;
                total_cooked = total_cooked && child.GetComponent<Dish>().inSlot;
                //g.Log(child.GetComponent<Dish>().cooked_status);
                add_price += child.GetComponent<Dish>().avg_price;
            }

        }
        //Debug.Log(total_cooked);
        if (timer >= 30f || total_cooked)
        {
            if (total_cooked) GameManager.GetComponent<GameManager>().total_price += add_price;
            GameManager.GetComponent<GameManager>().orderList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
