using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float distance;

    private void Awake()
    {
        distance = Vector3.Distance(transform.position, target.position);
    }

    private void LateUpdate()
    {
        if(target == null) return;

        transform.position = target.position + transform.rotation * new Vector3(0,0,-distance);
    }
}
