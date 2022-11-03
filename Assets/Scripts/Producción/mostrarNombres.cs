using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarNombres : MonoBehaviour
{
    public GameObject blancoNombre;

    public void Start()
    {
        blancoNombre = GameObject.FindGameObjectWithTag("nblanco");
        //blancoNombre.GetComponent<Text>().text=PlayerPrefs.GetString("bnombre");
        
    }
}
