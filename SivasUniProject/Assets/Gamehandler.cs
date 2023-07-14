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

        foreach (VideoClipObject obj in m_videoClipObjects)
        {
            Debug.Log( obj.sceneType +" "+obj.m_GameName);
        }


        VideoClip videoClip = null;
        try
        {
            videoClip = m_videoClipObjects.Find(x => x.m_GameName == GameName).m_VideoClip;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString() + " Not FOUND! Defaulting to main video");
            
        }
        finally
        {
            Debug.Log("Found = " + videoClip);
        }
        return videoClip;
    }


    public Scenes GetSceneType (string GameName)
    {

        Scenes sceneToLoad = Scenes.Archery;
        try
        {
            sceneToLoad = m_videoClipObjects.Find(x => x.m_GameName == GameName).sceneType;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString() + " Not FOUND! Defaulting to main game scene");
        }
        finally
        {
            Debug.Log("Found Scene Type = " + sceneToLoad.ToString());
        }
        return sceneToLoad;
    }

}
