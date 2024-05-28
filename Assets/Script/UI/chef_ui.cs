using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChefUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ChefSelected chefSelect;
    public string chef_name;
    public int fried, grill, boil, steam, bake, prepare;
    public List<string> ability_ingred = new List<string>();

    public GameObject selected_black;
    private GameObject profile;
    private TMP_Text name_text;

    public bool is_selecting;
    public bool is_selected;
    public bool is_locked;

    void Start()
    {
        profile = transform.GetChild(0).gameObject;
        name_text = transform.GetChild(2).GetComponent<TMP_Text>();
        name_text.text = chef_name;
        selected_black = transform.GetChild(3).gameObject;
        selected_black.SetActive(false);
        if(is_locked) transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (is_selecting)
        {
            profile.transform.GetComponent<Image>().color = new Color(0.9764706f, 0.7450981f, 0.3843137f, 1f);
        }
        else
        {
            profile.transform.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }

    // ChefUI is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!is_selected)
        {
            is_selected = true;
            chefSelect.SelectChef(this);
            selected_black.SetActive(true);
        }
    }

    // ChefUI is hovered
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!is_selected)
        {
            is_selecting = true;
            chefSelect.ShowChef(this);
        }
    }

    // pointer exit the ChefUI, Hide chef detail if not selected
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!is_selected)
        {
            chefSelect.HideChef();
        }
        is_selecting = false;  
    }

    public void Reset()
    {
        is_selected = false; 
        selected_black.SetActive(false);
    }

    public string printChefDetail()
    {
        string ability_cook_string, ability_ingred_string;
        ability_cook_string = fried + " " + grill + " " + boil + " " + steam + " " + bake + " " + prepare;
        ability_ingred_string = "";
        foreach(var ingred in ability_ingred)
        {
            ability_ingred_string += ingred.ToString() + " ";
        }
        //Debug.Log(chef_name + "; " + ability_cook_string + "; " + ability_ingred_string);
        string detail = chef_name + "; " + ability_cook_string + "; " + ability_ingred_string;
        return detail;
    }
}
