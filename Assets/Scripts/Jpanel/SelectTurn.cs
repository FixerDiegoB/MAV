using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTurn : MonoBehaviour
{
    public void SaveTurnJ1()
    {
        PlayerPrefs.SetInt("J1_isTurn", 1);
        SceneManager.LoadScene("GameScene");
    }
    public void SaveTurnJ2()
    {
        PlayerPrefs.SetInt("J1_isTurn", 0);
        SceneManager.LoadScene("GameScene");
    }
}