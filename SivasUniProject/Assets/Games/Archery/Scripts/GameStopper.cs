using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
public class GameStopper : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        pause = !pause;
    }

    [SerializeField] private int duration;
    private bool pause;
    [SerializeField] private int remainingDuration;
    [SerializeField] private GameObject m_TimerWarning;
    [SerializeField] private TextMeshProUGUI m_UGUI;

    [SerializeField] private Image UIfill;
    [SerializeField] private Text UItext;
    [SerializeField] private Image m_UITransparent;
    [SerializeField] private GameObject m_scoreText;
    [SerializeField] private ObjectSpawner m_Spawner;
    private void Start()
    {
        Being(duration);
        m_Spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<ObjectSpawner>();
    }

    private void Being(int second)
    {
        remainingDuration= second;
        StartCoroutine(UpdateTimer()); 
    }

    IEnumerator UpdateTimer()
    {

        float green = 1f;
        float blue = 1f;

        while(remainingDuration > 0) { 
            if (!pause)
            {
                if (remainingDuration <= 5f)
                {
                    m_TimerWarning.SetActive(true);
                    m_UGUI.text = "Süreniz Bitiyor! " + remainingDuration.ToString();
                    m_UGUI.color = new Color(1f, green, blue,1f);
                    green -= 0.2f;
                    blue -= 0.2f;
                }
                UItext.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                UIfill.fillAmount= Mathf.InverseLerp(0,duration,remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }            
        }
        OnEnd();
        yield return new WaitForSeconds(1.5f);
        OpenCanvas();
        yield return null;
    }

    private void OnEnd()
    {
        UIfill.enabled = false;
        UItext.enabled = false;
        m_UITransparent.enabled = false;
        m_scoreText.SetActive(false);
        m_UGUI.text = "Oyun Bitti!";
        m_Spawner.EndSpawner();
        Debug.Log("Ending Function");
    }


    [SerializeField]
    private GameObject m_EndCanvas;

    private void OpenCanvas()
    {
        m_EndCanvas.SetActive(true);
        //SceneManager.LoadScene("Archery_LevelScoreScene");

        m_EndCanvas.GetComponentInChildren<FinalMenuYourScore>().ShowScoreOnCanvas();

    }
}
