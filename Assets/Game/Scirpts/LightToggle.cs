using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

[RequireComponent(typeof(Light2D))]
public class LightFadeToggle : MonoBehaviour
{
    [Header("目标 Light2D")]
    public Light2D targetLight;

    [Header("切换按键")]
    public KeyCode toggleKey = KeyCode.Z;

    [Header("渐变时长")]
    public float fadeDuration = 1f;

    [Header("开启时的强度")]
    public float onIntensity = 1f;

    [Header("关闭时的强度")]
    public float offIntensity = 0f;

    private bool isOn;

    private void Awake()
    {
        // 自动获取 Light2D
        if (targetLight == null)
            targetLight = GetComponent<Light2D>();

        // 初始化状态
        isOn = targetLight.intensity > (offIntensity + 0.01f);
        // 直接设置到 offIntensity 或 onIntensity
        targetLight.intensity = isOn ? onIntensity : offIntensity;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // // 检测是否按下切换键
         if (!other.CompareTag("Player")) return;
        if (Input.GetKeyDown(toggleKey))
        {
            // 切换状态
            isOn = !isOn;

            // DOTween 插值强度
            float start = targetLight.intensity;
            float end = isOn ? onIntensity : offIntensity;

            // 若之前有在跑的 tween，可以先 Kill
            DOTween.Kill(targetLight);

            DOTween.To(
                () => start,
                x =>
                {
                    start = x;
                    targetLight.intensity = x;
                },
                end,
                fadeDuration
            );
        }
    }
}
