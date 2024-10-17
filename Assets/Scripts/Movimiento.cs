using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public int carril;
    public int lateral;
    public Vector3 posObjetivo;
    public float velocidad;

    private int posicionZ;

    public Mundo mundo;
    public Transform grafico;
    public LayerMask capaObstaculos;
    public LayerMask capaAgua;
    public float distanciaVista = 1;
    public bool vivo = true;
    public Animator animaciones; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MirarAgua", 1,0.5f);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarPosicion();
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            Avanzar();
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            Retroceder();
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            MoverLados(1);
        }else if (Input.GetKeyDown(KeyCode.A))
        {
            MoverLados(-1);
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(grafico.position + Vector3.up * 0.5f , grafico.position + Vector3.up * 0.5f + grafico.forward * distanciaVista);
       

    }

    public void ActualizarPosicion()
    {
        if (!vivo)
        {
            return;
        }
        posObjetivo = new Vector3(lateral, 0, posicionZ);
       // transform.position = posObjetivo;
       transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad * Time.deltaTime);
    }

    public void Avanzar()
    {
        if (!vivo)
        {
            return;
            
        }
        grafico.eulerAngles = Vector3.zero;
        if (MirarAdelante())
        {
            print("Verdadero");
            return;
        }
        
        posicionZ++;
        animaciones.SetTrigger("saltar");
        if (posicionZ > carril)
        {
            carril = posicionZ;
            mundo.CrearPiso();
        }
    }

    public void Retroceder()
    {
        if (!vivo)
        {
            return;
        }
        grafico.eulerAngles = new Vector3(0,180,0);
        if (MirarAdelante())
        {
            return;
        }
        if (posicionZ > carril - 3)
        {
            posicionZ--;
            animaciones.SetTrigger("saltar");
        }
    }

    public void MoverLados(int cuanto)
    {
        if (!vivo)
        {
            return;
        }
        grafico.eulerAngles = new Vector3(0, 90 * cuanto, 0);
        if (MirarAdelante())
        {
            return;
        }
        lateral += cuanto;
        animaciones.SetTrigger("saltar");
        lateral = Mathf.Clamp(lateral, -4, 4);
    }


    public bool MirarAdelante()
    {
      
        RaycastHit hit;
        Ray rayo = new Ray(grafico.position + Vector3.up * 0.5f, grafico.forward);

        if (Physics.Raycast(rayo, out hit, distanciaVista ,capaObstaculos ))
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("carro"))
        {
            animaciones.SetTrigger("morir");
            vivo = false;
        }
    }



    public void MirarAgua()
    {
        RaycastHit hit;
        Ray rayo = new Ray(transform.position + Vector3.up, Vector3.down);

        if (Physics.Raycast(rayo, out hit, 3, capaAgua))
        {
            if (hit.collider.CompareTag("Agua"))
            {
                
                animaciones.SetTrigger("agua");
                vivo = false;
                Debug.Log("Agua cai");
            }
        }


    }
}

