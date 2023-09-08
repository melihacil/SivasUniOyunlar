using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object pooler needed

public class BallDispenser : MonoBehaviour
{

    [SerializeField] private Transform m_spawnPosition;

    private void Start()
    {

    }

    bool m_Spawned = false;
    private void Update()
    {
     

        if (!m_Spawned)
        {
            StartCoroutine(SpawnTest());
            m_Spawned = true;
        }
    }


    IEnumerator SpawnTest()
    {

        while (true)
        {
            GameObject testBall = ObjectPooler.m_ObjectPooler.InstantiateObject();
            if (testBall != null)
            {
                testBall.transform.position = m_spawnPosition.position;
                testBall.SetActive(true);
                Debug.Log("Spawning basketball" + testBall.transform.position);
            }
            yield return new WaitForSeconds(1.5f);
        }

    }


}
