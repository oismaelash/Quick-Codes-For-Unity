using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]
public class ShowVideoPlayerUI : MonoBehaviour
{
    [Header("Video Player")]
    [SerializeField] private RawImage m_RawImage;
    [SerializeField] private VideoPlayer m_VideoPlayer;

    private void Start()
    {
        StartCoroutine(StartVideo_Coroutine());
    }

    private IEnumerator StartVideo_Coroutine()
    {
        m_VideoPlayer.EnableAudioTrack(0, true);
        m_VideoPlayer.SetTargetAudioSource(0, GetComponent<AudioSource>());

        m_VideoPlayer.Prepare();

        while (!m_VideoPlayer.isPrepared)
        {
            yield return null;
        }

        m_RawImage.texture = m_VideoPlayer.texture;

        m_VideoPlayer.Play();

        GetComponent<AudioSource>().Play();

        while (m_VideoPlayer.isPlaying)
        {
            print("Video isPlaying");
            yield return null;
        }

        print("Done Playing Video");
    }
}
