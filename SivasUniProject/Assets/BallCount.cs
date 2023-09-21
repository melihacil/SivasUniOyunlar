using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCount : MonoBehaviour
{

    [SerializeField] private int m_DesiredCount;
    [SerializeField] private Transform m_spawnPosition;
    [SerializeField] private float m_SpawnTime = 0.6f;
    [SerializeField] private List<Material> materials = new List<Material>();
    private int m_BallCount = 0;



    // Update is called once per frame
    private bool m_Spawned = false;


    void Update()
    {
        if (m_BallCount < m_DesiredCount && !m_Spawned)
        {
            m_Spawned = true;
            // Code for spawning balls
            Invoke(nameof(SpawnBasketball), m_SpawnTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Basketball"))
        {
            m_BallCount += 1;

            //if (m_BallCount < m_DesiredCount)
            //{
            //    // Code for spawning balls
            //    Invoke(nameof(SpawnBasketball), 0.3f);
            //}
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball"))
        {
            m_BallCount -= 1;
            //if (m_BallCount < m_DesiredCount)
            //{
            //    // Code for spawning balls
            //    Invoke(nameof(SpawnBasketball), 0.3f);
            //}
        }
    }



    private void SpawnBasketball()
    {

        int index = (int) Random.Range(0f, (float)materials.Count);
        
        GameObject testBall = ObjectPooler.m_ObjectPooler.InstantiateObject();
        if (testBall != null)
        {
            m_Spawned = false;
            testBall.transform.position = m_spawnPosition.position;
            testBall.GetComponent<MeshRenderer>().material = materials[index];
            testBall.SetActive(true);
            Debug.Log("Spawning basketball " + (m_BallCount) + " / " + m_DesiredCount);
        }
    }

}
