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
    public int numeroCartasMazo;

    // Start is called before the first frame update
    void Start()
    {
        estaCarta[0] = BDCartas.cartasTodas[esteId];
        numeroCartasMazo = Mazo.mazoSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Repartiendo")
        {
            estaCarta[0] = Mazo.staticMazoCartas1[numeroCartasMazo - 1];
            numeroCartasMazo--;
            Mazo.mazoSize--;
            dorsoCarta = false;
            this.tag = "Untagged";
        }
        imagenSprite.sprite = estaCarta[0].spriteImagen;

        staticDorsoCarta = dorsoCarta;

    }

}
