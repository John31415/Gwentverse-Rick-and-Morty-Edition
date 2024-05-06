using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class CartaAMover : MonoBehaviour
{
    public GameObject mazo;
    public GameObject esto;
    public List<Carta> estaCarta = new List<Carta>();
    
    public GameObject cartaAMover;
    public GameObject cartaAMano;
    public GameObject cartaARIP;

    // Start is called before the first frame update
    void Start()
    {
        estaCarta.Clear();
        estaCarta.Add(esto.GetComponent<EstaCarta>().estaCarta[0]);
        string cad = "";
        if (estaCarta[0].tipoId == 0) cad += "Aumento";
        else if (estaCarta[0].tipoId == 1) cad += "Clima";
        else cad += "Fila";
        cad += estaCarta[0].filas;
        if (estaCarta[0].faccion == 1) cad += "1";
        else cad += "2";
        mazo = GameObject.Find(cad);

        Efectos();

        if (esto.tag == "Reciente")
        {
            esto.tag = "Untagged";
            return;
        }

        SistemaTurnos.turno = SistemaTurnos.turno % 2 + 1;
    }

    // Update is called once per frame
    void Update()
    {
        esto.transform.SetParent(mazo.transform);
        esto.transform.localScale = Vector3.one;
        esto.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        esto.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void Efectos()
    {
        int id = estaCarta[0].id;
        string nombre = estaCarta[0].nombre;
        int faccion = estaCarta[0].faccion;
        string filas = estaCarta[0].filas;
        int poder = estaCarta[0].poder;
        int efectoId = estaCarta[0].efectosId;
        int ataque = estaCarta[0].ataque;
        int tipoId = estaCarta[0].tipoId;

        //Clima dinamico
        if (tipoId == 5)
        {
            Transform tAux = GameObject.Find("Clima" + filas + faccion.ToString()).transform;
            if (tAux.childCount == 1)
            {
                int ataque_ = tAux.GetChild(0).gameObject.GetComponent<EstaCarta>().estaCarta[0].ataque;
                if (ataque_ >= esto.GetComponent<EstaCarta>().estaCarta[0].poder)
                {
                    StartCoroutine(Destruccion(faccion));
                    return;
                }
                esto.GetComponent<EstaCarta>().estaCarta[0].poder -= ataque_;
            }
            tAux = GameObject.Find("Clima" + filas + (faccion % 2 + 1).ToString()).transform;
            if (tAux.childCount == 1)
            {
                int ataque_ = tAux.GetChild(0).gameObject.GetComponent<EstaCarta>().estaCarta[0].ataque;
                if (ataque_ >= esto.GetComponent<EstaCarta>().estaCarta[0].poder)
                {
                    StartCoroutine(Destruccion(faccion));
                    return;
                }
                esto.GetComponent<EstaCarta>().estaCarta[0].poder -= ataque_;
            }
        }
        poder = estaCarta[0].poder = esto.GetComponent<EstaCarta>().estaCarta[0].poder;

        if (faccion == 1) Puntos.puntos1 += poder;
        else Puntos.puntos2 += poder;

        if (efectoId == 0) Aumento(faccion, filas, ataque);
        if (efectoId == 1) Clima(filas, ataque);
        if (efectoId == 2) Despeje(faccion, filas);
        if (efectoId == 4) QuitarMenosPoderosa(faccion);
        if (efectoId == 5) LimpiaFila(faccion);
        if (efectoId == 6) PonerClima(faccion);
        if (efectoId == 7) RobarCarta(faccion);
        if (efectoId == 8) MultiplicaPoder(id, nombre, faccion, filas);
        if (efectoId == 9) PonerAumento(faccion);
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
        Destroy(destruir);
    }

    IEnumerator Destruccion(int faccion)
    {
        yield return new WaitForSeconds(0.5f);
        Destructor(esto);
    }

    // Aumenta cada carta de Plata de una fila propia en N unidades
    void Aumento(int faccion, string filas, int ataque)
    {
        string cad = "Fila" + filas + faccion.ToString();
        GameObject filaCartas = GameObject.Find(cad);

        for (int i = 0; i < filaCartas.transform.childCount; i++)
        {
            Transform child = filaCartas.transform.GetChild(i);
            if (child.GetComponent<EstaCarta>().estaCarta[0].tipoId != 5)
            {
                continue;
            }
            child.GetComponent<EstaCarta>().estaCarta[0].poder += ataque;
            if (faccion == 1) Puntos.puntos1 += ataque;
            else Puntos.puntos2 += ataque;
        }
    }

    // Disminuye cada carta de Plata de una fila propia y del rival en N unidades, si el valor de la carta se vuelve negativo esta es eliminada del campo
    void Clima(string filas, int ataque)
    {
        string cad = "Fila" + filas + "1";
        GameObject filaCartas1 = GameObject.Find(cad);

        for (int i = 0; i < filaCartas1.transform.childCount; i++)
        {
            Transform child = filaCartas1.transform.GetChild(i);
            if (child.GetComponent<EstaCarta>().estaCarta[0].tipoId != 5)
            {
                continue;
            }
            int childPoder = child.GetComponent<EstaCarta>().estaCarta[0].poder;
            if (ataque >= childPoder)
            {
                Puntos.puntos1 -= childPoder;
                Destructor(child.gameObject);
            }
            else
            {
                child.GetComponent<EstaCarta>().estaCarta[0].poder -= ataque;
                Puntos.puntos1 -= ataque;
            }
        }

        cad = "Fila" + filas + "2";
        GameObject filaCartas2 = GameObject.Find(cad);

        for (int i = 0; i < filaCartas2.transform.childCount; i++)
        {
            Transform child = filaCartas2.transform.GetChild(i);
            if (child.GetComponent<EstaCarta>().estaCarta[0].tipoId != 5)
            {
                continue;
            }
            int childPoder = child.GetComponent<EstaCarta>().estaCarta[0].poder;
            if (ataque > childPoder)
            {
                Puntos.puntos2 -= childPoder;
                Destructor(child.gameObject);
            }
            else
            {
                child.GetComponent<EstaCarta>().estaCarta[0].poder -= ataque;
                Puntos.puntos2 -= ataque;
            }
        }
    }

    // Elimina el clima (si existe) que se encuentra en su fila simetrica en el campo del rival
    void Despeje(int faccion, string filas)
    {
        Transform aux = GameObject.Find("Clima" + filas + (faccion % 2 + 1).ToString()).transform;
        if (aux.childCount == 0)
        {
            return;
        }
        int puntos1 = 0, puntos2 = 0;
        Transform filaAux = GameObject.Find("Fila" + filas + faccion.ToString()).transform;
        for(int i=0;i<filaAux.childCount;i++)
        {
            if (filaAux.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].tipoId == 5)
            {
                filaAux.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].poder += aux.GetChild(0).gameObject.GetComponent<EstaCarta>().estaCarta[0].ataque;
                puntos1 += aux.GetChild(0).gameObject.GetComponent<EstaCarta>().estaCarta[0].ataque;
            }
        }
        filaAux = GameObject.Find("Fila" + filas + (faccion % 2 + 1).ToString()).transform;
        for (int i = 0; i < filaAux.childCount; i++)
        {
            if (filaAux.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].tipoId == 5)
            {
                filaAux.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].poder += aux.GetChild(0).gameObject.GetComponent<EstaCarta>().estaCarta[0].ataque;
                puntos2 += aux.GetChild(0).gameObject.GetComponent<EstaCarta>().estaCarta[0].ataque;
            }
        }
        StartCoroutine(QuitarClima(aux, faccion, puntos1, puntos2));
    }

    IEnumerator QuitarClima(Transform aux, int faccion, int puntos1, int puntos2)
    {
        yield return new WaitForSeconds(0.4f);
        Destructor(aux.GetChild(0).gameObject);
        if(faccion == 1)
        {
            Puntos.puntos1 += puntos1;
            Puntos.puntos2 += puntos2;
        }
        else
        {
            Puntos.puntos1 += puntos2;
            Puntos.puntos2 += puntos1;
        }
        yield return new WaitForSeconds(0.4f);
        Destructor(esto);
    }

    // Elimina carta menos poderosa del rival
    void QuitarMenosPoderosa(int faccion)
    {
        int pos = -1, menor = int.MaxValue;
        string fila = "";
        faccion = faccion % 2 + 1;
        string[] filas = { "M", "R", "S" };
        foreach(string f in filas)
        {
            Transform t_ = GameObject.Find("Fila" + f + faccion.ToString()).transform;
            for(int i=0;i<t_.childCount;i++)
            {
                Carta carta_ = t_.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0];
                if (carta_.tipoId != 5)
                {
                    continue;
                }
                int poder = carta_.poder;
                if (poder < menor)
                {
                    menor = poder;
                    fila = f;
                    pos = i;
                }
            }
        }

        if(pos != -1)
        {
            GameObject g = GameObject.Find("Fila" + fila + faccion.ToString()).transform.GetChild(pos).gameObject;
            if (faccion == 1) Puntos.puntos1 -= g.GetComponent<EstaCarta>().estaCarta[0].poder;
            else Puntos.puntos2 -= g.GetComponent<EstaCarta>().estaCarta[0].poder;
            Destructor(g);
        }
    }

    // Elimina todas las cartas de Plata de la fila no vacia del rival que menor cantidad de cartas contega
    void LimpiaFila(int faccion)
    {
        faccion = faccion % 2 + 1;

        string[] filas = { "M", "R", "S" };
        int menor = int.MaxValue;
        string fila = "";

        foreach(string f in filas)
        {
            Transform t_ = GameObject.Find("Fila" + f + faccion.ToString()).transform;
            if(t_.childCount < menor && t_.childCount > 0)
            {
                menor = t_.childCount;
                fila = f;
            }
        }

        if(menor != int.MaxValue)
        {
            int suma = 0;
        
            Transform t = GameObject.Find("Fila" + fila + faccion.ToString()).transform;
            for (int i = 0; i < t.childCount; i++)
            {
                if (t.GetChild(i).GetComponent<EstaCarta>().estaCarta[0].tipoId == 5)
                {
                    suma += t.GetChild(i).GetComponent<EstaCarta>().estaCarta[0].poder;
                    Destructor(t.GetChild(i).gameObject);
                }
            }

            if (faccion == 1) Puntos.puntos1 -= suma;
            else Puntos.puntos2 -= suma;
        }
    }

    // Pone una carta Clima aleatoria de la mano
    void PonerClima(int faccion)
    {
        Transform t = GameObject.Find("PanelHand" + faccion.ToString()).transform;
        List<GameObject> lista = new List<GameObject>();
        lista.Clear();
        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].tipoId == 1)
            {
                lista.Add(t.GetChild(i).gameObject);
            }
        }
        if (lista.Count == 0)
        {
            return;
        }
        int r = UnityEngine.Random.Range(0, lista.Count - 1);
        StartCoroutine(PonerElClima(lista[r]));
        StartCoroutine(QuitarInstanciaClima(t, lista[r].GetComponent<EstaCarta>().estaCarta[0].id));
    }

    IEnumerator PonerElClima(GameObject carta_)
    {
        yield return new WaitForSeconds(0.3f);
        int val = carta_.GetComponent<EstaCarta>().estaCarta[0].id;
        for (int i = 0; i < BDCartas.cartasTodas.Count; i++)
        {
            if (BDCartas.cartasTodas[i].id == val)
            {
                cartaAMover.GetComponent<EstaCarta>().esteId = i;
                break;
            }
        }
        cartaAMover.tag = "Reciente";
        Instantiate(cartaAMover, transform.position, transform.rotation);
    }

    IEnumerator QuitarInstanciaClima(Transform t, int id)
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].id == id)
            {
                Destroy(t.GetChild(i).gameObject);
                break;
            }
        }
    }

    // Roba una carta del mazo
    void RobarCarta(int faccion)
    {
        StartCoroutine(Robo(faccion));
    }

    IEnumerator Robo(int faccion)
    {
        yield return new WaitForSeconds(0.3f);
        cartaAMano.tag = "Repartiendo" + faccion.ToString();
        Instantiate(cartaAMano, transform.position, transform.rotation);
    }

    // N = cantidad de cartas iguales a ella en el campo, multiplica su poder por N
    void MultiplicaPoder(int id ,string nombre, int faccion, string filas)
    {
        Transform t = GameObject.Find("Fila" + filas + faccion.ToString()).transform;
        int contador = 1;
        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].nombre == nombre && t.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].id != id)
            {
                contador++;
            }
        }
        if (faccion == 1) Puntos.puntos1 += esto.GetComponent<EstaCarta>().estaCarta[0].poder * (contador - 1);
        else Puntos.puntos2 += esto.GetComponent<EstaCarta>().estaCarta[0].poder * (contador - 1);
        esto.GetComponent<EstaCarta>().estaCarta[0].poder *= contador;
    }

    // Pone un aumento aleatorio de la mano
    void PonerAumento(int faccion)
    {
        Transform t = GameObject.Find("PanelHand" + faccion.ToString()).transform;
        List<GameObject> lista = new List<GameObject>();
        lista.Clear();
        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].tipoId == 0)
            {
                lista.Add(t.GetChild(i).gameObject);
            }
        }
        if (lista.Count == 0)
        {
            return;
        }
        int r = UnityEngine.Random.Range(0, lista.Count - 1);
        StartCoroutine(PonerElAumento(lista[r]));
        StartCoroutine(QuitarInstanciaAumento(t, lista[r].GetComponent<EstaCarta>().estaCarta[0].id));
    }

    IEnumerator PonerElAumento(GameObject carta_)
    {
        yield return new WaitForSeconds(0.3f);
        int val = carta_.GetComponent<EstaCarta>().estaCarta[0].id;
        for (int i = 0; i < BDCartas.cartasTodas.Count; i++)
        {
            if (BDCartas.cartasTodas[i].id == val)
            {
                cartaAMover.GetComponent<EstaCarta>().esteId = i;
                break;
            }
        }
        cartaAMover.tag = "Reciente";
        Instantiate(cartaAMover, transform.position, transform.rotation);
    }

    IEnumerator QuitarInstanciaAumento(Transform t, int id)
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.GetComponent<EstaCarta>().estaCarta[0].id == id)
            {
                Destroy(t.GetChild(i).gameObject);
                break;
            }
        }
    }
}