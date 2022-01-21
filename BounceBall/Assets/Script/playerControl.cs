using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float jumpPower = 13f;
    public float speed = 5f;
    public Rigidbody2D playerRegidbody;
    void Start()
    {
        playerRegidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float fhorizontal = Input.GetAxis("Horizontal");
        float xspeed = fhorizontal * speed;
        transform.Translate(Vector2.right*xspeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D pos = col.GetContacts(col.contacts);

        if (transform.position.y>col.contacts)
        {
            playerRegidbody.velocity = new Vector2(0, 0);
            playerRegidbody.velocity = new Vector2(0, jumpPower);
        }
    }
}
