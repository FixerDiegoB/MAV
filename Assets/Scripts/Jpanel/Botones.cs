using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
 
    void Start()
    {
       
        gameManager = FindObjectOfType<GameManager>();

        //3. Acciones de cada bot�n

        //Bot�n inicio 
        if (botonInicio)
        {
            //Le a�ado la acci�n a ejecutar (cambiar a la escena de Inicio)
            botonInicio.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Inicio"));
        }

        //Bot�n jugar 
        if (botonJuego)
        {
            //Le a�ado la acci�n a ejecutar (cambiar a la escena de Juego)
            botonJuego.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Juego"));
        }

        //Bot�n opciones 
        if (botonOpciones)
        {
            //Le a�ado la acci�n a ejecutar (cambiar a la escena de Opciones)
            botonOpciones.GetComponent<Button>().onClick.AddListener(() => gameManager.cambiarEscena("Opciones"));
        }

        if (botonSalir)
        {
            //Le a�ado la acci�n a ejecutar (salir del juego)
            //Este bot�n no funcionar� en el Editor de Unity, pero s� al hacer la Build
            botonSalir.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
        }

    }
    }
}
