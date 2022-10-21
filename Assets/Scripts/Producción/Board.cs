using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Cell> casillas;
    [HideInInspector]
    public List<Token> fichasBlancas, fichasNegras;
    [HideInInspector]
    public int numPiezasBlancas, numPiezasNegras;

    
    


    private void Start()
    {
        numPiezasBlancas = numPiezasNegras = 0;
    }

}
