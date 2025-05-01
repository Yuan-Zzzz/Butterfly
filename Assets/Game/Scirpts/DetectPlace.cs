using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DetectPlace : MonoBehaviour
{
    public PlayableDirector aimDirector;

    [Header("表现层")]
    public bool playerHasEnter;

    private void Start()
    {
        //aimDirector.stopped += OnPlayableDirectorStopped;
        //aimDirector.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            aimDirector.Play();
        }
    }
}
