using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool m_IsGameOver = false;

    void OnRestart()
    {
        if (m_IsGameOver == true)
        {
            // reload the scene
            SceneManager.LoadScene("Game");
        }
    }

    public void GameOver()
    {
        m_IsGameOver = true;
    }
}
