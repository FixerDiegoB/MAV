using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reglas : MonoBehaviour
{
    public float altura;
    public GameObject piezaBlanca, piezaNegra, piezaReferencia;
    public Tablero tablero;
    public GameObject sonidoCasillaOcupada;

    private bool turno; // true = blanco, false = negro
    private GameObject nuevaPieza;


    private void Start()
    {
        turno = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ColocarPieza();
        }
    }

    private void ColocarPieza()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.gameObject != null)
            {
                Debug.Log(hitInfo.collider.gameObject.transform.parent.name);
                int[] casilla = obtenerIndiceCasilla(hitInfo.collider.gameObject.transform.parent.name);
                if (tablero.casillas[casilla[0], casilla[1]] == 0)
                {
                    Vector3 posicion = hitInfo.collider.gameObject.transform.parent.position;
                    posicion = new Vector3(posicion.x, altura, posicion.z);
                    if (turno)
                    {
                        tablero.casillas[casilla[0], casilla[1]] = 1;
                        nuevaPieza = Instantiate(piezaBlanca, posicion, Quaternion.identity);
                        nuevaPieza.transform.parent = piezaReferencia.transform;

                    }
                    else
                    {
                        tablero.casillas[casilla[0], casilla[1]] = 2;
                        nuevaPieza = Instantiate(piezaNegra, posicion, Quaternion.identity);
                        nuevaPieza.transform.parent = piezaReferencia.transform;

                    }
                    turno = !turno;
                }
                else {
                    Instantiate(sonidoCasillaOcupada);
                }
            }
        }
    }

    private int[] obtenerIndiceCasilla(string name)
    {
        int cas = int.Parse(name[1].ToString());
        if (name[0] == 'E')
            return new int[] { 0, cas};
        if (name[0] == 'M')
            return new int[] { 1, cas};
        return new int[] { 2, cas};
    }

    public void reiniciarTablero()
    {
        foreach (Transform child in piezaReferencia.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 8; j++)
                tablero.casillas[i, j] = 0;

        turno = true;
    }
}
