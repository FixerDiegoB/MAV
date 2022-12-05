using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SeleccionarNombre : MonoBehaviour
{
    public Text TextBlanco;
    public Image luzBlanco;
    public InputField textb;
    public Text TextNegro;
    public Image luzNegro;
    public InputField textN;
    public GameObject botonIniciar;

    private void Awake()
    {
        luzBlanco.color = Color.red;
        luzNegro.color = Color.red;
    }

    private void Update()
    {
        if (TextBlanco.text.Length < 4)
        {
            luzBlanco.color = Color.red;
        }
        else {
            luzBlanco.color = Color.green;
        }

        if (TextNegro.text.Length < 4)
        {
            luzNegro.color = Color.red;
        }
        else {
            luzNegro.color = Color.green;
        }

        
    }
    //agregar un if 
    public void InciarPartida()
    {
        PlayerPrefs.SetString("blancoNombre",  textb.text);
        PlayerPrefs.SetString("negroNombre", textN.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
