using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnterPlay : MonoBehaviour
{
    [Tooltip("视频播放器")]
    public VideoPlayer videoPlayer;
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 这里可以添加其他逻辑，比如开始游戏等
            Debug.Log("Player entered the play area.");
            AudioManager.Instance.StopMusic();
            videoPlayer.Play();
            
            // 设置回调，当视频播放完毕后执行
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // 视频播放完毕后执行的逻辑
        AudioManager.Instance.PlayMusic(clip);
        // 停止视频播放
        vp.Stop();
        
        Destroy(gameObject);
        // 这里可以添加其他逻辑，比如切换场景等
        // GameArchitecture.Interface.GetSystem<ISwitchSceneSystem>().SwitchSceneAsync("NextSceneName");
    }
}
