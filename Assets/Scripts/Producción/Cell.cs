using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum StatusCell { EMPTY, WHITE, BLACK};

public class Cell : MonoBehaviour
{
    [SerializeField]
    private List<Cell> neighbors;
    private StatusCell status;
    private Vector3 position;

    private void Start()
    {
        status = StatusCell.EMPTY;
        position = transform.position;
    }
}
