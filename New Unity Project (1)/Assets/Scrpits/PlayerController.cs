using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, startX, startY;
    public GameManager textmanager;
    private float x, y;
    private Rigidbody2D rigid2D;
    Vector3 viewpos, dirVec;
    private Animator anim;
    Image progressimg, fish_progressimg;
    Text progresstext, Leveltext, Hptext;
    public GameObject targetobj; // 씨앗을 뿌릴 땅 저장 오브젝트
    public GameObject targetobj2; // 구멍으로 갈 땅...
    private SpriteRenderer spriteR;
    private Sprite[] seeds, tools, Uiboxs, invens, fruit_afters, fish_results;
    private Sprite[] fishes1, fishes2, fishes3, fishes4, fishes5, fishes6, fishes7, fishes8, fishes9, fishes10;
    private Sprite[] hole;
    GameObject chatEffect, Sleep, user_man, user_woman;
    Animator SleepAni;
    public GameObject PlayerUI;
    ChatEffect chat;
    public GameObject scanObj; // 스캔 오브젝트
    UserInfo userInfo;
    public bool isPlayerUI, isHoeing, isFishing, Fishing_Result, isnow_fishing, isInven;
    GameObject proobj;
    public Dictionary<string, List<string>> SeedField; // 0. 심은 날, 1. 종류, 2. 물 횟수 3. 오늘 물 뿌렸는지? 4. 상태
    public List<GameObject> SeedField_name;
    public int count;
    public float fish_clicked, fish_difficulty;
    int FruitCount = 0, Fish_count = 0; // 인벤 과일 개수
    bool isSameKey, isFarm, isbtfirst;
    MenuControl menuControl;
    string NowField;
    public StoreUIManager storeUIManager;
    string get_fish_name;
    int aniDir, pick_count;
    monsterHP mHP;

    /**************************꼰 코드에 추가할 거 ******************/
    public GameObject Hole_UI, furnace, fin_box, proobj2, exit;
    public Image progressimg2;
    public Text progresstext2;
    public bool isSecret;
    public bool isSeeSecret;
    public bool isGoHole;


    // Start is called before the first frame update
    void Start()
    {
        SeedField_name = new List<GameObject>();
        SeedField = new Dictionary<string, List<string>>();
        chatEffect = GameObject.Find("Talk").transform.GetChild(0).gameObject;
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
        tools = Resources.LoadAll<Sprite>("Sprites/Tool");
        Uiboxs = Resources.LoadAll<Sprite>("Sprites/ItemBox");
        invens = Resources.LoadAll<Sprite>("Sprites/Inven");
        fruit_afters = Resources.LoadAll<Sprite>("Sprites/Fruit/after");
        fish_results = Resources.LoadAll<Sprite>("Sprites/fish/Result");
        fishes1 = Resources.LoadAll<Sprite>("Sprites/fish/난이도1"); // 1마리
        fishes2 = Resources.LoadAll<Sprite>("Sprites/fish/난이도2"); // 2마리
        fishes3 = Resources.LoadAll<Sprite>("Sprites/fish/난이도3"); // 2마리
        fishes4 = Resources.LoadAll<Sprite>("Sprites/fish/난이도4"); // 2마리
        fishes5 = Resources.LoadAll<Sprite>("Sprites/fish/난이도5"); // 2마리
        fishes6 = Resources.LoadAll<Sprite>("Sprites/fish/난이도6"); // 2마리
        fishes7 = Resources.LoadAll<Sprite>("Sprites/fish/난이도7"); // 4마리
        fishes8 = Resources.LoadAll<Sprite>("Sprites/fish/난이도8"); // 2마리
        fishes9 = Resources.LoadAll<Sprite>("Sprites/fish/난이도9"); // 2마리
        fishes10 = Resources.LoadAll<Sprite>("Sprites/fish/난이도10"); // 1마리
        hole = Resources.LoadAll<Sprite>("Sprites/Hole");
        menuControl = GameObject.Find("MenuManager").GetComponent<MenuControl>();
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

        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // 검
        {
            Input_playerUI();
            GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
            GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            GameObject itembox5 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
            Image selectItemBox1 = itembox1.GetComponent<Image>();
            selectItemBox1.sprite = Uiboxs[0]; // 선택으로 변경
            if (userInfo.isHoe) { Image selectItemBox2 = itembox2.GetComponent<Image>(); selectItemBox2.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isFishingRod) { Image selectItemBox3 = itembox3.GetComponent<Image>(); selectItemBox3.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isWaterPPU) { Image selectItemBox4 = itembox4.GetComponent<Image>(); selectItemBox4.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isPick) { Image selectItemBox5 = itembox5.GetComponent<Image>(); selectItemBox5.sprite = Uiboxs[1]; }// 비선택으로 변경
            userInfo.isWaterPPU = false;
            userInfo.isHoe = false;
            userInfo.isFishingRod = false;
            userInfo.isSword = true;
            userInfo.isPick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // 호미
        {
            Input_playerUI();
            GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
            GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            GameObject itembox5 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
            Image selectItemBox2 = itembox2.GetComponent<Image>();
            selectItemBox2.sprite = Uiboxs[0]; // 선택으로 변경
            if (userInfo.isSword) { Image selectItemBox1 = itembox1.GetComponent<Image>(); selectItemBox1.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isFishingRod) { Image selectItemBox3 = itembox3.GetComponent<Image>(); selectItemBox3.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isWaterPPU) { Image selectItemBox4 = itembox4.GetComponent<Image>(); selectItemBox4.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isPick) { Image selectItemBox5 = itembox5.GetComponent<Image>(); selectItemBox5.sprite = Uiboxs[1]; }// 비선택으로 변경
            userInfo.isWaterPPU = false;
            userInfo.isHoe = true;
            userInfo.isFishingRod = false;
            userInfo.isSword = false;
            userInfo.isPick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // 낚시대
        {
            Input_playerUI();
            GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
            GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            GameObject itembox5 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
            Image selectItemBox3 = itembox3.GetComponent<Image>();
            selectItemBox3.sprite = Uiboxs[0]; // 선택으로 변경
            if (userInfo.isSword) { Image selectItemBox1 = itembox1.GetComponent<Image>(); selectItemBox1.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isHoe) { Image selectItemBox2 = itembox2.GetComponent<Image>(); selectItemBox2.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isWaterPPU) { Image selectItemBox4 = itembox4.GetComponent<Image>(); selectItemBox4.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isPick) { Image selectItemBox5 = itembox5.GetComponent<Image>(); selectItemBox5.sprite = Uiboxs[1]; }// 비선택으로 변경
            userInfo.isWaterPPU = false;
            userInfo.isHoe = false;
            userInfo.isFishingRod = true;
            userInfo.isSword = false;
            userInfo.isPick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) // 물뿌리개
        {
            Input_playerUI();
            GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
            GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            GameObject itembox5 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
            Image selectItemBox4 = itembox4.GetComponent<Image>();
            selectItemBox4.sprite = Uiboxs[0]; // 선택으로 변경
            if (userInfo.isSword) { Image selectItemBox1 = itembox1.GetComponent<Image>(); selectItemBox1.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isFishingRod) { Image selectItemBox3 = itembox3.GetComponent<Image>(); selectItemBox3.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isHoe) { Image selectItemBox2 = itembox2.GetComponent<Image>(); selectItemBox2.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isPick) { Image selectItemBox5 = itembox5.GetComponent<Image>(); selectItemBox5.sprite = Uiboxs[1]; }// 비선택으로 변경
            userInfo.isWaterPPU = true;
            userInfo.isHoe = false;
            userInfo.isFishingRod = false;
            userInfo.isSword = false;
            userInfo.isPick = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) // 씨앗통
        {
            Input_playerUI();
            GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
            GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
            GameObject itembox5 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
            Image selectItemBox5 = itembox5.GetComponent<Image>();
            selectItemBox5.sprite = Uiboxs[0]; // 선택으로 변경
            if (userInfo.isSword) { Image selectItemBox1 = itembox1.GetComponent<Image>(); selectItemBox1.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isFishingRod) { Image selectItemBox3 = itembox3.GetComponent<Image>(); selectItemBox3.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isWaterPPU) { Image selectItemBox4 = itembox4.GetComponent<Image>(); selectItemBox4.sprite = Uiboxs[1]; }// 비선택으로 변경
            if (userInfo.isHoe) { Image selectItemBox2 = itembox2.GetComponent<Image>(); selectItemBox2.sprite = Uiboxs[1]; }// 비선택으로 변경
            userInfo.isWaterPPU = false;
            userInfo.isHoe = false;
            userInfo.isFishingRod = false;
            userInfo.isSword = false;
            userInfo.isPick = true;
        }

        if(userInfo.getLevel() < 10 && userInfo.getExp() > 150)
        {
            int Level = userInfo.getLevel();
            int Exp = userInfo.getExp();
            Level += 1;
            Exp -= 150;
            userInfo.setLevel(Level);
            userInfo.setExp(Exp);
            int maxHp = userInfo.getMaxHp();
            maxHp = maxHp + 10;
            userInfo.setMaxHp(maxHp);
            Hptext.text = userInfo.getHp() + " / " + userInfo.getMaxHp();
            Leveltext.text = "Lv. "+userInfo.getLevel().ToString();    
            menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
        }
        else if(userInfo.getLevel() < 20 && userInfo.getExp() > 350)
        {
            int Level = userInfo.getLevel();
            int Exp = userInfo.getExp();
            Level += 1;
            Exp -= 350;
            userInfo.setLevel(Level);
            userInfo.setExp(Exp);
            int maxHp = userInfo.getMaxHp();
            maxHp = maxHp + 10;
            userInfo.setMaxHp(maxHp);
            Hptext.text = userInfo.getHp() + " / " + userInfo.getMaxHp();
            Leveltext.text = "Lv. " + userInfo.getLevel().ToString();
            menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
        }
        else if (userInfo.getLevel() < 30 && userInfo.getExp() > 650)
        {
            int Level = userInfo.getLevel();
            int Exp = userInfo.getExp();
            Level += 1;
            Exp -= 650;
            userInfo.setLevel(Level);
            userInfo.setExp(Exp);
            int maxHp = userInfo.getMaxHp();
            maxHp = maxHp + 10;
            userInfo.setMaxHp(maxHp);
            Hptext.text = userInfo.getHp() + " / " + userInfo.getMaxHp();
            Leveltext.text = "Lv. " + userInfo.getLevel().ToString();
            menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
        }
        else if (userInfo.getLevel() < 40 && userInfo.getExp() > 1000)
        {
            int Level = userInfo.getLevel();
            int Exp = userInfo.getExp();
            Level += 1;
            Exp -= 650;
            userInfo.setLevel(Level);
            userInfo.setExp(Exp);
            int maxHp = userInfo.getMaxHp();
            maxHp = maxHp + 10;
            userInfo.setMaxHp(maxHp);
            Hptext.text = userInfo.getHp() + " / " + userInfo.getMaxHp();
            Leveltext.text = "Lv. " + userInfo.getLevel().ToString();
            menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
        }
        else if (userInfo.getLevel() < 50 && userInfo.getExp() > 1300)
        {
            int Level = userInfo.getLevel();
            int Exp = userInfo.getExp();
            Level += 1;
            Exp -= 650;
            userInfo.setLevel(Level);
            userInfo.setExp(Exp);
            int maxHp = userInfo.getMaxHp();
            maxHp = maxHp + 10;
            userInfo.setMaxHp(maxHp);
            Hptext.text = userInfo.getHp() + " / " + userInfo.getMaxHp();
            Leveltext.text = "Lv. " + userInfo.getLevel().ToString();
            menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space) && scanObj != null && isFarm == false)
        {
            if (SceneManager.GetActiveScene().name == "StoreScene (10)")
            {
                storeUIManager = GameObject.Find("StoreUIManager").GetComponent<StoreUIManager>();
                storeUIManager.Action(scanObj);
            }
            else if (!chat.buttonOn)
            {
                textmanager.Action(scanObj); // 대화창 출력
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && scanObj == null && isFarm == false && isnow_fishing == false) // 가끔 발생하는 오류 해결 
        {
            if (!chat.buttonOn)
            {
                textmanager.isAction = false;
                textmanager.talk.SetBool("isShow", textmanager.isAction);
            }
            if (userInfo.isSword == true &&
                (SceneManager.GetActiveScene().name == "Dungeon (11)" ||
            SceneManager.GetActiveScene().name == "Dungeon1 (12)" ||
            SceneManager.GetActiveScene().name == "Dungeon2 (13)"))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("ManDown") || anim.GetCurrentAnimatorStateInfo(0).IsName("ManIdle"))
                {
                    aniDir = 0; // 정면, 즉 아래를 보고 있을 때
                    anim.SetBool("isFrontSword", userInfo.isSword);
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("ManLeft") || anim.GetCurrentAnimatorStateInfo(0).IsName("ManLeftIdle"))
                {
                    aniDir = 1; // 왼쪽을 보고 있을 때
                    anim.SetBool("isLeftSword", userInfo.isSword);
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("ManRight") || anim.GetCurrentAnimatorStateInfo(0).IsName("ManRightIdle"))
                {
                    aniDir = 2; // 오른쪽을 보고 있을 때
                    anim.SetBool("isRightSword", userInfo.isSword);
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("ManUp") || anim.GetCurrentAnimatorStateInfo(0).IsName("ManBackIdle"))
                {
                    aniDir = 3; // Back, 즉 위를 보고 있을 때
                    anim.SetBool("isBackSword", userInfo.isSword);
                }
                Attack(aniDir);
            }
        }

        if (Input.GetKeyDown(KeyCode.I) && userInfo.storycounter > 0)
        {
            if (menuControl.Inventory.activeSelf)
            {
                menuControl.Inventory.SetActive(false);
                isInven = false;
            }
            else
            {
                menuControl.Inventory.SetActive(true);
                isInven = true;
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

        if (Input.GetKeyDown(KeyCode.Space) && targetobj != null && isHoeing == false &&isInven == false) // 스페이스바 누를 시 
        {
            if (targetobj.tag.Equals("Not_Feed_Field"))
            {
                Do_Farming();
            }
            else if (targetobj.tag.Equals("Sea") && userInfo.isFishingRod && isnow_fishing == false)
            {
                Do_Fishing();
            }  
        }

        // ************* 나중에 코드 추가할 거
        if (Input.GetKeyDown(KeyCode.Space) && targetobj2 != null && isSecret == false && userInfo.isSword == true && userInfo.getItem_Weapon().GetWeaponName().Equals("galaxysword")) // 갤럭시 검 장착 + 스페이스바 누를 시                                                                                                                                                                           // 우선 예시로 부서진 검 등록해둠
        {
            if (targetobj2.tag.Equals("goHole"))
            {
                Go_Hole();
                isGoHole = true;
                Change_Hole();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && targetobj2 != null && isSecret == true && isGoHole == true && userInfo.isSword == true && userInfo.getItem_Weapon().GetWeaponName().Equals("galaxysword")) //
        {
            textmanager.isAction = true;
            See_Hole();
            isSecret = false;
        }


    }

    void Go_Hole() // 갤럭시 검으로 특정 지점 캤을 때
    {
        spriteR = targetobj2.GetComponent<SpriteRenderer>();
        if (spriteR.sprite.name.Equals("goHole"))
        {
            proobj2 = GameObject.Find("Secret").transform.GetChild(0).gameObject;
            progressimg2 = proobj2.transform.GetChild(1).gameObject.GetComponent<Image>();
            progresstext2 = proobj2.transform.GetChild(2).gameObject.GetComponent<Text>();
            progressimg2.fillAmount = 0;
            textmanager.isAction = true;
            proobj2.SetActive(true);
        }
    }

    void Change_Hole()
    {
        if (isGoHole == true)
        {
            spriteR.sprite = hole[0]; // 구멍이 생긴 땅으로 바뀜
            textmanager.isAction = false;
            isSeeSecret = true;
        }

    }
    void See_Hole()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spriteR.sprite.name.Equals("hole") && isSeeSecret == true)
        {
            Hole_UI = GameObject.Find("Hole_UI").transform.GetChild(0).gameObject;
            furnace = Hole_UI.transform.GetChild(0).gameObject;
            fin_box = Hole_UI.transform.GetChild(1).gameObject;
            exit = Hole_UI.transform.GetChild(2).gameObject;
            Hole_UI.SetActive(true);
            furnace.SetActive(true);
            fin_box.SetActive(true);
            exit.SetActive(true);
        }
    }


    void Input_playerUI()
    {
        if(PlayerUI == null) 
        { 
            PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            Leveltext = PlayerUI.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>(); 
            Hptext = PlayerUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();

        }
    }
    void FixedUpdate()
    {
        Move();// 이동
        //Debug.Log(rigid2D.position);
        //Ray 보는 방향 오브젝트 정보 저장
        RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid2D.position, dirVec, 0.7f, LayerMask.GetMask("Water"));
        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
        {
            scanObj = null;
        }
        if (rayHit2.collider != null)
        {
            if(Input.GetKeyDown(KeyCode.Space) && userInfo.isWaterPPU)
            {
                GameObject gameogj = GameObject.Find("WaterPPU").transform.GetChild(1).gameObject;
                gameogj.SetActive(true);
            }
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
        if(proobj == null) 
        { 
            proobj = GameObject.Find("Farm").transform.GetChild(0).gameObject;
            progressimg = proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
            progresstext = proobj.transform.GetChild(2).gameObject.GetComponent<Text>();
        }

        if (spriteR.sprite.name.Equals("not_feed") && userInfo.isHoe) // 밭 갈기
        {
            int UserHp = userInfo.getHp();
            if (UserHp > 1)
            {
                progresstext.text = "Hoeing...";
                proobj.SetActive(true);
                progressimg = proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
                progressimg.fillAmount = 0;
                isHoeing = true;
                textmanager.isAction = true;
                isFarm = true;
                Invoke("Seed_Hoeing", userInfo.getItem_Hoe().GetHoeSpeed());
                count = (int)userInfo.getItem_Hoe().GetHoeSpeed();
            }
               
        }
        else if (spriteR.sprite.name.Equals("Hoeing") && userInfo.isPick && userInfo.getItem_Pick().GetPickName() != null) // 씨 뿌리기
        {
            if (userInfo.getItem_Pick().GetPickName().Equals("Orgol")) { return; }
            if (userInfo.SeedItem[userInfo.getItem_Pick().GetPickName()] == 0)
            {
                return;
            }

            proobj.SetActive(true);
            progressimg = proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
            progressimg.fillAmount = 0;
            progresstext.text = "Sowing...";
            isHoeing = true;
            textmanager.isAction = true;
            isFarm = true;
            Invoke("Seed_Seed", 2f);
            count = 2;
        }
        else if (spriteR.sprite.name.Equals("Seed") && userInfo.isWaterPPU) // 물 주기
        {
            if(userInfo.getItem_WaterPPU().GetWaterPPUFilled() <= 0)
            {
                GameObject gameogj = GameObject.Find("WaterPPU").transform.GetChild(0).gameObject;
                gameogj.SetActive(true);
                return;
            }
            if (SeedField_name.Count > 0)
            {
                for (int i = 0; i < SeedField_name.Count; i++)
                {
                    if (SeedField_name[i].name.Equals(targetobj.name))
                    {
                        if (int.Parse(SeedField[targetobj.name][3]) != 1)
                        {
                            proobj.SetActive(true);
                            progressimg = proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
                            progressimg.fillAmount = 0;
                            progresstext.text = "Watering...";
                            isHoeing = true;
                            textmanager.isAction = true;
                            isFarm = true;
                            Invoke("Seed_Water", 2f);
                            count = 2;
                        }
                    }
                }
            }
        }
        else if ((!spriteR.sprite.name.Equals("Seed") || !spriteR.sprite.name.Equals("not_feed") || spriteR.sprite.name.Equals("Hoeing")) && userInfo.isWaterPPU && userInfo.getItem_WaterPPU().GetWaterPPUFilled() > 0) // 물 주기
        {
            if (userInfo.getItem_WaterPPU().GetWaterPPUFilled() <= 0)
            {
                GameObject gameogj = GameObject.Find("WaterPPU").transform.GetChild(0).gameObject;
                gameogj.SetActive(true);
                return;
            }
            if (SeedField_name.Count > 0)
            {
                for (int i = 0; i < SeedField_name.Count; i++)
                {
                    if (SeedField_name[i].name.Equals(targetobj.name))
                    {
                        if (int.Parse(SeedField[targetobj.name][3]) != 1)
                        {
                            proobj.SetActive(true);
                            progressimg = proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
                            progressimg.fillAmount = 0;
                            progresstext.text = "Watering...";
                            isHoeing = true;
                            textmanager.isAction = true;
                            isFarm = true;
                            Invoke("Seed_Water2", 2f);
                            count = 2;
                        }
                    }
                }
            }
        }
        else if (!spriteR.sprite.name.Equals("Seed") && !spriteR.sprite.name.Equals("Hoeing") && !spriteR.sprite.name.Equals("not_feed") 
            && !spriteR.sprite.name.Equals("Water") && !spriteR.sprite.name.Equals("Sprout") && userInfo.isHoe) // 수확하기
        {
            proobj.SetActive(true);
            NowField = targetobj.name;
            progressimg = proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
            progressimg.fillAmount = 0;
            progresstext.text = "Harvesting...";
            isHoeing = true;
            textmanager.isAction = true;
            isFarm = true;
            Invoke("Seed_Get", 4f);
            count = 4;
        }
    }

    void Attack(int aniDir)
    {
        if (SceneManager.GetActiveScene().name == "Dungeon (11)" ||
            SceneManager.GetActiveScene().name == "Dungeon1 (12)" ||
            SceneManager.GetActiveScene().name == "Dungeon2 (13)")
        {
            List<GameObject> slimeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Slime"));
            GameObject enemy = slimeObjects[0];
            if (aniDir == 0 || aniDir == 3) // 0 : 정면 - 아래 / 3 : 뒷모습 - 위
            {
                float disY = slimeObjects[0].transform.position.y - transform.position.y;
                foreach (GameObject found in slimeObjects) // y좌표값 차이의 절댓값이 가장 작은 경우를 찾음.
                {
                    float dy = found.transform.position.y - transform.position.y;

                    if (Mathf.Abs(disY) > Mathf.Abs(dy)) // dy의 절댓값이 더 작을 때
                    {
                        enemy = found;
                        disY = dy;
                    }
                }
                if (Mathf.Abs(enemy.transform.position.x - transform.position.x) >= 1)
                    return;
                if (aniDir == 0 && 0 > disY && disY > -1)
                {
                    Debug.Log("아래로 공격 성공");
                    mHP = enemy.GetComponent<monsterHP>();
                    mHP.Hit(10);
                }
                else if (aniDir == 3 && 0 < disY && disY < 1)
                {
                    Debug.Log("위로 공격 성공");
                    mHP = enemy.GetComponent<monsterHP>();
                    mHP.Hit(10); // 10은 임시로 넣은 값. 이후 무기에 따라서 값 넣어줘야 함.
                }
            }
            else if (aniDir == 1 || aniDir == 2) // 1 : 왼쪽/ 2 : 오른쪽
            {
                float disX = slimeObjects[0].transform.position.x - transform.position.x;
                foreach (GameObject found in slimeObjects) // y좌표값 차이의 절댓값이 가장 작은 경우를 찾음.
                {
                    float dx = found.transform.position.x - transform.position.x;

                    if (Mathf.Abs(disX) > Mathf.Abs(dx)) // dy의 절댓값이 더 작을 때
                    {
                        enemy = found;
                        disX = dx;
                    }
                }

                if (Mathf.Abs(enemy.transform.position.y - transform.position.y) >= 1)
                    return;
                if (aniDir == 1 && 0 > disX && disX > -1.5)
                {
                    Debug.Log("왼쪽으로 공격 성공");
                    mHP = enemy.GetComponent<monsterHP>();
                    mHP.Hit(10);
                }
                else if (aniDir == 2 && 0 < disX && disX < 1.5)
                {
                    Debug.Log("오른쪽으로 공격 성공");
                    mHP = enemy.GetComponent<monsterHP>();
                    mHP.Hit(10);
                }

            }
        }
    }


    void Seed_Hoeing() // 밭 갈기
    {
        int UserHp = userInfo.getHp();
        spriteR.sprite = seeds[0]; // Hoeing으로 변경
        targetobj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90)); // target object 90도 회전시키기
        if((int)userInfo.getItem_Hoe().GetHoeSpeed() == 10) { UserHp = UserHp - 15; }
        else if((int)userInfo.getItem_Hoe().GetHoeSpeed() == 8) { UserHp = UserHp - 12; }
        else if ((int)userInfo.getItem_Hoe().GetHoeSpeed() == 6) { UserHp = UserHp - 10; }
        else if ((int)userInfo.getItem_Hoe().GetHoeSpeed() == 4) { UserHp = UserHp - 8; }
        else if ((int)userInfo.getItem_Hoe().GetHoeSpeed() == 2) { UserHp = UserHp - 5; }
        userInfo.setHp(UserHp);
        userInfo.setUIHp();
        textmanager.isAction = false;
        isFarm = false;
    }

    void Seed_Water() // 물주기
    {
        if(SeedField_name.Count > 0)
        {
            for(int i = 0; i < SeedField_name.Count; i++)
            {
                if (SeedField_name[i].name.Equals(targetobj.name))
                {
                    if (int.Parse(SeedField[targetobj.name][3]) != 1)
                    {
                        spriteR.sprite = seeds[4]; // 물뿌린 땅으로 변경
                        int Water = int.Parse(SeedField[targetobj.name][2]);
                        if (Water < 3) { Water++; }
                        SeedField[targetobj.name][2] = Water.ToString();
                        SeedField[targetobj.name][3] = "1";
                        int waterP = userInfo.getItem_WaterPPU().GetWaterPPUFilled();
                        waterP = waterP - 20;
                        userInfo.getItem_WaterPPU().SetWaterPPUFilled(waterP);
                        textmanager.isAction = false;
                        isFarm = false;
                    }
                }
            }
        }
    }
    void Seed_Water2() // 물주기
    {
        if (SeedField_name.Count > 0)
        {
            for (int i = 0; i < SeedField_name.Count; i++)
            {
                if (SeedField_name[i].name.Equals(targetobj.name))
                {
                    if (int.Parse(SeedField[targetobj.name][3]) != 1)
                    {
                        int Water = int.Parse(SeedField[targetobj.name][2]);
                        if (Water < 3) { Water++; }
                        SeedField[targetobj.name][2] = Water.ToString();
                        SeedField[targetobj.name][3] = "1";
                        int waterP = userInfo.getItem_WaterPPU().GetWaterPPUFilled();
                        waterP = waterP - 20;
                        userInfo.getItem_WaterPPU().SetWaterPPUFilled(waterP);
                        textmanager.isAction = false;
                        isFarm = false;
                    }
                }
            }
        }
    }
    void Seed_Seed() // 씨 뿌리기
    {
        Input_playerUI();
        for (int i = 0; i < SeedField_name.Count; i++)
        {
            if (SeedField_name[i].name.Equals(targetobj.name))
            {
                return;
            }
        }
        if (userInfo.getItem_Pick().GetPickName().Equals("milSeed")) { count_Seed();  }
        else if (userInfo.getItem_Pick().GetPickName().Equals("potatoSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("carrotSeed")) { count_Seed();  }
        else if (userInfo.getItem_Pick().GetPickName().Equals("dhrtntnSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("dkqhzkehSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("GrapeSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("lemonSeed")) { count_Seed();  }
        else if (userInfo.getItem_Pick().GetPickName().Equals("blueberrySeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("melonSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("pineappleSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("pumpkinSeed")) { count_Seed();}
        else if (userInfo.getItem_Pick().GetPickName().Equals("rkwlSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("strawberrySeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("tnsanSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("tomatoSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("watermelonSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("darkSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("lightSeed")) { count_Seed(); }
        else if (userInfo.getItem_Pick().GetPickName().Equals("starrySeed")) { count_Seed(); }


        spriteR.sprite = seeds[2]; // 씨앗뿌린 땅으로 변경
        int Day = userInfo.getDay();
        SeedField.Add(targetobj.name, new List<string> { Day.ToString(), userInfo.getItem_Pick().GetPickKinds(), "3", "0", "0" });
        SeedField_name.Add(targetobj);
        textmanager.isAction = false;
        isFarm = false;
    }
    void count_Seed()
    {
        Image UISeed = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>();
        GameObject UISeedcount0 = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).gameObject;
        GameObject UISeedimg = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject;
        Text UISeedcount = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Text>();
        pick_count = userInfo.SeedItem[userInfo.getItem_Pick().GetPickName()];
        if (pick_count > 0)
        {
            userInfo.SeedItem[userInfo.getItem_Pick().GetPickName()] = userInfo.SeedItem[userInfo.getItem_Pick().GetPickName()] - 1;
            pick_count = userInfo.SeedItem[userInfo.getItem_Pick().GetPickName()];
            UISeedcount.text = pick_count.ToString();
            for(int i = 0; i<userInfo.SeedItemkey.Count; i++)
            {
                GameObject seedi = menuControl.InventorySeed.transform.GetChild(i).gameObject;
                Image img = seedi.transform.GetChild(0).GetComponent<Image>();
                Debug.LogError(userInfo.getItem_Pick().GetPickName());
                if (img.sprite.name.Equals(userInfo.getItem_Pick().GetPickName()))
                {
                    Text text = seedi.transform.GetChild(1).GetComponent<Text>();
                    text.text = pick_count.ToString();
                }
            }
            if(pick_count == 0)
            {
                UISeedimg.SetActive(false);
                UISeedcount0.SetActive(false);
                userInfo.getItem_Pick().SetPickName(null);
                userInfo.getItem_Pick().SetPickName(null);
                for (int i = 0; i < userInfo.SeedItemkey.Count; i++)
                {
                    GameObject seedi = menuControl.InventorySeed.transform.GetChild(i).gameObject;
                    Image img = seedi.transform.GetChild(0).GetComponent<Image>();
                    Debug.LogError(userInfo.getItem_Pick().GetPickName());
                    if (img.sprite.name.Equals(userInfo.getItem_Pick().GetPickName()))
                    {
                        Text text = seedi.transform.GetChild(1).GetComponent<Text>();
                        text.text = pick_count.ToString();
                    }
                }
            }
        }
    }
    void Seed_Get() // 수확하기
    {
        /////// 인벤 추가
        string Fruit = SeedField[NowField][1];
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            if (userInfo.FruitItemkey[i].Equals(Fruit))
            {
                FruitCount = userInfo.FruitItem[Fruit];
            }
        }
        FruitCount++;
        for(int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            if (userInfo.FruitItemkey[i].Equals(Fruit)) { isSameKey = true; }
        }
        if (!isSameKey)
        {
            userInfo.FruitItemkey.Add(Fruit);
            userInfo.FruitItem.Add(Fruit, FruitCount);
        }
        userInfo.FruitItem[Fruit] = FruitCount;
        isSameKey = false;

        for(int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            GameObject bottonobj = menuControl.InventoryFruit.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image Fruitimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.FruitItemkey[i].Equals("Blueberry"))
            { 
                Fruitimg.sprite = fruit_afters[0]; 
                int Exp = userInfo.getExp();
                Exp += 50;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("carrot")) 
            { 
                Fruitimg.sprite = fruit_afters[1];
                int Exp = userInfo.getExp();
                Exp += 40;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("DARK")) 
            { 
                Fruitimg.sprite = fruit_afters[2];
                int Exp = userInfo.getExp();
                Exp += 200;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("dhrtntn1")) 
            { 
                Fruitimg.sprite = fruit_afters[3];
                int Exp = userInfo.getExp();
                Exp += 200;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("dkqhzkeh1")) 
            { 
                Fruitimg.sprite = fruit_afters[4];
                int Exp = userInfo.getExp();
                Exp += 130;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("Grape")) 
            { 
                Fruitimg.sprite = fruit_afters[5];
                int Exp = userInfo.getExp();
                Exp += 80;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("lemon1")) 
            { 
                Fruitimg.sprite = fruit_afters[6];
                int Exp = userInfo.getExp();
                Exp += 110;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) 
            { 
                Fruitimg.sprite = fruit_afters[7];
                int Exp = userInfo.getExp();
                Exp += 200;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("melon")) 
            { 
                Fruitimg.sprite = fruit_afters[8];
                int Exp = userInfo.getExp();
                Exp += 120;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("mil1")) 
            { 
                Fruitimg.sprite = fruit_afters[9];
                int Exp = userInfo.getExp();
                Exp += 30;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("pineapple1")) 
            {
                Fruitimg.sprite = fruit_afters[10];
                int Exp = userInfo.getExp();
                Exp += 170;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("Potato")) 
            { 
                Fruitimg.sprite = fruit_afters[11];
                int Exp = userInfo.getExp();
                Exp += 100;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("Pumpkin")) 
            { 
                Fruitimg.sprite = fruit_afters[12];
                int Exp = userInfo.getExp();
                Exp += 120;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("rkwl1")) 
            { 
                Fruitimg.sprite = fruit_afters[13];
                int Exp = userInfo.getExp();
                Exp += 160;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("starry")) 
            { 
                Fruitimg.sprite = fruit_afters[14];
                int Exp = userInfo.getExp();
                Exp += 300;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) 
            { 
                Fruitimg.sprite = fruit_afters[15];
                int Exp = userInfo.getExp();
                Exp += 130;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("tnsan1")) {
                Fruitimg.sprite = fruit_afters[16];
                int Exp = userInfo.getExp();
                Exp += 100;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("Tomato")) 
            {
                Fruitimg.sprite = fruit_afters[17];
                int Exp = userInfo.getExp();
                Exp += 110;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            else if (userInfo.FruitItemkey[i].Equals("watermelon")) 
            {
                Fruitimg.sprite = fruit_afters[18];
                int Exp = userInfo.getExp();
                Exp += 180;
                userInfo.setExp(Exp);
                menuControl.ExpInfo.text = "Exp : " + userInfo.getExp().ToString();
            }
            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fruittext = text.GetComponent<Text>(); // 과일 개수
            Fruittext.text = userInfo.FruitItem[userInfo.FruitItemkey[i]].ToString();
            text.SetActive(true);
            FruitCount = 0;
        }

        /////// List 삭제
        SeedField.Remove(targetobj.name);
        for (int i = 0; i < SeedField_name.Count; i++)
        { 
            if (SeedField_name[i].name.Equals(targetobj.name))
            {
                SeedField_name.RemoveAt(i);
                spriteR.sprite = seeds[1]; // 씨앗뿌린 땅으로 변경
                textmanager.isAction = false;
                isFarm = false;
                NowField = null;
                break;
            }
        }
        ////// 인벤토리 넣기 추가
    }

    void Do_Fishing()
    {
        textmanager.isAction = true;
        isnow_fishing = true;
        isFishing = true;
        Fishing_Result = false;
        fish_progressimg = GameObject.Find("Fishing").transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).GetComponent<Image>();
        Button fish_button = GameObject.Find("Fishing").transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Button>();
        fish_button.onClick.AddListener(menuControl.Fish_Clicked);
        fish_progressimg.fillAmount = 0;
        int hp = userInfo.getHp();
        hp = hp - 10;
        userInfo.setHp(hp);
        userInfo.setUIHp();
        anim.SetBool("isFishing", isFishing);
        int random = Random.Range(1, 11); // 1~10초
        Debug.LogError("random : " + random);
        Invoke("GoFishing", random); // random 초 후 실행
    }

    void GoFishing()
    { 
        isFishing = false; // 낚시 중인 애니 종료
        
        //고기잡이 창 시작
        GameObject Fishing_obj = GameObject.Find("Fishing").transform.GetChild(0).gameObject;
        Fishing_obj.SetActive(true);

        //filled량 설정
        int difficulty = Random.Range(1, 100); // 물고기 난이도
        Debug.LogError("difficulty : " + difficulty);
        if(difficulty < 20) { fish_difficulty = 1; } // 최하 난이도 1
        else if(difficulty < 40) { fish_difficulty = 0.5f; } // 2
        else if (difficulty < 60) { fish_difficulty = 0.1f; } // 3
        else if (difficulty < 68) { fish_difficulty = 0.08f; } // 4
        else if (difficulty < 75) { fish_difficulty = 0.06f; } // 5
        else if (difficulty < 82) { fish_difficulty = 0.05f; } // 6
        else if (difficulty < 87) { fish_difficulty = 0.04f; } // 7
        else if (difficulty < 92) { fish_difficulty = 0.03f; } // 8
        else if (difficulty < 96) { fish_difficulty = 0.02f; } // 9
        else if (difficulty < 100) { fish_difficulty = 0.01f; } // 10

        //물고기 올리는 애니 트리거 실행
        Invoke("Filled_FishBar", 0.1f);
        Invoke("Finish_Fishing", 10f);
    }

    void Filled_FishBar()
    {
        float finish = fish_progressimg.fillAmount;
        if (finish > 0.99f) 
        {
            Fishing_Result = true;
            Success_fishing();
            return; 
        }
        else
        {
            Invoke("Filled_FishBar", 0.1f);
        }

    }

    void Finish_Fishing()
    {
        float finish = fish_progressimg.fillAmount;
        if (!Fishing_Result)
        {
            if (finish > 0.77f) 
            { 
                Fishing_Result = true;
                CancelInvoke("Filled_FishBar");
                Success_fishing();
            }
            else // 고기 잡기 실패
            {
                CancelInvoke("Filled_FishBar");
                False_fishing();
            }
        }
    }
    void Success_fishing()
    { 
        GameObject Fishing_obj = GameObject.Find("Fishing").transform.GetChild(0).gameObject;
        Fishing_obj.SetActive(false);
        GameObject Result_obj = GameObject.Find("Fishing").transform.GetChild(1).gameObject;
        Result_obj.SetActive(true);
        Image resultimg = Result_obj.transform.GetChild(0).GetComponent<Image>();
        if (userInfo.getGender().Equals("man")) { resultimg.sprite = fish_results[1]; }
        else { resultimg.sprite = fish_results[4]; }
        Text resulttext = Result_obj.transform.GetChild(1).GetComponent<Text>();
        textmanager.isAction = true;
        if (fish_difficulty == 1) { get_fish_name = fishes1[0].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes1[0].name); }
        else if (fish_difficulty == 0.5f) { int result = Random.Range(0, 2); get_fish_name = fishes2[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes2[result].name); }
        else if (fish_difficulty == 0.1f) { int result = Random.Range(0, 2); get_fish_name = fishes3[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes3[result].name); }
        else if (fish_difficulty == 0.08f) { int result = Random.Range(0, 2); get_fish_name = fishes4[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes4[result].name); }
        else if (fish_difficulty == 0.06f) { int result = Random.Range(0, 2); get_fish_name = fishes5[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes5[result].name); }
        else if (fish_difficulty == 0.05f) { int result = Random.Range(0, 2); get_fish_name = fishes6[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes6[result].name); }
        else if (fish_difficulty == 0.04f) { int result = Random.Range(0, 5); get_fish_name = fishes7[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes7[result].name); }
        else if (fish_difficulty == 0.03f) { int result = Random.Range(0, 2); get_fish_name = fishes8[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes8[result].name); }
        else if (fish_difficulty == 0.02f) { int result = Random.Range(0, 2); get_fish_name = fishes9[result].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes9[result].name); }
        else if (fish_difficulty == 0.01f) { get_fish_name = fishes10[0].name; resulttext.text = get_fish_name + "를 잡았어요!!!"; Fish_IntoInven(fishes10[0].name); }
        CancelInvoke("Finish_Fishing");
        Invoke("finish_result", 5f);
    }
    void Fish_IntoInven(string Fish_name)
    {
        for (int i = 0; i < userInfo.FishItemkey.Count; i++)
        {
            if (userInfo.FishItemkey[i].Equals(Fish_name))
            {
                Fish_count = userInfo.FishItem[Fish_name];
            }
        }
        Fish_count++;
        for (int i = 0; i < userInfo.FishItemkey.Count; i++)
        {
            if (userInfo.FishItemkey[i].Equals(Fish_name)) { isSameKey = true; }
        }
        if (!isSameKey)
        {
            userInfo.FishItemkey.Add(Fish_name);
            userInfo.FishItem.Add(Fish_name, Fish_count);
        }
        userInfo.FishItem[Fish_name] = Fish_count;
        isSameKey = false;
        for (int i = 0; i < userInfo.FishItemkey.Count; i++)
        {
            GameObject bottonobj = menuControl.InventoryFish.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image Fishimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.FishItemkey[i].Equals("평범한물고기")) { Fishimg.sprite = fishes1[0]; }
            else if (userInfo.FishItemkey[i].Equals("빨강물고기")) { Fishimg.sprite = fishes2[0]; }
            else if (userInfo.FishItemkey[i].Equals("주황물고기")) { Fishimg.sprite = fishes2[1]; }
            else if (userInfo.FishItemkey[i].Equals("노랑물고기")) { Fishimg.sprite = fishes3[0]; }
            else if (userInfo.FishItemkey[i].Equals("초록물고기")) { Fishimg.sprite = fishes3[1]; }
            else if (userInfo.FishItemkey[i].Equals("남색물고기")) { Fishimg.sprite = fishes4[0]; }
            else if (userInfo.FishItemkey[i].Equals("하늘색물고기")) { Fishimg.sprite = fishes4[1]; }
            else if (userInfo.FishItemkey[i].Equals("보라물고기")) { Fishimg.sprite = fishes5[0]; }
            else if (userInfo.FishItemkey[i].Equals("의사물고기")) { Fishimg.sprite = fishes5[1]; }
            else if (userInfo.FishItemkey[i].Equals("농부물고기")) { Fishimg.sprite = fishes6[0]; }
            else if (userInfo.FishItemkey[i].Equals("무지개물고기")) { Fishimg.sprite = fishes6[1]; }
            else if (userInfo.FishItemkey[i].Equals("공주물고기")) { Fishimg.sprite = fishes7[0]; }
            else if (userInfo.FishItemkey[i].Equals("군인물고기")) { Fishimg.sprite = fishes7[1]; }
            else if (userInfo.FishItemkey[i].Equals("신부물고기")) { Fishimg.sprite = fishes7[2]; }
            else if (userInfo.FishItemkey[i].Equals("신사물고기")) { Fishimg.sprite = fishes7[3]; }
            else if (userInfo.FishItemkey[i].Equals("악마물고기")) { Fishimg.sprite = fishes8[0]; }
            else if (userInfo.FishItemkey[i].Equals("천사물고기")) { Fishimg.sprite = fishes8[1]; }
            else if (userInfo.FishItemkey[i].Equals("스태리팜물고기")) { Fishimg.sprite = fishes9[1]; }
            else if (userInfo.FishItemkey[i].Equals("공대생물고기")) { Fishimg.sprite = fishes9[0]; }
            else if (userInfo.FishItemkey[i].Equals("할머니의사랑물고기")) { Fishimg.sprite = fishes10[0]; }
            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fishtext = text.GetComponent<Text>(); // 과일 개수
            Fishtext.text = userInfo.FishItem[userInfo.FishItemkey[i]].ToString();
            text.SetActive(true);
            Fish_count = 0;
        }
    }
    void False_fishing()
    {
        GameObject Fishing_obj = GameObject.Find("Fishing").transform.GetChild(0).gameObject;
        Fishing_obj.SetActive(false);
        GameObject Result_obj = GameObject.Find("Fishing").transform.GetChild(1).gameObject;
        Result_obj.SetActive(true);
        Image resultimg = Result_obj.transform.GetChild(0).GetComponent<Image>();
        Text resulttext = Result_obj.transform.GetChild(1).GetComponent<Text>();
        textmanager.isAction = true;
        if (userInfo.getGender().Equals("man")) { resultimg.sprite = fish_results[0]; }
        else { resultimg.sprite = fish_results[2]; }
        if (fish_difficulty == 1) { get_fish_name = fishes1[0].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.5f) { int result = Random.Range(0, 2); get_fish_name = fishes2[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.1f) { int result = Random.Range(0, 2); get_fish_name = fishes3[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.08f) { int result = Random.Range(0, 2); get_fish_name = fishes4[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.06f) { int result = Random.Range(0, 2); get_fish_name = fishes5[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.05f) { int result = Random.Range(0, 2); get_fish_name = fishes6[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.04f) { int result = Random.Range(0, 5); get_fish_name = fishes7[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.03f) { int result = Random.Range(0, 2); get_fish_name = fishes8[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.02f) { int result = Random.Range(0, 2); get_fish_name = fishes9[result].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        else if (fish_difficulty == 0.01f) { get_fish_name = fishes10[0].name; resulttext.text = get_fish_name + "를 놓쳤어요..."; }
        CancelInvoke("Finish_Fishing");
        Invoke("finish_result", 5f);
    }
    void finish_result()
    {
        GameObject Result_obj = GameObject.Find("Fishing").transform.GetChild(1).gameObject;
        textmanager.isAction = false;
        isnow_fishing = false;
        isFishing = false;
        Result_obj.SetActive(false);

        anim.SetBool("isFishing", isFishing);
    }

    void OnTriggerStay2D(Collider2D o)
    {
        targetobj = o.gameObject;
        targetobj2 = o.gameObject;
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
            isFishing = false;
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
