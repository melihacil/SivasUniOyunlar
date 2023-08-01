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


    private void Start()
    {
        m_LeftKatana = leftHand.modelParent.gameObject;
        m_RightKatana = rightHand.modelParent.gameObject;
    }


    public void LoadThisScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);

    }
    [SerializeField]
    GameObject m_RightKatana;
    [SerializeField]
    GameObject m_LeftKatana;
    [SerializeField]
    GameObject m_LeftLightSaber;
    [SerializeField]
    GameObject m_RightLightSaber;

    bool m_ChangeModelType = true;
    [ContextMenu("Test")]
    public void ChangeModel()
    {      
        if (m_ChangeModelType)
        {
            m_ChangeModelType = !m_ChangeModelType;
            m_LeftLightSaber.SetActive(true);
            m_RightLightSaber.SetActive(true);
            m_LeftKatana.SetActive(false);
            m_RightKatana.SetActive(false);
        }
        else
        {
            m_ChangeModelType = !m_ChangeModelType;
            m_LeftLightSaber.SetActive(false);
            m_RightLightSaber.SetActive(false);
            m_LeftKatana.SetActive(true);
            m_RightKatana.SetActive(true);
        }
    }


}
