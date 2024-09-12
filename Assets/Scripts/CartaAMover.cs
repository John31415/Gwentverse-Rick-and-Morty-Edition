using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using System;
using Unity.VisualScripting;
using Odin;

public class CartaAMover : MonoBehaviour
{
    public GameObject mazo;
    public GameObject esto;
    public List<Carta> estaCarta = new List<Carta>();

    public GameObject cartaAMover;
    public GameObject cartaAMano;
    public GameObject cartaARIP;

    public bool bandReciente = false;

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

        if (!bandReciente) Efectos();
        else return;
        bandReciente = false;

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
        if (efectoId == 10)
        {
            DataCollecter dataCollecter = new DataCollecter();
            dataCollecter.Collect(id);
            GameState gameState = dataCollecter.Estado();

            List<Carta> estaCarta = new List<Carta>();
            for (int i = 0; i < BDCartas.cartasTodas.Count; i++)
            {
                if (BDCartas.cartasTodas[i].id == id)
                {
                    estaCarta.Add(BDCartas.cartasTodas[i]);
                }
            }
            Run.RunEffect(estaCarta[0].nombre, gameState);

            Actualizar(gameState, estaCarta[0].poder, estaCarta[0].faccion);
        }
    }
    #region Actualizar Juego

    public GameObject HandCard1;
    public GameObject HandCard2;
    public GameObject FieldCard;
    public GameObject GraveyardCard;

    public void Actualizar(GameState gameState, int PODER, int FACCION)
    {
        long triggerPlayer = gameState.TriggerPlayer;
        long otherPlayer = triggerPlayer % 2 + 1;
        Lists deck = gameState.Deck;
        Lists otherDeck = gameState.OtherDeck;
        Lists hand = gameState.Hand;
        Lists otherHand = gameState.OtherHand;
        Lists field = gameState.Field;
        Lists otherField = gameState.OtherField;
        Lists graveyard = gameState.Graveyard;
        Lists otherGraveyard = gameState.OtherGraveyard;

        foreach (var card in deck.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);
        foreach (var card in otherDeck.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);
        foreach (var card in hand.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);
        foreach (var card in otherHand.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);
        foreach (var card in field.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);
        foreach (var card in otherField.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);
        foreach (var card in graveyard.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);
        foreach (var card in otherGraveyard.Cards) BDCartas.cartasTodas[BuscarId((int)card.Id)] = ConvertirCard(card);

        if (triggerPlayer == 1)
        {
            ActualizarDeck(deck.Cards, otherDeck.Cards);
            ActualizarField(field.Cards, otherField.Cards, PODER, FACCION);
            ActualizarRIP(graveyard.Cards, otherGraveyard.Cards);
            ActualizarHand(hand.Cards, otherHand.Cards);
        }
        else
        {
            ActualizarDeck(otherDeck.Cards, deck.Cards);
            ActualizarField(otherField.Cards, field.Cards, PODER, FACCION);
            ActualizarRIP(otherGraveyard.Cards, graveyard.Cards);
            ActualizarHand(otherHand.Cards, hand.Cards);
        }
    }

    public void ActualizarDeck(List<Card> deck, List<Card> otherDeck)
    {
        Mazo.staticMazoCartas1 = new List<Carta>();
        foreach (var card in deck)
        {
            Mazo.staticMazoCartas1.Add(ConvertirCard(card));
        }
        Mazo.staticMazoCartas2 = new List<Carta>();
        foreach (var card in otherDeck)
        {
            Mazo.staticMazoCartas2.Add(ConvertirCard(card));
        }
        Mazo.mazoSize1 = deck.Count;
        Mazo.mazoSize2 = otherDeck.Count;
    }

    public void ActualizarHand(List<Card> hand, List<Card> otherHand)
    {
        GameObject handZone = GameObject.Find("PanelHand1");
        GameObject otherHandZone = GameObject.Find("PanelHand2");
        Destroyer(handZone);
        Destroyer(otherHandZone);
        foreach (var card in hand)
        {
            HandCard1.tag = "Untagged";
            HandCard1 = Instantiate(HandCard1);
            List<Carta> estaCarta = new List<Carta> { ConvertirCard(card) };
            HandCard1.GetComponent<EstaCarta>().esteId = BuscarId(estaCarta[0].id);
            HandCard1.GetComponent<EstaCarta>().estaCarta = estaCarta;
        }
        foreach (var card in otherHand)
        {
            HandCard2.tag = "Untagged";
            HandCard2 = Instantiate(HandCard2);
            List<Carta> estaCarta = new List<Carta> { ConvertirCard(card) };
            HandCard2.GetComponent<EstaCarta>().esteId = BuscarId(estaCarta[0].id);
            HandCard2.GetComponent<EstaCarta>().estaCarta = estaCarta;
        }
    }

    public void ActualizarField(List<Card> field, List<Card> otherField, int PODER, int FACCION)
    {
        string[] zones = { "Fila", "Aumento", "Clima" };
        string filas = "MRS";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject Zone1 = GameObject.Find(zones[i] + filas[j] + "1");
                GameObject Zone2 = GameObject.Find(zones[i] + filas[j] + "2");
                Destroyer(Zone1);
                Destroyer(Zone2);
            }
        }
        Puntos.puntos1 = 0;
        Puntos.puntos2 = 0;
        if (FACCION == 1) Puntos.puntos1 = PODER;
        else Puntos.puntos2 = PODER;
        foreach (var card in field)
        {
            List<Carta> estaCarta = new List<Carta> { ConvertirCard(card) };
            if (estaCarta[0].faccion == 1) Puntos.puntos1 += estaCarta[0].poder;
            else Puntos.puntos2 += estaCarta[0].poder;
            string zone = "";
            if (estaCarta[0].tipoId == 0) zone += "Aumento";
            else if (estaCarta[0].tipoId == 1) zone += "Clima";
            else zone += "Fila";
            zone += estaCarta[0].filas[0];
            zone += estaCarta[0].faccion.ToString();
            GameObject Zone = GameObject.Find(zone);
            FieldCard.GetComponent<CartaAMover>().bandReciente = true;
            FieldCard = Instantiate(FieldCard);
            FieldCard.GetComponent<EstaCarta>().esteId = BuscarId(estaCarta[0].id);
            FieldCard.GetComponent<EstaCarta>().estaCarta = estaCarta;
            FieldCard.transform.SetParent(Zone.transform);
        }
        foreach (var card in otherField)
        {
            List<Carta> estaCarta = new List<Carta> { ConvertirCard(card) };
            if (estaCarta[0].faccion == 1) Puntos.puntos1 += estaCarta[0].poder;
            else Puntos.puntos2 += estaCarta[0].poder;
            string zone = "";
            if (estaCarta[0].tipoId == 0) zone += "Aumento";
            else if (estaCarta[0].tipoId == 1) zone += "Clima";
            else zone += "Fila";
            zone += estaCarta[0].filas[0];
            zone += estaCarta[0].faccion.ToString();
            GameObject Zone = GameObject.Find(zone);
            FieldCard.GetComponent<CartaAMover>().bandReciente = true;
            FieldCard = Instantiate(FieldCard);
            FieldCard.GetComponent<EstaCarta>().esteId = BuscarId(estaCarta[0].id);
            FieldCard.GetComponent<EstaCarta>().estaCarta = estaCarta;
            FieldCard.transform.SetParent(Zone.transform);
        }
    }

    public void ActualizarRIP(List<Card> graveyard, List<Card> otherGraveyard)
    {
        GameObject graveyardZone = GameObject.Find("RIP1");
        GameObject otherGraveyardZone = GameObject.Find("RIP2");
        Destroyer(graveyardZone);
        Destroyer(otherGraveyardZone);
        foreach (var card in graveyard)
        {
            GraveyardCard = Instantiate(GraveyardCard);
            List<Carta> estaCarta = new List<Carta> { ConvertirCard(card) };
            GraveyardCard.GetComponent<EstaCarta>().esteId = BuscarId(estaCarta[0].id);
            GraveyardCard.GetComponent<EstaCarta>().estaCarta = estaCarta;
            GraveyardCard.tag = "RIP1";
        }
        foreach (var card in otherGraveyard)
        {
            GraveyardCard = Instantiate(GraveyardCard);
            List<Carta> estaCarta = new List<Carta> { ConvertirCard(card) };
            GraveyardCard.GetComponent<EstaCarta>().esteId = BuscarId(estaCarta[0].id);
            GraveyardCard.GetComponent<EstaCarta>().estaCarta = estaCarta;
            GraveyardCard.tag = "RIP2";
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

    public void Destroyer(GameObject obj)
    {
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            Destroy(obj.transform.GetChild(i).gameObject);
        }
    }

    public Carta ConvertirCard(Card card)
    {
        long id = card.Id;
        List<Carta> estaCarta = new List<Carta>();
        for (int i = 0; i < BDCartas.cartasTodas.Count; i++)
        {
            if (BDCartas.cartasTodas[i].id == id)
            {
                estaCarta.Add(BDCartas.cartasTodas[i]);
            }
        }
        return new Carta((int)card.Id, card.Name, Faccion(card.Faction), card.Range, (int)card.Power, estaCarta[0].efectosId, estaCarta[0].ataque, estaCarta[0].tipoId, estaCarta[0].descripcion, estaCarta[0].spriteImagen);
    }

    public int Faccion(string faccion)
    {
        if (faccion == "Rick Sanchez") return 1;
        return 2;
    }

    #endregion

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
        for (int i = 0; i < filaAux.childCount; i++)
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
        if (faccion == 1)
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
        foreach (string f in filas)
        {
            Transform t_ = GameObject.Find("Fila" + f + faccion.ToString()).transform;
            for (int i = 0; i < t_.childCount; i++)
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

        if (pos != -1)
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

        foreach (string f in filas)
        {
            Transform t_ = GameObject.Find("Fila" + f + faccion.ToString()).transform;
            if (t_.childCount < menor && t_.childCount > 0)
            {
                menor = t_.childCount;
                fila = f;
            }
        }

        if (menor != int.MaxValue)
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
    void MultiplicaPoder(int id, string nombre, int faccion, string filas)
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