using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Carta
{
    public int id;
    public string nombre;
    public int faccion;
    public string filas;
    public int poder;
    public int efectosId;
    public int ataque;
    public int tipoId;
    public string descripcion;
    public Sprite spriteImagen;

    public Carta()
    {

    }

    public Carta(int Id, string Nombre, int Faccion, string Filas, int Poder, int EfectosId, int Ataque, int TipoId, string Descripcion, Sprite SpriteImagen)
    {
        id = Id;
        nombre = Nombre;
        faccion = Faccion;
        filas = Filas;
        poder = Poder;
        efectosId = EfectosId;
        ataque = Ataque;
        tipoId = TipoId;
        descripcion = Descripcion;
        spriteImagen = SpriteImagen;
    }
}
