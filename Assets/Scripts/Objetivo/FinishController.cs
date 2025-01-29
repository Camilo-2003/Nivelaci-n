using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishController : MonoBehaviour
{
    public GameObject mensajeFinal;
    public string mensaje = "¡Ganaste!";  
    public float tiempoAntesDeDesaparecer = 3f;  
    public float tiempoParaDetenerMusica = 3f;  

    private bool jugadorCerca = false;  
    private BackgroundMusicController musicController;

    void Start()
    {
        
        musicController = FindObjectOfType<BackgroundMusicController>();
        if (musicController == null)
        {
            Debug.LogWarning("No se encontró un BackgroundMusicController en la escena.");
        }
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.Space))
        {
        
            Destroy(gameObject);

            if (mensajeFinal != null)
            {
                mensajeFinal.SetActive(true);
                var textComponent = mensajeFinal.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = mensaje;
                }
                else
                {
                    Debug.LogError("El objeto mensajeFinal no tiene un componente TextMeshProUGUI.");
                }

                
                if (musicController != null)
                {
                    musicController.DetenerMusicaConRetraso(tiempoParaDetenerMusica);
                }

                
                Invoke("OcultarMensaje", tiempoAntesDeDesaparecer);
            }
        }
    }

   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true; 
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;  
        }
    }

    void OcultarMensaje()
    {
        if (mensajeFinal != null)
        {
            mensajeFinal.SetActive(false);
        }
    }
}
