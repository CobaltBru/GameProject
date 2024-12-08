using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float xMoveSpeed = 2;
    [SerializeField]
    private float xDelta = 2;
    private float xStartPosition;

    [Header("Virtical Movement")]
    [SerializeField]
    private float yMoveSpeed = 0.5f;
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        xStartPosition = transform.position.x;
    }

    public void MoveToX()
    {
        float x = xStartPosition + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void MoveToY()
    {
        rigid2D.AddForce(transform.up * yMoveSpeed, ForceMode2D.Impulse);
    }
}
