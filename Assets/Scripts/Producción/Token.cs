using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Token : MonoBehaviour { 

public Cell cell;
[HideInInspector]
public Status color;
public Rulescopia rules;
public Color defaultColor;
public Color newColor;
[HideInInspector]
public Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void OnMouseOver()
    {
        if (rules == null) return;
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.WHITE)
        {
            render.material.color = newColor;
        }
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.BLACK)
        {
            render.material.color = newColor;
        }
    }

    private void OnMouseExit()
    {
        if (rules == null) return;
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.WHITE)
        {
            render.material.color = defaultColor;
        }
        if (rules.phase == GamePhase.MOVE && rules.turn == Status.BLACK)
        {
            render.material.color = defaultColor;
        }
    }
}
