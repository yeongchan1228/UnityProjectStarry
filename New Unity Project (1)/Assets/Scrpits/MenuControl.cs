using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject Menu; // 메뉴 오브젝트
    GameManager textmanager;
    GameObject user_man, user_woman;
    PlayerController playercontrol;
    public GameObject game1, game2;
    GameObject PlayerUI;
    GameObject chatEffect;
    GameObject Sleep, realSleep, Back;
    Animator SleepAni;
    ChatEffect chat;
    bool isMan; // 남자인지
    bool isWoman; // 여자인지
    bool isDeleteButton; // Delete 버튼이 커져있는지  
    private Sprite[] genders;
    public Button Menu_Button1, Menu_Button2;
    public Sprite[] seeds, fruit_afters, fruit_befores;
    //public Image man, woman;
    //Image ManImage, WomanImage;
    UserInfo userInfo;
    public GameObject Inventory, SeedItem, FruitItem, FishItem;
    GameObject InvenInfo;
    Image ManInfo, WomanInfo;
    public Text NameInfo, FarmNameInfo, LevelInfo, ExpInfo, PowerInfo, ArmorInfo;
    GameObject DeleteButton1, DeleteButton2, DeleteButton3, DeleteButton4, DeleteButton5, DeleteButton6, DeleteButton7, DeleteButton8, DeleteButton9, DeleteButton10,
        DeleteButton11, DeleteButton12, DeleteButton13, DeleteButton14, DeleteButton15, DeleteButton16, DeleteButton17, DeleteButton18, DeleteButton19, DeleteButton20;
    // Start is called before the first frame update
    void Start()
    {
        //ManImage = ManButton.GetComponent<Image>();
        //WomanImage = WomanButton.GetComponent<Image>();
        //genders = Resources.LoadAll<Sprite>("Sprites/SelectGender");
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        seeds = Resources.LoadAll<Sprite>("Sprites/Seed");
        fruit_afters = Resources.LoadAll<Sprite>("Sprites/Fruit/after");
        fruit_befores = Resources.LoadAll<Sprite>("Sprites/Fruit/before");
        //GetInfo();
        //Menu_Button1 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Button>();
        //Menu_Button2 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.GetComponent<Button>();
        //Menu_Button1.onClick.AddListener(Menu1Clicked);
        //Menu_Button2.onClick.AddListener(Menu2Clicked);

        ///////////////////////Inventory////////////////////////////
        Inventory = GameObject.Find("Canvas").transform.GetChild(5).gameObject;
        SeedItem = Inventory.transform.GetChild(1).gameObject;
        FruitItem = Inventory.transform.GetChild(2).gameObject;
        FishItem = Inventory.transform.GetChild(3).gameObject;

        InvenInfo = Inventory.transform.GetChild(9).gameObject;
        ManInfo = InvenInfo.transform.GetChild(0).gameObject.GetComponent<Image>();
        WomanInfo = InvenInfo.transform.GetChild(1).gameObject.GetComponent<Image>();
        NameInfo = InvenInfo.transform.GetChild(2).gameObject.GetComponent<Text>();
        FarmNameInfo = InvenInfo.transform.GetChild(3).gameObject.GetComponent<Text>();
        ExpInfo = InvenInfo.transform.GetChild(4).gameObject.GetComponent<Text>();
        PowerInfo = InvenInfo.transform.GetChild(5).gameObject.GetComponent<Text>();
        ArmorInfo = InvenInfo.transform.GetChild(6).gameObject.GetComponent<Text>();

        DeleteButton1 = Inventory.transform.GetChild(6).transform.GetChild(0).transform.GetChild(2).gameObject;
        DeleteButton2 = Inventory.transform.GetChild(6).transform.GetChild(1).transform.GetChild(2).gameObject;
        DeleteButton3 = Inventory.transform.GetChild(6).transform.GetChild(2).transform.GetChild(2).gameObject;
        DeleteButton4 = Inventory.transform.GetChild(6).transform.GetChild(3).transform.GetChild(2).gameObject;
        DeleteButton5 = Inventory.transform.GetChild(6).transform.GetChild(4).transform.GetChild(2).gameObject;
        DeleteButton6 = Inventory.transform.GetChild(6).transform.GetChild(5).transform.GetChild(2).gameObject;
        DeleteButton7 = Inventory.transform.GetChild(6).transform.GetChild(6).transform.GetChild(2).gameObject;
        DeleteButton8 = Inventory.transform.GetChild(6).transform.GetChild(7).transform.GetChild(2).gameObject;
        DeleteButton9 = Inventory.transform.GetChild(6).transform.GetChild(8).transform.GetChild(2).gameObject;
        DeleteButton10 = Inventory.transform.GetChild(6).transform.GetChild(9).transform.GetChild(2).gameObject;
        DeleteButton11 = Inventory.transform.GetChild(6).transform.GetChild(10).transform.GetChild(2).gameObject;
        DeleteButton12 = Inventory.transform.GetChild(6).transform.GetChild(11).transform.GetChild(2).gameObject;
        DeleteButton13 = Inventory.transform.GetChild(6).transform.GetChild(12).transform.GetChild(2).gameObject;
        DeleteButton14 = Inventory.transform.GetChild(6).transform.GetChild(13).transform.GetChild(2).gameObject;
        DeleteButton15 = Inventory.transform.GetChild(6).transform.GetChild(14).transform.GetChild(2).gameObject;
        DeleteButton16 = Inventory.transform.GetChild(6).transform.GetChild(15).transform.GetChild(2).gameObject;
        DeleteButton17 = Inventory.transform.GetChild(6).transform.GetChild(16).transform.GetChild(2).gameObject;
        DeleteButton18 = Inventory.transform.GetChild(6).transform.GetChild(17).transform.GetChild(2).gameObject;
        DeleteButton19 = Inventory.transform.GetChild(6).transform.GetChild(18).transform.GetChild(2).gameObject;
        DeleteButton20 = Inventory.transform.GetChild(6).transform.GetChild(19).transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) // Esc 눌렀을 시
        {
            if (Menu.activeSelf)
            {
                textmanager.isAction = false; // 다시 움직이게
                Menu.SetActive(false);
            }
            else
            {
                Menu.SetActive(true);
                textmanager.isAction = true; // 캐릭터 움직이지 못하게 막기
            }
        }
    }

    void GetInfo()
    {
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (isMan)
        {
            userInfo = user_man.GetComponent<UserInfo>();
            playercontrol = user_man.GetComponent<PlayerController>();
        }
        else { 
            userInfo = user_woman.GetComponent<UserInfo>();
            playercontrol = user_woman.GetComponent<PlayerController>();
        }
    }

    public void GameContinues() // 게임 계속 실행
    {
        textmanager.isAction = false; // 다시 움직이게
        Menu.SetActive(false); // 메뉴 끄기
    }

    public void GameExit() // 게임 종료
    {
        Application.Quit();
    }

    public void GameSave() // 게임 저장
    {
        //PlayerPefs 데이터 저장 함수
        //플레이어 위치 저장
        PlayerPrefs.SetFloat("PlayerX", user_man.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", user_man.transform.position.y);
        
        //UserInfo 저장


        //PlayerPrefs에 저장
        PlayerPrefs.Save();

        //메뉴 닫기
        textmanager.isAction = false; // 다시 움직이게
        Menu.SetActive(false); // 메뉴 끄기
    } 

    public void CreateMan()
    {
        isMan = true;
        isWoman = false;
        GameObject Man = GameObject.Find("Canvas").transform.GetChild(0).gameObject.transform.GetChild(5).gameObject;
        Text textman = Man.GetComponent<Text>();
        Shadow shadowman = Man.GetComponent<Shadow>();
        GameObject Woman = GameObject.Find("Canvas").transform.GetChild(0).gameObject.transform.GetChild(6).gameObject;
        Text textwoman = Woman.GetComponent<Text>();
        Shadow shadowwoman = Woman.GetComponent<Shadow>();
        textman.color = new Color(152 / 255f, 78 / 255f, 233 / 255f, 255 / 255f);
        shadowman.effectColor = new Color(255 / 255f, 255 / 255f, 255 / 255f, 128 / 255f);
        textwoman.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        shadowwoman.effectColor = new Color(0 / 255f, 0 / 255f, 0 / 255f, 128 / 255f);
    }

    public void CreateWoMan()
    {
        isMan = false;
        isWoman = true;
        GameObject Man = GameObject.Find("Canvas").transform.GetChild(0).gameObject.transform.GetChild(5).gameObject;
        Text textman = Man.GetComponent<Text>();
        Shadow shadowman = Man.GetComponent<Shadow>();
        GameObject Woman = GameObject.Find("Canvas").transform.GetChild(0).gameObject.transform.GetChild(6).gameObject;
        Text textwoman = Woman.GetComponent<Text>();
        Shadow shadowwoman = Woman.GetComponent<Shadow>();
        textman.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        shadowman.effectColor = new Color(0 / 255f, 0 / 255f, 0 / 255f, 128 / 255f);
        textwoman.color = new Color(152 / 255f, 78 / 255f, 233 / 255f, 255 / 255f);
        shadowwoman.effectColor = new Color(255 / 255f, 255 / 255f, 255 / 255f, 128 / 255f);
    }

    public void Name_FarmName()
    {
        GetInfo();
        Text text1 = game1.GetComponent<Text>();
        Text text2 = game2.GetComponent<Text>();
        if(text1.text.Length < 1 || text2.text.Length < 1 || (isMan == false && isWoman == false))
        {

        }
        else
        {
            userInfo.setName(text1.text);
            userInfo.setFarmName(text2.text);
            userInfo.isTrue = true;
            userInfo.setHp(100);
            userInfo.setDay(1);
            userInfo.setCheckDay(1);
            userInfo.setLevel(1);
            userInfo.setExp(0);
            userInfo.setMaxHp(100);
            SceneManager.LoadScene("FirstStory (4)");
        }
    }

    public void Menu1Clicked()
    {
        chatEffect = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).gameObject;
        chat = chatEffect.GetComponent<ChatEffect>();
        if (playercontrol.scanObj.name.Equals("poor-kid1")) // 광부일 때
        {
            textmanager.isAction = false; // 다시 움직이게
            textmanager.talk.SetBool("isShow", textmanager.isAction);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            textmanager.talkIndex = 0;
            userInfo.userWhere = 1;
            chat.buttonOn = false;
            //chat.isbt1 = true;
            //chat.isbt2 = false;
            //chat.isallbutton = false;
            SceneManager.LoadScene("Dungeon (11)");
        }
        if (playercontrol.scanObj.name.Equals("bed")) // 침대일 때(쉬기)
        {
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            textmanager.talkIndex = 0;
            Back = GameObject.Find("Sleep").transform.GetChild(0).gameObject;
            Sleep = Back.transform.GetChild(0).gameObject; // Sleep 배경
            realSleep = Sleep.transform.GetChild(1).gameObject;
            SleepAni = realSleep.GetComponent<Animator>();
            textmanager.talk.SetBool("isShow", false);
            Back.SetActive(true);
            Sleep.SetActive(true);
            realSleep.SetActive(true);
            SleepAni.SetTrigger("isRest");
            Invoke("Off_Rest", 2f);
            userInfo.setHp(100);
            userInfo.setUIHp();
            //chat.isbt1 = true;
            //chat.isbt2 = false;
            //chat.isallbutton = false;
        }

    }

    public void Menu2Clicked()
    {
        chatEffect = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).gameObject;
        Debug.Log(chatEffect);
        chat = chatEffect.GetComponent<ChatEffect>();
        if (playercontrol.scanObj.name.Equals("poor-kid1")) // 광부일 때
        {
            textmanager.isAction = false; // 다시 움직이게
            textmanager.talk.SetBool("isShow", textmanager.isAction);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            chat.buttonOn = false;
            textmanager.talkIndex = 0;
            //chat.isbt1 = true;
            //chat.isbt2 = false;
            //chat.isallbutton = false;
        }
        else if (playercontrol.scanObj.name.Equals("bed")) // 침대일 때 (잠자기)
        {
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            textmanager.talkIndex = 0;
            Back = GameObject.Find("Sleep").transform.GetChild(0).gameObject;
            Sleep = Back.transform.GetChild(0).gameObject; // Sleep 배경
            realSleep = Sleep.transform.GetChild(0).gameObject;
            SleepAni = realSleep.GetComponent<Animator>();
            textmanager.talk.SetBool("isShow", false);
            Back.SetActive(true);
            Sleep.SetActive(true);
            realSleep.SetActive(true);
            SleepAni.SetTrigger("isSleep");
            Invoke("Off_Sleep", 4.6f);
            int checkday = userInfo.getCheckDay();
            int day = userInfo.getDay();
            userInfo.setCheckDay(++checkday);
            userInfo.setDay(++day);
            userInfo.setHp(100);
            PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            userInfo.setUIHp();
            Text Daytext = PlayerUI.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            if (userInfo.getCheckDay() < 30)
            {
                Daytext.text = "봄, " + userInfo.getDay() + "일";
            }
            else if(userInfo.getCheckDay() < 60)
            {
                Daytext.text = "여름, " + userInfo.getDay() + "일";
            }
            //chat.isbt1 = true;
            //chat.isbt2 = false;
            //chat.isallbutton = false;

           
            for (int i = 0; i < playercontrol.SeedField_name.Count;)
            {
                SpriteRenderer spriteR = playercontrol.SeedField_name[i].GetComponent<SpriteRenderer>();
                playercontrol.SeedField[playercontrol.SeedField_name[i].name][3] = "0"; // 물뿌린 횟수 0
                int WaterCount = int.Parse(playercontrol.SeedField[playercontrol.SeedField_name[i].name][2]);
                WaterCount--;
                playercontrol.SeedField[playercontrol.SeedField_name[i].name][2] = WaterCount.ToString();
                if (spriteR.sprite.name.Equals("Water"))
                {
                    spriteR.sprite = seeds[2]; // 물 안뿌린 땅으로 변경
                }
                if (int.Parse(playercontrol.SeedField[playercontrol.SeedField_name[i].name][2]) == 0) // 물 2번 안주면 죽이기
                {
                    playercontrol.SeedField.Remove(playercontrol.SeedField_name[i].name); // 없애기
                    playercontrol.SeedField_name.RemoveAt(i); // 없애기
                    spriteR.sprite = seeds[1]; // 농사 가능 땅으로 변경
                    continue;
                }
                int SeedDay = int.Parse(playercontrol.SeedField[playercontrol.SeedField_name[i].name][0]);
                if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0"))
                {
                    if (userInfo.getDay() - SeedDay > 1) // 2일 지나면 새싹 자라기
                    {
                        playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                        spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                        playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                    }
                }
                if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1"))
                {
                    if (userInfo.getDay() - SeedDay > 4) // 5일 지나면  자라기
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("blueberry")) { spriteR.sprite = fruit_befores[0]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("carrot")) { spriteR.sprite = fruit_befores[1]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dark")) { spriteR.sprite = fruit_befores[2]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dhrtntn")) { spriteR.sprite = fruit_befores[3]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dkqhzkeh0")) { spriteR.sprite = fruit_befores[4]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("grape")) { spriteR.sprite = fruit_befores[5]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("lemon0")) { spriteR.sprite = fruit_befores[6]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("light1")) { spriteR.sprite = fruit_befores[7]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("melon")) { spriteR.sprite = fruit_befores[8]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("mil0")) { spriteR.sprite = fruit_befores[9]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("pineapple0")) { spriteR.sprite = fruit_befores[10]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("potato")) { spriteR.sprite = fruit_befores[11]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("pumpkin")) { spriteR.sprite = fruit_befores[12]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("rkwl0")) { spriteR.sprite = fruit_befores[13]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("starry1")) { spriteR.sprite = fruit_befores[14]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("strawberry")) { spriteR.sprite = fruit_befores[15]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("tnsan0")) { spriteR.sprite = fruit_befores[16]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("tomato")) { spriteR.sprite = fruit_befores[17]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("watermelon")) { spriteR.sprite = fruit_befores[18]; }
                        playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "2";
                    }
                }
                /*if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("2"))
                {
                    if (userInfo.getDay() - SeedDay > 6) // 7일 후 열매
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("blueberry")) { spriteR.sprite = fruit_afters[0]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("carrot")) { spriteR.sprite = fruit_afters[1]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dark")) { spriteR.sprite = fruit_afters[2]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dhrtntn")) { spriteR.sprite = fruit_afters[3]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dkqhzkeh0")) { spriteR.sprite = fruit_afters[4]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("grape")) { spriteR.sprite = fruit_afters[5]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("lemon0")) { spriteR.sprite = fruit_afters[6]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("light1")) { spriteR.sprite = fruit_afters[7]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("melon")) { spriteR.sprite = fruit_afters[8]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("mil0")) { spriteR.sprite = fruit_afters[9]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("pineapple0")) { spriteR.sprite = fruit_afters[10]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("potato")) { spriteR.sprite = fruit_afters[11]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("pumpkin")) { spriteR.sprite = fruit_afters[12]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("rkwl0")) { spriteR.sprite = fruit_afters[13]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("starry1")) { spriteR.sprite = fruit_afters[14]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("strawberry")) { spriteR.sprite = fruit_afters[15]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("tnsan0")) { spriteR.sprite = fruit_afters[16]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("tomato")) { spriteR.sprite = fruit_afters[17]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("watermelon")) { spriteR.sprite = fruit_afters[18]; }
                        playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "3";
                    } 
                }*/
                i++;
            }
        }

    }

    public void On_DeleteButton()  // Delete 버튼 On
    {
        if (isDeleteButton)
        {
            DeleteButton1.SetActive(false);
            DeleteButton2.SetActive(false);
            DeleteButton3.SetActive(false);
            DeleteButton4.SetActive(false);
            DeleteButton5.SetActive(false);
            DeleteButton6.SetActive(false);
            DeleteButton7.SetActive(false);
            DeleteButton8.SetActive(false);
            DeleteButton9.SetActive(false);
            DeleteButton10.SetActive(false);
            DeleteButton11.SetActive(false);
            DeleteButton12.SetActive(false);
            DeleteButton13.SetActive(false);
            DeleteButton14.SetActive(false);
            DeleteButton15.SetActive(false);
            DeleteButton16.SetActive(false);
            DeleteButton17.SetActive(false);
            DeleteButton18.SetActive(false);
            DeleteButton19.SetActive(false);
            DeleteButton20.SetActive(false);
            isDeleteButton = false;
        }
        else
        {
            DeleteButton1.SetActive(true);
            DeleteButton2.SetActive(true);
            DeleteButton3.SetActive(true);
            DeleteButton4.SetActive(true);
            DeleteButton5.SetActive(true);
            DeleteButton6.SetActive(true);
            DeleteButton7.SetActive(true);
            DeleteButton8.SetActive(true);
            DeleteButton9.SetActive(true);
            DeleteButton10.SetActive(true);
            DeleteButton11.SetActive(true);
            DeleteButton12.SetActive(true);
            DeleteButton13.SetActive(true);
            DeleteButton14.SetActive(true);
            DeleteButton15.SetActive(true);
            DeleteButton16.SetActive(true);
            DeleteButton17.SetActive(true);
            DeleteButton18.SetActive(true);
            DeleteButton19.SetActive(true);
            DeleteButton20.SetActive(true);
            isDeleteButton = true;
        }
    }

    public void Cancel_Inventory()
    {
        Inventory.SetActive(false);
    } // Inventory 종료

    public void On_SeedItem() // Seed Item 창 키기
    {
        SeedItem.SetActive(true);
        if (FruitItem.activeSelf) { FruitItem.SetActive(false); }
        if (FishItem.activeSelf) { FishItem.SetActive(false); }
    }
    public void On_Fruittem() // Fruit Item 창 키기
    {
        FruitItem.SetActive(true);
        if (SeedItem.activeSelf) { SeedItem.SetActive(false); }
        if (FishItem.activeSelf) { FishItem.SetActive(false); }
    }
    public void On_FishItem() // Fish Item 창 키기
    {
        FishItem.SetActive(true);
        if (FruitItem.activeSelf) { FruitItem.SetActive(false); }
        if (SeedItem.activeSelf) { SeedItem.SetActive(false); }
    }


    void Off_Sleep()
    {
        realSleep.SetActive(false);
        Sleep.SetActive(false);
        chat.buttonOn = false;
        Back.SetActive(false);
        textmanager.isAction = false; // 다시 움직이게
    }
    void Off_Rest()
    {
        realSleep.SetActive(false);
        chat.buttonOn = false;
        Sleep.SetActive(false);
        Back.SetActive(false);
        textmanager.isAction = false; // 다시 움직이게
    }

}
