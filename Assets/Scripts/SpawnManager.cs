using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_EnemyPrefab;

    [SerializeField]
    private Transform m_EnemyContainer;

    private bool m_IsSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        // infinite while loop
        // instantiate an enemy
        // wait 5 seconds
        while (m_IsSpawning == true)
        {
            Vector3 pos = new Vector3(Random.Range(-9f, 9f), 7.5f, 0);
            
            // Instantiate gives back the enemy as a GameObject
            // which we then parent under the enemy container.
            GameObject enemy = Instantiate(m_EnemyPrefab, pos, Quaternion.identity);
            enemy.transform.SetParent(m_EnemyContainer);

            yield return new WaitForSeconds(5f);
        }
    }

    public void OnPlayerDeath()
    {
        m_IsSpawning = false;
    }
}
