using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    private BoxCollider2D colEspada;
    [SerializeField] private AudioClip[] sonidosMuerteOrco;

    private void Awake()
    {
     
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Orco"))
        {
            // Selecciona un sonido aleatorio de la matriz
            AudioClip sonidoAleatorio = sonidosMuerteOrco[Random.Range(0, sonidosMuerteOrco.Length)];

            ControladorSonidos.Instance.EjecutarSonido(sonidoAleatorio);
            Destroy(otro.gameObject);
        }
    }
}
