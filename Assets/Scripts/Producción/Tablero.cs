using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EstadoCasilla { EMPTY, WHITE, BLACK};

public class Tablero : MonoBehaviour
{
    [HideInInspector]
    public int[,] casillas;
    [HideInInspector]
    public int numPiezasBlancas, numPiezasNegras;

    
    


    private void Start()
    {
        casillas = new int[3, 8]; // 0: vacio, 1: blancas, 2: negras
        numPiezasBlancas = numPiezasNegras = 0;
    }

}
