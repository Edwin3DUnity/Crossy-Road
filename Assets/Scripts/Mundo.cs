using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mundo : MonoBehaviour
{

    public GameObject[] pisos;
    public int carril = 0;
    public int pisosDiferencia;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < pisosDiferencia;i++)
        {
            CrearPiso();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CrearPiso()
    {
        Instantiate(pisos[Random.Range(0, pisos.Length)], Vector3.forward * carril, Quaternion.identity );
        carril++;

    }
    
}
