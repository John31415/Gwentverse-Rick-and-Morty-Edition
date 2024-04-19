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
        mazo = GameObject.Find("PanelHand1");
        esto.transform.SetParent(mazo.transform);
        esto.transform.localScale = Vector3.one;
        esto.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        esto.transform.eulerAngles = new Vector3(0,0,0);
    }
}
