using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
public class OrcoScript : MonoBehaviour
{
    public Transform jugador;
    public Transform [] puntosPatrullaje;
    private int indicePatrullaje;
    private NavMeshAgent agente;
    private bool jugadorDetectado;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }


    private void Update()
    {
        this.transform.position = new Vector3 (transform.position.x,transform.position.y,0);
        float distancia = Vector3.Distance(jugador.position,this.transform.position);
        if(this.transform.position == puntosPatrullaje[indicePatrullaje].position)
        {
            if (indicePatrullaje < puntosPatrullaje.Length - 1)
            {
                indicePatrullaje++;
            }
            else if (indicePatrullaje == puntosPatrullaje.Length - 1)
            {
                indicePatrullaje = 0;
            }
        }

        if (distancia < 3)
        {
            jugadorDetectado = true;
        }
        MovimientoOrco(jugadorDetectado);
    }

    void MovimientoOrco(bool detectado)
    {
        if (detectado)
        {
            agente.SetDestination(jugador.position);
        }
        else
        {
            agente.SetDestination(puntosPatrullaje[indicePatrullaje].position);
        }
    }
}
