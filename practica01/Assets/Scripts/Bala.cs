using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidadBala = -2;
    void Update()
    {
        MoverBala();
        if (transform.position.z >= 5f || transform.position.z <= -5f)
        {
            Destroy(gameObject);
        }
    }

    private void MoverBala()
    {
        transform.Translate(Vector3.forward * velocidadBala * Time.deltaTime);
    }
}
