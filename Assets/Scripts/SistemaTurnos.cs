using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaTurnos : MonoBehaviour
{
    public int turno;
    public GameObject panel1;
    public GameObject panel2;

    // Start is called before the first frame update
    void Start()
    {
        turno = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(turno == 1)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
        else
        {
            panel2.SetActive(false);
            panel1.SetActive(true);
        }
    }

    public void CambioTurno()
    {
        turno = turno % 2 + 1;
    }
}
