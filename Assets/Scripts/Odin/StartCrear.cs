using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCrear : MonoBehaviour
{
    public TMP_InputField Code;
    public TMP_Text Errors;

    public static string code = "effect{\n\t\n\t// Añade código aquí\n\t\n}\n\ncard{\n\t\n\t// Añade código aquí\n\t\n}​"; 
    public static string errors = "";

    // Start is called before the first frame update
    void Start()
    {
        Code.text = code;
        Errors.text = errors;
    }
}
