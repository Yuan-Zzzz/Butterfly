using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InteractionPrompt : MonoBehaviour
{
    public TextMeshProUGUI promptText; // 提示文本组件
    public string promptMessage = "Press E to interact"; // 提示信息
    public string interactionMessage = "You have interacted!"; // 交互信息
    public float fadeDuration = 0.5f; // 淡入淡出时间
    public bool requiresInput = false; // 是否需要玩家输入

    private CanvasGroup canvasGroup;
    private bool isPlayerInRange = false;
    private bool hasPrompted = false; // 标记是否已显示提示

    private void Awake()
    {
        canvasGroup = promptText.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0; // 初始时文本不可见
    }

    private void Update()
    {
        if (isPlayerInRange && !hasPrompted)
        {
            if (requiresInput)
            {
                promptText.text = promptMessage;
                ShowText();
            }
            else
            {
                promptText.text = promptMessage;
                ShowText();
            }
        }
        else if (isPlayerInRange && requiresInput && Input.GetKeyDown(KeyCode.E))
        {
            ShowText(interactionMessage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            hasPrompted = false; // 重置提示标记
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            HideText();
        }
    }

    private void ShowText(string message = null)
    {
        if (!string.IsNullOrEmpty(message))
        {
            promptText.text = message;
        }
        canvasGroup.DOFade(1, fadeDuration);
        hasPrompted = true; // 设置提示已显示
    }

    private void HideText()
    {
        canvasGroup.DOFade(0, fadeDuration);
        hasPrompted = false; // 重置提示标记
    }
}