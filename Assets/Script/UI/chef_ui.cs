using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChefUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ChefSelected chefSelect;
    public string name;
    public int fried, grill, boil, steam, bake, prepare;
    public List<string> ability_ingred = new List<string>();

    private GameObject profile;
    private TMP_Text name_text;

    public bool is_selecting = false;
    public bool is_selected = false;
    public bool is_locked = true;

    void Update()
    {
        if (is_selecting)
        {
            profile.transform.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            profile.transform.GetComponent<Image>().color = new Color(0.8745098f, 0.9019608f, 0.9137255f, 1f);
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name + " " + fried + " " + ability_ingred[0]);
        chefSelect.SelectChef(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        is_selecting = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        is_selecting = false;
    }

    void Start()
    {
        profile = transform.GetChild(0).gameObject;
        name_text = transform.GetChild(1).GetComponent<TMP_Text>();
        name_text.text = name;
    }
}
