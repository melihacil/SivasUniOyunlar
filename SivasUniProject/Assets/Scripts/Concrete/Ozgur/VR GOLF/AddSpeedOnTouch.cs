using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedOnTouch : MonoBehaviour
{
    public string targetTag;
    public GameManagerGolf gameManager;

    private Vector3 prevPos;
    private Vector3 velocity;
    private Collider clubCollider;

    // Start is called before the first frame update

    /// Assignments or assign functions should be used in awake rather than start
    /// In awake process components ara initialized and can be assigned or used
    /// In start process gameobjects are initialized and can be assigned or used (also accessed for both these processes)

    private void Awake()
    {
        clubCollider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        velocity = (transform.position - prevPos) / Time.deltaTime;
        prevPos = transform.position;
    }


    [SerializeField]
    BoxCollider m_GolfClubRedundant;
    [SerializeField]
    private float m_ResetSpeed = 0.1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Colliding...");
            //clubCollider.enabled = false;

            /// Vector improvements can be made, rather than choosing the closestpoint vector line should be calculated
            /// and force should be added on that vector line
            /// With this change code readability improves 


            Vector3 collisionPos = clubCollider.ClosestPoint(other.transform.position);
            Vector3 collisionNorm = other.transform.position - collisionPos;
            Vector3 projectedVelocity = Vector3.Project(velocity, collisionNorm);
            other.GetComponent<GolfBall>().PlayHitSound();

            Rigidbody rb = other.attachedRigidbody;

            rb.AddForce(projectedVelocity, ForceMode.Impulse);

            // Gerekmediði sürece Velocity eriþilerek deðiþtirilmemeli
            //rb.velocity = projectedVelocity;
            gameManager.currentHitNumber++;

            //Invoke(nameof(OpenCollider), m_ResetSpeed);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag(targetTag))
        {
            Debug.Log("Colliding Golf with Collision Method");


            Vector3 collisionPos = clubCollider.ClosestPoint(collision.transform.position);
            Vector3 collisionNorm = collision.transform.position - collisionPos;
            Vector3 projectedVelocity = Vector3.Project(velocity, collisionNorm);
            collision.collider.gameObject.GetComponent<GolfBall>().PlayHitSound();

            Rigidbody rb = collision.rigidbody; //attachedRigidbody;

            rb.AddForce(projectedVelocity, ForceMode.Impulse);
            gameManager.currentHitNumber++;

        }
    }

    // Redundant test code
    //private void OpenCollider()
    //{
    //    clubCollider.enabled = true;
    //}


}
