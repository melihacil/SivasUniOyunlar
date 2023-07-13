using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    [SerializeField] private float treshhold = 0.1f;
    [SerializeField] private float deadzone=0.2f;

    private Vector3 startPos;
    public GameObject Button;
    private ConfigurableJoint joint;

    public UnityEvent press;
    public UnityEvent released;

    GameObject presser;
    bool ispressed;

    private void Start()
    {
        ispressed = false;
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

    }
    private void Update()
    {
        if(!ispressed && GetValue() + treshhold >= 1)
        {
            Pressed();
            
        }
        if (ispressed && GetValue() - treshhold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadzone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }
    private void Pressed()
    {
        ispressed = true;
        press.Invoke();
        Debug.Log("butona basýldý");
           
        
    }
    private void Released()
    {
        ispressed = false;
        press.Invoke();
        Debug.Log("butona tekrar basýldý");
    }
}

