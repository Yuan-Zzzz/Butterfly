using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum DetectType
{
    EnterToClose,
    EnterToPlay
}

public class DetectPlace : MonoBehaviour
{
    public DetectType type;
    public PlayableDirector aimDirector;
    public KeyCode needKey;

    [Header("表现层")]
    public bool playerHasEnter;

    private void Start()
    {
        aimDirector.stopped += OnPlayableDirectorStopped;
        aimDirector.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHasEnter = other.tag == "Player";
        
        if (other.tag == "Player" && !aimDirector.gameObject.activeSelf && type == DetectType.EnterToClose)
        {
            aimDirector.gameObject.SetActive(true);
            aimDirector.Play();
        }
        
        
    }
    
    //todo:在open的时候，人物不能动，要等待播放完毕



    private void Update()
    {
        switch (type)
        {
            case DetectType.EnterToPlay:
                if (playerHasEnter && !aimDirector.gameObject.activeSelf && Input.GetKey(needKey))
                {
                    aimDirector.gameObject.SetActive(true);
                    aimDirector.Play();
                }
                break;
            case DetectType.EnterToClose:
                if (playerHasEnter  && Input.GetKey(needKey))
                {
                    aimDirector.gameObject.SetActive(false);
                    aimDirector.Stop();
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHasEnter = false;
        }
    }

    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        if (director == aimDirector)
        {
            director.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
