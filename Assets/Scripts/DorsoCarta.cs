using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorsoCarta : MonoBehaviour
{
    public GameObject dorsoCarta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EstaCarta.staticDorsoCarta)
        {
            dorsoCarta.SetActive(true);
        }
        else
        {
            dorsoCarta.SetActive(false);
        }
    }
}
