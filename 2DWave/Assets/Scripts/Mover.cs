using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float xDelta;
    [SerializeField]
    private float  xMoveSpeed;

    [Header("Virtical Movement")]
    [SerializeField]
    private float yDelta;
    [SerializeField]
    private float yMoveSpeed;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; 
    }

    private void FixedUpdate()
    {
        if (xMoveSpeed != 0)
        {
            float x = startPosition.x + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        if (yMoveSpeed != 0)
        {
            float y = startPosition.y + yDelta * Mathf.Sin(Time.time * yMoveSpeed);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
