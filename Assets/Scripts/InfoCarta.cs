using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InfoCarta : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panelHover;

    // Start is called before the first frame update
    void Start()
    {
        panelHover = GameObject.Find("InfoCarta");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        panelHover.SetActive(true);
        int tipoId = this.GetComponent<EstaCarta>().estaCarta[0].tipoId;
        int poder = this.GetComponent<EstaCarta>().estaCarta[0].poder;
        string fila = this.GetComponent<EstaCarta>().estaCarta[0].filas;
        string descripcion = this.GetComponent<EstaCarta>().estaCarta[0].descripcion;
        string cad = "#Tipo: ";
        if (tipoId == 0) cad += "\"Aumento\"";
        if (tipoId == 1) cad += "\"Clima\"";
        if (tipoId == 2) cad += "\"Despeje\"";
        if (tipoId == 3) cad += "\"Lider\"";
        if (tipoId == 4) cad += "\"Oro\"";
        if (tipoId == 5) cad += "\"Plata\"";
        if (tipoId == 6) cad += "\"Senuelo\"";
        cad += "\n#Poder: \"" + poder.ToString() + "\"\n#Fila: \"" + fila + "\"\n<" + descripcion + ">";
        panelHover.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = cad;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelHover.SetActive(false);
    }
}
