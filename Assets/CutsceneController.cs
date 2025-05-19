using System.Collections;
using System.Collections.Generic;
using ProjectAssets.Scripts.Game.System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;
    public AudioClip clip;

    void Start()
    {
        AudioManager.Instance.StopMusic();
        // 设置回调，当视频播放完毕后切换场景
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
        
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // if (AudioManager.Instance != null)
        // {
        //     AudioManager.Instance.MuteTransition(1.5f,1.5f);
        // }
        AudioManager.Instance.PlayMusic(clip);
        // 播放完毕，加载下一个场景
        // 这里可以添加淡出效果等
        GameArchitecture.Interface.GetSystem<ISwitchSceneSystem>().SwitchSceneAsync(nextSceneName);
        
    }
}
