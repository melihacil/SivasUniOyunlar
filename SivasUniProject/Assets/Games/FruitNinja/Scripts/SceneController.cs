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

    [SerializeField]
    GameObject m_LightSaber;
    [SerializeField]
    GameObject m_Katana;

    bool m_ChangeModelType = true;
    [ContextMenu("Test")]
    public void ChangeModel()
    {

        GameObject obj1 = leftHand.modelPrefab.gameObject;
        GameObject obj2 = rightHand.modelPrefab.gameObject;

        obj1.SetActive(false);
        obj2.SetActive(false);
        //if (m_ChangeModelType)
        //{
        //    m_ChangeModelType = !m_ChangeModelType;
        //    leftHand.modelPrefab = m_LightSaber.transform;
        //    rightHand.modelPrefab = m_LightSaber.transform;
        //}
        //else
        //{
        //    m_ChangeModelType = !m_ChangeModelType;
        //    leftHand.modelPrefab = m_Katana.transform;
        //    rightHand.modelPrefab = m_Katana.transform;
        //}
    }


}
