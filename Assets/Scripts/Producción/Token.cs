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

    private void OnMouseDown()
    {
        Debug.Log("adios");
    }

}
