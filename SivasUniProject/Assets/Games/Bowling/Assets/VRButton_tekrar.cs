using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton_tekrar : MonoBehaviour
{
    //Butona dokunulduktan sonra i�eride biraz beklemsini sa�layan �zellik
    public float deadTime2 = 1f;
    //Bool de�eri dead time s�resince butonun kilitli kalmas�n� sa�l�yor.
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
             float s�re = 50f;
            s�re-= 1 * Time.deltaTime;
            if (s�re < 0)
            {
                on2 = false;
                s�re = 0;
            }
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive2)
        {
            onPressed2?.Invoke();
            Debug.Log("Tekrar tu�a bast�n");
            //GetComponent<bowlingball>().startingTime = 50f;
            on2 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive2)
        {
            onReleased2?.Invoke();
            Debug.Log("Tu� serbest kald�");
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
