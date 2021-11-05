using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed variable of 8
    [SerializeField]
    private float m_Speed = 8f;

    // Update is called once per frame
    void Update()
    {
        // move laser up
        transform.Translate(Vector3.up * m_Speed * Time.deltaTime);

        // if laser position on Y > 8
        // kill the laser
        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}
