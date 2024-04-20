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

    public bool dorsoCarta;
    public static bool staticDorsoCarta;

    public GameObject Mano1;
    public int numeroCartasMazo1;
    public int numeroCartasMazo2;

    // Start is called before the first frame update
    void Start()
    {
        estaCarta[0] = BDCartas.cartasTodas[esteId];
        numeroCartasMazo1 = Mazo.mazoSize1;
        numeroCartasMazo2 = Mazo.mazoSize2;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Repartiendo1")
        {
            estaCarta[0] = Mazo.staticMazoCartas1[numeroCartasMazo1 - 1];
            numeroCartasMazo1--;
            Mazo.mazoSize1--;
            dorsoCarta = false;
            this.tag = "Untagged";
        }
        if (this.tag == "Repartiendo2")
        {
            estaCarta[0] = Mazo.staticMazoCartas2[numeroCartasMazo2 - 1];
            numeroCartasMazo2--;
            Mazo.mazoSize2--;
            dorsoCarta = false;
            this.tag = "Untagged";
        }
        imagenSprite.sprite = estaCarta[0].spriteImagen;

        staticDorsoCarta = dorsoCarta;

    }

}