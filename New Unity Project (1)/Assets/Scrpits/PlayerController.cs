using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public string user_name;
    public GameManager textmanager;
    public float startX, startY;
    private float x, y;
    private Rigidbody2D rigid2D;
    Vector3 viewpos, dirVec;
    private Animator anim;
    public GameObject targetobj; // 씨앗을 뿌릴 땅 저장 오브젝트
    private SpriteRenderer spriteR;
    private Sprite[] seeds;
    private GameObject scanObj; // 스캔 오브젝트
    
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        rigid2D = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(startX, startY, 0);
        anim = GetComponent<Animator>();
        seeds = Resources.LoadAll<Sprite>("Sprites/Seed");
        user_name = "test1";
    }

    // Update is called once per frame
    void Update()
    {
        x = textmanager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        y = textmanager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        bool hDown = textmanager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = textmanager.isAction ? false : Input.GetButtonDown("Vertical"); 
        bool hUp = textmanager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vUp = textmanager.isAction ? false : Input.GetButtonDown("Vertical");
        anim.SetFloat("MoveX", x);
        anim.SetFloat("MoveY", y);

        if(vDown && y == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && y == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && x == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && x == 1)
        {
            dirVec = Vector3.right;
        }

        if(Input.GetKeyDown(KeyCode.Space) && scanObj != null)
        {
            textmanager.Action(scanObj); // 대화창 출력
            /*if (Input.GetButtonDown("Vertical"))
            {

            }*/
        }
        else if(Input.GetKeyDown(KeyCode.Space) && scanObj == null) // 가끔 발생하는 오류 해결 
        {
            textmanager.isAction = false;
            textmanager.talk.SetBool("isShow", textmanager.isAction);
        }

        if (Input.GetKeyDown(KeyCode.Space) && targetobj != null) // 스페이스바 누를 시 
        {
            Do_Farming();    
        }


    }
    
    void FixedUpdate()
    {
        Move();// 이동

        //Ray 보는 방향 오브젝트 정보 저장
        RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if(rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
        {
            scanObj = null;
        }
    }
   
    public void setXY(float nowX, float nowY)
    {
        x = nowX;
        y = nowY;
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }

    void Move()
    {
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }

    void Do_Farming()
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
