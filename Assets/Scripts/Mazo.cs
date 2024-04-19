using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mazo : MonoBehaviour
{
    public List<Carta> mazoCartas1 = new List<Carta>();
    public List<Carta> mazoCartasAux1 = new List<Carta>();
    public static List<Carta> staticMazoCartas1 = new List<Carta>();
    public static int mazoSize = 23;

    public GameObject cartaEnMazo1;
    public GameObject cartaEnMazo2;
    public GameObject cartaEnMazo3;
    public GameObject cartaEnMazo4;
    public GameObject cartaEnMazo5;

    public GameObject cartaAMano;
    public GameObject Mano;

    // Start is called before the first frame update
    void Start()
    {
        //Creando Mazo1
        mazoCartas1 = Enumerable.Concat(mazoCartas1,BDCartas.cartaAumentoList1).ToList();
        
        int[] aux = { 0, 1, 2, 3 };
        for(int i = 0; i < 4; i++)
        {
            int r = Random.Range(0, 3);
            (aux[i], aux[r]) = (aux[r], aux[i]);
        }
        for(int i=0;i<3;i++)
        {
            Carta cartaAux = BDCartas.cartaClimaList1[aux[i]];
            for(int j = 0; j < mazoCartasAux1.Count; j++)
            {
                if (mazoCartasAux1[j].filas == cartaAux.filas)
                {
                    cartaAux.filas = BDCartas.cartaClimaList1[aux[3]].filas;
                }
            }
            Debug.Log(cartaAux.filas);
            mazoCartasAux1.Add(cartaAux);
        }
        mazoCartas1 = Enumerable.Concat(mazoCartas1,mazoCartasAux1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1,BDCartas.cartaDespejeList1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1,BDCartas.cartaOroList1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1,BDCartas.cartaPlataList1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1,BDCartas.cartaSenueloList1).ToList();
        //Mezclando Mazo1
        for(int i=0;i<mazoSize;i++)
        {
            int r = Random.Range(0, 22);
            Debug.Log(mazoCartas1[i].nombre);
            Debug.Log(mazoCartas1[r].nombre);
            (mazoCartas1[i], mazoCartas1[r]) = (mazoCartas1[r], mazoCartas1[i]);
            Debug.Log(mazoCartas1[i].nombre);
            Debug.Log(mazoCartas1[r].nombre);
        }

        //Repartir Cartas
        StartCoroutine(ComenzarJuego());
    }

    // Update is called once per frame
    void Update()
    {
        staticMazoCartas1 = mazoCartas1;

        if (mazoSize < 20)
        {
            cartaEnMazo1.SetActive(false);
        }
        if (mazoSize < 15)
        {
            cartaEnMazo2.SetActive(false);
        }
        if (mazoSize < 10)
        {
            cartaEnMazo3.SetActive(false);
        }
        if (mazoSize < 5)
        {
            cartaEnMazo4.SetActive(false);
        }
        if (mazoSize == 0)
        {
            cartaEnMazo5.SetActive(false);
        }
    }
    IEnumerator ComenzarJuego()
    {
        for(int i = 0; i <10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            cartaAMano.tag = "Repartiendo";
            Instantiate(cartaAMano, transform.position, transform.rotation);
        }
    }

}
