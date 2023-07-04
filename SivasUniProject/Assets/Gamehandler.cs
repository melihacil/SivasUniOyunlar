using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Gamehandler : MonoBehaviour
{

    [SerializeField]
    VideoClip m_ArcheryClip;

    [SerializeField]
    List<VideoClip> m_videoClips = new List<VideoClip>();

}
