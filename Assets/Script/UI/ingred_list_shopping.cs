using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredListShop : MonoBehaviour
{
    public List<GameObject> ingredList;

    public List<IngredientUI> shopped_ingred_list;
    public List<Sprite> ingred_sprite;
    // set ingredients list on the left of the screen
    public void CreateList(List<IngredientUI> shopped_ingred)
    {
        //foreach(IngredientUI ingred in shopped_ingred)
        //{
        //    Debug.Log(ingred.name + " " + ingred.type + " " + ingred.count);
        //}

        // save the shopped ingrendient list
        shopped_ingred_list = shopped_ingred;

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
            if (shopped_ingred_list[i].ingred_name.Equals("small_fish")) ingred_img.sprite = ingred_sprite[0];
            else if (shopped_ingred_list[i].ingred_name.Equals("duduclam")) ingred_img.sprite = ingred_sprite[1];
            else if (shopped_ingred_list[i].ingred_name.Equals("deeproot")) ingred_img.sprite = ingred_sprite[2];
            else if (shopped_ingred_list[i].ingred_name.Equals("jelly_seaweed")) ingred_img.sprite = ingred_sprite[3];
            else if (shopped_ingred_list[i].ingred_name.Equals("dark_berry")) ingred_img.sprite = ingred_sprite[4];
            else if (shopped_ingred_list[i].ingred_name.Equals("canned_radiance_milk")) ingred_img.sprite = ingred_sprite[5];
            else if (shopped_ingred_list[i].ingred_name.Equals("lumin_egg")) ingred_img.sprite = ingred_sprite[6];
            else if (shopped_ingred_list[i].ingred_name.Equals("pink_coral_sugar")) ingred_img.sprite = ingred_sprite[7];
            else ingred_img.sprite = ingred_sprite[0];

            TMP_Text ingred_name = ingredList[i].transform.GetChild(1).GetComponent<TMP_Text>();
            TMP_Text ingred_count = ingredList[i].transform.GetChild(2).GetComponent<TMP_Text>();
            ingred_name.text = shopped_ingred[i].ingred_name.Replace("_", " ");
            ingred_count.text = "x " + shopped_ingred[i].count.ToString() + " (" + shopped_ingred[i].count.ToString() + ")";

            // set up the total count
            shopped_ingred_list[i].total_count = shopped_ingred[i].count;
        }
    }

    // if the ingred count is changed, update the ingred count on the left side
    public void UpdateIngredCount(string ingred_name, int count, int each_count)
    {
        for (int i = 0; i < shopped_ingred_list.Count; i++)
        {
            if (shopped_ingred_list[i].ingred_name.Equals(ingred_name)) { 
                shopped_ingred_list[i].count -= count*each_count; 
                TMP_Text ingred_count = ingredList[i].transform.GetChild(2).GetComponent<TMP_Text>();
                ingred_count.text = "x " + shopped_ingred_list[i].count.ToString() + " (" + shopped_ingred_list[i].total_count.ToString() + ")";
                if (shopped_ingred_list[i].count == 0)
                {
                    ingred_count.color = Color.red;
                }
                else
                {
                    ingred_count.color = Color.black;
                }
            }
        }
    }

    public int CheckIngredCount(string ingred_name, int input_count, int each_count) 
    {
        for (int i = 0; i < shopped_ingred_list.Count; i++)
        {
            // get the ingred
            if (shopped_ingred_list[i].ingred_name.Equals(ingred_name)) {
                // if current count of the ingred < what we need
                //Debug.Log(ingred_name + ", " + shopped_ingred_list[i].count + ", " + input_count * each_count);
                if(shopped_ingred_list[i].count < input_count*each_count)
                {
                    // return the feasible count 
                    return Mathf.FloorToInt(shopped_ingred_list[i].count/each_count);
                }
            }
        }
        return input_count; // if the input count is feasible, return the input count
    }
    

    public void HighlightIngred(List<string> ingred_name)
    {
        for(int i = 0; i<shopped_ingred_list.Count; i++)
        {
            Image bk = ingredList[i].transform.GetComponent<Image>();
            if (ingred_name.Contains(shopped_ingred_list[i].ingred_name))
            {
                bk.color = new Color(1, 0.7f, 0.7f, 1);
            }
            else
            {
                bk.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
