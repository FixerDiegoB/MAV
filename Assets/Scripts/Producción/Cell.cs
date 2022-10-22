using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cell : MonoBehaviour
{
    [SerializeField]
    private List<Cell> neighbors;
    [SerializeField]
    private List<Mill> mills;
    private Status status;
    private Vector3 position;

    private void Start()
    {
        status = Status.EMPTY;
        position = transform.position;
    }
}
