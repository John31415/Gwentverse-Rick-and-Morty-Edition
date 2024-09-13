using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RTE : MonoBehaviour
{
    public GameObject bigPanel;
    public GameObject regresarACrear;
    public TMP_Text errors;
    public static string errorText;

    // Start is called before the first frame update
    void Start()
    {
        errorText = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(errorText != "")
        {
            errors.text = errorText;
            bigPanel.SetActive(true);
            regresarACrear.SetActive(true);
        }
    }
}
