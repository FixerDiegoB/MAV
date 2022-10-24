using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAlPasar : MonoBehaviour
{
    public UnityEngine.Color defaultcolor;
    public UnityEngine.Color newColor;
    public Renderer render;

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
