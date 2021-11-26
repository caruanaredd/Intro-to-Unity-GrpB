using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 4f;

    private Player m_Player;

    void Start()
    {
        m_Player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4m/s
        transform.Translate(Vector3.down * m_Speed * Time.deltaTime);

        // if at the bottom of the screen
        // respawn at the top with a random X position
        if (transform.position.y < -5.5f)
        {
            float posX = Random.Range(-9f, 9f);
            transform.position = new Vector3(posX, 7.5f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if other is player
        // Damage player
        // Destroy us
        if (other.tag == "Player")
        {
            // get the player script
            // check that it is not null (it exists)
            // damage the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Destroy(gameObject);
        }

        // if other is laser
        // Destroy laser
        // Destroy us
        if (other.tag == "Laser")
        {
            if (m_Player != null)
            {
                m_Player.AddScore();
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
