using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool m_IsGameOver = false;

    private int m_PlayerCount = 0;

    private SpawnManager m_SpawnManager;

    private UIManager m_UIManager;

    void Start()
    {
        // look for the spawn manager and keep a reference.
        m_SpawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if (m_SpawnManager == null)
        {
            Debug.LogWarning("Spawn Manager is missing!");
        }

        m_UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (m_UIManager == null)
        {
            Debug.LogWarning("UI Manager is missing!");
        }
    }

    void OnRestart()
    {
        if (m_IsGameOver == true)
        {
            // reload the scene
            SceneManager.LoadScene("Game");
        }
    }

    public void AddPlayer()
    {
        m_PlayerCount++;
    }

    public void GameOver()
    {
        m_PlayerCount--;

        if (m_PlayerCount < 1)
        {
            m_IsGameOver = true;
            m_UIManager.GameOver();
            m_SpawnManager.OnPlayerDeath();
            GetComponent<PlayerInput>().enabled = true;
        }
    }
}
