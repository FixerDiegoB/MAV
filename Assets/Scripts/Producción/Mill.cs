using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour
{
    public Cell[] cells;
    public Color defaultColor;
    public Color millCreatedColor;
    [HideInInspector]
    public Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    public Status isComplete()
    {
        Status status = cells[0].status;

        foreach (Cell cell in cells)
        {
            if (cell.status == Status.EMPTY || status != cell.status)
            {
                render.material.color = defaultColor;
                return Status.EMPTY;
            }
        }
        render.material.color = millCreatedColor;
        return status;
    }
}
