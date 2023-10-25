using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] private float velocidad;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spriteJugador;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteJugador = GetComponentInChildren<SpriteRenderer>();
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
            spriteJugador.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteJugador.flipX= true;
        }

    }

}
