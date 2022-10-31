using TMPro;
using UnityEngine;

public class ShowTurn : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("J1_isTurn") == 1)
        {
            //int randomNumber = Random.Range(0, 2);
            //PlayerPrefs.SetInt("J1_isTurn", randomNumber);

            textMeshProUGUI.text = "Turno del jugador 1";
        }
        else
        {
            textMeshProUGUI.text = "Turno del jugador 2";
        }
    }
}