using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2f;
    public GameObject menu;
    public InputActionProperty showButton;
    public GameObject leftHandRay;
    public GameObject rightHandRay;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (showButton.action.WasPressedThisFrame())
        //{
        //    menu.SetActive(!menu.activeSelf);
        //    menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        //    leftHandRay.SetActive(!leftHandRay.activeSelf);
        //    rightHandRay.SetActive(!rightHandRay.activeSelf);
        //}

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }
}
