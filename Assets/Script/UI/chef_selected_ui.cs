using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChefSelectedUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool is_locked;
    public bool is_selecting;
    public bool is_selected;

    public bool is_empty;

    public ChefUI last_selected;

    public ChefSelected chefSelected;

    public GameObject selected_bk;
    public GameObject add_bk;
    public GameObject profile;
    public GameObject chef_name;
    public GameObject ability_cook;
    public TMP_Text fried, grill, bake, boil, steam, prepare;

    public GameObject ability_ingred;
    public GameObject ingred1, ingred2, ingred3, ingred4;

    public Sprite[] ingred_icons;

    public ChefUI selectedChef;

    // Start is called before the first frame update
    void Start()
    {
        selected_bk = transform.GetChild(0).gameObject;
        selected_bk.SetActive(is_selecting);
        add_bk = transform.GetChild(3).gameObject;
        add_bk.SetActive(is_empty);

        profile = transform.GetChild(4).gameObject;
        profile.SetActive(!is_empty);

        chef_name = transform.GetChild(5).gameObject;
        chef_name.SetActive(!is_empty);

        ability_cook = transform.GetChild(6).gameObject;
        ability_cook.SetActive(!is_empty);
        fried = ability_cook.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        grill = ability_cook.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>();
        bake = ability_cook.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>();
        boil = ability_cook.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>();
        steam = ability_cook.transform.GetChild(4).GetChild(0).GetComponent<TMP_Text>();
        prepare = ability_cook.transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>();

        ability_ingred = transform.GetChild(7).gameObject;
        ability_ingred.SetActive(!is_empty);
        ingred1 = ability_ingred.transform.GetChild(0).GetChild(0).gameObject;
        ingred2 = ability_ingred.transform.GetChild(0).GetChild(1).gameObject;
        ingred3 = ability_ingred.transform.GetChild(1).GetChild(0).gameObject;
        ingred4 = ability_ingred.transform.GetChild(1).GetChild(1).gameObject;
    }

    public void SetChef(ChefUI chef)
    {
        
        chef_name.GetComponent<TMP_Text>().text = chef.name;
        fried.text = chef.fried.ToString();
        grill.text = chef.grill.ToString();
        bake.text = chef.bake.ToString();
        boil.text = chef.boil.ToString();
        steam.text = chef.steam.ToString();
        prepare.text = chef.prepare.ToString();
        SetIngred(chef.ability_ingred);

        if (is_empty)
        {
            is_empty = false;
            ShowChef();
        }
    }
  

    private void SetIngred(List<string> ability_ingred)
    {
        Image icon1 = ingred1.transform.GetChild(0).GetComponent<Image>();
        TMP_Text text1 = ingred1.transform.GetChild(1).GetComponent<TMP_Text>();
        Image icon2 = ingred2.transform.GetChild(0).GetComponent<Image>();
        TMP_Text text2 = ingred2.transform.GetChild(1).GetComponent<TMP_Text>();
        Image icon3 = ingred3.transform.GetChild(0).GetComponent<Image>();
        TMP_Text text3 = ingred3.transform.GetChild(1).GetComponent<TMP_Text>();
        Image icon4 = ingred4.transform.GetChild(0).GetComponent<Image>();
        TMP_Text text4 = ingred4.transform.GetChild(1).GetComponent<TMP_Text>();

        ingred1.SetActive(false);
        ingred2.SetActive(false);
        ingred3.SetActive(false);
        ingred4.SetActive(false);

        if (ability_ingred.Count >= 1) 
        { 
            icon1.sprite = getIngredIcon(ability_ingred[0]);
            text1.text = ability_ingred[0];
            ingred1.SetActive(true);
        }
        if (ability_ingred.Count >= 2)
        {
            icon2.sprite = getIngredIcon(ability_ingred[1]);
            text2.text = ability_ingred[1];
            ingred2.SetActive(true);
        }
        if (ability_ingred.Count >= 3)
        {
            icon3.sprite = getIngredIcon(ability_ingred[2]);
            text3.text = ability_ingred[2];
            ingred3.SetActive(true);
        }
        if (ability_ingred.Count >= 4)
        {
            icon4.sprite = getIngredIcon(ability_ingred[3]);
            text4.text = ability_ingred[3];
            ingred4.SetActive(true);
        }
    }

    private Sprite getIngredIcon(string v)
    {
        if (v.Contains("egg")) return ingred_icons[0];
        else if (v.Contains("bug")) return ingred_icons[1];
        else if (v.Contains("shell")) return ingred_icons[2];
        else if (v.Contains("milk")) return ingred_icons[3];
        else if (v.Contains("ferment")) return ingred_icons[4];
        else if(v.Contains("fish")) return ingred_icons[5];
        else if(v.Contains("meat")) return ingred_icons[6];
        else if(v.Contains("fruit")) return ingred_icons[7];
        else if(v.Contains("seaweed")) return ingred_icons[8];
        else if(v.Contains("coral")) return ingred_icons[9];
        else return ingred_icons[10];
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        is_selecting = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!is_selected) is_selecting = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chefSelected.SelectSpot(this.transform.gameObject);
        //if (is_selected)
        //{
        //    is_selected = false;
        //    last_selected.is_selected = false;
        //    last_selected.selected_black.SetActive(false);
        //    is_empty = true;
        //    ShowChef();
        //}
        //else
        //{
        //    chefSelected.SelectSpot(this.transform.gameObject);
        //}
    }
    
    void Update()
    {
        selected_bk.SetActive(is_selecting);
        
    }

    public void ShowChef()
    {
        profile.SetActive(!is_empty);
        add_bk.SetActive(is_empty);
        chef_name.SetActive(!is_empty);
        ability_cook.SetActive(!is_empty);
        ability_ingred.SetActive(!is_empty);
    }

    
}
