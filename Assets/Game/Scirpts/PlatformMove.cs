using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [Header("平台移动速度")]
    public float moveSpeed = 2f;

    [Header("停留时间")]
    public float waitTime = 1f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool shouldMove = false;
    private float stayTimer = 0f;
    private bool playerOnPlatform = false;

    private void Start()
    {
        startPos = transform.position;
        targetPos = transform.position; // 初始终点设为当前位置
    }

    public void SetTargetPosition(Vector3 newTarget)
    {
        targetPos = newTarget;
        shouldMove = false; // 重设移动标志
        stayTimer = 0f;
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= waitTime)
            {
                shouldMove = true;
            }
        }

        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = true;
            stayTimer = 0f;
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = false;
            stayTimer = 0f;
            shouldMove = false;
        }
    }
}