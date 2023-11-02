using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTexto : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string [] arrayTextos;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private MovimientoPersonaje jugador;
    private int indice;
    public bool verificarHablando;

    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").GetComponent<MovimientoPersonaje>();
    }

    private void OnMouseDown()
    {
        float distancia = Vector2.Distance(this.gameObject.transform.position, jugador.transform.position); 
        if (distancia <= 3)
        {
            uIManager.ActivaDesactivaCajaTextos(true);
            jugador.VerificarHablando(true);
            ActivaCartel();
        }
    }
    void ActivaCartel()
    {
        if (indice < arrayTextos.Length)
        {
            uIManager.MostrarTextos(arrayTextos[indice]);
            indice++;
            verificarHablando = true;
        }
        else
        {
            uIManager.ActivaDesactivaCajaTextos(false);
            jugador.VerificarHablando(false);
            verificarHablando = false;
        }
    }

}



