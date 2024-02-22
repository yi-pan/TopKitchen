using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public TextAsset textFile;     // drop your file here in inspector
    string[] full_menu;
    string[] main;
    string[] appetizer;
    string[] side;
    string[] dessert;

    Order[] orderList;

    // Start is called before the first frame update
    void Start()
    {
        string text = textFile.text;  //this is the content as string
        full_menu = text.Split("\n");
        //Debug.Log(full_menu[1]);
        main = full_menu[0].Split(';');
        appetizer = full_menu[1].Split(';');
        side = full_menu[2].Split(';');
        dessert = full_menu[3].Split(';');
        //Debug.Log(dessert);

        orderList = new Order[3];
        orderList[0] = new Order(main[Random.Range(0, 2)].Split(':')[0], appetizer[Random.Range(0, 2)], side[Random.Range(0, 2)], dessert[Random.Range(0, 2)]);
        //Debug.Log(orderList[0].main);
        orderList[1] = new Order(main[Random.Range(0, 2)].Split(':')[0], appetizer[Random.Range(0, 2)], side[Random.Range(0, 2)], dessert[Random.Range(0, 2)]);
        orderList[2] = new Order(main[Random.Range(0, 2)].Split(':')[0], appetizer[Random.Range(0, 2)], side[Random.Range(0, 2)], dessert[Random.Range(0, 2)]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < 3; i++)
            {
                orderList[i].print();
            }
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            int random = Random.Range(0, 3);
            orderList[random] = new Order(main[Random.Range(0, 2)].Split(':')[0], appetizer[Random.Range(0, 2)], side[Random.Range(0, 2)], dessert[Random.Range(0, 2)]);

        }
    }

    class Order
    {
        public string main;
        public string appetizer;
        public string side;
        public string dessert;

        public Order(string m, string a, string s, string d)
        {
            main = m;
            appetizer = a;
            side = s;
            dessert = d;
        }

        public void print()
        {
            Debug.Log(main + "," + appetizer + "," + side + "," + dessert);
        }
    }
}
