using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaAMover : MonoBehaviour
{
    public GameObject mazo;
    public GameObject esto;
    public List<Carta> estaCarta = new List<Carta>();

    // Start is called before the first frame update
    void Start()
    {
        estaCarta.Add(esto.GetComponent<EstaCarta>().estaCarta[0]);
    }

    // Update is called once per frame
    void Update()
    {
        string cad = "";
        if (estaCarta[0].tipoId == 0) cad += "Aumento";
        else if (estaCarta[0].tipoId == 1) cad += "Clima";
        else cad += "Fila";
        cad += estaCarta[0].filas;
        if (estaCarta[0].faccion == 1) cad += "1";
        else cad += "2";
        mazo = GameObject.Find(cad);
        if(mazo != null)
        {
            Debug.Log(esto.GetComponent<EstaCarta>().estaCarta[0].nombre);
            Debug.Log(mazo.transform);
            esto.transform.SetParent(mazo.transform);
            esto.transform.localScale = Vector3.one;
            esto.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            esto.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
