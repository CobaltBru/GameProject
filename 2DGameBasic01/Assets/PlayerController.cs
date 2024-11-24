using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement2D.Move(x);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        if(Input.GetKey(KeyCode.Space))
        {
            movement2D.isLongJump = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            movement2D.isLongJump = false;
        }
    }
}
