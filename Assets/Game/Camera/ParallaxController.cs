using UnityEngine;

[ExecuteAlways]
public class ParallaxController : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform;      // 背景层的 Transform
        [Range(0f, 1f)]
        public float parallaxFactor = 0.5f;   // 0 = 固定不动, 1 = 与摄像机同速
        private Vector3 initialPosition;      // 初始位置缓存

        public void Initialize() => initialPosition = layerTransform.position;
        public void UpdateParallax(Vector3 deltaCam)
        {
            // 根据摄像机的移动量和视差因子计算层的偏移
            Vector3 newPos = initialPosition + deltaCam * parallaxFactor;
            layerTransform.position = new Vector3(newPos.x, newPos.y, layerTransform.position.z);
        }
    }

    public ParallaxLayer[] layers;     // 在 Inspector 中配置各背景层
    private Transform camTransform;
    private Vector3 previousCamPos;

    void Start()
    {
        camTransform = Camera.main.transform;
        previousCamPos = camTransform.position;
        foreach (var layer in layers)
            layer.Initialize();
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = camTransform.position - previousCamPos;
        foreach (var layer in layers)
            layer.UpdateParallax(deltaMovement);
        previousCamPos = camTransform.position;
    }
}