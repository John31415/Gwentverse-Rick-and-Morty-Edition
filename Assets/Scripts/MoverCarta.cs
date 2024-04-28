using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCarta : MonoBehaviour
{
    public GameObject cartaAMover;
    public GameObject cartaHand;

    public void MoverLaCarta()
    {
        if (!Robar2.robado)
        {
            int val = cartaHand.GetComponent<EstaCarta>().estaCarta[0].id;
            for (int i = 0; i < BDCartas.cartasTodas.Count; i++)
            {
                if (BDCartas.cartasTodas[i].id == val)
                {
                    cartaAMover.GetComponent<EstaCarta>().esteId = i;
                    break;
                }
            }
            GameObject.Find("Controlador").GetComponent<Controlador>().panelHover.SetActive(false);
            Instantiate(cartaAMover);
            Destroy(cartaHand);
        }
    }
}