using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproductor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("musica").GetComponent<ControladorMusica>().PlayMusic();
    }
}
