using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    //Butona dokunulduktan sonra içeride biraz beklemsini saðlayan özellik
    public float deadTime = 1f;
    //Bool deðeri dead time süresince butonun kilitli kalmasýný saðlýyor.
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
            Debug.Log("Tuþa bastýn");
            on = true;
        }
    }

   public void OnTriggerExit(Collider other)
    {
        if(other.tag=="Button" && !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("Tuþ serbest kaldý");
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
