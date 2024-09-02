using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigo01 : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemigo01;
    [SerializeField]
    private float iniciarTiempo;
    [SerializeField]
    private float repetirTiempo;

    void Start()
    {
        InvokeRepeating("GenerarEnemigo", iniciarTiempo, repetirTiempo);
    }

    public void GenerarEnemigo()
    {
            Instantiate(Enemigo01, transform.position, transform.rotation);
    }
}
