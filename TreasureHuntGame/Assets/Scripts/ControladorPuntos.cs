using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    // Start is called before the first frame update
    public static ControladorPuntos Instance;
    [SerializeField] private float cantidadPuntos;

    private void Awake() //se ejecuta antes de cualquier elemento del juego
    {
        if(ControladorPuntos.Instance == null)
        {
            ControladorPuntos.Instance = this;
            DontDestroyOnLoad(this.gameObject); //No se destruya el objeto en la siguient escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(float puntos)
    {
        cantidadPuntos += puntos;
    }
}
