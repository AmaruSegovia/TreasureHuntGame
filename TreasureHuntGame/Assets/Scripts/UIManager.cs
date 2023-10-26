using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int totalMonedas;
    [SerializeField] private TMP_Text textoCantidadMonedas;
    // Start is called before the first frame update
    private void Start()
    {
        Moneda.sumaMoneda += SumarMonedas;
    }

    private void SumarMonedas(int moneda)
    {
        totalMonedas += moneda;
        textoCantidadMonedas.text = totalMonedas.ToString();
    }

}
