using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoCreditos : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] string videoName;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }
    private void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(videoName);
    }
}
