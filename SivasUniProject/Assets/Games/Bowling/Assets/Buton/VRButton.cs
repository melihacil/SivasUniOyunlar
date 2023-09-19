using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    
    //Butona dokunulduktan sonra i�eride biraz beklemsini sa�layan �zellik
    public float deadTime = 0.4f;
    //Bool de�eri dead time s�resince butonun kilitli kalmas�n� sa�l�yor.
    private bool _deadTimeActive = false;

    public UnityEvent onPressed, onReleased;

    public static bool on;



    [SerializeField] private GameObject m_ButtonMesh;


    private GameObject m_Hand = null;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
        m_ButtonMesh.transform.localPosition = new Vector3(0f, 0.065f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.tag + " name " + other.name);
        if(other.tag == "Hand")
        {

            onPressed?.Invoke();
            Debug.Log("Tu�a bast�n");
            on = true;
            m_Hand = other.gameObject;
            m_ButtonMesh.transform.localPosition = new Vector3(0f, 0.03f, 0f);
        }
    }

    
   private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Hand") //&& !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("Tu� serbest kald�");
            StartCoroutine(WaitForDeadTime());
            m_ButtonMesh.transform.localPosition = new Vector3(0f, 0.065f, 0f);
        }
       
    }


    [ContextMenu("TestTriggerEnter")]
    public void TestEnter()
    {
        m_ButtonMesh.transform.localPosition = new Vector3(0f, 0.033f, 0f);
    }

    [ContextMenu("TestTriggerExit")]
    public void TestExit()
    {
        m_ButtonMesh.transform.localPosition = new Vector3(0f, 0.065f, 0f);
    }
    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }
}
