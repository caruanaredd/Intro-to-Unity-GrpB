using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool m_IsGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && m_IsGameOver == true)
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
