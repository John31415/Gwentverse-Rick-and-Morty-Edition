using Odin;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator
{
    private Dictionary<string, string> sprites = new Dictionary<string, string>();

    public CardCreator(List<Card> cards)
    {
        foreach (var card in cards)
        {
            InicializarSprites();
            int id = BDCartas.cartasTodas.Count;
            string nombre = card.Name;
            int faccion = Faccion(card.Faction);
            string filas = card.Range[0] + "";
            int poder = (int)card.Power;
            int efectosId = 10;
            int ataque = 0;
            int tipoId = TipoId(card.Type);
            string descripcion = "'Interpretado por Odin.'";
            string imagen = "Odin";
            if (sprites.ContainsKey(nombre))
            {
                imagen = sprites[nombre];
            }
            else
            {
                imagen = sprites[imagen];
            }
            Sprite spriteImagen = Resources.Load<Sprite>(imagen);
            List<Carta> carta = new List<Carta> { new Carta(id, nombre, faccion, filas, poder, efectosId, ataque, tipoId, descripcion, spriteImagen) };
            BDCartas.cartasTodas.Add(carta[0]);
            if (faccion == 1) BDCartas.cartaOdin1.Add(carta[0]);
            else BDCartas.cartaOdin2.Add(carta[0]);
        }
    }

    public int Faccion(string faccion)
    {
        if (faccion == "Rick Sanchez") return 1;
        if (faccion == "Morty Smith") return 2;
        return Random.Range(1, 2);
    }

    public int TipoId(string tipo)
    {
        if (tipo == "Aumento") return 0;
        if (tipo == "Clima") return 1;
        if (tipo == "Despeje") return 2;
        if (tipo == "Lider") return 3;
        if (tipo == "Oro") return 4;
        if (tipo == "Senuelo") return 6;
        return 5;
    }

    public void InicializarSprites()
    {
        sprites["Jessica"] = "Cartas/Aumento/JESSICA";
        sprites["Beth Smith"] = "Cartas/Aumento/BETH";
        sprites["Jerry Smith"] = "Cartas/Aumento/JERRY";
        sprites["Mr. Goldenfold"] = "Cartas/Aumento/MR. GOLDENFOLD";
        sprites["Summer Smith"] = "Cartas/Aumento/SUMMER";
        sprites["Furp Rock"] = "Cartas/Clima/FURP ROCK";
        sprites["Galaxy"] = "Cartas/Clima/GALAXY";
        sprites["Pluto"] = "Cartas/Clima/PLUTO";
        sprites["Earth"] = "Cartas/Clima/EARTH";
        sprites["Midland Quasar"] = "Cartas/Clima/MIDLAND QUASAR";
        sprites["Gramuflack"] = "Cartas/Clima/GRAMUFLACK";
        sprites["Snake Planet"] = "Cartas/Clima/SNAKE PLANET";
        sprites["Ruben"] = "Cartas/Despeje/RUBEN";
        sprites["Hormigas en los ojos Johnson"] = "Cartas/Despeje/HORMIGAS EN LOS OJOS JOHNSON";
        sprites["Vendedor de puertas falsas reales"] = "Cartas/Despeje/VENDEDOR DE PUERTAS FALSAS REALES";
        sprites["Rick Sanchez"] = "Cartas/Lider/RICK";
        sprites["Morty Smith"] = "Cartas/lider/MORTY";
        sprites["Scary Terry"] = "Cartas/Oro/SCARY TERRY";
        sprites["Hepatitis A"] = "Cartas/Oro/HEPATITIS A";
        sprites["Squanchy"] = "Cartas/Oro/SQUANCHY";
        sprites["Joyce Smith"] = "Cartas/Oro/JOYCE SMITH";
        sprites["Abradolf Lincler"] = "Cartas/Oro/ABRADOLF LINCLER";
        sprites["Hepatitis C"] = "Cartas/Oro/HEPATITIS C";
        sprites["Morty Smith Jr."] = "Cartas/Oro/MORTY SMITH JR.";
        sprites["Leonard Smith"] = "Cartas/Oro/LEONARD SMITH";
        sprites["Pickle Rick"] = "Cartas/Plata/PICKLE RICK";
        sprites["Birdperson"] = "Cartas/Plata/BIRDPERSON";
        sprites["Mr. Meeseeks"] = "Cartas/Plata/MR. MEESEEKS";
        sprites["Mr. Poopybutthole"] = "Cartas/Plata/MR. POOPYBUTTHOLE";
        sprites["Dos Hermanos"] = "Cartas/Plata/DOS HERMANOS";
        sprites["Snuffles (Snowball)"] = "Cartas/Plata/SNOWBALLS";
        sprites["Jacob Philip"] = "Cartas/Señuelo/JACOB PHILIP";
        sprites["Gwendolyn"] = "Cartas/Señuelo/GWENDOLYN";
        sprites["Rey Frijol"] = "Cartas/Señuelo/REY FRIJOL";
        sprites["Odin"] = "Cartas/Odin/ODIN";
    }
}
