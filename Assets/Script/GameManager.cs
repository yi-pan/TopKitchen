using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextAsset textFile;     // drop your file here in inspector
    string[] Days;
    string[] DataList;
    string[] ChefData;
    string[] DishData;

    public List<GameObject> mainDish = new List<GameObject>();
    public List<GameObject> sideDish = new List<GameObject>();
    public List<GameObject> dessertDish = new List<GameObject>();
    public List<GameObject> beverageDish = new List<GameObject>();

    public GameObject[] mainDishList;
    public GameObject[] sideDishList;
    public GameObject[] dessertDishList;
    public GameObject[] beverageDishList;
    string[] mainDishNames;
    string[] sideDishNames;
    string[] dessertDishNames;
    string[] beverageDishNames;

    //mainPos, sidePos,dessertPos, beveragePos,freePos
    public Vector3[] positions;
    //list of chef
    public GameObject[] Chefs;
    string[] ChefNames = new string[5];

    //spawn orders on canvas
    public GameObject ui;
    public GameObject orderPrefab;

    //TODO: total price
    public float total_price = 0;

    //orderlist
    public List<GameObject> orderList = new List<GameObject>();
    float timer = 0.0f;

    //dialogue TODO
    public GameObject dialogue;

    // Start is called before the first frame update
    void Start()
    {
        string text = textFile.text;  //this is the content as string
        Days = text.Split("***");
        DataList = Days[Days.Length - 1].Split("---");
        ChefData = DataList[0].Split("\n");
        DishData = DataList[2].Split("\n");

        //fill in chef names
        for (var i = 0; i < Chefs.Length; i++) {
            ChefNames[i] = Chefs[i].name;
            //Debug.Log(ChefNames[i]);
        }

        //spawn chef at correct position
        for(var i = 2; i < ChefData.Length-2; i++) {
            //Debug.Log(ChefData[i]);
            int spawn_index = System.Array.IndexOf(ChefNames, ChefData[i].Split("; ")[1]);
            Instantiate(Chefs[spawn_index], positions[i-2], Quaternion.identity);
        }

        //fill in dish names
        mainDishNames = new string[mainDishList.Length];
        populateArray(mainDishNames, mainDishList);
        sideDishNames = new string[sideDishList.Length];
        populateArray(sideDishNames, sideDishList);
        dessertDishNames = new string[dessertDishList.Length];
        /*
        populateArray(dessertDishNames, dessertDishList);
        beverageDishNames = new string[beverageDishList.Length];
        populateArray(beverageDishNames, beverageDishList);
        */

        //populate current dish list
        for(var i = 2; i < DishData.Length-2; i++) {
            Debug.Log(DishData[i]);
            //Debug.Log(mainDishNames);
            //Debug.Log(DishData[i].Split(" ")[0]);
            int dish_index = System.Array.IndexOf(mainDishNames, DishData[i].Split(" ")[0]);
            //Debug.Log(dish_index);
            if (dish_index != -1) {
                for (var l = 0; l < int.Parse(DishData[i].Split(" ")[1]); l++)
                {
                    mainDish.Add(mainDishList[dish_index]);
                }
                continue;
            }
            dish_index = System.Array.IndexOf(sideDishNames, DishData[i].Split(" ")[0]);
            if (dish_index != -1) {
                for (var l = 0; l < int.Parse(DishData[i].Split(" ")[1]); l++)
                {
                    sideDish.Add(sideDishList[dish_index]);
                }
                continue;
            }
            /*
            dish_index = System.Array.IndexOf(dessertDishNames, DishData[i].Split(" ")[0]);
            if (dish_index != -1) {
                dessertDish.Add(dessertDishList[dish_index]);
                continue;
            }
            dish_index = System.Array.IndexOf(beverageDishNames, DishData[i].Split(" ")[0]);
            if (dish_index != -1) {
                beverageDish.Add(beverageDishList[dish_index]);
                continue;
            }
            */
        }

        //spawn first order
        GameObject order = (GameObject)Instantiate(orderPrefab, ui.transform);
        order.transform.SetSiblingIndex(order.transform.parent.transform.childCount - 2);
        if (mainDish.Count != 0)
        {
            order.GetComponent<Order>().main = mainDish[0];
            mainDish.RemoveAt(0);
        }

        if (sideDish.Count != 0)
        {
            order.GetComponent<Order>().side = sideDish[0];
            sideDish.RemoveAt(0);
        }

        /*
        order.GetComponent<Order>().dessert = dessertDish[0];
        order.GetComponent<Order>().drink = beverageDish[0];
        */
        foreach (GameObject orderItem in orderList)
        {
            orderItem.transform.position = new Vector3(orderItem.transform.position.x - 250, orderItem.transform.position.y, 0);
        }
        orderList.Add(order);


    }

    void populateArray(string[] names, GameObject[] list) {
        for (var i = 0; i < list.Length; i++) {
            names[i] = list[i].name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(Time.deltaTime);
        if (timer >= 5.0f && (mainDish.Count > 0 || sideDish.Count > 0))
        {
            timer = 0.0f;
            //test: spawn the first order, TODO:edit to be inside update
            GameObject order = (GameObject)Instantiate(orderPrefab, ui.transform);
            order.transform.SetSiblingIndex(order.transform.parent.transform.childCount - 2);
            if (mainDish.Count != 0)
            {
                order.GetComponent<Order>().main = mainDish[0];
                mainDish.RemoveAt(0);
            } 

            if (sideDish.Count != 0)
            {
                order.GetComponent<Order>().side = sideDish[0];
                sideDish.RemoveAt(0);
            }

            /*
            order.GetComponent<Order>().dessert = dessertDish[0];
            order.GetComponent<Order>().drink = beverageDish[0];
            */
            foreach (GameObject orderItem in orderList)
            {
                orderItem.transform.position = new Vector3(orderItem.transform.position.x - 250, orderItem.transform.position.y, 0);
            }
            orderList.Add(order);
        }
        if (mainDish.Count <= 0 && sideDish.Count <= 0 && orderList.Count <= 0)
        {
            dialogue.SetActive(true);
        }
    }

}
