using UnityEngine;

public class TriggerTarget : MonoBehaviour
{
    [Tooltip("关联的平台")]
    public PlatformMove targetPlatform;

    [Tooltip("新的目标位置")]
    public Vector3 newTargetPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && targetPlatform != null)
        {
            Debug.Log("Player entered trigger area. Setting new target position.");
            targetPlatform.SetTargetPosition(newTargetPosition);
        }
    }
}