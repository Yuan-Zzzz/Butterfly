using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackArea"))
        {
            GetComponent<SpriteRenderer>().DOFade(0, 0.5f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
