using System;
using UnityEngine;
using DG.Tweening; // 如果你用 DOTween

[RequireComponent(typeof(CanvasGroup))]
public class TextFader : MonoBehaviour
{
    public CanvasGroup cg;
    public float fadeInDuration = 0.5f;
    public float fadeOutDuration = 0.5f;

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0; // 初始透明度设置为0
    }

    public void FadeIn()
        => cg.DOFade(1, fadeInDuration);

    public void FadeOut()
        => cg.DOFade(0, fadeOutDuration);
}