using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCount : MonoBehaviour
{




    [SerializeField] private int m_DesiredCount;
    [SerializeField] private Transform m_spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int m_BallCount;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Basketball"))
        {
            m_BallCount += 1;

            if (m_BallCount < m_DesiredCount)
            {
                // Code for spawning balls
                SpawnBasketball();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball"))
        {
            m_BallCount -= 1;
            if (m_BallCount < m_DesiredCount)
            {
                // Code for spawning balls
                SpawnBasketball();
            }
        }
    }



    private void SpawnBasketball()
    {
        GameObject testBall = ObjectPooler.m_ObjectPooler.InstantiateObject();
        if (testBall != null)
        {
            testBall.transform.position = m_spawnPosition.position;
            testBall.SetActive(true);
            Debug.Log("Spawning basketball" + testBall.transform.position);
        }
    }

}
