using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EstaCarta : MonoBehaviour
{
    public List<Carta> estaCarta = new List<Carta>();
    public int esteId;

    public Image imagenSprite;

    public GameObject Mano1;
    public int numeroCartasMazo1;
    public int numeroCartasMazo2;

    public bool auxFinJuego = false;
    public static int c1 = 0;
    public static int c2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        estaCarta[0] = BDCartas.cartasTodas[esteId];
        numeroCartasMazo1 = Mazo.mazoSize1;
        numeroCartasMazo2 = Mazo.mazoSize2;

        if (auxFinJuego)
        {
            if (estaCarta[0].id == 17)
            {
                estaCarta[0].filas = "M";
            }
            if(estaCarta[0].id == 26)
            {
                estaCarta[0].filas = "R";
            }
            if (estaCarta[0].nombre == "Furp Rock")
            {
                estaCarta[0].tipoId = 2;
                estaCarta[0].filas = "S";
            }
            if (estaCarta[0].tipoId == 1)
            {
                string[] filas = { "M", "R", "S" };
                if (estaCarta[0].faccion == 1)
                {
                    estaCarta[0].filas = filas[c1];
                    c1++;
                }
                else
                {
                    estaCarta[0].filas = filas[c2];
                    c2++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Repartiendo1")
        {
            estaCarta[0] = Mazo.staticMazoCartas1[numeroCartasMazo1 - 1];
            numeroCartasMazo1--;
            Mazo.mazoSize1--;
            this.tag = "Untagged";
        }
        if (this.tag == "Repartiendo2")
        {
            estaCarta[0] = Mazo.staticMazoCartas2[numeroCartasMazo2 - 1];
            numeroCartasMazo2--;
            Mazo.mazoSize2--;
            this.tag = "Untagged";
        }
        imagenSprite.sprite = estaCarta[0].spriteImagen;
    }

}