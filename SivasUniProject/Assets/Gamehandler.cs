using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Gamehandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    VideoClip m_ArcheryClip;

    [SerializeField]
    VideoClip m_ArcheryClip;

    [SerializeField]
    VideoClip m_ArcheryClip;


    [SerializeField]
    List<VideoClip> m_videoClips = new List<VideoClip>();

    // Update is called once per frame
    void Update()
    {
        
    }



    private string m_GameName = "okçuluk";

    public void ChangeSelectedGame(string GameName)
    {
       this.m_GameName = GameName;
    }


}
