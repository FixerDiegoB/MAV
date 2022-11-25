using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour
{
    public Cell[] cells;
    public Color defaultColor;
    public Color millCreatedColor;
    public Status status;
    [HideInInspector]
    public Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    public Status isComplete()
    {
        Status cell_status = cells[0].status;

        foreach (Cell cell in cells)
        {
            if (cell.status == Status.EMPTY || cell_status != cell.status)
            {
                render.material.color = defaultColor;
                status = Status.EMPTY;
                return status;
            }
        }

        render.material.color = millCreatedColor;
        status = cell_status;
        return status;
    }
}
