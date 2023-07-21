using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour
{
    
   public GameObject Toys;
    Rigidbody m_Rigidbody;
    MeshRenderer m_mesh;
    public static int score =0;
   
    IEnumerator KuzuYok()
    {
        yield return new WaitForSeconds(2f);
        m_mesh.enabled = false;
      
      
        
    }
    void Start()
    {
       
        m_Rigidbody = Toys.GetComponent<Rigidbody>();
        m_mesh = Toys.GetComponent<MeshRenderer>();


    }

    private void Update()
    {
       
    }

    private bool isUsed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="ball" && !isUsed)
        {
            isUsed = true;
            m_Rigidbody.isKinematic = false;
            score = score + 10;
            StartCoroutine(KuzuYok());

        }
    }

}

   

