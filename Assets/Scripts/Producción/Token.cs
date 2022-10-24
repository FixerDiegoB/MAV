using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Token : MonoBehaviour
{
    private bool formaMolino;
    [HideInInspector]
    public Cell cell;
    [HideInInspector]
    public Status color;
    public Rulescopia rules;
    public UnityEngine.Color defaultcolor;
    public UnityEngine.Color newColor;
    public Renderer render;

    private void OnMouseDown()
    {
        Debug.Log("adios");
    }

    private void OnMouseOver()
    {
        render = GetComponent<Renderer>();
        render.material.color = newColor;
    }

    private void OnMouseExit()
    {
        render = GetComponent<Renderer>();
        render.material.color = defaultcolor;
    }
}

