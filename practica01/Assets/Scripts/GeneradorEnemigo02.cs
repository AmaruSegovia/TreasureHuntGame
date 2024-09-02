using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigo02 : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemigo02; 
    [SerializeField]
    private float iniciarTiempo = 1;
    [SerializeField]
    private float velocidad = 2;

    private int enemigosGenerados = 0; 
    private bool generacionHabilitada = true;

    void Start()
    {
        InvokeRepeating("GenerarEnemigo", iniciarTiempo, 1f);
    }

    void Update()
    {
        transform.Translate(0, 0, velocidad * Time.deltaTime);
        RebotarGenerador();
        if (enemigosGenerados >= 5)
        {
            generacionHabilitada = false;
        }
    }
    public void GenerarEnemigo()
    {
        if (generacionHabilitada)
        {
            Instantiate(Enemigo02, transform.position, transform.rotation);
            enemigosGenerados++; 
        }
    }

    private void RebotarGenerador()
    {
        float nuevaPosicionZ = transform.position.z + velocidad * Time.deltaTime;

        if (nuevaPosicionZ >= 4f || nuevaPosicionZ <= -3f)
        {
            velocidad *= -1;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, nuevaPosicionZ);
    }
}