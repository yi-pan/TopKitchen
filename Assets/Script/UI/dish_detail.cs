using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Security.Cryptography;

public class DishDetail : MonoBehaviour
{
    public DishListUI dishList;
    [SerializeField] Sprite[] ingred_type_sprite;
    private DishUI dish;

    public GameObject dish_layer, price_time, ingredients, dish_level, dish_cookingList;

    public GameObject fried, grill, bake, boil, steam, prepare;
    public Image dish_img;
    public TMP_Text dish_name, dish_price;
    [SerializeField] Sprite[] dishSprite;
    private Sprite img;
    private object ingrendientList;

    void Start()
    {
        dish_layer = transform.GetChild(0).gameObject;
        price_time = transform.GetChild(1).gameObject;
        ingredients = transform.GetChild(2).gameObject;

        dish_img = dish_layer.transform.GetChild(1).GetComponent<Image>();

        dish_name = dish_layer.transform.GetChild(2).GetComponent<TMP_Text>();
        dish_level = dish_layer.transform.GetChild(3).gameObject;

        dish_cookingList = dish_layer.transform.GetChild(4).gameObject;

        fried = dish_cookingList.transform.GetChild(0).gameObject;
        grill = dish_cookingList.transform.GetChild(1).gameObject;
        bake = dish_cookingList.transform.GetChild(2).gameObject;
        boil = dish_cookingList.transform.GetChild(3).gameObject;
        steam = dish_cookingList.transform.GetChild(4).gameObject;
        prepare = dish_cookingList.transform.GetChild(5).gameObject;
    }
    public void SetDishDetail(string name)
    {
        dish = dishList.GetDishDetail(name);

        // set up image
        SetDishImage(name);

        // set up name
        string n = name.Replace("_", " ");
        dish_name.text = n;

        // set up level/star
        SetDishLevel(dish.level);
        
        // set up cooking method
        SetCookMethod(dish.cookingList);

        // set up price
        dish_price.text = dish.avg_price.ToString("0");

        // set up time

        // set up ingredients
        SetIngredients(dish.ingredientList);
        
    }

    private void SetIngredients(List<IngredientUI> ingredientList)
    {
        int ingred_count = dish.ingredientList.Count;
        // hide ingredients
        for(int i =  0; i < 8; i++)
        {
            ingredients.transform.GetChild(i).gameObject.SetActive(false);
        }
        // show ingredients
        for (int i = 0; i < ingred_count; i++)
        {
            GameObject ingred = ingredients.transform.GetChild(i).gameObject;
            ingred.SetActive(true);
            Image dish_img = ingred.transform.GetChild(1).GetComponent<Image>();
            // set up dish image


            // set up type icon
            Image type_img = ingred.transform.GetChild(2).GetComponent<Image>();
            if (ingredientList[i].type.Equals("egg")) type_img.sprite = ingred_type_sprite[0];
            if (ingredientList[i].type.Equals("bug")) type_img.sprite = ingred_type_sprite[1];
            if (ingredientList[i].type.Equals("shell")) type_img.sprite = ingred_type_sprite[2];
            if (ingredientList[i].type.Equals("milk")) type_img.sprite = ingred_type_sprite[3];
            if (ingredientList[i].type.Equals("ferment")) type_img.sprite = ingred_type_sprite[4];
            if (ingredientList[i].type.Equals("fish")) type_img.sprite = ingred_type_sprite[5];
            if (ingredientList[i].type.Equals("meat")) type_img.sprite = ingred_type_sprite[6];
            if (ingredientList[i].type.Equals("fruit")) type_img.sprite = ingred_type_sprite[7];
            if (ingredientList[i].type.Equals("seaweed")) type_img.sprite = ingred_type_sprite[8];
            if (ingredientList[i].type.Equals("coral")) type_img.sprite = ingred_type_sprite[9];
            if (ingredientList[i].type.Equals("root")) type_img.sprite = ingred_type_sprite[10];
            // set up count
            string count = "x ";
            count += ingredientList[i].count.ToString("0");
            ingred.transform.GetChild(3).GetComponent<TMP_Text>().text = count;
        }
    }

    private void SetCookMethod(List<string> cookingList)
    {
        fried.SetActive(false);
        grill.SetActive(false);
        bake.SetActive(false);
        boil.SetActive(false);
        steam.SetActive(false);
        prepare.SetActive(false);

        string result = "";
        foreach (string item in cookingList)
        {
            result += item.ToString() + " ";
        }
        //Debug.Log(result);
        if (result.Contains("fried")) fried.SetActive(true);
        if (result.Contains("grill")) grill.SetActive(true);
        if (result.Contains("bake")) bake.SetActive(true);
        if (result.Contains("boil")) boil.SetActive(true);
        if (result.Contains("steam")) steam.SetActive(true);
        if (result.Contains("prepare")) prepare.SetActive(true);

    }

    private void SetDishLevel(float level)
    {
        if (level < 1)
        {
            dish_level.SetActive(false);
        }
        else
        {
            dish_level.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                if (i >= level) dish_level.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
                if (i < level) dish_level.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 0.75f, 0f, 1f);
            }
        }
    }

    private void SetDishImage(string name)
    {
        if (name == "dudu_soup") img = dishSprite[0];
        if (name == "omurice") img = dishSprite[1];
        if (name == "sashimi") img = dishSprite[2];
        if (name == "fried_lumin_egg") img = dishSprite[3];
        if (name == "seaweed_jelly") img = dishSprite[4];
        if (name == "berry_juice") img = dishSprite[5];
        dish_img.sprite = img;
    }
}
