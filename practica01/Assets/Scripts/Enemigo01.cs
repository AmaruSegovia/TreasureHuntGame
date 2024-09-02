using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemigo01 : MonoBehaviour
{
    [SerializeField]
    private GameObject balaEnemigo;
    [SerializeField]
    private float velocidadX = -1f;
    [SerializeField]
    private float velocidadZ = -1f;
    [SerializeField]
    private int tipoEnemigo;
    private float tiempoRandom = 0;

    private void Start()
    {

        switch(tipoEnemigo)
        {
            case 1:
                {
                    InvokeRepeating("BalaEnemigo", 0, 2f);
                    break;
                }
            case 2:
                {
                    Invoke("BalaEnemigo", tiempoRandom);
                    break;
                }
        }
    }

    void Update()
    {
        switch (tipoEnemigo)
        {
            case 1:
                {
                    transform.Translate(velocidadX * Time.deltaTime, 0, velocidadZ * Time.deltaTime);
                    if (transform.position.z >= 5f || transform.position.z <= -5f)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
            case 2:
                {
                    if(transform.position.x < -1.5f || transform.position.x > 7.5f)
                    {
                        velocidadX *= -1;
                    }
                    transform.Translate(velocidadX * Time.deltaTime, 0, 0);
                    break;
                }
        }

        
    }

    public void BalaEnemigo()
    {
        Instantiate(balaEnemigo, transform.position, transform.rotation);

        // Verificar si el enemigo está fuera de los límites y destruirlo
        if (tipoEnemigo == 1 && (transform.position.x < -1.5f || transform.position.x > 7.5f))
        {
            Destroy(gameObject);
        }

        // Si tipoEnemigo es igual a 2, configura el próximo tiempo de invocación
        if (tipoEnemigo == 2)
        {
            tiempoRandom = Random.Range(1, 3);
            Invoke("BalaEnemigo", tiempoRandom);
        }
    }


}
