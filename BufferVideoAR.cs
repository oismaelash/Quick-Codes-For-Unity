using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class BufferVideoAR : MonoBehaviour
{
    private static BufferVideoAR instance;
    public static BufferVideoAR Instance
    {
        get
        {
            if(instance == null)
                instance = new GameObject("BufferVideoAR").AddComponent<BufferVideoAR>();

            return instance;
        }
    }
    private bool cleanVideosBuffer;
    public bool CleanVideosBuffer
    {
        get
        {
            return cleanVideosBuffer;
        }
        set
        {
            cleanVideosBuffer = value;
            CleanVideoOnBuffer();
        }
    }

    private const string nameFolder = "VideosBuffer";
    public Action<bool, string> OnGetVideo;

    public void GetVideoForBuffer(string uri)
    {
        StartCoroutine(GetVideo_Coroutine(uri));
    }

    private IEnumerator GetVideo_Coroutine(string ulrVideo)
    {
        Debug.Log("Start get video");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(ulrVideo))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.LogError("GetVideo_Coroutine:: " + webRequest.error);
                OnGetVideo?.Invoke(true, webRequest.error);
            }
            else
            {
                Debug.Log("GetVideo_Coroutine");
                string nameVideo = ulrVideo.Split('/')[ulrVideo.Split('/').Length-1];
                string pathVideo = Path.Combine(GetPathVideos(), nameVideo);
                byte[] bytesVideo = webRequest.downloadHandler.data;

                if (!Directory.Exists(GetPathVideos()))
                    Directory.CreateDirectory(GetPathVideos());

                File.WriteAllBytes(pathVideo, bytesVideo);
                OnGetVideo?.Invoke(false, pathVideo);
            }
        }
    }

    private void CleanVideoOnBuffer()
    {
        if (cleanVideosBuffer)
        {
            string[] videos = Directory.GetFiles(GetPathVideos());

            foreach(string video in videos)
            {
                File.Delete(video);
            }

            Debug.Log("CleanVideoOnBuffer");
        }
    }

    private string GetPathVideos()
    {
        return Path.Combine(Application.persistentDataPath, nameFolder);
    }
}
