using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float movePower = 1f;
    GameObject traceTarget;
    bool isTracing;
    //public Animator animator;
    Animator animator;
    Vector3 movement;
    private Rigidbody2D rigid2D;
    int moveFlag = 0;  // 0: Front , 1:Left, 2: Right, 3: Back
    float x, y;

    void Start()
    {
        animator = GetComponent<Animator>();
        //animator = ani;
        rigid2D = GetComponent<Rigidbody2D>();
        StartCoroutine("ChangeMovement");
    }

    public void Spawn(Animator ani)
    {
        animator = GetComponent<Animator>();
        //animator = ani;
        rigid2D = GetComponent<Rigidbody2D>();
        StartCoroutine("ChangeMovement");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     
        if(other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;
            StopCoroutine("ChangeMovement");
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
            //StopCoroutine("ChangeMovement");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
            StopCoroutine("ChangeMovement");
        }
    }

    void changeAni(int moveFlag)
    {
        if (moveFlag == 0)
        {
            animator.SetBool("isFront", true);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isBack", false);
        }
        else if (moveFlag == 1)
        {
            animator.SetBool("isFront", false);
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isBack", false);
        }
        else if (moveFlag == 2)
        {
            animator.SetBool("isFront", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", true);
            animator.SetBool("isBack", false);

        }
        else if (moveFlag == 3)
        {
            animator.SetBool("isFront", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isBack", true);
        }
    }

    IEnumerator ChangeMovement()
    {
        moveFlag = Random.Range(0, 4);
        changeAni(moveFlag);
        yield return new WaitForSeconds(3f);
        StartCoroutine("ChangeMovement");
    }

    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";
        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
            else if (playerPos.y < transform.position.y)
                dist = "Back";
            else if (playerPos.y > transform.position.y)
                dist = "Front";
        }
        else
        {
            if (moveFlag == 0)
                dist = "Front";
            if (moveFlag == 1)
                dist = "Left";
            if (moveFlag == 2)
                dist = "Right";
            if (moveFlag == 3)
                dist = "Back";
        }

        if (dist == "Front")
        {
            moveVelocity = Vector3.forward;
            //transform.localScale = new Vector3(1, 1, 0);
            changeAni(0);
            x = 0;
            y = -1;
        }
        else if(dist == "Left")
        {
            moveVelocity = Vector3.left;
            //transform.localScale = new Vector3(1, 1, 0);
            changeAni(1);
            y = 0;
            x = -1;
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            changeAni(2);
            //transform.localScale = new Vector3(-1, 1, 0);
            y = 0;
            x = 1;
        }
        else if (dist == "Back")
        {
            moveVelocity = Vector3.back;
            changeAni(3);
            //transform.localScale = new Vector3(-1, 1, 0);
            x = 0;
            y = 1;
        }
        rigid2D.velocity = new Vector3(x, y, 0) * movePower;
    }
}
