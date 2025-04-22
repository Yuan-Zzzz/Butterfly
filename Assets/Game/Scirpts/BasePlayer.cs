using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasePlayer : MonoBehaviour
{
    [Header("参数展示")]
    public bool isRight = true;//默认朝向右边
    public bool isGround = false;
    public bool isMove = true;

    [Header("参数修改")] 
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 0.25f;
    public float upPower = 0.25f;
    public float rayDistance = 0.25f;
    public LayerMask groundLayer;

    [Header("临时使用")] 
    public SpriteRenderer zhuWang;
    public GameObject huaYuan;

    //Awake获取的私有变量
    private float scaleX;
    private Rigidbody2D rb;
    private Animator anim;

    private bool hasEnterMove;
    //实际变量
    public bool IsRight
    {
        get
        {
            return isRight;
        }
        set
        {
            isRight = value;
            
            if (isRight)
            {
                transform.DOScaleX(scaleX, rotateSpeed);
            }
            else
            {
                transform.DOScaleX(-scaleX, rotateSpeed);
            }
        }
    }

    public bool IsGround
    {
        get
        {
            return isGround;
        }
        set
        {
            isGround = value;
            anim.SetBool("isGround",value);
        }
    }

    public bool IsMove
    {
        get
        {
            return isMove;
        }
        set
        {
            isMove = value;
            anim.SetBool("isMove",value);
        }
    }

    private void Awake()
    {
        scaleX = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        //行动方向控制
        if (Input.GetKey(KeyCode.A))
        {
            if (IsRight)
            {
                IsRight = false;
            }
            transform.position += Vector3.left * moveSpeed;
            hasEnterMove = true;
        }else if (Input.GetKey(KeyCode.D))
        {
            if (!IsRight)
            {
                IsRight = true;
            }
            transform.position += Vector3.right * moveSpeed;
            hasEnterMove = true;
        }
        
        
        if(Input.GetKey(KeyCode.X))
        {
            //扇动翅膀
            anim.Play("Fanning");
            //固定高度，此时左右移动和上下移动全部禁用
            //DoMove 1.6
            transform.DOMoveY(1.6f, 2f);
            zhuWang.DOFade(0, 2f);
        }
        
        if (Input.GetKey(KeyCode.C))
        {
            //释放磷粉
            anim.Play("Release");
        }

        if (Input.GetKey(KeyCode.F1))
        {
            huaYuan.SetActive(true);
        }
        
        //空格充气向上
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up*upPower,ForceMode2D.Impulse);
        }
        
        
        
        //动画切换
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
        if (hit.collider != null)
        {
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }//射线检测
        
        
        IsMove = hasEnterMove;//输入检测
        hasEnterMove = false;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position + Vector3.down*rayDistance);
    }
}
