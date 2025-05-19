using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    private bool isPlaying = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPlaying)
        {
            isPlaying = true;
            Debug.Log("Player entered trigger area. Playing audio.");
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
