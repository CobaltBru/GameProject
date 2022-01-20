using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpPower = 10f;
    public Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.contacts[0].normal.y>0.7f)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.velocity = new Vector2(0, jumpPower);
        }
    }
}
