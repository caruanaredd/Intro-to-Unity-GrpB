using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 3 parts to a variable declaration (optionally 4)
    // private or public
    // data type -> int, float, bool, string, etc.
    // every variable has a name
    // optionally we assign a value (speed -> 5)
    [SerializeField]
    private float m_Speed = 3.5f;

    [SerializeField]
    private Transform m_LaserPrefab;

    [SerializeField]
    private float m_FireRate = 0.5f;

    private float m_NextFire = -1f;

    [SerializeField]
    private int m_Lives = 3;

    private int m_Score = 0;

    private SpawnManager m_SpawnManager;

    private UIManager m_UIManager;

    // Start is called before the first frame update
    void Start()
    {
        // take the current player position, and set it to [0, 0, 0]
        transform.position = new Vector3(0, 0, 0);

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

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        // if I hit the space key and can fire
        // spawn laser
        // set the next fire time
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > m_NextFire)
        {
            FireLaser();
        }
    }

    // Calculates the player movement.
    void CalculateMovement()
    {
        // get the horizontal input from the Input Manager.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // More efficient version of the code below.
        Vector3 direction = new Vector3(horizontal, vertical);
        transform.Translate(direction * m_Speed * Time.deltaTime);

        // Move the player 1 on the X axis every frame.
        // [1, 0, 0] x horizontal input x 5 x real time per second
        // transform.Translate(Vector3.right * horizontal * m_Speed * Time.deltaTime);
        // transform.Translate(Vector3.up * vertical * m_Speed * Time.deltaTime);


        // if player position on Y is greater than 0
        // player position on Y = 0
        // else if player position on Y is less than -3.8
        // player position on Y = -3.8

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -2.8f)
        {
            transform.position = new Vector3(transform.position.x, -2.8f, 0);
        }

        // if player position on X > 11
        // player position on X = -11
        // else if player position on X < -11
        // player position on X = 11
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

    // Fires a laser.
    void FireLaser()
    {
        // offset the laser by 0.8 on Y
        Vector3 offset = new Vector3(0, 0.8f, 0);
        Instantiate(m_LaserPrefab, transform.position + offset, Quaternion.identity);

        m_NextFire = Time.time + m_FireRate;
    }

    // Damages the player
    public void Damage()
    {
        // decrease the number of lives
        m_Lives -= 1;
        // m_Lives = m_Lives - 1;
        // m_Lives--;
        m_UIManager.UpdateLives(m_Lives);

        // if player is dead
        // destroy us
        if (m_Lives < 1) 
        {
            // Communicate with spawn manager
            // tell it to stop.
            m_UIManager.GameOver();
            m_SpawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        m_Score += 10;
        m_UIManager.UpdateScore(m_Score);
    }
}
