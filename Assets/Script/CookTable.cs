using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CookTable : MonoBehaviour
{
    float timer = 0.0f;
    public int gameSeconds;
    //dish info
    public GameObject[] dishes;
    public GameObject currentDish;
    private string[] materials;
    private string[] cookings;
    private List<GameObject> currentChefs = new List<GameObject>();

    //workload info
    public float workload;
    float overallWork;
    private bool canChange;
    public float workPerSecond = 0.0f;

    //loading info
    public Animator loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        canChange = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collide");
        if (collision.gameObject.tag == "Chef" && currentDish != null)
        {
            //add the amount to the equation
            float addUp = CalculateAddUp(collision.gameObject);
            workPerSecond += 5f * (1 + addUp);
            Debug.Log(workPerSecond);
        } else if (collision.gameObject.tag == "Chef" && currentDish == null)
        {
            currentChefs.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Chef" && currentDish != null)
        {
            //delete the amount from the equation
            float addUp = CalculateAddUp(collision.gameObject);
            workPerSecond -= 5f * (1 + addUp);
        } else if (collision.gameObject.tag == "Chef" && currentDish == null)
        {
            currentChefs.Remove(collision.gameObject);
        }
    }

    private float CalculateAddUp(GameObject chef)
    {
        //cooking skill addup
        float skillAddUp = 0.0f;
        for (int j = 0; j < cookings.Length; j++)
        {
            skillAddUp += (float)chef.GetComponent<Chef>().GetType().GetField(cookings[j]).GetValue(chef.GetComponent<Chef>());
            Debug.Log("skillAddUp" + skillAddUp);
        }

        //material addup
        int material_num = 0;
        for (int i = 0; i < materials.Length; i++)
        {
            if (System.Array.IndexOf(chef.GetComponent<Chef>().materials, materials[i]) != -1)
            {
                material_num += 1;
            }
        }
        //Debug.Log("material match" + material_num);
        float finalAddUp = skillAddUp * 0.07f + ((float)material_num / materials.Length) * 0.1f + chef.GetComponent<Chef>().fastCook*0.2f;
        Debug.Log(finalAddUp);
        return finalAddUp;
    }

    private void Update()
    {
        //when asign new dish
        if (canChange && currentDish != null)
        {
            workload = currentDish.GetComponent<Dish>().workload;
            overallWork = workload;
            materials = currentDish.GetComponent<Dish>().materialList;
            cookings = currentDish.GetComponent<Dish>().cookingList;
            foreach(GameObject Chef in currentChefs)
            {
                Debug.Log(Chef.name);
                workPerSecond += 5f * (1 + CalculateAddUp(Chef));
                
            }
            canChange = false;
        }

        timer += Time.deltaTime;
        //Debug.Log(Time.deltaTime);
        if (timer >= 1.0f && currentDish != null)
        {
            timer = 0.0f;
            gameSeconds += 1;
            workload -= workPerSecond;
            loadingBar.SetFloat("LoadingTime", (overallWork - workload) / overallWork);
            if (workload <= 0)
            {
                workPerSecond = 0;
                overallWork = 0;
                canChange = true;
                currentDish.GetComponent<Dish>().cooked_status = true;
                currentDish = null;
            }
        }

    }
}
