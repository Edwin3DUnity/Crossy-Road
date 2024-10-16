using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCarros : MonoBehaviour
{
    public GameObject inicio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("carro"))
        {
            other.transform.Translate(0,0,-15);
            
        }
    }
}
