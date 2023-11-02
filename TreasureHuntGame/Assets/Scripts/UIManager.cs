using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int totalMonedas;
    private int totalObjetos;
    private int precioObjeto;

    [SerializeField] private TMP_Text textoCantidadMonedas;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado, corazonActivado;
    [SerializeField] private GameObject cajaTexto;
    [SerializeField] private TMP_Text textoDialogo;

    [SerializeField] private GameObject panelEquipo;

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

    public void RestaCorazones (int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }
    public void SumaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonActivado;
    }

    public void ActivaDesactivaCajaTextos (bool activado)
    {
        cajaTexto.SetActive (activado);
    }
    public void MostrarTextos (string texto)
    {
        textoDialogo.text = texto.ToString();
    }

    public void PrecioObjeto(string objeto)
    {
        switch(objeto)
        {
            case "PocionPeq":
                precioObjeto = 1;
                break;
            default:
                Debug.LogError("Nombre de objeto desconocido: " + objeto);
                break;
        }
    }

    public void AdquirirObjeto (string objeto)
    {
        PrecioObjeto(objeto);

        if(precioObjeto <= totalMonedas && totalObjetos <3)
        {
            totalObjetos++;
            totalMonedas -= precioObjeto;
            textoCantidadMonedas.text = totalMonedas.ToString();

            Debug.Log("Adquiriendo objeto: " + (objeto) + ", Precio: " + precioObjeto);
            Debug.Log("Precio del objeto: " + precioObjeto);
            Debug.Log("Total de monedas: " + totalMonedas);
            GameObject equipo = (GameObject)Resources.Load (objeto);
            Instantiate(equipo, Vector3.zero, Quaternion.identity, panelEquipo.transform);
        }
    }
}
