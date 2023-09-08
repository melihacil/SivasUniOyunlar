using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] public static ObjectPooler m_ObjectPooler;
    [SerializeField] private List<GameObject> m_pooledObjects;
    [SerializeField] private GameObject m_objectToPool;
    [SerializeField] public int m_maxObjects;
    // Start is called before the first frame update


    private void Awake()
    {
        m_ObjectPooler = this;
    }

    void Start()
    {
        m_pooledObjects = new List<GameObject>();
        GameObject temp;

        for (int i = 0; i < m_maxObjects; i++)
        {
            temp = Instantiate(m_objectToPool);
            temp.SetActive(false);
            m_pooledObjects.Add(temp);
        }
    }

    //Function for setting active and restarting position

    public GameObject InstantiateObject()
    {
        for (int i = 0; i < m_pooledObjects.Count; i++)
        {
            if (!m_pooledObjects[i].activeInHierarchy)
            {
                return m_pooledObjects[i];
            }
        }
        return null;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
