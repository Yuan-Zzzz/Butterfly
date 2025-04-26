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
    [Header("开/关 灯强度")]
    public float onIntensity = 1f;
    public float offIntensity = 0f;

    private bool isOn;
    private bool isPlayerInZone;               // 玩家是否在触发区

    private void Awake()
    {
        if (targetLight == null)
            targetLight = GetComponent<Light2D>();
        isOn = targetLight.intensity > (offIntensity + 0.01f);
        targetLight.intensity = isOn ? onIntensity : offIntensity;
    }

    private void Update()
    {
        // 每帧检测：玩家在区域内 & 按下开关键
        if (isPlayerInZone && Input.GetKeyDown(toggleKey))
        {
            isOn = !isOn;
            float start = targetLight.intensity;
            float end   = isOn ? onIntensity : offIntensity;
            DOTween.Kill(targetLight);
            DOTween.To(() => start, x => {
                start = x;
                targetLight.intensity = x;
            }, end, fadeDuration);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInZone = true;          // 进入触发区
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInZone = false;         // 离开触发区
    }
}