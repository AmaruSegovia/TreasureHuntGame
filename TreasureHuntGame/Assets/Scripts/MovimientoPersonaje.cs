using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Moneda;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D colEspada;
    [SerializeField] private BoxCollider2D colEspada2;
    [SerializeField] UIManager uIManager;
    [SerializeField] private GameObject Orco;
    [SerializeField] private AudioClip sonidoMuerte;
    [SerializeField] private AudioClip sonidoTrabalenguas;
    public DatosEscenas datosEscenas;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spriteJugador;
    private float posColX = 1;
    private float posColY = 0;
    private float posColXX = 0;
    private float posColYY = 0.5f;
    private bool jugadorHablando;
    private bool ataqueArriba;
    public CambiarEscenas cambiarescenas;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spriteJugador = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Escena1")
        {
            datosEscenas.vidas = 3;
        }

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !jugadorHablando)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Ataque horizontal
            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                if (horizontal > 0)
                {
                    spriteJugador.flipX = false;
                }
                else if (horizontal < 0)
                {
                    spriteJugador.flipX = true;
                }

                anim.SetTrigger("Atacando");
            }
            // Ataque vertical
            else if (vertical > 0)
            {
                anim.SetTrigger("AtacandoArriba");
                colEspada2.offset = new Vector2(posColXX, posColYY);
            }
            else if (vertical < 0)
            {
                // Voltear temporalmente al personaje solo para el ataque hacia abajo
                spriteJugador.flipY = true;
                anim.SetTrigger("AtacandoArriba"); // Atacando hacia abajo
                StartCoroutine(RevertirAnimacionAtaque());
                colEspada2.offset = new Vector2(posColXX, -posColYY);
            }
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

    public void VerificarHablando(bool hablando)
    {
        jugadorHablando = hablando;
        ControladorSonidos.Instance.EjecutarSonido(sonidoTrabalenguas);
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (jugadorHablando)
        {
            rig.velocity = Vector2.zero;
        }
        else
        {
            rig.velocity = new Vector2(horizontal, vertical) * velocidad;
            anim.SetFloat("Moviendose", rig.velocity.magnitude);
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

    private IEnumerator RevertirAnimacionAtaque()
    {
        yield return new WaitForSeconds(0.5f); 
        spriteJugador.flipY = false;
    }

    public void HerirPersonaje()
    {
        if (datosEscenas.vidas > 0)
        {
            datosEscenas.vidas--;
            uIManager.RestaCorazones(datosEscenas.vidas);

            Debug.Log(datosEscenas.vidas);
            if (datosEscenas.vidas == 0)
            {
                ControladorSonidos.Instance.EjecutarSonido(sonidoMuerte);
                anim.SetTrigger("Muriendose");
                Invoke(nameof(Morir), 1f);
                Debug.Log("Jugador Muerto");
                cambiarescenas.LoadScene("FinalMalo");
            }
        }
    }

    public void SumaVida()
    {
        if (datosEscenas.vidas < 3)
        {
            uIManager.SumaCorazones(datosEscenas.vidas);

            datosEscenas.vidas++;
        }
    }

    public void SumaVelocidad()
    {
        velocidad = 4;
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }

}
