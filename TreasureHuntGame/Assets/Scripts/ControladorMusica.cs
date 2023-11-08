using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladorMusica : MonoBehaviour
{
    private static AudioSource musica;

    private void Awake()
    {
       if(musica != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            musica = GetComponent<AudioSource>();
        }
    }

  public void PlayMusic()
    {
        if (musica.isPlaying) return;
        musica.Play();
    }

    public void StopMusic()
    {
        musica.Stop();
    }
}
