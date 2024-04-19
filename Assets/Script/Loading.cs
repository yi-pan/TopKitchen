using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject CookingTable;
    float workload;

    // Start is called before the first frame update
    void Start()
    {
        workload = CookingTable.GetComponent<CookTable>().workload;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
