using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VrButton_cikis : MonoBehaviour
{
  

    //Butona dokunulduktan sonra içeride biraz beklemsini saðlayan özellik
    public float deadTime3 = 1f;
    //Bool deðeri dead time süresince butonun kilitli kalmasýný saðlýyor.
    private bool _deadTimeActive3 = false;

    public UnityEvent onPressed3;

    public static bool on3;
    // Start is called before the first frame update
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive3)
        {
            onPressed3?.Invoke();
            Debug.Log("çýkýþ butonuna bastýn");
            Application.Quit();
           
        }
    }

   

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive3 = true;
        yield return new WaitForSeconds(deadTime3);
        _deadTimeActive3 = false;
    }
}


