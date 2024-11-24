
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float jumpForce = 8.0f;
    private Rigidbody2D rigid2D;

    public bool isLongJump = false;

    public LayerMask groundLayer;
    public CapsuleCollider2D capsuleCollider2D;
    public bool isGrounded;
    public Vector3 footPosition;

    public int maxJumpCount = 2;
    public int currentJumpCount = 0;
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        Bounds bounds = capsuleCollider2D.bounds;

        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if(isGrounded == true && rigid2D.velocity.y <=0)
        {
            currentJumpCount = maxJumpCount;
        }

        if(isLongJump && rigid2D.velocity.y>0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }

    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }
    public void Jump()
    {
        if (currentJumpCount > 0)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCount--;
        }
        
    }
}
