using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
 
public class Controlador : MonoBehaviour
{
    public GameObject cartaARIP;
    public GameObject cartaAMano1;
    public GameObject cartaAMano2; 
    public GameObject cartaAMover;
    public GameObject bigPanel;
    public GameObject regresarAMenu;
    public GameObject panelHover;

    public static bool jugadorActivo1;
    public static bool jugadorActivo2;
    public TMP_Text Ganador;

    public static bool aux;

    public int victorias1;
    public int victorias2;

    public static int numeroRonda;

    public bool bandDestructorAux;

    public bool band1;
    public bool band2;
    public bool band3;
    public bool band4;

    // Start is called before the first frame update
    void Start()
    {
        jugadorActivo1 = true;
        jugadorActivo2 = true;
        aux = false;
        victorias1 = 0;
        victorias2 = 0;
        numeroRonda = 1;
        bandDestructorAux = false;
        band1 = false;
        band2 = false;
        band3 = false;
        band4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!band4 && (victorias1 == 6 || victorias2 == 6 || numeroRonda == 4))
        {
            numeroRonda = 4;
            StartCoroutine(GanadorJuego());
            band4 = true;
        }
        if(numeroRonda == 1 && !band1)
        {
            if (aux) StartCoroutine(Verificar());
            if (!jugadorActivo1 && !jugadorActivo2)
            {
                Cementerio();
                StartCoroutine(GanadorRonda());
                aux = false;
                StartCoroutine(ComenzarRonda2_3());
                band1 = true;
            }
        }
        if(numeroRonda == 2 && !band2)
        {
            if (aux) StartCoroutine(Verificar());
            if (!jugadorActivo1 && !jugadorActivo2)
            {
                Cementerio();
                StartCoroutine(GanadorRonda());
                aux = false;
                StartCoroutine(ComenzarRonda2_3());
                band2 = true;
            }
        }
        if(numeroRonda == 3 && !band3)
        {
            if (aux) StartCoroutine(Verificar());
            if (!jugadorActivo1 && !jugadorActivo2)
            {
                Cementerio();
                StartCoroutine(GanadorRonda());
                numeroRonda++;
                band3 = true;
            }
        }
    }

    public void VolverAMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator GanadorJuego()
    {
        yield return new WaitForSeconds(3);
        bigPanel.SetActive(true);
        string cad = "EL GANADOR DE LA PARTIDA ES ";
        if (victorias1 == victorias2)
        {
            cad = "LA PARTIDA HA TERMINADO EN EMPATE";
        }
        else if (victorias1 > victorias2)
        {
            cad += "RICK";
        }
        else
        {
            cad += "MORTY";
        }
        Puntos.puntos1 = 0;
        Puntos.puntos2 = 0;
        DestruirTodo();
        StartCoroutine(InstanciarTodo());
        Ganador.text = cad;
    }

    void DestruirTodo()
    {
        Mazo.mazoSize1 = 0;
        Mazo.mazoSize2 = 0;
        Transform t = GameObject.Find("RIP1").transform;
        for(int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
        t = GameObject.Find("RIP2").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
        t = GameObject.Find("PanelHand1").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
        t = GameObject.Find("PanelHand2").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
        t = GameObject.Find("Lider1").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
        t = GameObject.Find("Lider2").transform;
        for (int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
    }

    IEnumerator InstanciarTodo()
    {
        List<int> numerosAux = new List<int>();
        for (int i = 0; i < 50; i++) numerosAux.Add(i);
        for (int i = 0; i < 50; i++)
        {
            int r = UnityEngine.Random.Range(0, 50);
            (numerosAux[i], numerosAux[r]) = (numerosAux[r], numerosAux[i]);
        }
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.1f);
            cartaAMover.GetComponent<EstaCarta>().auxFinJuego = true;
            cartaAMover.GetComponent<EstaCarta>().esteId = numerosAux[i];
            Instantiate(cartaAMover, transform.position, transform.rotation);
        }
        regresarAMenu.SetActive(true);
    }

    IEnumerator ComenzarRonda2_3()
    {
        yield return new WaitForSeconds(3);
        if (victorias1 != 6 && victorias2 != 6)
        {
            Puntos.puntos1 = 0;
            Puntos.puntos2 = 0;
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(0.2f);
                if (GameObject.Find("PanelHand1").transform.childCount < 10)
                {
                    cartaAMano1.tag = "Repartiendo1";
                    Instantiate(cartaAMano1, transform.position, transform.rotation);
                }
                else
                {
                    cartaAMano1.GetComponent<EstaCarta>().estaCarta[0] = Mazo.staticMazoCartas1[Mazo.mazoSize1 - 1];
                    cartaAMano1.GetComponent<EstaCarta>().esteId = BuscarId(Mazo.staticMazoCartas1[Mazo.mazoSize1 - 1].id);
                    Mazo.mazoSize1--;
                    bandDestructorAux = true;
                    Destructor(cartaAMano1);
                    bandDestructorAux = false;
                }
                if (GameObject.Find("PanelHand2").transform.childCount < 10)
                {
                    cartaAMano2.tag = "Repartiendo2";
                    Instantiate(cartaAMano2, transform.position, transform.rotation);
                }
                else
                {
                    cartaAMano2.GetComponent<EstaCarta>().estaCarta[0] = Mazo.staticMazoCartas2[Mazo.mazoSize2 - 1];
                    cartaAMano2.GetComponent<EstaCarta>().esteId = BuscarId(Mazo.staticMazoCartas2[Mazo.mazoSize2 - 1].id);
                    Mazo.mazoSize2--;
                    bandDestructorAux = true;
                    Destructor(cartaAMano2);
                    bandDestructorAux = false;
                }
            }
            jugadorActivo1 = true;
            jugadorActivo2 = true;
            aux = true;
            numeroRonda++;
        }
    }

    public int BuscarId(int id)
    {
        for (int i = 0; i < BDCartas.cartasTodas.Count; i++)
        {
            if (BDCartas.cartasTodas[i].id == id)
            {
                return i;
            }
        }
        return 0;
    }

    IEnumerator Verificar()
    {
        bool mark1 = false, mark2 = false;
        if (GameObject.Find("PanelHand1").transform.childCount == 0) mark1 = true;
        if (GameObject.Find("PanelHand2").transform.childCount == 0) mark2 = true;
        yield return new WaitForSeconds(0.8f);
        if (GameObject.Find("PanelHand1").transform.childCount == 0 && mark1) jugadorActivo1 = false;
        if (GameObject.Find("PanelHand2").transform.childCount == 0 && mark2) jugadorActivo2 = false;
    }

    IEnumerator GanadorRonda()
    {
        string cad = "EL GANADOR DE LA RONDA ES ";
        if (Puntos.puntos1 == Puntos.puntos2)
        {
            cad = "EMPATE";
            victorias1++;
            victorias2++;
            SistemaTurnos.turno = UnityEngine.Random.Range(1, 3);
        }
        else if (Puntos.puntos1 > Puntos.puntos2)
        {
            cad += "RICK";
            victorias1 += 3;
            SistemaTurnos.turno = 1;
        }
        else
        {
            cad += "MORTY";
            victorias2 += 3;
            SistemaTurnos.turno = 2;
        }
        Ganador.text = cad;
        yield return new WaitForSeconds(3);
        Ganador.text = "";
    }

    void Cementerio()
    {
        string[] zonas = { "Fila", "Aumento", "Clima" };
        string[] filas = { "M", "R", "S" };
        foreach(var zona in zonas)
        {
            foreach (var fila in filas)
            {
                for(int faccion = 1; faccion < 3; faccion++)
                {
                    Transform t = GameObject.Find(zona.ToString() + fila.ToString() + faccion.ToString()).transform;
                    for(int i = 0; i < t.childCount; i++)
                    {
                        Destructor(t.GetChild(i).gameObject);
                    }
                }
            }
        }
    }

    void Destructor(GameObject destruir)
    {
        for (int i = 0; i < BDCartas.cartasTodas.Count; i++)
        {
            if (BDCartas.cartasTodas[i].id == destruir.GetComponent<EstaCarta>().estaCarta[0].id)
            {
                cartaARIP.GetComponent<EstaCarta>().esteId = i;
                break;
            }
        }
        cartaARIP.tag = "RIP" + destruir.GetComponent<EstaCarta>().estaCarta[0].faccion.ToString();
        Instantiate(cartaARIP, transform.position, transform.rotation);
        if(!bandDestructorAux) Destroy(destruir);
    }
}
