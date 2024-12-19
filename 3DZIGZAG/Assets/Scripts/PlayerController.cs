using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    private Movement movement;
    private float limitDeathY;

    private void Awake()
    {
        movement = GetComponent<Movement>();

        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;
    }

    private IEnumerator Start()
    {
        while(true)
        {
            if(gameController.IsGameStart == true)
            {
                movement.MoveTo(Vector3.right);
                yield break;
            }
            yield return null;
        }
    }

    private void Update()
    {
        if (gameController.IsGameOver == true) return;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = movement.MoveDirection == Vector3.forward ? Vector3.right : Vector3.forward;
            movement.MoveTo(direction);

            gameController.IncreaseScore();
        }

        if (transform.position.y < limitDeathY)
        {
            gameController.GameOver();
        }
    }
}
