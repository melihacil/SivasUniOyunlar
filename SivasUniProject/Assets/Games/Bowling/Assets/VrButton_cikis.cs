using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VrButton_cikis : MonoBehaviour
{
  

    //Butona dokunulduktan sonra i�eride biraz beklemsini sa�layan �zellik
    public float deadTime3 = 1f;
    //Bool de�eri dead time s�resince butonun kilitli kalmas�n� sa�l�yor.
    private bool _deadTimeActive3 = false;

    public UnityEvent onPressed3;

    public static bool on3;
    // Start is called before the first frame update
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive3)
        {
            onPressed3?.Invoke();
            Debug.Log("��k�� butonuna bast�n");
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


