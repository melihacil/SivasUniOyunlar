using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Gamehandler : MonoBehaviour
{

    [SerializeField]
    VideoClip m_ArcheryClip;

    //[SerializeField]
    //List<VideoClip> m_videoClips = new List<VideoClip>();


    [SerializeField]
    List<VideoClipObject> m_videoClipObjects = new List<VideoClipObject>();



    public VideoClip GetVideoClip(string GameName)
    {

        VideoClip videoClip = null;
        
        videoClip = m_videoClipObjects.Find(x => x.m_Name == GameName).m_VideoClip;
        Debug.Log("Found = " + videoClip.name);
        return videoClip;
    }

}
