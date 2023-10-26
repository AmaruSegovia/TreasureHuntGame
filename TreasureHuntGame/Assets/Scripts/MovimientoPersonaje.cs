using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spriteJugador;
    private float posColX = 1;
    private float posColY = 0;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteJugador = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Atacando");
        }
    }

    private void FixedUpdate()
    {
        Movimiento();
    }
    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.velocity = new Vector2 (horizontal, vertical) * velocidad;
        anim.SetFloat("Moviendose", Mathf.Abs(rig.velocity.magnitude));

        if(horizontal > 0)
        {
            colEspada.offset = new Vector2(posColX, posColY);
            spriteJugador.flipX = false;
        }
        else if (horizontal < 0)
        {
            colEspada.offset = new Vector2(-posColX, posColY);
            spriteJugador.flipX= true;
        }

    }

}
