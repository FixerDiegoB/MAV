using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class establecerNombres : MonoBehaviour
{
    public TMP_InputField inputText;
    public TMP_Text nombre;
    public Image permitido;
    
    
    public void Awake()
    {
        permitido.color = UnityEngine.Color.red;
    }
    public void Update()
    {
        if (nombre.text.Length < 3)
        {
            permitido.color = UnityEngine.Color.red;
        }
        if (nombre.text.Length >= 3) {
            permitido.color = UnityEngine.Color.green;
        }
    }

    public void Establecer() {

        PlayerPrefs.SetString("blancoNombre", inputText.text);
        Debug.Log(PlayerPrefs.GetString("bnombre"));
    }


}
