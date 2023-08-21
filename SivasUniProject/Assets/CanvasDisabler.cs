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
        m_Canvas.enabled = false;
    }
    [ContextMenu("TestEnable")]
    public void CanvasEnabler()
    {
        m_Canvas.enabled = true;      
    }
}
