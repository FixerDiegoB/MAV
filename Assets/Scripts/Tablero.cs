using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    [HideInInspector]
    public int[,] casillas;

    private void Start()
    {
        casillas = new int[3, 8];
    }

}
