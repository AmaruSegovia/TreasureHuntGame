using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrcoScript : MonoBehaviour
{
    public Transform jugador;
    public Transform[] puntosPatrullaje;
    private int indicePatrullaje;
    private NavMeshAgent agente;
    private bool jugadorDetectado;
    [SerializeField] public MovimientoPersonaje movimientoPersonaje;
    [SerializeField] AudioClip sonidoMordida;

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
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);


        if (jugador != null)
        {
            float distancia = Vector3.Distance(jugador.position, this.transform.position);

            if (puntosPatrullaje.Length > 0 && puntosPatrullaje[indicePatrullaje] != null)
            {
                if (Vector3.Distance(this.transform.position, puntosPatrullaje[indicePatrullaje].position) < 0.1f)
                {
                    if (indicePatrullaje < puntosPatrullaje.Length - 1)
                    {
                        indicePatrullaje++;
                    }
                    else
                    {
                        indicePatrullaje = 0;
                    }
                }
            }

            if (distancia < 4)
            {
                jugadorDetectado = true;
            }
            else
            {
                jugadorDetectado = false;
            }

            MovimientoOrco(jugadorDetectado);
        }
    }

    void MovimientoOrco(bool detectado)
    {
        if (detectado && jugador != null)
        {
            agente.SetDestination(jugador.position);
        }
        else if (puntosPatrullaje.Length > 0 && puntosPatrullaje[indicePatrullaje] != null)
        {
            agente.SetDestination(puntosPatrullaje[indicePatrullaje].position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            ControladorSonidos.Instance.EjecutarSonido(sonidoMordida);
            movimientoPersonaje.HerirPersonaje();
        }
    }
}
