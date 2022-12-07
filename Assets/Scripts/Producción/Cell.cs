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
    public Color defaultcolor;
    public Color newcolor;
    private GameObject hijo;
    private Renderer render;

    private void Start()
    {
        hijo = transform.GetChild(0).gameObject;
        render = hijo.GetComponent<Renderer>();

    }

    public void encender()
    {

        render.material.color = newcolor;
    }

    public void apagar()
    {

        render.material.color = defaultcolor;
    }
}
