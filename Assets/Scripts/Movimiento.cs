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
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
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

    public void ActualizarPosicion()
    {
        posObjetivo = new Vector3(lateral, 0, posicionZ);
       // transform.position = posObjetivo;
       transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad * Time.deltaTime);
    }

    public void Avanzar()
    {
        posicionZ++;
        if (posicionZ > carril)
        {
            carril = posicionZ;
            mundo.CrearPiso();
        }
    }

    public void Retroceder()
    {
        if (posicionZ > carril - 3)
        {
            posicionZ--;
        }
    }

    public void MoverLados(int cuanto)
    {
        lateral += cuanto;
        lateral = Mathf.Clamp(lateral, -4, 4);
    }
}

