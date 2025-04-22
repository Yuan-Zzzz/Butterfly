using System;
using UnityEngine;
using DG.Tweening;

public class BasePlayer : MonoBehaviour
{
    [Header("参数展示")]
    public bool isRight = true;    // 默认朝向右边
    public bool isGround = false;
    public bool isMove = true;

    [Header("参数修改")]
    public float moveSpeed = 3f;   // 最大移动速度（单位：m/s）
    public float rotateSpeed = 0.25f;
    public float upPower = 5f;     // 跳跃冲量
    public float rayDistance = 0.25f;
    public LayerMask groundLayer;

    [Header("加减速参数")]
    public float acceleration = 10f;   // 加速度（单位：m/s²）
    public float deceleration = 8f;    // 减速度（单位：m/s²）



    // —— 私有字段 —— 
    private float scaleX;
    private Rigidbody2D rb;
    private Animator anim;

    // 用于平滑加减速的当前横向速度
    private float currentVelocityX = 0f;

    // 标记本帧是否曾经移动（用于动画）
    private bool hasEnterMove;

    // —— 属性封装 —— 
    public bool IsRight
    {
        get => isRight;
        set
        {
            isRight = value;
            float targetScaleX = value ? scaleX : -scaleX;
            transform.DOScaleX(targetScaleX, rotateSpeed);
        }
    }

    public bool IsGround
    {
        get => isGround;
        set
        {
            isGround = value;
            anim.SetBool("isGround", value);
        }
    }

    public bool IsMove
    {
        get => isMove;
        set
        {
            isMove = value;
            anim.SetBool("isMove", value);
        }
    }

    private void Awake()
    {
        scaleX = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // —— 1. 读取左右输入 —— 
        float inputX = 0f;
        if (Input.GetKey(KeyCode.A)) inputX = -1f;
        else if (Input.GetKey(KeyCode.D)) inputX = +1f;

        // —— 2. 翻转角色 —— 
        if (inputX > 0 && !IsRight) IsRight = true;
        else if (inputX < 0 && IsRight) IsRight = false;

        // —— 3. 计算当前速度 —— 
        float targetSpeed = inputX * moveSpeed;
        float accel = (Mathf.Abs(inputX) > 0.01f) ? acceleration : deceleration;
        currentVelocityX = Mathf.MoveTowards(
            currentVelocityX,
            targetSpeed,
            accel * Time.deltaTime
        );

        // —— 4. 应用位移 —— 
        transform.position += Vector3.right * currentVelocityX * Time.deltaTime;
        hasEnterMove = Mathf.Abs(currentVelocityX) > 0.01f;

        // —— 5. 其他输入 —— 
        if (Input.GetKey(KeyCode.X))
        {
            anim.Play("Fanning");
            // 固定高度飞
            transform.DOMoveY(1.6f, 2f);
            //zhuWang.DOFade(0, 2f);
        }

        if (Input.GetKey(KeyCode.C))
        {
            anim.Play("Release");
        }

        if (Input.GetKey(KeyCode.F1))
        {
           // huaYuan.SetActive(true);
        }

        // —— 6. 空格跳跃 —— 
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * upPower, ForceMode2D.Impulse);
        }

        // —— 7. 地面检测 —— 
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            rayDistance,
            groundLayer
        );
        IsGround = hit.collider != null;

        // —— 8. 切换行走动画 —— 
        IsMove = hasEnterMove;
        hasEnterMove = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(
            transform.position,
            transform.position + Vector3.down * rayDistance
        );
    }
}
