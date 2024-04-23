using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robar2 : MonoBehaviour
{
    public static bool robado = false;
    public static int cantidadCartasRobadas1 = 0;
    public static int cantidadCartasRobadas2 = 0;

    public void Robo() 
    {
        int faccion = this.transform.parent.gameObject.GetComponent<EstaCarta>().estaCarta[0].faccion;
        GameObject panel = GameObject.Find("PanelHand" + faccion.ToString());
        int numeroCartasMazo = Mazo.mazoSize1;
        int cantidadCartasRobadas = cantidadCartasRobadas1;
        if (faccion == 2)
        {
            numeroCartasMazo = Mazo.mazoSize2;
            cantidadCartasRobadas = cantidadCartasRobadas2;
        }
        if(Controlador.numeroRonda == 1 && cantidadCartasRobadas < 2 && panel.transform.childCount == 10 && numeroCartasMazo == 13)
        {
            if (faccion == 1)
            {
                this.transform.parent.gameObject.GetComponent<EstaCarta>().estaCarta[0] = Mazo.staticMazoCartas1[Mazo.mazoSize1 - 1];
                (Mazo.staticMazoCartas1[Mazo.mazoSize1 - 1], Mazo.staticMazoCartas1[cantidadCartasRobadas]) = (Mazo.staticMazoCartas1[cantidadCartasRobadas], Mazo.staticMazoCartas1[Mazo.mazoSize1 - 1]);
                cantidadCartasRobadas1++;
            }
            else
            {
                this.transform.parent.gameObject.GetComponent<EstaCarta>().estaCarta[0] = Mazo.staticMazoCartas2[Mazo.mazoSize2 - 1];
                (Mazo.staticMazoCartas2[Mazo.mazoSize2 - 1], Mazo.staticMazoCartas2[cantidadCartasRobadas]) = (Mazo.staticMazoCartas2[cantidadCartasRobadas], Mazo.staticMazoCartas2[Mazo.mazoSize2 - 1]);
                cantidadCartasRobadas2++;
            }
            robado = true;
            StartCoroutine(Auxiliar());
        }
    }
    IEnumerator Auxiliar()
    {
        yield return new WaitForSeconds(1f);
        robado = false;
    }
}
