using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisabler : MonoBehaviour
{
    public void CanvasDisable()
    {
        this.gameObject.SetActive(false);
    }

    public void CanvasEnabler()
    {
        this.gameObject.SetActive(true);
    }
}
