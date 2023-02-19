using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    bool isJump;
    public float JumpPower;
    public int itemCount;
    AudioSource audio;
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isJump == false) 
        {
            isJump= true;
            rigid.AddForce(new Vector3(0,JumpPower,0),ForceMode.Impulse);
        }

    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal")*0.5f;
        float v = Input.GetAxisRaw("Vertical") * 0.5f;

        rigid.AddForce(new Vector3(h, 0, v),ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
            isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
        }
    }
}
