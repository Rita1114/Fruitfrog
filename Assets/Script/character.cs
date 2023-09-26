using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}