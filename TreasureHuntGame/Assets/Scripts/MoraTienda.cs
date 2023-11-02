using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraTienda : MonoBehaviour
{
    [SerializeField] private GameObject tienda;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tienda.SetActive(true);
    }

}
