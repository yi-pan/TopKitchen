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

    //mainPos, sidePos,dessertPos, beveragePos,freePos
    public Vector3[] positions;
    //list of chef
    public GameObject[] Chefs;
    string[] ChefNames = new string[5];

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
            Debug.Log(ChefData[i]);
            int spawn_index = System.Array.IndexOf(ChefNames, ChefData[i].Split("; ")[1]);
            Instantiate(Chefs[spawn_index], positions[i-2], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
