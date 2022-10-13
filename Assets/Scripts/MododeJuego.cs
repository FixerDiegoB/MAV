using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MododeJuego : MonoBehaviour
{
    [Header("MododeJuego")]

    public toggle Persona;
    public toggle Computadora;

    [Header("Panels")]
    public GameObject MododeJuego;
    public GameObject OptionPanel;
    public GameObject LevelSelectPanel;
    public void OpenPanel (GameObject panel)
        mainPanel.SetActive(false);
        OptionPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
        panel.SetActve(true);

}
