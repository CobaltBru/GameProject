using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    bool isJump;
    public float JumpPower;
    public int itemCount;
    AudioSource audio;

    public GameManagerLogic manager;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }

        else if (other.tag == "Finish")
        {
            if(itemCount == manager.totalItemCount)
            {
                if (manager.stage == 1) SceneManager.LoadScene(0);
                //Clear;
                else SceneManager.LoadScene(manager.stage + 1);
            }
            else
            {
                //Restart
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
