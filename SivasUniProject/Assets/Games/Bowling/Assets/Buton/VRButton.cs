using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    //Butona dokunulduktan sonra i�eride biraz beklemsini sa�layan �zellik
    public float deadTime = 1f;
    //Bool de�eri dead time s�resince butonun kilitli kalmas�n� sa�l�yor.
    private bool _deadTimeActive = false;

    public UnityEvent onPressed, onReleased;

    public static bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Button" && !_deadTimeActive)
        {
            onPressed?.Invoke();
            Debug.Log("Tu�a bast�n");
            on = true;
        }
    }

   public void OnTriggerExit(Collider other)
    {
        if(other.tag=="Button" && !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("Tu� serbest kald�");
            StartCoroutine(WaitForDeadTime());
            
            
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }
}
