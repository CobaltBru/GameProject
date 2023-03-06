using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    Animator anim;
    SpriteRenderer spriteRenderer;
    BoxCollider2D collid;


    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        collid= GetComponent<BoxCollider2D>();
        Invoke("Think", 3);
    }

    
    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.5f, rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }

    void Think()
    {
        //Set Next Active
        nextMove = Random.Range(-1,2);
        
        //Sprite Animation
        anim.SetInteger("WalkSpeed", nextMove);
        //Flip Sprite
        if(nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        //Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

    void Turn()
    {
        if (spriteRenderer.flipY == true) nextMove = 0;
        else nextMove *= -1;
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;
        CancelInvoke();
        Invoke("Think", 3);
    }

    public void OnDamaged()
    {
        //Sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //Sprite Flip Y
        spriteRenderer.flipY = true;
        //Collider Diable
        collid.enabled= false;
        //Die Effect Jump
        rigid.AddForce(Vector2.up*5,ForceMode2D.Impulse);
        //Destroy
        StartCoroutine(Croute());
    }

    IEnumerator Croute()
    {
        yield return new WaitForSeconds(3);
        DeActive();
    }

    public void DeActive()
    {
        gameObject.SetActive(false);
    }
}
