using System.Collections;
using UnityEngine;

/// <summary>
/// 让 Animator 里的单个动画每隔 3-5 秒随机播放一次（附带随机播放速度）。
/// </summary>
public class RandomAnimationSpeed : MonoBehaviour
{
    [Header("若留空则自动在本对象上寻找 Animator")]
    public Animator animator;

    // 如果你只有一个状态机层，stateHash 写 0 即可；
    // 如需指定动画可直接填写动画片段或状态机中对应的 State 名称
    [Tooltip("要播放的 Animator 状态名（留空则直接重播当前 State）")]
    public string stateName = "";

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(PlayLoop());
    }

    IEnumerator PlayLoop()
    {
        while (true)
        {
            // 1. 随机等待 3~5 秒
            yield return new WaitForSeconds(Random.Range(3f, 5f));

            // 3. 从头播放动画
            if (string.IsNullOrEmpty(stateName))
            {
                // 重播当前动画
                animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0f);
            }
            else
            {
                // 播放指定动画 State
                animator.Play(stateName, 0, 0f);
            }
        }
    }
}