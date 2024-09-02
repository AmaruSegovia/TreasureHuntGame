using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private float velocidad =10;
    [SerializeField] private GameObject bala;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, transform.position, transform.rotation);
        }
    }
}
