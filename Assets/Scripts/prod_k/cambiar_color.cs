using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiar_color : MonoBehaviour
{
    public UnityEngine.Color inicial;
    public UnityEngine.Color final;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
       this.gameObject.GetComponent<Renderer>().material.color = final;
    }
    public void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = inicial;
    }
}
