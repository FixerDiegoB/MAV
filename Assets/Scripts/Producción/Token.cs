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
    private Rulescopia rules;
    public UnityEngine.Color defaultcolor;
    public UnityEngine.Color newColor;
    public Renderer render;

    private void OnMouseDown()
    {
        Debug.Log("adios");
    }

    private void OnMouseOver()
    {
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.WHITE)
        {
            render = GetComponent<Renderer>();
            render.material.color = newColor;
        }
        else if (rules.phase == GamePhase.MOVE && rules.turn == Status.BLACK)
        {
            render = GetComponent<Renderer>();
            render.material.color = newColor;
        }
    }

    private void OnMouseExit()
    {
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.WHITE)
        {
            render = GetComponent<Renderer>();
            render.material.color = defaultcolor;
        }
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.BLACK)
        {
            render = GetComponent<Renderer>();
            render.material.color = defaultcolor;
        }
    }
}

