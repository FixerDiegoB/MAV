using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reglas : MonoBehaviour
{
    public float altura;
    public GameObject piezaBlanca, piezaNegra, piezaReferencia;

    private bool turno; // true = blanco, false = negro
    private Ray ray;
    private Vector3 posicion;
    private GameObject nuevaPieza;

    private void Start()
    {
        turno = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject != null)
                {
                    Debug.Log(hitInfo.collider.gameObject.name);
                    posicion = hitInfo.collider.gameObject.transform.parent.position;
                    posicion = new Vector3(posicion.x, altura, posicion.z);
                    if (turno)
                    {
                        nuevaPieza = Instantiate(piezaBlanca, posicion, Quaternion.identity);
                        nuevaPieza.transform.parent = piezaReferencia.transform;
                        nuevaPieza.transform.position = posicion;
                    }
                    else
                    {
                        nuevaPieza = Instantiate(piezaNegra, posicion, Quaternion.identity);
                        nuevaPieza.transform.parent = piezaReferencia.transform;
                        nuevaPieza.transform.position = posicion;
                    }
                    turno = !turno;
                }
            }
        }
    }

}
