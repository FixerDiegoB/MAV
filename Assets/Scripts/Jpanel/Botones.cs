using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        gameManager = FindObjectOfType<GameManager>();

        //3. Acciones de cada botón

        //Botón inicio (si existe)
        if (botonInicio)
        {
            //Le añado la acción a ejecutar (cambiar a la escena de Inicio)
            botonInicio.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Inicio"));
        }

        //Botón jugar (si existe)
        if (botonJuego)
        {
            //Le añado la acción a ejecutar (cambiar a la escena de Juego)
            botonJuego.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Juego"));
        }

        //Botón opciones (si existe)
        if (botonOpciones)
        {
            //Le añado la acción a ejecutar (cambiar a la escena de Opciones)
            botonOpciones.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Opciones"));
        }

      
        }
    }
}
