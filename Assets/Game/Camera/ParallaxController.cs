using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [Tooltip("主相机引用")]
    public Transform cameraTransform;
    [Tooltip("视差因子 (0~1)：越小越远，越大越近")]
    public Vector2 parallaxFactor = new Vector2(0.5f, 0f);

    private Vector3 previousCamPos;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
        previousCamPos = cameraTransform.position;
    }

    void Update()
    {
        Vector3 camPos = cameraTransform.position;
        Vector3 delta = previousCamPos - camPos;

        // 按比例移动背景
        Vector3 move = new Vector3(delta.x * parallaxFactor.x, delta.y * parallaxFactor.y, 0f);
        transform.position += move;

        previousCamPos = camPos;
    }
}