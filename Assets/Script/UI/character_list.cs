using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class character_list : MonoBehaviour
{
    [SerializeField] private TextAsset _file;

    public List<ChefUI> chefList;

    void Start()
    {
        var content = _file.text;
        var words = content.Split("\n");
        var lines = new List<string>(words);
        foreach (var line in lines)
        {
            var variables = new List<string>(line.Split("; "));
            foreach(ChefUI c in chefList)
            {
                if (c.name.Equals(variables[0]))
                {
                    var ability_cooked_text = new List<string>(variables[1].Split(" "));
                    c.fried = int.Parse(ability_cooked_text[0]);
                    c.grill = int.Parse(ability_cooked_text[1]);
                    c.boil = int.Parse(ability_cooked_text[2]);
                    c.steam = int.Parse(ability_cooked_text[3]);
                    c.bake = int.Parse(ability_cooked_text[4]);
                    c.prepare = int.Parse(ability_cooked_text[5]);

                    var ability_ingred_text = new List<string>(variables[2].Split(" "));
                    foreach (var ingred in ability_ingred_text)
                    {
                        c.ability_ingred.Add(ingred);
                    }
                    break;
                }
            }
        }
    }
    public ChefUI GetChefDetail(string name)
    {
        //Debug.Log(name);
        foreach (var chef in chefList)
        {
            //Debug.Log(chef.name);
            if (chef.name == name) return chef;
        }
        return null;
    }
}
