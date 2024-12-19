using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float increaseAmount;
    [SerializeField]
    private float increaseCycleTime;

    private Vector3 moveDirection;

    public Vector3 MoveDirection => moveDirection;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(increaseCycleTime);

            moveSpeed += increaseAmount;
        }
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
