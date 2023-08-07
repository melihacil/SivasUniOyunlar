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
    //dartýn hareket edip etmediði kontrolü

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
        if (stopped)//dartýn hareket ediþini kontrol ediyor
        {
            return;
        }
        //bir obje bir objenin hareketine göre yönünü deðiþtirebilir
        m_Rigidbody.MoveRotation(Quaternion.LookRotation(m_Rigidbody.velocity, transform.up));

        //collision kontrolü 
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
        //hýz verir
       
    }
   
}
