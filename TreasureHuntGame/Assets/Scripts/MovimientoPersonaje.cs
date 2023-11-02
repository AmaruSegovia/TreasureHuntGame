using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;
    [SerializeField] UIManager uIManager;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spriteJugador;
    private float posColX = 1;
    private float posColY = 0;
    private int vidaJugador = 3;
    private bool jugadorHablando;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteJugador = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && jugadorHablando == false)
        {
            anim.SetTrigger("Atacando");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            HerirPersonaje();
        }
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    public void VerificarHablando (bool hablando)
    {
        jugadorHablando = hablando;
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (jugadorHablando)
        {
            rig.velocity = Vector2.zero; // Detener completamente el movimiento
        }
        else
        {
            rig.velocity = new Vector2(horizontal, vertical) * velocidad;
            anim.SetFloat("Moviendose", Mathf.Abs(rig.velocity.magnitude));
        }

        if (horizontal > 0)
        {
            colEspada.offset = new Vector2(posColX, posColY);
            spriteJugador.flipX = false;
        }
        else if (horizontal < 0)
        {
            colEspada.offset = new Vector2(-posColX, posColY);
            spriteJugador.flipX = true;
        }

    }

    public void HerirPersonaje()
    {
        if (vidaJugador > 0)
        {
            vidaJugador--;
            uIManager.RestaCorazones(vidaJugador);
            if (vidaJugador == 0)
            {
                anim.SetTrigger("Muriendose");
                Invoke(nameof(Morir), 1f);
                Debug.Log("Jugador Muerto");
            }
        }
    }

    public void SumaVida()
    {
        if (vidaJugador < 3)
        {
            uIManager.SumaCorazones(vidaJugador);
            vidaJugador++;
        }
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }

}
