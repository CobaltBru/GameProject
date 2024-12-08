using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float yOffset = 8;
    [SerializeField]
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothTime);
    }
    public void ChangeBackgroundColor()
    {
        float colorHue = Random.Range(0, 10);
        colorHue *= 0.1f;
        mainCamera.backgroundColor = Color.HSVToRGB(colorHue, 0.6f, 0.8f);
    }
}
