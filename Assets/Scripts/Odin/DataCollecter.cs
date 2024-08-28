using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Odin;

using static System.Console;

public class DataCollecter
{
    public int TriggerPlayer { get; set; }
    private List<Card> board, deck, otherDeck, hand, otherHand, field, otherField, graveyard, otherGraveyard;

    public Lists Board { get; set; }
    public Lists Deck { get; set; }
    public Lists OtherDeck { get; set; }
    public Lists Hand { get; set; }
    public Lists OtherHand { get; set; }
    public Lists Field { get; set; }
    public Lists OtherField { get; set; }
    public Lists Graveyard { get; set; }
    public Lists OtherGraveyard { get; set; }

    public void Collect()
    {
        TriggerPlayer = SistemaTurnos.turno;
        int OtherPlayer = TriggerPlayer % 2 + 1;
        board = new List<Card>();
        deck = new List<Card>();
        otherDeck = new List<Card>();
        hand = new List<Card>();
        otherHand = new List<Card>();
        field = new List<Card>();
        otherField = new List<Card>();
        graveyard = new List<Card>();
        otherGraveyard = new List<Card>();
        foreach (var carta in CollectZone("PanelHand" + TriggerPlayer))
        {
            hand.Add(CardConverter(carta));
        }
        foreach (var carta in CollectZone("PanelHand" + OtherPlayer))
        {
            otherHand.Add(CardConverter(carta));
        }
        foreach (var carta in CollectZone("RIP" + TriggerPlayer))
        {
            graveyard.Add(CardConverter(carta));
        }
        foreach (var carta in CollectZone("RIP" + OtherPlayer))
        {
            otherGraveyard.Add(CardConverter(carta));
        }
        string range = "MRS";
        for (int i = 0; i < 3; i++)
        {
            foreach (var carta in CollectZone("Fila" + range[i].ToString() + TriggerPlayer.ToString()))
            {
                field.Add(CardConverter(carta));
            }
            foreach (var carta in CollectZone("Fila" + range[i].ToString() + OtherPlayer.ToString()))
            {
                otherField.Add(CardConverter(carta));
            }
        }
        if (TriggerPlayer == 1)
        {
            for (int i = 0; i < Mazo.mazoSize1; i++) deck.Add(CardConverter(Mazo.staticMazoCartas1[i]));
            for (int i = 0; i < Mazo.mazoSize2; i++) otherDeck.Add(CardConverter(Mazo.staticMazoCartas2[i]));
        }
        else
        {
            for (int i = 0; i < Mazo.mazoSize2; i++) deck.Add(CardConverter(Mazo.staticMazoCartas2[i]));
            for (int i = 0; i < Mazo.mazoSize1; i++) otherDeck.Add(CardConverter(Mazo.staticMazoCartas1[i]));
        }
        board = field;
        board.Concat(otherField);
        board.Concat(hand);
        board.Concat(otherHand);
        board.Concat(graveyard);
        board.Concat(otherGraveyard);
        for (int i = 0; i < 3; i++)
        {
            foreach (var carta in CollectZone("Clima" + range[i].ToString() + TriggerPlayer.ToString()))
            {
                board.Add(CardConverter(carta));
            }
            foreach (var carta in CollectZone("Aumento" + range[i].ToString() + TriggerPlayer.ToString()))
            {
                board.Add(CardConverter(carta));
            }
            foreach (var carta in CollectZone("Clima" + range[i].ToString() + OtherPlayer.ToString()))
            {
                board.Add(CardConverter(carta));
            }
            foreach (var carta in CollectZone("Aumento" + range[i].ToString() + OtherPlayer.ToString()))
            {
                board.Add(CardConverter(carta));
            }
        }
        Board = new Lists(board);
        Deck = new Lists(deck);
        OtherDeck = new Lists(otherDeck);
        Hand = new Lists(hand);
        OtherHand = new Lists(otherHand);
        Field = new Lists(field);
        OtherField = new Lists(otherField);
        Graveyard = new Lists(graveyard);
        OtherGraveyard = new Lists(otherGraveyard);
    }

    private List<Carta> CollectZone(string zoneName)
    {
        List<Carta> list = new List<Carta>();
        GameObject zone = GameObject.Find(zoneName);
        for (int i = 0; i < zone.transform.childCount; i++)
        {
            Transform child = zone.transform.GetChild(i);
            list.Add(child.gameObject.GetComponent<EstaCarta>().estaCarta[0]);
        }
        return list;
    }

    private Card CardConverter(Carta carta)
    {
        Card card = new Card(carta.faccion, carta.id, Type(carta.tipoId), carta.nombre, Faction(carta.faccion), carta.poder, carta.filas, carta.descripcion);
        return card;
    }

    private string Type(int type)
    {
        if (type == 0) return "Aumento";
        if (type == 1) return "Clima";
        if (type == 2) return "Despeje";
        if (type == 3) return "Lider";
        if (type == 4) return "Oro";
        if (type == 5) return "Plata";
        return "Senuelo";
    }

    private string Faction(int faction)
    {
        if (faction == 1) return "Rick Sanchez";
        return "Morty Smith";
    }
}
