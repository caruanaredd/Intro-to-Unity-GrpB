using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text m_ScoreText;

    [SerializeField]
    private Image m_LivesImage;

    [SerializeField]
    private Sprite[] m_LivesSprites;

    [SerializeField]
    private GameObject m_GameOver;

    [SerializeField]
    private GameObject m_RestartText;

    // function - update the score
    public void UpdateScore(int score)
    {
        m_ScoreText.text = $"Score: {score}";
    }

    public void UpdateLives(int lives)
    {
        // access the sprite on the image
        // change it to the correct sprite
        m_LivesImage.sprite = m_LivesSprites[lives];
    }

    public void GameOver()
    {
        m_GameOver.SetActive(true);
        m_RestartText.SetActive(true);
        StartCoroutine(GameOverRoutine());
    }

    // timed event - flicker the game over text
    IEnumerator GameOverRoutine()
    {
        // infinite loop
            // wait 0.5s
            // disable/clear gameover
            // wait 0.5s
            // enable/fill gameover
        
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            // m_GameOver.text = "";
            m_GameOver.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            // m_GameOver.text = "GAME OVER";
            m_GameOver.SetActive(true);
        }
    }
}
