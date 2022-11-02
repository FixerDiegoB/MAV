using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private const int V = 1;

    public void InicarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + V);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

}