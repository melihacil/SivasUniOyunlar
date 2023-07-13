using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{

    public float boostSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Daha bitmedi.
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            other.attachedRigidbody.AddForce(this.gameObject.transform.forward * boostSpeed);
        }
    }
}
