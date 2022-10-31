using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //int randomNumber = Random.Range(0, 2);
        //PlayerPrefs.SetInt("J1_isTurn", randomNumber);
        PlayerPrefs.SetInt("J1_isTurn", 1);
        SceneManager.LoadScene("GameScene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}