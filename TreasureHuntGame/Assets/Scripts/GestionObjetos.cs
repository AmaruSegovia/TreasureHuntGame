using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionObjetos : MonoBehaviour
{
    public enum ObjetosEquipables
    {
        SaludPeq,
        SaludMed,
        Velocidad
    };

    [SerializeField] ObjetosEquipables objetosEquipables;

    public void UsarObjeto()
    {
        MovimientoPersonaje personaje = GameObject.FindObjectOfType<MovimientoPersonaje>();

        switch(objetosEquipables)
        {
            case ObjetosEquipables.SaludPeq:
                personaje.SumaVida();
                Debug.Log("Cura 1 de salud");
                break;
            case ObjetosEquipables.SaludMed:
                Debug.Log("Cura 2 de salud");
                break;
            case ObjetosEquipables.Velocidad:
                Debug.Log("Da velocidad");
                break;
        }
        Destroy(this.gameObject);
    }
}
