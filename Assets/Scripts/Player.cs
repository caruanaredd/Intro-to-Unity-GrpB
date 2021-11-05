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

    // Start is called before the first frame update
    void Start()
    {
        // take the current player position, and set it to [0, 0, 0]
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
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
        else if (transform.position.y < -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        // if player position on X > 11
        // player position on X = -11
        // else if player position on X < -11
        // player position on X = 11
        if (transform.position.x > 11f)
        {
            transform.position = new Vector3(-11f, transform.position.y, 0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
    }
}
