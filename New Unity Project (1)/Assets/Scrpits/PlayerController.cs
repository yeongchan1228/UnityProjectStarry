using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public GameManager textmanager;
    public float startX, startY;
    private float x, y;
    private Rigidbody2D rigid2D;
    Vector3 viewpos, dirVec;
    private Animator anim;
    public GameObject targetobj; // 씨앗을 뿌릴 땅 저장 오브젝트
    private SpriteRenderer spriteR;
    private Sprite[] seeds;
    GameObject chatEffect;
    GameObject Sleep;
    Animator SleepAni;
    ChatEffect chat;
    public GameObject scanObj; // 스캔 오브젝트
    GameObject user_man;
    GameObject user_woman;
    UserInfo userInfo;
    // Start is called before the first frame update
    void Start()
    {
        chatEffect = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).gameObject;
        chat = chatEffect.GetComponent<ChatEffect>();
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else
        {
            userInfo = user_woman.GetComponent<UserInfo>();
        }
        rigid2D = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(startX, startY, 0);
        anim = GetComponent<Animator>();
        seeds = Resources.LoadAll<Sprite>("Sprites/Seed");
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
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
            if (!chat.buttonOn)
            {
                textmanager.Action(scanObj); // 대화창 출력
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && scanObj == null) // 가끔 발생하는 오류 해결 
        {
            if (!chat.buttonOn)
            {
                textmanager.isAction = false;
                textmanager.talk.SetBool("isShow", textmanager.isAction);
            }
        }

        //if (chat.buttonOn) // 메뉴에서 버튼키가 On일 때 위,아래 방향키 누를 시 포커스 이동
        /*{
            if (Input.GetButtonDown("Vertical"))
            {
                if (chat.isbt1)
                {
                    Animator bt1 = textmanager.button1.GetComponent<Animator>();
                    Animator bt2 = textmanager.button2.GetComponent<Animator>();
                    bt1.SetTrigger("Normal");
                    bt2.SetTrigger("Highlighted");
                    chat.isbt1 = false;
                    chat.isbt2 = true;
                }
                else if (chat.isbt2)
                {
                    Animator bt1 = textmanager.button1.GetComponent<Animator>();
                    Animator bt2 = textmanager.button2.GetComponent<Animator>();
                    bt1.SetTrigger("Highlighted");
                    bt2.SetTrigger("Normal");
                    chat.isbt1 = true;
                    chat.isbt2 = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && chat.isallbutton)
            {
                if (chat.isbt1)
                {
                    textmanager.isAction = false; // 다시 움직이게
                    textmanager.talk.SetBool("isShow", textmanager.isAction);
                    textmanager.button1.SetActive(false);
                    textmanager.button2.SetActive(false);
                    textmanager.talkIndex = 0;
                    chat.buttonOn = false;
                    Sleep = GameObject.Find("Sleep").transform.GetChild(1).gameObject;
                    SleepAni = Sleep.GetComponent<Animator>();
                    Sleep.SetActive(true);
                    SleepAni.SetTrigger("isRest");
                    Invoke("Off_Rest", 0.6f);
                    userInfo.Hp = 100;
                    chat.isallbutton = false;
                }
                else if (chat.isbt2)
                {
                    textmanager.isAction = false; // 다시 움직이게
                    textmanager.talk.SetBool("isShow", textmanager.isAction);
                    textmanager.button1.SetActive(false);
                    textmanager.button2.SetActive(false);
                    chat.buttonOn = false;
                    textmanager.talkIndex = 0;
                    Sleep = GameObject.Find("Sleep").transform.GetChild(0).gameObject;
                    SleepAni = Sleep.GetComponent<Animator>();
                    Sleep.SetActive(true);
                    SleepAni.SetTrigger("isSleep");
                    Invoke("Off_Sleep", 1.6f);
                    userInfo.Day++;
                    userInfo.Hp = 100;
                    chat.isbt1 = true;
                    chat.isbt2 = false;
                    chat.isallbutton = false;
                }
            }
        }*/

        if (Input.GetKeyDown(KeyCode.Space) && targetobj != null) // 스페이스바 누를 시 
        {
            if (targetobj.tag.Equals("Not_Feed_Field"))
            {
                Do_Farming();
            }
            else if (targetobj.tag.Equals("Sea"))
            {
                Do_Fishing();
            }  
        }


    }
    
    void FixedUpdate()
    {
        Move();// 이동
        //Debug.Log(rigid2D.position);
        //Ray 보는 방향 오브젝트 정보 저장
        RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if(rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
           // Debug.Log(scanObj);
        }
        else
        {
            scanObj = null;
        }
    }
   
    public void SetStartXY(float x, float y)
    {
        startX = x;
        startY = y;
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

    void Do_Fishing()
    {
        Debug.Log("바다 낚시");
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
        if (o.gameObject.tag.Equals("Not_Sea"))
        {
            targetobj = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("frame3")) // house -> farm
        {
            userInfo.userWhere = 1;
            SceneManager.LoadScene("FarmScene (6)");     
        }
        if (collision.name.Equals("field2 (34)")) // farm -> house
        {
            SceneManager.LoadScene("HouseScene (5)");
        }
        if (collision.name.Equals("load")) //  town1 -> farm
        {
            userInfo.userWhere = 2;
            SceneManager.LoadScene("FarmScene (6)");
        }
        if (collision.name.Equals("load 0")) // farm -> town1
        {
            userInfo.userWhere = 1;
            SceneManager.LoadScene("Town1Scene (7)");
        }
        if (collision.name.Equals("amap20_119")) // sea -> town1
        {
            userInfo.userWhere = 2;
            SceneManager.LoadScene("Town1Scene (7)");
        }
        if(collision.name.Equals("load (12)")) // town1 -> sea
        {
            userInfo.userWhere = 1;
            SceneManager.LoadScene("SeaScene (8)");
        }
        if(collision.name.Equals("load2 (30)")) // town2 -> farm
        {
            userInfo.userWhere = 4;
            SceneManager.LoadScene("FarmScene (6)");
        }
        if (collision.name.Equals("aload2 (30)")) // farm -> town2
        {
            userInfo.userWhere = 1;
            SceneManager.LoadScene("Town2Scene (9)");
        }
        if (collision.name.Equals("map20_119"))  // town2 -> store
        {
            userInfo.userWhere = 1;
            SceneManager.LoadScene("StoreScene (10)"); 
        }
        if (collision.name.Equals("floors_8"))// store -> town2
        {
            userInfo.userWhere = 2;
            SceneManager.LoadScene("Town2Scene (9)"); 
        }
        if(collision.name.Equals("Dungeon_road (5)")) // dungeon -> farm
        {
            userInfo.userWhere = 3;
            SceneManager.LoadScene("FarmScene (6)");
        }
        if(collision.name.Equals("Dungeon_road (21)")) // dungeon -> dungeon2
        {
            userInfo.userWhere = 1;
            SceneManager.LoadScene("Dungeon2 (13)");
        }
        if(collision.name.Equals("aDungeon_road (5)")) // dungeon2 -> dungeon 
        {
            userInfo.userWhere = 2;
            SceneManager.LoadScene("Dungeon (11)");
        }
        if(collision.name.Equals("Dungeon_roadGaro (18)")) // dungeon -> dungeon1
        {
            userInfo.userWhere = 1;
            SceneManager.LoadScene("Dungeon1 (12)");
        }
        if(collision.name.Equals("Dungeon_roadGaro (23)")) // dungeon1 -> dungeon
        {
            userInfo.userWhere = 3;
            SceneManager.LoadScene("Dungeon (11)");
        }

    }
    void Off_Sleep()
    {
        Sleep = GameObject.Find("Sleep").transform.GetChild(0).gameObject;
        Sleep.SetActive(false);
    }
    void Off_Rest()
    {
        Sleep = GameObject.Find("Sleep").transform.GetChild(1).gameObject;
        Sleep.SetActive(false);
    }

}
