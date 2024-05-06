using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senuelo : MonoBehaviour
{
    public void Poder()
    {
        if (!MoverCarta.bandSenuelo || !(this.GetComponent<EstaCarta>().estaCarta[0].tipoId == 4 || this.GetComponent<EstaCarta>().estaCarta[0].tipoId == 5))
        {
            return;
        }
        if (this.GetComponent<EstaCarta>().estaCarta[0].faccion == 1) Puntos.puntos1 -= this.GetComponent<EstaCarta>().estaCarta[0].poder;
        else Puntos.puntos2 -= this.GetComponent<EstaCarta>().estaCarta[0].poder;
        (this.GetComponent<EstaCarta>().estaCarta[0], MoverCarta.objetoAux.GetComponent<EstaCarta>().estaCarta[0]) = (MoverCarta.objetoAux.GetComponent<EstaCarta>().estaCarta[0], this.GetComponent<EstaCarta>().estaCarta[0]);
        MoverCarta.bandSenuelo = false;
        SistemaTurnos.turno = SistemaTurnos.turno % 2 + 1;
    }
}
