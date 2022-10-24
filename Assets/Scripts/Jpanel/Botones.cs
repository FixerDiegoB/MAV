using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
 
    void Start()
    {
       
        gameManager = FindObjectOfType<GameManager>();

        //3. Acciones de cada botón

        //Botón inicio 
        if (botonInicio)
        {
            //Le añado la acción a ejecutar (cambiar a la escena de Inicio)
            botonInicio.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Inicio"));
        }

        //Botón jugar 
        if (botonJuego)
        {
            //Le añado la acción a ejecutar (cambiar a la escena de Juego)
            botonJuego.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Juego"));
        }

        //Botón opciones 
        if (botonOpciones)
        {
            //Le añado la acción a ejecutar (cambiar a la escena de Opciones)
            botonOpciones.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Opciones"));
        }

        if (botonSalir)
        {
            //Le añado la acción a ejecutar (salir del juego)
            //Este botón no funcionará en el Editor de Unity, pero sí al hacer la Build
            botonSalir.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
        }

    }
    }
}
