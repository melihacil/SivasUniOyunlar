using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
   
    public float speed = 100.0f;
    public GameObject dartArrow;
    //dart 
    bool checker=false;
    Rigidbody m_Rigidbody;
    public Transform m_tip = null;
    private bool stopped = true;
    //dart�n hareket edip etmedi�i kontrol�

    private Vector3 LastPosition = Vector3.zero;

    private void Awake()
    {
        m_Rigidbody = dartArrow.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.tag == "2"&&checker==false)
        {
            checker = true;
            skor.point2();
            Stop();
            
        }
        else if (collision.gameObject.tag == "4"&&checker==false)
        {
            checker = true;
            skor.point4();
            Stop();
        }
        else if (collision.gameObject.tag == "6"&&checker==false)
        {
            checker = true;
            skor.point6();
            Stop();
        }
        else if (collision.gameObject.tag == "8" && checker == false)
        {
            checker = true;
            skor.point8();
            Stop();
        }
        else if (collision.gameObject.tag == "10" && checker == false)
        {
            checker = true;
            skor.point10();
            Stop();
        }
        else if (collision.gameObject.tag == "12" && checker == false)
        {
            checker = true;
            skor.point12();
            Stop();
        }
    }
    private void FixedUpdate()
    {
        if (stopped)//dart�n hareket edi�ini kontrol ediyor
        {
            return;
        }
        //bir obje bir objenin hareketine g�re y�n�n� de�i�tirebilir
        m_Rigidbody.MoveRotation(Quaternion.LookRotation(m_Rigidbody.velocity, transform.up));

        //collision kontrol� 
        if (Physics.Linecast(LastPosition, m_tip.position))
        {
            Stop();
        }

        LastPosition = m_tip.position;
    }


    private void Stop()
{
         m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY|
                  RigidbodyConstraints.FreezeRotationZ| RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        stopped = true;
    m_Rigidbody.velocity = Vector3.zero;
    m_Rigidbody.angularVelocity = Vector3.zero;
    m_Rigidbody.isKinematic = true;
    m_Rigidbody.useGravity = false;
}
    public void Fire(float pullValue)
    {
        stopped = false;
        transform.parent = null;
        m_Rigidbody.isKinematic = false;
        m_Rigidbody.useGravity = true;
        m_Rigidbody.AddForce(transform.forward* speed);
        //h�z verir
       
    }
   
}
