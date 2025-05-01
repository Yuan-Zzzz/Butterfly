using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class ChessJar : MonoBehaviour
{
    [Header("交互设置")]
    [Tooltip("玩家必须打上的 Tag")]
    public string playerTag = "Player";
    [Tooltip("交互按键")]
    public KeyCode interactKey = KeyCode.Z;

    [Header("出现 & 移动")]
    [Tooltip("从初始位置向上移动的距离")]
    public float riseDistance = 2f;
    [Tooltip("向上移动的时长（秒）")]
    public float riseDuration = 1.5f;
    [Tooltip("渐显时长（秒）")]
    public float fadeDuration = 0.5f;

    // internal
    private SpriteRenderer _sr;
    private Collider2D     _col;
    private Vector3        _startPos;
    private bool           _playerInRange;
    private bool           _hasShown;

    void Awake()
    {
        _sr       = GetComponent<SpriteRenderer>();
        _col      = GetComponent<Collider2D>();
        _startPos = transform.position;

        // 确保是触发器
        if (!_col.isTrigger) _col.isTrigger = true;

        // 初始透明
        var c = _sr.color;
        _sr.color = new Color(c.r, c.g, c.b, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            _playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            _playerInRange = false;
    }

    void Update()
    {
        if (_playerInRange && !_hasShown && Input.GetKeyDown(interactKey))
        {
            _hasShown = true;
            _col.enabled = false;               // 防止重复触发
            ShowAndRise();
        }
    }

    private void ShowAndRise()
    {
        // 渐显
        _sr.DOFade(1f, fadeDuration);
        // 平滑向上移动
        transform.DOMoveY(_startPos.y + riseDistance, riseDuration)
            .SetEase(Ease.OutQuad).OnComplete(() =>
            {
                // 结束时禁用碰撞体
                _col.enabled = false;
                // 结束时销毁
                _sr.DOFade(0f, fadeDuration).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
    }
}