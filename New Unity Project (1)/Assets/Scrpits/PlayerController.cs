using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float startX, startY;
    private Rigidbody2D rigid2D;
    Vector3 viewpos;
    private Animator anim;
    public GameObject targetobj; // not_feed ∂•¿Œ¡ˆ
    private SpriteRenderer spriteR;
    private Sprite[] seeds;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(startX, startY, 0);
        anim = GetComponent<Animator>();
        seeds = Resources.LoadAll<Sprite>("Sprites/Seed");

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Do_Farming();
        }

    }
   
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;



        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }

    void Do_Farming()
    {
        if(targetobj != null)
        {
            spriteR = targetobj.GetComponent<SpriteRenderer>();
            if (spriteR.sprite.name.Equals("not_feed"))
            {
                spriteR.sprite = seeds[0];
            }
            else if (spriteR.sprite.name.Equals("hoeing"))
            {
                spriteR.sprite = seeds[1];
            }

        }
    }


    void OnTriggerStay2D(Collider2D o)
    {
        targetobj = o.gameObject;
        if (o.gameObject.name.Equals("not_feed4 (10)") || o.gameObject.name.Equals("not_feed4 (1)") || o.gameObject.name.Equals("not_feed4 (9)"))
        {
            targetobj = null;
        }
        if(o.gameObject.name.Equals("not_feed2 (36)") || o.gameObject.name.Equals("not_feed3 (5)"))
        {
            targetobj = null;
        }
    }

}
