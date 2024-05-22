using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectData : MonoBehaviour
{
    public string collectedData;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        collectedData = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
