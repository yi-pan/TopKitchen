using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{

    public GameObject[] main;
    public GameObject[] side;
    public GameObject[] dessert;
    public GameObject[] drink;

    public Vector3 mainPos;
    public Vector3 sidePos;
    public Vector3 dessertPos;
    public Vector3 drinkPos;

    // Start is called before the first frame update
    void Start()
    {
        int main_i = Random.Range(0, main.Length);
        int side_i = Random.Range(0, side.Length);
        GameObject main_dish = Instantiate(main[main_i], this.transform);
        main_dish.transform.localPosition = mainPos;
        GameObject side_dish = Instantiate(side[side_i], this.transform);
        side_dish.transform.localPosition = sidePos;
        GameObject dessert_dish = Instantiate(dessert[0], this.transform);
        dessert_dish.transform.localPosition = dessertPos;
        GameObject drink_dish = Instantiate(drink[0], this.transform);
        drink_dish.transform.localPosition = drinkPos;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: if finished, disppear
    }
}
