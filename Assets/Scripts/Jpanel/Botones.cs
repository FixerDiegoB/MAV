using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        gameManager = FindObjectOfType<GameManager>();

        //3. Acciones de cada bot�n

        //Bot�n inicio (si existe)
        if (botonInicio)
        {
            //Le a�ado la acci�n a ejecutar (cambiar a la escena de Inicio)
            botonInicio.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Inicio"));
        }

        //Bot�n jugar (si existe)
        if (botonJuego)
        {
            //Le a�ado la acci�n a ejecutar (cambiar a la escena de Juego)
            botonJuego.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Juego"));
        }

        //Bot�n opciones (si existe)
        if (botonOpciones)
        {
            //Le a�ado la acci�n a ejecutar (cambiar a la escena de Opciones)
            botonOpciones.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Opciones"));
        }

      
        }
    }
}
