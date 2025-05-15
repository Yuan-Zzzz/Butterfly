using System;
using System.Collections;
using System.Collections.Generic;
using ProjectAssets.Scripts.Game.System;
using UnityEngine;

public class SwitchSceneTrigger : MonoBehaviour
{
    public string SceneName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameArchitecture.Interface.GetSystem<ISwitchSceneSystem>().SwitchSceneAsync(SceneName);
            if(AudioManager.Instance!=null)
            {
                AudioManager.Instance.MuteTransition(1.5f,1.5f);
            }
        }
    }
}
