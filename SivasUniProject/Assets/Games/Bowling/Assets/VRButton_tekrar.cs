using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton_tekrar : MonoBehaviour
{
    //Butona dokunulduktan sonra içeride biraz beklemsini saðlayan özellik
    public float deadTime2 = 1f;
    //Bool deðeri dead time süresince butonun kilitli kalmasýný saðlýyor.
    private bool _deadTimeActive2 = false;
    
    public UnityEvent onPressed2, onReleased2;
    public float time;
    public static bool on2;
    // Start is called before the first frame update
    void Start()
    {
        on2 = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (on2 == true)
        {
             float süre = 50f;
            süre-= 1 * Time.deltaTime;
            if (süre < 0)
            {
                on2 = false;
                süre = 0;
            }
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive2)
        {
            onPressed2?.Invoke();
            Debug.Log("Tekrar tuþa bastýn");
            //GetComponent<bowlingball>().startingTime = 50f;
            on2 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive2)
        {
            onReleased2?.Invoke();
            Debug.Log("Tuþ serbest kaldý");
            StartCoroutine(WaitForDeadTime2());
            on2 = false;
            
        }
    }

    IEnumerator WaitForDeadTime2()
    {
        _deadTimeActive2 = true;
        yield return new WaitForSeconds(deadTime2);
        _deadTimeActive2 = false;
    }
}
