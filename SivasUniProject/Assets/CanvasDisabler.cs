using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisablerManager : MonoBehaviour { 

    [SerializeField]
    private Canvas m_Canvas;

    private void Start()
    {
        m_Canvas = GetComponent<Canvas>();
    }

    [ContextMenu("TestDisable")]
    public void CanvasDisable()
    {
        Debug.Log("Test 1");
        m_Canvas.enabled = false;
        Debug.Log("Test 2");
    }
    [ContextMenu("TestEnable")]
    public void CanvasEnabler()
    {
        m_Canvas.enabled = true;      
    }
}
