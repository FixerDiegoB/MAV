using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Token : MonoBehaviour { 

public Cell cell;
[HideInInspector]
public Status color;
public Rulescopia rules;
public UnityEngine.Color defaultColor;
public UnityEngine.Color newColor;
public Renderer render;

    private void OnMouseOver()
    {
        if (rules == null) return;
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.WHITE)
        {
            render = GetComponent<Renderer>();
            render.material.color = newColor;
        }
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.BLACK)
        {
            render = GetComponent<Renderer>();
            render.material.color = newColor;
        }
    }

    private void OnMouseExit()
    {
        if (rules == null) return;
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.WHITE)
        {
            render = GetComponent<Renderer>();
            render.material.color = defaultColor;
        }
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.BLACK)
        {
            render = GetComponent<Renderer>();
            render.material.color = defaultColor;
        }
    }
    
    private void OnMouseDown()
    {
        Debug.Log("adios");
    }

}
