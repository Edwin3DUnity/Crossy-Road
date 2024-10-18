using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LanzarRayo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanzarRayo()
    {
        RaycastHit hit;
        Ray rayo = new Ray(transform.position + Vector3.up * 3 - Vector3.forward, Vector3.down);
        if (Physics.Raycast(rayo, out hit))
        {
            if (hit.collider.CompareTag("hoja"))
            {
                Destroy(gameObject);
            }
        }
    }
}
