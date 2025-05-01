using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Vase : MonoBehaviour
{
    [Tooltip("渐变消失的时长（秒）")]
    public float fadeDuration = 1f;
    
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    private bool _playerInRange = false;

    void Awake()
    {
        // 获取组件引用
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D   = GetComponent<Collider2D>();

        // 确保 Collider2D 为触发器
        if (!_collider2D.isTrigger)
            _collider2D.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 要求玩家物体打了 Player 标签
        if (other.CompareTag("Player"))
            _playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _playerInRange = false;
    }

    void Update()
    {
        // 检测玩家在范围内且按下 Z
        if (_playerInRange && Input.GetKeyDown(KeyCode.Z))
            FadeOutAndDestroy();
    }

    private void FadeOutAndDestroy()
    {
        // 禁用碰撞体，避免重复触发
        _collider2D.enabled = false;
        // DOFade 将 SpriteRenderer 的 alpha 从当前值 tween 到 0
        _spriteRenderer.DOFade(0f, fadeDuration)
            .OnComplete(() => Destroy(gameObject));
    }
}