using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaLider : MonoBehaviour
{
    public GameObject mazo;
    public GameObject esto;
    public List<Carta> estaCarta = new List<Carta>();

    public GameObject cartaAMano;

    public static bool markRobarCarta1;
    public static bool markRobarCarta2;

    // Start is called before the first frame update
    void Start()
    {
        estaCarta.Clear();
        estaCarta.Add(esto.GetComponent<EstaCarta>().estaCarta[0]);
        markRobarCarta1 = false;
        markRobarCarta2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        string cad = "Lider";
        if(esto.tag == "Untagged")
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
        esto.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        esto.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        esto.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void RobarCarta()
    {
        int faccion = this.GetComponent<EstaCarta>().estaCarta[0].faccion;
        if (GameObject.Find("PanelHand" + faccion.ToString()).transform.childCount == 10)
        {
            return;
        }
        bool markRobarCarta = markRobarCarta1;
        if (faccion == 2) markRobarCarta = markRobarCarta2;
        if (!markRobarCarta && Controlador.numeroRonda != 1)
        {
            if (faccion == 1) markRobarCarta1 = true;
            else markRobarCarta2 = true;
            StartCoroutine(Robo(faccion));
        }
    }

    IEnumerator Robo(int faccion)
    {
        yield return new WaitForSeconds(0.3f);
        cartaAMano.tag = "Repartiendo" + faccion.ToString();
        Instantiate(cartaAMano, transform.position, transform.rotation);
        SistemaTurnos.turno = SistemaTurnos.turno % 2 + 1;
    }
}