using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaAMano : MonoBehaviour
{
    public GameObject mazo;
    public GameObject esto;

    // Update is called once per frame
    void Update()
    {
        string cad = "PanelHand";
        if (esto.tag == "Untagged")
        {
            if (esto.GetComponent<EstaCarta>().estaCarta[0].faccion == 1) cad += "1";
            else cad += "2";
        }
        else
        {
            if (esto.tag == "Repartiendo1") cad += "1";
            else cad += "2";
        }
        mazo = GameObject.Find(cad);
        esto.transform.SetParent(mazo.transform);
        esto.transform.localScale = Vector3.one;
        esto.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        esto.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}