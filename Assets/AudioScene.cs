using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScene : MonoBehaviour
{
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        if (AudioManager.Instance!=null)
        {
            AudioManager.Instance.PlayMusic(clips[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
