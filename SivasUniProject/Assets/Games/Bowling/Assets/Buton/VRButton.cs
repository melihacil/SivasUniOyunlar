using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    
    //Butona dokunulduktan sonra içeride biraz beklemsini saðlayan özellik
    public float deadTime = 0.4f;
    //Bool deðeri dead time süresince butonun kilitli kalmasýný saðlýyor.
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
            Debug.Log("Tuþa bastýn");
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
            Debug.Log("Tuþ serbest kaldý");
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
