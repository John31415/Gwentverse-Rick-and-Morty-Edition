using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaLider : MonoBehaviour
{
    public GameObject mazo;
    public GameObject esto;
    public List<Carta> estaCarta = new List<Carta>();

    // Start is called before the first frame update
    void Start()
    {
        estaCarta.Clear();
        estaCarta.Add(esto.GetComponent<EstaCarta>().estaCarta[0]);
    }

    // Update is called once per frame
    void Update()
    {
        string cad = "Lider";
        if (estaCarta[0].faccion == 1) cad += "1";
        else cad += "2";
        mazo = GameObject.Find(cad);
        esto.transform.SetParent(mazo.transform);
    }
}
