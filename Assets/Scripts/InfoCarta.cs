using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

using Odin;

public class InfoCarta : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject panelHover;

    // Start is called before the first frame update
    void Start()
    {
        panelHover = GameObject.Find("Controlador").GetComponent<Controlador>().panelHover;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int tipoId;
        int poder;
        string fila;
        string descripcion;
        panelHover.SetActive(true);
        if(transform.parent.transform.name == "CartaAMover(Clone)")
        {
            tipoId = transform.parent.transform.GetComponent<EstaCarta>().estaCarta[0].tipoId;
            poder = transform.parent.transform.GetComponent<EstaCarta>().estaCarta[0].poder;
            fila = transform.parent.transform.GetComponent<EstaCarta>().estaCarta[0].filas;
            descripcion = transform.parent.transform.GetComponent<EstaCarta>().estaCarta[0].descripcion;
        }
        else
        {
            tipoId = transform.GetComponent<EstaCarta>().estaCarta[0].tipoId;
            poder = transform.GetComponent<EstaCarta>().estaCarta[0].poder;
            fila = transform.GetComponent<EstaCarta>().estaCarta[0].filas;
            descripcion = transform.GetComponent<EstaCarta>().estaCarta[0].descripcion;
        }
        string cad = "#Tipo: ";
        if (tipoId == 0) cad += "\"Aumento\"";
        if (tipoId == 1) cad += "\"Clima\"";
        if (tipoId == 2) cad += "\"Despeje\"";
        if (tipoId == 3) cad += "\"Lider\"";
        if (tipoId == 4) cad += "\"Oro\"";
        if (tipoId == 5) cad += "\"Plata\"";
        if (tipoId == 6) cad += "\"Senuelo\"";
        cad += "\n#Poder: \"";
        if (poder > 0) cad += poder.ToString();
        cad += "\"\n#Fila: \"" + fila + "\"\n<" + descripcion + ">";
        panelHover.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = cad;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelHover.SetActive(false);
    }
}
