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
    GameObject Sleep, realSleep, Back , Delete_Button, Delete_Inventory;
    Animator SleepAni;
    ChatEffect chat;
    bool isMan; // 남자인지
    bool isWoman; // 여자인지
    public bool isDeleteButton, isSeed, isFruit, isFish; // Delete 버튼이 커져있는지  
    private Sprite[] genders;
    public Button Menu_Button1, Menu_Button2;
    public Sprite[] seeds, fruit_afters, fruit_befores, invens;
    //public Image man, woman;
    //Image ManImage, WomanImage;
    UserInfo userInfo;
    public GameObject Inventory, SeedItem, FruitItem, FishItem, ManInfo, WomanInfo;

    public GameObject InventorySeed, InventoryFruit, InventoryFish;

    GameObject InvenInfo;
    public Text NameInfo, FarmNameInfo, ExpInfo, PowerInfo, ArmorInfo;
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
        invens = Resources.LoadAll<Sprite>("Sprites/Inven");
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
        ManInfo = InvenInfo.transform.GetChild(0).gameObject;
        WomanInfo = InvenInfo.transform.GetChild(1).gameObject;
        NameInfo = InvenInfo.transform.GetChild(2).gameObject.GetComponent<Text>();
        FarmNameInfo = InvenInfo.transform.GetChild(3).gameObject.GetComponent<Text>();
        ExpInfo = InvenInfo.transform.GetChild(4).gameObject.GetComponent<Text>();
        PowerInfo = InvenInfo.transform.GetChild(5).gameObject.GetComponent<Text>();
        ArmorInfo = InvenInfo.transform.GetChild(6).gameObject.GetComponent<Text>();


        InventorySeed = Inventory.transform.GetChild(6).gameObject;
        InventoryFruit = Inventory.transform.GetChild(7).gameObject;
        InventoryFish = Inventory.transform.GetChild(8).gameObject;
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
        textmanager.isman = true;
        textmanager.iswoman = false;
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
        textmanager.isman = false;
        textmanager.iswoman = true;
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
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Blueberry")) { spriteR.sprite = fruit_befores[0]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("carrot")) { spriteR.sprite = fruit_befores[1]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("DARK")) { spriteR.sprite = fruit_befores[2]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dhrtntn1")) { spriteR.sprite = fruit_befores[3]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dkqhzkeh1")) { spriteR.sprite = fruit_befores[4]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Grape")) { spriteR.sprite = fruit_befores[5]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("lemon1")) { spriteR.sprite = fruit_befores[6]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("LIGHT")) { spriteR.sprite = fruit_befores[7]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("melon")) { spriteR.sprite = fruit_befores[8]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("mil1")) { spriteR.sprite = fruit_befores[9]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("pineapple1")) { spriteR.sprite = fruit_befores[10]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Potato")) { spriteR.sprite = fruit_befores[11]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Pumpkin")) { spriteR.sprite = fruit_befores[12]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("rkwl1")) { spriteR.sprite = fruit_befores[13]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("starry")) { spriteR.sprite = fruit_befores[14]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Strawberry")) { spriteR.sprite = fruit_befores[15]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("tnsan1")) { spriteR.sprite = fruit_befores[16]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Tomato")) { spriteR.sprite = fruit_befores[17]; }
                        else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("watermelon")) { spriteR.sprite = fruit_befores[18]; }
                        playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "2";
                    }
                }
                i++;
            }
        }

    }

    public void On_DeleteButton()  // Delete 버튼 On
    {
        if (isDeleteButton)
        {
            if (isSeed)
            {
                for(int i = 0; i < 20; i++)
                {
                    InventorySeed.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            else if (isFruit)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFruit.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            else if (isFish)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFish.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        else
        {
            if (isSeed)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventorySeed.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                }
            }
            else if (isFruit)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFruit.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                }
            }
            else if (isFish)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFish.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                }
            }
            isDeleteButton = true;
        }
    }

    public void Cancel_Inventory()
    {
        Inventory.SetActive(false);
    } // Inventory 종료

    public void On_SeedItem() // Seed Item 창 키기
    {
        if (isDeleteButton)
        {
            if (isFruit)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFruit.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            else if (isFish)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFish.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        InventorySeed.SetActive(true);
        isSeed = true;
        isFish = false;
        isFruit = false;
        if (InventoryFruit.activeSelf) { InventoryFruit.SetActive(false); }
        if (InventoryFish.activeSelf) { InventoryFish.SetActive(false); }
    }
    public void On_Fruittem() // Fruit Item 창 키기
    {
        if (isDeleteButton)
        {
            if (isSeed)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventorySeed.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            else if (isFish)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFish.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        InventoryFruit.SetActive(true);
        isSeed = false;
        isFish = false;
        isFruit = true;
        if (InventorySeed.activeSelf) { InventorySeed.SetActive(false); }
        if (InventoryFish.activeSelf) { InventoryFish.SetActive(false); }
    }
    public void On_FishItem() // Fish Item 창 키기
    {
        if (isDeleteButton)
        {
            if (isSeed)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventorySeed.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            else if (isFruit)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryFruit.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        InventoryFish.SetActive(true);
        isSeed = false;
        isFish = true;
        isFruit = false;
        if (InventoryFruit.activeSelf) { InventoryFruit.SetActive(false); }
        if (InventorySeed.activeSelf) { InventorySeed.SetActive(false); }
    }

    public void Delete_Okay() 
    {
        Image buttonImg = Delete_Button.GetComponent<Image>();
        Image parentImg = Delete_Button.transform.GetChild(0).GetComponent<Image>();
        string parentname = parentImg.sprite.name;
        if (parentname.Equals("Blueberry")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("carrot")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("DARK")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("dhrtntn1")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("dkqhzkeh1")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("Grape")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("lemon1")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("LIGHT")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("melon")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("mil1")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("pineapple1")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("Potato")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("Pumpkin")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("rkwl1")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("starry")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("Strawberry")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("tnsan1")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("Tomato")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("watermelon")) { Delete_Item_Fruit(parentname, parentImg, buttonImg, Delete_Inventory); }
        GameObject isDelete = Delete_Inventory.transform.parent.gameObject.transform.GetChild(10).gameObject;
        isDelete.SetActive(false);
    }
    public void Delete_Cancel() 
    {
        GameObject isDelete = Delete_Inventory.transform.parent.gameObject.transform.GetChild(10).gameObject;
        isDelete.SetActive(false);
    }

    public void Delete_Item()
    {
        Delete_Button = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Delete_Inventory = Delete_Button.transform.parent.gameObject;
        GameObject isDelete = Delete_Inventory.transform.parent.gameObject.transform.GetChild(10).gameObject;
        isDelete.SetActive(true);
        
    }

    void Delete_Item_Fruit(string name, Image parentImg, Image buttonImg, GameObject Inventory)
    {
        userInfo.FruitItem.Remove(name);
        userInfo.FruitItemkey.Remove(name);
        int count = userInfo.FishItemkey.Count;
        Inventory.transform.GetChild(count).transform.GetChild(0).gameObject.SetActive(false);
        Inventory.transform.GetChild(count).transform.GetChild(1).gameObject.SetActive(false);
        buttonImg.sprite = invens[0] as Sprite;
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            GameObject bottonobj = InventoryFruit.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            if (i == 0)
            {
                bottonimg.sprite = invens[1] as Sprite; // 인벤 선택
            }
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image Fruitimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.FruitItemkey[i].Equals("Blueberry")) { Fruitimg.sprite = fruit_afters[0]; }
            else if (userInfo.FruitItemkey[i].Equals("carrot")) { Fruitimg.sprite = fruit_afters[1]; }
            else if (userInfo.FruitItemkey[i].Equals("DARK")) { Fruitimg.sprite = fruit_afters[2]; }
            else if (userInfo.FruitItemkey[i].Equals("dhrtntn1")) { Fruitimg.sprite = fruit_afters[3]; }
            else if (userInfo.FruitItemkey[i].Equals("dkqhzkeh1")) { Fruitimg.sprite = fruit_afters[4]; }
            else if (userInfo.FruitItemkey[i].Equals("Grape")) { Fruitimg.sprite = fruit_afters[5]; }
            else if (userInfo.FruitItemkey[i].Equals("lemon1")) { Fruitimg.sprite = fruit_afters[6]; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { Fruitimg.sprite = fruit_afters[7]; }
            else if (userInfo.FruitItemkey[i].Equals("melon")) { Fruitimg.sprite = fruit_afters[8]; }
            else if (userInfo.FruitItemkey[i].Equals("mil1")) { Fruitimg.sprite = fruit_afters[9]; }
            else if (userInfo.FruitItemkey[i].Equals("pineapple1")) { Fruitimg.sprite = fruit_afters[10]; }
            else if (userInfo.FruitItemkey[i].Equals("Potato")) { Fruitimg.sprite = fruit_afters[11]; }
            else if (userInfo.FruitItemkey[i].Equals("Pumpkin")) { Fruitimg.sprite = fruit_afters[12]; }
            else if (userInfo.FruitItemkey[i].Equals("rkwl1")) { Fruitimg.sprite = fruit_afters[13]; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { Fruitimg.sprite = fruit_afters[14]; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { Fruitimg.sprite = fruit_afters[15]; }
            else if (userInfo.FruitItemkey[i].Equals("tnsan1")) { Fruitimg.sprite = fruit_afters[16]; }
            else if (userInfo.FruitItemkey[i].Equals("Tomato")) { Fruitimg.sprite = fruit_afters[17]; }
            else if (userInfo.FruitItemkey[i].Equals("watermelon")) { Fruitimg.sprite = fruit_afters[18]; }
            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fruittext = text.GetComponent<Text>(); // 과일 개수
            Fruittext.text = userInfo.FruitItem[userInfo.FruitItemkey[i]].ToString();
            text.SetActive(true);
        }
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
