using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status { EMPTY, WHITE, BLACK };

public class Board : MonoBehaviour
{
    public List<Cell> casillas;
    // public List<Mill> mills;
    [HideInInspector]
    public List<Token> fichasBlancas, fichasNegras;
    [HideInInspector]
    public int numPiezasBlancas, numPiezasNegras;

    
    


    private void Start()
    {
        numPiezasBlancas = numPiezasNegras = 0;
    }

}
