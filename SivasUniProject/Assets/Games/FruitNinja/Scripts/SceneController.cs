using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
public class SceneController : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField]
    XRController leftHand;
    [SerializeField]
    XRController rightHand;


    public void LoadThisScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);

    }



}
