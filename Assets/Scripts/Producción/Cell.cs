using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cell : MonoBehaviour
{
    public List<Cell> neighbors;
    public List<Mill> mills;
    [HideInInspector]
    public Status status;
    [HideInInspector]
    public Vector3 position;
    [HideInInspector]
    public Token token;

    private void Start()
    {
        status = Status.EMPTY;
        position = transform.position;
    }
}
