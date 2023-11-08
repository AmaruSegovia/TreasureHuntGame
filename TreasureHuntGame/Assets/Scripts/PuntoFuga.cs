using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Moneda;

public class PuntoFuga : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Jugador") && SceneManager.GetActiveScene().name == "Escena1")
        {
            SceneManager.LoadScene("Escena2");   
        }
        if (collision.gameObject.CompareTag("Jugador") && SceneManager.GetActiveScene().name == "Escena2")
        {
            SceneManager.LoadScene("FinalBueno");
        }
    }

}
