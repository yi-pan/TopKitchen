using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredListShop : MonoBehaviour
{
    public List<GameObject> ingredList;

    // set ingredients list on the left of the screen
    public void CreateList(List<IngredientUI> shopped_ingred)
    {
        //foreach(IngredientUI ingred in shopped_ingred)
        //{
        //    Debug.Log(ingred.name + " " + ingred.type + " " + ingred.count);
        //}

        // load the ingred list
        for (int i = 0; i < transform.childCount; i++)
        {
            ingredList.Add(transform.GetChild(i).gameObject);
        }

        // hide all ingred
        foreach (GameObject ingred in ingredList)
        {
            ingred.SetActive(false);
        }

        // show the first a few ingred
        for(int i = 0; i<shopped_ingred.Count; i++)
        {
            ingredList[i].SetActive(true);
        }

        // set up the ingred's image, name and count
        for(int i = 0; i<shopped_ingred.Count; i++)
        {
            Image ingred_img = ingredList[i].transform.GetChild(0).GetComponent<Image>();
            TMP_Text ingred_name = ingredList[i].transform.GetChild(1).GetComponent<TMP_Text>();
            TMP_Text ingred_count = ingredList[i].transform.GetChild(2).GetComponent<TMP_Text>();
            ingred_name.text = shopped_ingred[i].name.Replace("_", " ");
            ingred_count.text = "x " + shopped_ingred[i].count.ToString() + " (" + shopped_ingred[i].count.ToString() + ")";
        }
        
    }
}
