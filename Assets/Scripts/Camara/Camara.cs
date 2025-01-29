using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform jugador;  
    public Vector3 offset = new Vector3(0, 10, -10);  
    public float velocidadDeMovimiento = 5f;  

    
    void Start()
    {
        if (jugador != null)
        {
            
            transform.position = jugador.position + offset;
        }
    }

    
    void Update()
    {
        if (jugador != null)
        {
            
            Vector3 posicionDeseada = jugador.position + offset;

            
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, velocidadDeMovimiento * Time.deltaTime);
            
            
            transform.LookAt(jugador);
        }
    }
}

