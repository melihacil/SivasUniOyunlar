using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private GameManagerGolf gameManager;
    // Start is called before the first frame update
    
    IEnumerator ReplaceBallWithDelay()
    {
        Debug.Log("Enum Triggered");

        yield return new WaitForSeconds(3);

        gameManager.ReplaceBall();
        

    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Ball")
        {
            Debug.Log("Entered Dead Zone");
           StartCoroutine(ReplaceBallWithDelay());
        }
    }
}
