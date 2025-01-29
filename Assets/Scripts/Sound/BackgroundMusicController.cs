using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip musicaDeFondo; 
    public float volumen = 0.5f;    

    private AudioSource audioSource;

    void Awake()
    {
        
        if (FindObjectsOfType<BackgroundMusicController>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicaDeFondo;
        audioSource.loop = true;
        audioSource.volume = volumen;
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        
        if (musicaDeFondo != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se asignó un clip de música de fondo en el controlador.");
        }
    }

    
    public void SetVolume(float newVolume)
    {
        volumen = Mathf.Clamp(newVolume, 0f, 1f);
        audioSource.volume = volumen;
    }

    
    public void DetenerMusicaConRetraso(float delay)
    {
        StartCoroutine(DetenerMusica(delay));
    }

    private IEnumerator DetenerMusica(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (audioSource != null && audioSource.isPlaying)
        {
            Debug.Log("Deteniendo la música...");
            audioSource.Stop();
        }
    }
}
