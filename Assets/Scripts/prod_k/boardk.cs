using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardk : MonoBehaviour
{

    public List<Cell> casillas;
    // public List<Mill> mills;
    [HideInInspector]
    public List<Token> fichasBlancas, fichasNegras;
    [HideInInspector]
    public int numPiezasBlancas, numPiezasNegras;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numPiezasBlancas = numPiezasNegras = 0;
    }
}
