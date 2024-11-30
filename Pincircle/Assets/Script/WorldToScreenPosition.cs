using UnityEngine;

public class WorldToScreenPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.zero;
    private Transform targetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        targetTransform = target;
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if(targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPosition + distance;
    }
}
