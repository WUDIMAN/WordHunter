using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverImage;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverImage.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameOverImage.SetActive(false);
    }
}
