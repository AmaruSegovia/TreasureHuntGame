using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
public class Orco : MonoBehaviour
{
    public Transform personaje;
    private NavMeshAgent agente;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agente.SetDestination(personaje.position);
    }
}
