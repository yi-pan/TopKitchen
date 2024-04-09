using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    public TextAsset textFile;
    public float fried;
    public float grill;
    public float boil;
    public float steam;
    public float bake;
    public float prepare;
    public string[] materials;
    public int fastCook;

    
    // Start is called before the first frame update
    void Start()
    {
        string text = textFile.text;  //this is the content as string
        string[] data = text.Split("\n");
        fried = float.Parse(data[0].Split(":")[1]);
        grill = float.Parse(data[1].Split(":")[1]);
        boil = float.Parse(data[2].Split(":")[1]);
        steam = float.Parse(data[3].Split(":")[1]);
        bake = float.Parse(data[4].Split(":")[1]);
        prepare = float.Parse(data[5].Split(":")[1]);

        //Debug.Log(fried + "," + grill + "," + boil + "," + steam + "," + bake + "," + prepare);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    //DRAG CHEF
    Vector3 mousePosition;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        Vector3 currentPos = transform.position;
        Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).x, currentPos.y, Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).z);
        transform.position = newPos;
    }
}
