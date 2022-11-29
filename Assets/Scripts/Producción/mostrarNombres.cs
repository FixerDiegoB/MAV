using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarNombres : MonoBehaviour
{
    private GameObject blancoNombre;
    private GameObject negroNombre;

    public void Start()
    {
        blancoNombre = GameObject.FindGameObjectWithTag("blancoNombre");
        blancoNombre.GetComponent<Text>().text=PlayerPrefs.GetString("blancoNombre");

        negroNombre = GameObject.FindGameObjectWithTag("negroNombre");
        negroNombre.GetComponent<Text>().text = PlayerPrefs.GetString("negroNombre");
        
    }
}
