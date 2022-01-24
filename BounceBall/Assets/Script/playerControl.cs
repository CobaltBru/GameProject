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
    void OnCollisionStay2D(Collision2D collision)
    {
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        int length = collision.GetContacts(contacts);
        for (int i = 0; i < length; i++) 
            {
                if (contacts[i].normal.y > 0.7f)
                {
                    playerRegidbody.velocity = new Vector2(0, jumpPower);
                break;
                }
            }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag=="Dead")
        {
            Destroy(gameObject);
        }
        if (col.tag == "Success")
        {
            col.GetComponent<GemScript>().DestroyGem(transform.position);
        }
    }


}
