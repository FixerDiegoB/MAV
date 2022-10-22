using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reglask : MonoBehaviour
{
    public float altura;
    public GameObject piezaBlanca, piezaNegra, piezaReferencia;
    public boardk tablero;
    public GameObject sonidoCasillaOcupada;

    private bool turno; // true = blanco, false = negro
    private GameObject nuevaPieza;
    // Start is called before the first frame update
    void Start()
    {
        turno = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }
            
}
