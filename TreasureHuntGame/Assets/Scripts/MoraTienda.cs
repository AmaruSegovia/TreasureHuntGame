using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraTienda : MonoBehaviour
{
    [SerializeField] private GameObject tienda;
    [SerializeField] private AudioClip sonidoMora;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tienda.SetActive(true);
        ControladorSonidos.Instance.EjecutarSonido(sonidoMora);
    }

}
