using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu]
public class VideoClipObject : ScriptableObject
{
    
    public VideoClip m_VideoClip;
    [SerializeField]
    public string m_Name;
}
