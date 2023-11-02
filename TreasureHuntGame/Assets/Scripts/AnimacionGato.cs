using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionGato : MonoBehaviour
{
    [SerializeField] ControlTexto controlTexto;
    private Animator anim;
    private SpriteRenderer spriteJugador;
        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
            spriteJugador = GetComponentInChildren<SpriteRenderer>();
        }

    // Update is called once per frame
    private void Update()
    {
        if (controlTexto.verificarHablando == true)
        {
            anim.SetBool("GatoHablando", true);
        }
        else
        {
            anim.SetBool("GatoHablando", false);
        }
    }
}
