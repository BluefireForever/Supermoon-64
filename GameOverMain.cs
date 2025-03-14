using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMain : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ResetGame());
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MMenuButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("TitleScreen");
    }

}
