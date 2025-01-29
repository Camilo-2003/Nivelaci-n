using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Movimiento : MonoBehaviour
{
    public float velocidad = 10f;
    public float rotacionVelocidad = 10f; 
    private NavMeshAgent navAgent;

    void Start()
    {
       
        navAgent = GetComponent<NavMeshAgent>();

        navAgent.updateRotation = false;

        navAgent.speed = velocidad;

        navAgent.autoBraking = false;

        
        navAgent.stoppingDistance = 0.3f;  
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");  
        float vertical = Input.GetAxis("Vertical");      

        
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        
        if (direccion.magnitude >= 0.1f)
        {
            
            Vector3 destino = transform.position + direccion;

          
            navAgent.SetDestination(destino);

            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, rotacionVelocidad * Time.deltaTime);
        }
        else
        {
           
            navAgent.ResetPath();
        }
    }
}

    
