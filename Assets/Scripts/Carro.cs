using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{

    public float velocidad;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, velocidad  * Time.deltaTime);
    }
}
