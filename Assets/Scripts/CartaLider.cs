using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaLider : MonoBehaviour
{
    public GameObject mazo;
    public GameObject esto;
    public List<Carta> estaCarta = new List<Carta>();

    public GameObject cartaAMano;

    public static bool markRobarCarta;

    // Start is called before the first frame update
    void Start()
    {
        estaCarta.Clear();
        estaCarta.Add(esto.GetComponent<EstaCarta>().estaCarta[0]);
        markRobarCarta = false;
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
    }

    public void RobarCarta()
    {
        if(markRobarCarta || Controlador.numeroRonda == 1)
        {
            return;
        }
        markRobarCarta = true;
        StartCoroutine(Robo(this.GetComponent<EstaCarta>().estaCarta[0].faccion));
    }

    IEnumerator Robo(int faccion)
    {
        yield return new WaitForSeconds(0.3f);
        cartaAMano.tag = "Repartiendo" + faccion.ToString();
        Instantiate(cartaAMano, transform.position, transform.rotation);
    }
}