 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occupiedCellLife : MonoBehaviour
{
    public float duracion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,duracion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
