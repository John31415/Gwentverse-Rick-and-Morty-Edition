using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mazo : MonoBehaviour
{
    public List<Carta> mazoCartas1 = new List<Carta>();
    public List<Carta> mazoCartasAux1 = new List<Carta>();
    public static List<Carta> staticMazoCartas1 = new List<Carta>();
    public static int mazoSize1 = 24;

    public List<Carta> mazoCartas2 = new List<Carta>();
    public List<Carta> mazoCartasAux2 = new List<Carta>();
    public static List<Carta> staticMazoCartas2 = new List<Carta>();
    public static int mazoSize2 = 24;

    public GameObject cartaEnMazo1;
    public GameObject cartaEnMazo2;
    public GameObject cartaEnMazo3;
    public GameObject cartaEnMazo4;
    public GameObject cartaEnMazo5;
    public GameObject cartaEnMazo12;
    public GameObject cartaEnMazo22;
    public GameObject cartaEnMazo32;
    public GameObject cartaEnMazo42;
    public GameObject cartaEnMazo52;

    public GameObject cartaAMano1;
    public GameObject cartaAMano2;

    public GameObject cartaLider1;
    public GameObject cartaLider2;

    // Start is called before the first frame update
    void Start()
    {
        mazoCartas1.Clear();
        mazoCartasAux1.Clear();
        mazoSize1 = 24;
        mazoCartas2.Clear();
        mazoCartasAux2.Clear();
        mazoSize2 = 24;

        //Creando Mazo1
        mazoCartas1 = Enumerable.Concat(mazoCartas1, BDCartas.cartaAumentoList1).ToList();

        int[] aux = { 0, 1, 2, 3 };
        for (int i = 0; i < 4; i++)
        {
            int r = Random.Range(0, 3);
            (aux[i], aux[r]) = (aux[r], aux[i]);
        }
        for (int i = 0; i < 3; i++)
        {
            Carta cartaAux = BDCartas.cartaClimaList1[aux[i]];
            for (int j = 0; j < mazoCartasAux1.Count; j++)
            {
                if (mazoCartasAux1[j].filas == cartaAux.filas)
                {
                    cartaAux.filas = BDCartas.cartaClimaList1[aux[3]].filas;
                }
            }
            mazoCartasAux1.Add(cartaAux);
        }
        mazoCartas1 = Enumerable.Concat(mazoCartas1, mazoCartasAux1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1, BDCartas.cartaDespejeList1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1, BDCartas.cartaOroList1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1, BDCartas.cartaPlataList1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1, BDCartas.cartaSenueloList1).ToList();

        //Creando Mazo2
        mazoCartas2 = Enumerable.Concat(mazoCartas2, BDCartas.cartaAumentoList2).ToList();
        for (int i = 0; i < 4; i++)
        {
            int r = Random.Range(0, 3);
            (aux[i], aux[r]) = (aux[r], aux[i]);
        }
        for (int i = 0; i < 3; i++)
        {
            Carta cartaAux = BDCartas.cartaClimaList2[aux[i]];
            for (int j = 0; j < mazoCartasAux2.Count; j++)
            {
                if (mazoCartasAux2[j].filas == cartaAux.filas)
                {
                    cartaAux.filas = BDCartas.cartaClimaList2[aux[3]].filas;
                }
            }
            mazoCartasAux2.Add(cartaAux);
        }
        mazoCartas2 = Enumerable.Concat(mazoCartas2, mazoCartasAux2).ToList();
        mazoCartas2 = Enumerable.Concat(mazoCartas2, BDCartas.cartaDespejeList2).ToList();
        mazoCartas2 = Enumerable.Concat(mazoCartas2, BDCartas.cartaOroList2).ToList();
        mazoCartas2 = Enumerable.Concat(mazoCartas2, BDCartas.cartaPlataList2).ToList();
        mazoCartas2 = Enumerable.Concat(mazoCartas2, BDCartas.cartaSenueloList2).ToList();

        //Mezclando Mazo1
        for (int i = 0; i < mazoSize1 - 1; i++)
        {
            int r = Random.Range(0, 23);
            (mazoCartas1[i], mazoCartas1[r]) = (mazoCartas1[r], mazoCartas1[i]);
        }

        mazoCartas1 = Enumerable.Concat(mazoCartas1, BDCartas.cartaOdin1).ToList();
        mazoCartas1 = Enumerable.Concat(mazoCartas1, BDCartas.cartaLiderList1).ToList();
        mazoSize1 += BDCartas.cartaOdin1.Count;

        //Mezclando Mazo2
        for (int i = 0; i < mazoSize2 - 16; i++)
        {
            int r = Random.Range(0, 23);
            (mazoCartas2[i], mazoCartas2[r]) = (mazoCartas2[r], mazoCartas2[i]);
        }

        mazoCartas2 = Enumerable.Concat(mazoCartas2, BDCartas.cartaOdin2).ToList();
        mazoCartas2 = Enumerable.Concat(mazoCartas2, BDCartas.cartaLiderList2).ToList();
        mazoSize2 += BDCartas.cartaOdin2.Count;

        //Repartir Cartas
        StartCoroutine(ComenzarJuego());
    }

    // Update is called once per frame
    void Update()
    {
        staticMazoCartas1 = mazoCartas1;
        staticMazoCartas2 = mazoCartas2;

        if (mazoSize1 < 20)
        {
            cartaEnMazo1.SetActive(false);
        }
        if (mazoSize1 < 15)
        {
            cartaEnMazo2.SetActive(false);
        }
        if (mazoSize1 < 10)
        {
            cartaEnMazo3.SetActive(false);
        }
        if (mazoSize1 < 5)
        {
            cartaEnMazo4.SetActive(false);
        }
        if (mazoSize1 == 0)
        {
            cartaEnMazo5.SetActive(false);
        }

        if (mazoSize2 < 20)
        {
            cartaEnMazo12.SetActive(false);
        }
        if (mazoSize2 < 15)
        {
            cartaEnMazo22.SetActive(false);
        }
        if (mazoSize2 < 10)
        {
            cartaEnMazo32.SetActive(false);
        }
        if (mazoSize2 < 5)
        {
            cartaEnMazo42.SetActive(false);
        }
        if (mazoSize2 == 0)
        {
            cartaEnMazo52.SetActive(false);
        }
    }

    IEnumerator ComenzarJuego()
    {
        yield return new WaitForSeconds(0.4f);
        cartaLider1.tag = "Repartiendo1";
        cartaLider2.tag = "Repartiendo2";
        Instantiate(cartaLider1, transform.position, transform.rotation);
        Instantiate(cartaLider2, transform.position, transform.rotation);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            cartaAMano1.tag = "Repartiendo1";
            cartaAMano2.tag = "Repartiendo2";
            Instantiate(cartaAMano1, transform.position, transform.rotation);
            Instantiate(cartaAMano2, transform.position, transform.rotation);
        }
        Controlador.aux = true;
    }
}