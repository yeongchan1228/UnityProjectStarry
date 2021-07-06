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
    public bool issave, issavefirst;
    public GameObject game1, game2;
    Image fish_progressimg;
    GameObject PlayerUI;
    GameObject chatEffect;
    GameObject Sleep, realSleep, Back , Delete_Button, Delete_Inventory, Map, treasure_Map;
    Animator SleepAni;
    ChatEffect chat;
    bool isMan; // 남자인지
    bool isWoman; // 여자인지
    public bool isDeleteButton, isSeed, isFruit, isFish, isStory; // Delete 버튼이 커져있는지  
    private Sprite[] genders;
    public Button Menu_Button1, Menu_Button2;
    public Sprite[] seeds, fruit_afters, fruit_befores, invens, seed2s, special;
    private Sprite[] fishes1, fishes2, fishes3, fishes4, fishes5, fishes6, fishes7, fishes8, fishes9, fishes10;
    //public Image man, woman;
    //Image ManImage, WomanImage;
    UserInfo userInfo;
    public GameObject Inventory, SeedItem, FruitItem, FishItem, ManInfo, WomanInfo;

    public GameObject InventorySeed, InventoryFruit, InventoryFish, InventoryStory;

    GameObject InvenInfo;
    public Text NameInfo, FarmNameInfo, ExpInfo, PowerInfo, ArmorInfo;

    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        //ManImage = ManButton.GetComponent<Image>();
        //WomanImage = WomanButton.GetComponent<Image>();
        //genders = Resources.LoadAll<Sprite>("Sprites/SelectGender");
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        seeds = Resources.LoadAll<Sprite>("Sprites/Seed");
        seed2s = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        fruit_afters = Resources.LoadAll<Sprite>("Sprites/Fruit/after");
        fruit_befores = Resources.LoadAll<Sprite>("Sprites/Fruit/before");
        special = Resources.LoadAll<Sprite>("Sprites/Final");
        invens = Resources.LoadAll<Sprite>("Sprites/Inven");
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

        //GetInfo();
        //Menu_Button1 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Button>();
        //Menu_Button2 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.GetComponent<Button>();
        //Menu_Button1.onClick.AddListener(Menu1Clicked);
        //Menu_Button2.onClick.AddListener(Menu2Clicked);

        ///////////////////////Inventory////////////////////////////
        Inventory = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
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
        InventoryStory = Inventory.transform.GetChild(12).gameObject;
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
                soundManager.GetSlider();
                textmanager.isAction = true; // 캐릭터 움직이지 못하게 막기
            }
        }
        if (issave && issavefirst == false) // 세이브 실행시 한번만
        {
            user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
            user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
            UserInfo user2 = user_man.GetComponent<UserInfo>();
            if (user2.isTrue) { userInfo = user_man.GetComponent<UserInfo>(); playercontrol = user_man.GetComponent<PlayerController>(); }
            else { userInfo = user_woman.GetComponent<UserInfo>(); playercontrol = user_woman.GetComponent<PlayerController>(); }
            issavefirst = true;
            TalkManager TalkMake = GameObject.Find("TalkManager").GetComponent<TalkManager>();
            TalkMake.makeTalking();
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
        if (userInfo.getGender().Equals("man")) {

            PlayerPrefs.SetFloat("PlayerX", user_man.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", user_man.transform.position.y);
        }
        else
        {
            PlayerPrefs.SetFloat("PlayerX", user_woman.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", user_woman.transform.position.y);
        }

        //UserInfo 저장
        PlayerPrefs.SetInt("Day", userInfo.getDay());
        PlayerPrefs.SetInt("CheckDay", userInfo.getCheckDay());
        PlayerPrefs.SetInt("Gold", userInfo.getGold());
        PlayerPrefs.SetInt("Hp", userInfo.getHp());
        PlayerPrefs.SetInt("MaxHp", userInfo.getMaxHp());
        PlayerPrefs.SetInt("Level", userInfo.getLevel());
        PlayerPrefs.SetInt("Exp", userInfo.getExp());
        PlayerPrefs.SetString("Name", userInfo.getName());
        PlayerPrefs.SetString("FarmName", userInfo.getFarmName());
        PlayerPrefs.SetString("Scene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetString("Gender", userInfo.getGender());

        //user Item 저장
        PlayerPrefs.SetString("Weapon_Name", userInfo.getItem_Weapon().GetWeaponName());
        PlayerPrefs.SetInt("Weapon_Power", userInfo.getItem_Weapon().GetWeaponPower());
        if (userInfo.getItem_Armor().GetArmorName() != null)
        {
            PlayerPrefs.SetString("Armor_Name", userInfo.getItem_Armor().GetArmorName());
            PlayerPrefs.SetInt("Armor_Power", userInfo.getItem_Armor().GetArmorPower());
        }
        PlayerPrefs.SetString("Hoe_Name", userInfo.getItem_Hoe().GetHoeName());
        PlayerPrefs.SetFloat("Hoe_Speed", userInfo.getItem_Hoe().GetHoeSpeed());
        PlayerPrefs.SetString("FishingRod_Name", userInfo.getItem_FishingRod().GetFishingRodName());
        PlayerPrefs.SetFloat("FishingRod_Efficiency", userInfo.getItem_FishingRod().GetFishingRodEfficiency());
        PlayerPrefs.SetString("WaterPPU_Name", userInfo.getItem_WaterPPU().GetWaterPPUName());
        PlayerPrefs.SetInt("WaterPPU_Filled", userInfo.getItem_WaterPPU().GetWaterPPUFilled());
        PlayerPrefs.SetInt("SeedItemCount", userInfo.SeedItem.Count);
        PlayerPrefs.SetInt("FishItemCount", userInfo.FishItem.Count);
        PlayerPrefs.SetInt("FruitItemCount", userInfo.FruitItem.Count);
        PlayerPrefs.SetInt("StoryItemCount", userInfo.StoryItem.Count);
        //user Inven 저장
        for (int i = 0; i < userInfo.SeedItemkey.Count; i++)
        {
            PlayerPrefs.SetString("SeedItem" + i, userInfo.SeedItemkey[i]); //Itemkey
            PlayerPrefs.SetString("SeedItemKey"+i, userInfo.SeedItemkey[i]); //Item <- key
            PlayerPrefs.SetInt("SeedItemValue" + i, userInfo.SeedItem[userInfo.SeedItemkey[i]]);//Item <- value
        }
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            PlayerPrefs.SetString("FruitItem" + i, userInfo.FruitItemkey[i]); //Itemkey
            PlayerPrefs.SetString("FruitItemKey" + i, userInfo.FruitItemkey[i]); //Item <- key
            PlayerPrefs.SetInt("FruitItemValue" + i, userInfo.FruitItem[userInfo.FruitItemkey[i]]);//Item <- value
        }
        for (int i = 0; i < userInfo.FishItemkey.Count; i++)
        {
            PlayerPrefs.SetString("FishItem" + i, userInfo.FishItemkey[i]); //Itemkey
            PlayerPrefs.SetString("FishItemKey" + i, userInfo.FishItemkey[i]); //Item <- key
            PlayerPrefs.SetInt("FishItemValue" + i, userInfo.FishItem[userInfo.FishItemkey[i]]);//Item <- value
        }
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            PlayerPrefs.SetString("StoryItem" + i, userInfo.StoryItemkey[i]); //Itemkey
            PlayerPrefs.SetString("StoryItemKey" + i, userInfo.StoryItemkey[i]); //Item <- key
            PlayerPrefs.SetInt("StoryItemValue" + i, userInfo.StoryItem[userInfo.StoryItemkey[i]]);//Item <- value
        }


        ///농사 땅 저장
        PlayerPrefs.SetInt("Saved_FieldCount", playercontrol.SeedField.Count);
        for(int i = 0; i< playercontrol.SeedField.Count; i++)
        {
            SpriteRenderer spriteR = playercontrol.SeedField_name[i].GetComponent<SpriteRenderer>();
            PlayerPrefs.SetString("Saved_Field_Object" + i, playercontrol.SeedField_name[i].name);
            PlayerPrefs.SetString("Saved_Field_Object_sprite" + i, spriteR.sprite.name);
            PlayerPrefs.SetString("Saved_Field_value1_" + i, playercontrol.SeedField[playercontrol.SeedField_name[i].name][0]);
            PlayerPrefs.SetString("Saved_Field_value2_" + i, playercontrol.SeedField[playercontrol.SeedField_name[i].name][1]);
            PlayerPrefs.SetString("Saved_Field_value3_" + i, playercontrol.SeedField[playercontrol.SeedField_name[i].name][2]);
            PlayerPrefs.SetString("Saved_Field_value4_" + i, playercontrol.SeedField[playercontrol.SeedField_name[i].name][3]);
            PlayerPrefs.SetString("Saved_Field_value5_" + i, playercontrol.SeedField[playercontrol.SeedField_name[i].name][4]);
        }
        if (userInfo.npcFinish)
        {
            PlayerPrefs.SetInt("npcFinish2", 1);
        }

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
        GameObject Man = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(5).gameObject;
        Text textman = Man.GetComponent<Text>();
        Shadow shadowman = Man.GetComponent<Shadow>();
        GameObject Woman = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(6).gameObject;
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
        GameObject Man = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(5).gameObject;
        Text textman = Man.GetComponent<Text>();
        Shadow shadowman = Man.GetComponent<Shadow>();
        GameObject Woman = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(6).gameObject;
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
        chatEffect = GameObject.Find("Canvas").transform.GetChild(3).transform.GetChild(0).gameObject;
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
            userInfo.setHp(userInfo.getMaxHp());
            userInfo.setUIHp();
            //chat.isbt1 = true;
            //chat.isbt2 = false;
            //chat.isallbutton = false;
        }

        if(playercontrol.scanObj.name.Equals("dog")) // 강아지한테 지도 본다고 했을 때
        {
            textmanager.talk.SetBool("isShow", false);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            textmanager.talkIndex = 0;
            Map = GameObject.Find("Treasure_Map").transform.GetChild(0).gameObject;
            treasure_Map = Map.transform.GetChild(0).gameObject; // Map 배경
            Map.SetActive(true);
            treasure_Map.SetActive(true);
        }

    }

    public void Menu2Clicked()
    {
        chatEffect = GameObject.Find("Canvas").transform.GetChild(3).transform.GetChild(0).gameObject;
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

        if (playercontrol.scanObj.name.Equals("dog")) // 강아지한테 지도 안 본다고 했을 때
        {
            textmanager.isAction = false; // 다시 움직이게
            textmanager.talk.SetBool("isShow", false);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            chat.buttonOn = false;
            textmanager.talkIndex = 0;
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
            if (checkday == 121)
            {
                userInfo.setCheckDay(0);
                checkday = 0;
            }
            if(day == 30)
            {
                userInfo.setDay(0);
                day = 0;
            }
            userInfo.setCheckDay(++checkday);
            userInfo.setDay(++day);
            userInfo.setHp(userInfo.getMaxHp());
            PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            userInfo.setUIHp();
            Text Daytext = PlayerUI.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            if (userInfo.getCheckDay() < 31) { Daytext.text = "봄, " + userInfo.getDay() + "일"; }
            else if (userInfo.getCheckDay() < 61) { Daytext.text = "여름, " + userInfo.getDay() + "일"; }
            else if (userInfo.getCheckDay() < 91) { Daytext.text = "가을, " + userInfo.getDay() + "일"; }
            else if (userInfo.getCheckDay() < 121) { Daytext.text = "겨울, " + userInfo.getDay() + "일"; }

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
                if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") || playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1"))
                {
                    if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Blueberry"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 1) // 2일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 4)
                        {
                            spriteR.sprite = fruit_befores[0];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("carrot"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 0) // 2일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 3)
                        {
                            spriteR.sprite = fruit_befores[1];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("DARK"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 6) // 7일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 13)
                        {
                            spriteR.sprite = fruit_befores[2];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dhrtntn1"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 2) // 3일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 5)
                        {
                            spriteR.sprite = fruit_befores[3];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("dkqhzkeh1"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 3) // 4일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 7)
                        {
                            spriteR.sprite = fruit_befores[4];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Grape"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 2) // 3일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 4)
                        {
                            spriteR.sprite = fruit_befores[5];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("lamon1"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 2) // 3일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 6)
                        {
                            spriteR.sprite = fruit_befores[6];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("LIGHT"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 6) // 7일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 13)
                        {
                            spriteR.sprite = fruit_befores[7];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("melon"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 3) // 4일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 8)
                        {
                            spriteR.sprite = fruit_befores[8];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("mil1"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 0) // 1일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 2)
                        {
                            spriteR.sprite = fruit_befores[9];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("pineapple1"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 5) // 6일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 10)
                        {
                            spriteR.sprite = fruit_befores[10];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Potato"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 1) // 2일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 5)
                        {
                            spriteR.sprite = fruit_befores[11];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Pumpkin"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 3) // 4일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 8)
                        {
                            spriteR.sprite = fruit_befores[12];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("rkwl1"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 3) // 4일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 9)
                        {
                            spriteR.sprite = fruit_befores[13];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("starry"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 8) // 9일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 15)
                        {
                            spriteR.sprite = fruit_befores[14];
                        }
                    }
                    else if(playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Strawberry"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 3) // 4일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 7)
                        {
                            spriteR.sprite = fruit_befores[15];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("tnsan1"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 2) // 3일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 5)
                        {
                            spriteR.sprite = fruit_befores[16];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("Tomato"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 2) // 3일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 6)
                        {
                            spriteR.sprite = fruit_befores[17];
                        }
                    }
                    else if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][1].Equals("watermelon"))
                    {
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("0") && userInfo.getDay() - SeedDay > 5) // 6일 지나면 새싹 자라기
                        {
                            playercontrol.SeedField_name[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // 다시 돌려주기
                            spriteR.sprite = seeds[3]; // 새싹이 난 땅으로 변경
                            playercontrol.SeedField[playercontrol.SeedField_name[i].name][4] = "1";
                        }
                        if (playercontrol.SeedField[playercontrol.SeedField_name[i].name][4].Equals("1") && userInfo.getDay() - SeedDay > 11)
                        {
                            spriteR.sprite = fruit_befores[18];
                        }
                    }
                }
            i++;
            }
        }
    }
    public void Fish_Clicked() // 물고기 버튼 클릭
    {
        if(fish_progressimg == null) { fish_progressimg = GameObject.Find("Fishing").transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).GetComponent<Image>(); }
        fish_progressimg.fillAmount += userInfo.getItem_FishingRod().GetFishingRodEfficiency() * (float)(playercontrol.fish_difficulty * 0.05);
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
            else if (isStory)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryStory.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
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
            else if (isStory)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryStory.transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
                }
            }
            isDeleteButton = true;
        }
    }

    public void Cancel_Inventory()
    {
        playercontrol.isInven = false;
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
            else if (isStory)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryStory.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        InventorySeed.SetActive(true);
        Image Seedimg = Inventory.transform.GetChild(1).GetComponent<Image>();
        Image Fishimg = Inventory.transform.GetChild(3).GetComponent<Image>();
        Image Fruitimg = Inventory.transform.GetChild(2).GetComponent<Image>();
        Image Storyimg = Inventory.transform.GetChild(11).GetComponent<Image>();
        Seedimg.sprite = invens[2] as Sprite;
        Fishimg.sprite = invens[3] as Sprite;
        Fruitimg.sprite = invens[3] as Sprite;
        Storyimg.sprite = invens[3] as Sprite;
        isSeed = true;
        isFish = false;
        isFruit = false;
        isStory = false;
        if (InventoryFruit.activeSelf) { InventoryFruit.SetActive(false); }
        if (InventoryFish.activeSelf) { InventoryFish.SetActive(false); }
        if (InventoryStory.activeSelf) { InventoryStory.SetActive(false); }
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
            else if (isStory)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryStory.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        InventoryFruit.SetActive(true);
        Image Seedimg = Inventory.transform.GetChild(1).GetComponent<Image>();
        Image Fishimg = Inventory.transform.GetChild(3).GetComponent<Image>();
        Image Fruitimg = Inventory.transform.GetChild(2).GetComponent<Image>();
        Image Storyimg = Inventory.transform.GetChild(11).GetComponent<Image>();
        Seedimg.sprite = invens[3] as Sprite;
        Fishimg.sprite = invens[3] as Sprite;
        Fruitimg.sprite = invens[2] as Sprite;
        Storyimg.sprite = invens[3] as Sprite;
        isSeed = false;
        isFish = false;
        isFruit = true;
        isStory = false;
        if (InventorySeed.activeSelf) { InventorySeed.SetActive(false); }
        if (InventoryFish.activeSelf) { InventoryFish.SetActive(false); }
        if (InventoryStory.activeSelf) { InventoryStory.SetActive(false); }
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
            else if (isStory)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryStory.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        InventoryFish.SetActive(true);
        Image Seedimg = Inventory.transform.GetChild(1).GetComponent<Image>();
        Image Fishimg = Inventory.transform.GetChild(3).GetComponent<Image>();
        Image Fruitimg = Inventory.transform.GetChild(2).GetComponent<Image>();
        Image Storyimg = Inventory.transform.GetChild(11).GetComponent<Image>();
        Seedimg.sprite = invens[3] as Sprite;
        Fishimg.sprite = invens[2] as Sprite;
        Fruitimg.sprite = invens[3] as Sprite;
        Storyimg.sprite = invens[3] as Sprite;
        isSeed = false;
        isFish = true;
        isStory = false;
        isFruit = false;
        if (InventoryFruit.activeSelf) { InventoryFruit.SetActive(false); }
        if (InventorySeed.activeSelf) { InventorySeed.SetActive(false); }
        if (InventoryStory.activeSelf) { InventoryStory.SetActive(false); }
    }
    public void On_StoryItem() // Story Item 창 키기
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
            else if (isFish)
            {
                for (int i = 0; i < 20; i++)
                {
                    InventoryStory.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                }
            }
            isDeleteButton = false;
        }
        InventoryStory.SetActive(true);
        Image Seedimg = Inventory.transform.GetChild(1).GetComponent<Image>();
        Image Fishimg = Inventory.transform.GetChild(3).GetComponent<Image>();
        Image Fruitimg = Inventory.transform.GetChild(2).GetComponent<Image>();
        Image Storyimg = Inventory.transform.GetChild(11).GetComponent<Image>();
        Seedimg.sprite = invens[3] as Sprite;
        Fishimg.sprite = invens[3] as Sprite;
        Fruitimg.sprite = invens[3] as Sprite;
        Storyimg.sprite = invens[2] as Sprite;
        isSeed = false;
        isFish = false;
        isFruit = false;
        isStory = true;
        if (InventoryFruit.activeSelf) { InventoryFruit.SetActive(false); }
        if (InventorySeed.activeSelf) { InventorySeed.SetActive(false); }
        if (InventoryFish.activeSelf) { InventoryFish.SetActive(false); }
    }

    public void Delete_Okay() 
    {
        Image buttonImg = Delete_Button.GetComponent<Image>();
        GameObject asd = Delete_Button.transform.GetChild(0).gameObject;
        Image parentImg = Delete_Button.transform.GetChild(0).GetComponent<Image>();
        if (!asd.activeSelf) { return; }
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

        if (parentname.Equals("평범한물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("빨강물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("주황물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("노랑물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("초록물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("남색물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("하늘색물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("보라물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("의사물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("농부물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("무지개물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("공주물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("군인물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("신부물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("신사물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("악마물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("천사물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("스태리팜물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("공대생물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("할머니의사랑물고기")) { Delete_Item_Fish(parentname, parentImg, buttonImg, Delete_Inventory); }
        
        if (parentname.Equals("milSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("potatoSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("carrotSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("dhrtntnSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("dkqhzkehSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("GrapeSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("lemonSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("blueberrySeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("melonSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("pineappleSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("pumpkinSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("rkwlSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("strawberrySeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("tnsanSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("tomatoSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("watermelonSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("darkSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("lightSeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("starrySeed")) { Delete_Item_Seed(parentname, parentImg, buttonImg, Delete_Inventory); }


        if (parentname.Equals("Orgol")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("하늘색 열쇠")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("초록색 열쇠")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("분홍색 열쇠")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("최종 열쇠")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("할머니의 밀짚모자")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("곰인형")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }
        else if (parentname.Equals("보라색 열쇠")) { Delete_Item_Story(parentname, parentImg, buttonImg, Delete_Inventory); }

        GameObject isDelete = Delete_Inventory.transform.parent.gameObject.transform.GetChild(13).gameObject;
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
        GameObject parentImg = Delete_Button.transform.GetChild(0).gameObject;
        if (parentImg.activeSelf)
        {
            GameObject isDelete = Delete_Inventory.transform.parent.gameObject.transform.GetChild(13).gameObject;
            isDelete.SetActive(true);
        }
        
    }

    void Delete_Item_Fruit(string name, Image parentImg, Image buttonImg, GameObject Inventory)
    {
        userInfo.FruitItem.Remove(name);
        userInfo.FruitItemkey.Remove(name);
        int count = userInfo.FruitItemkey.Count;
        Inventory.transform.GetChild(count).transform.GetChild(0).gameObject.SetActive(false);
        Inventory.transform.GetChild(count).transform.GetChild(1).gameObject.SetActive(false);
        buttonImg.sprite = invens[0] as Sprite;
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            GameObject bottonobj = InventoryFruit.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
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
    void Delete_Item_Seed(string name, Image parentImg, Image buttonImg, GameObject Inventory)
    {
        userInfo.SeedItem.Remove(name);
        userInfo.SeedItemkey.Remove(name);
        GameObject off_img = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject;
        GameObject off_text = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).gameObject;
        Image deleteimg = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>();
        if (deleteimg.sprite.name.Equals(name)){ userInfo.getItem_Pick().SetPickName(null); off_img.SetActive(false); off_text.SetActive(false); }
        int count = userInfo.SeedItemkey.Count;
        Inventory.transform.GetChild(count).transform.GetChild(0).gameObject.SetActive(false);
        Inventory.transform.GetChild(count).transform.GetChild(1).gameObject.SetActive(false);
        buttonImg.sprite = invens[0] as Sprite;
        for (int i = 0; i < userInfo.SeedItemkey.Count; i++)
        {
            GameObject bottonobj = InventorySeed.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image seedimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.SeedItemkey[i].Equals("milSeed")) { seedimg.sprite = seed2s[9]; }
            else if (userInfo.SeedItemkey[i].Equals("potatoSeed")) { seedimg.sprite = seed2s[12]; }
            else if (userInfo.SeedItemkey[i].Equals("carrotSeed")) { seedimg.sprite = seed2s[1]; }
            else if (userInfo.SeedItemkey[i].Equals("dhrtntnSeed")) { seedimg.sprite = seed2s[3]; }
            else if (userInfo.SeedItemkey[i].Equals("dkqhzkehSeed")) { seedimg.sprite = seed2s[4]; }
            else if (userInfo.SeedItemkey[i].Equals("GrapeSeed")) { seedimg.sprite = seed2s[5]; }
            else if (userInfo.SeedItemkey[i].Equals("lemonSeed")) { seedimg.sprite = seed2s[6]; }
            else if (userInfo.SeedItemkey[i].Equals("blueberrySeed")) { seedimg.sprite = seed2s[0]; }
            else if (userInfo.SeedItemkey[i].Equals("melonSeed")) { seedimg.sprite = seed2s[8]; }
            else if (userInfo.SeedItemkey[i].Equals("pineappleSeed")) { seedimg.sprite = seed2s[11]; }
            else if (userInfo.SeedItemkey[i].Equals("pumpkinSeed")) { seedimg.sprite = seed2s[13]; }
            else if (userInfo.SeedItemkey[i].Equals("rkwlSeed")) { seedimg.sprite = seed2s[14]; }
            else if (userInfo.SeedItemkey[i].Equals("strawberrySeed")) { seedimg.sprite = seed2s[16]; }
            else if (userInfo.SeedItemkey[i].Equals("tnsanSeed")) { seedimg.sprite = seed2s[17]; }
            else if (userInfo.SeedItemkey[i].Equals("tomatoSeed")) { seedimg.sprite = seed2s[18]; }
            else if (userInfo.SeedItemkey[i].Equals("watermelonSeed")) { seedimg.sprite = seed2s[19]; }
            else if (userInfo.SeedItemkey[i].Equals("darkSeed")) { seedimg.sprite = seed2s[2]; }
            else if (userInfo.SeedItemkey[i].Equals("lightSeed")) { seedimg.sprite = seed2s[7]; }
            else if (userInfo.SeedItemkey[i].Equals("starrySeed")) { seedimg.sprite = seed2s[15]; }
            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fruittext = text.GetComponent<Text>(); // 과일 개수
            Fruittext.text = userInfo.SeedItem[userInfo.SeedItemkey[i]].ToString();
            text.SetActive(true);
        }
    }
    void Delete_Item_Story(string name, Image parentImg, Image buttonImg, GameObject Inventory)
    {
        userInfo.StoryItem.Remove(name);
        userInfo.StoryItemkey.Remove(name);
        int count = userInfo.StoryItemkey.Count;
        Inventory.transform.GetChild(count).transform.GetChild(0).gameObject.SetActive(false);
        Inventory.transform.GetChild(count).transform.GetChild(1).gameObject.SetActive(false);
        buttonImg.sprite = invens[0] as Sprite;
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            GameObject bottonobj = InventoryStory.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image seedimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.StoryItemkey[i].Equals("Orgol")) { seedimg.sprite = seed2s[10]; }
            else if (userInfo.StoryItemkey[i].Equals("하늘색 열쇠")) { seedimg.sprite = special[0]; }
            else if (userInfo.StoryItemkey[i].Equals("최종 열쇠")) { seedimg.sprite = special[1]; }
            else if (userInfo.StoryItemkey[i].Equals("초록색 열쇠")) { seedimg.sprite = special[2]; }
            else if (userInfo.StoryItemkey[i].Equals("할머니의 밀짚모자")) { seedimg.sprite = special[3]; }
            else if (userInfo.StoryItemkey[i].Equals("분홍색 열쇠")) { seedimg.sprite = special[4]; }
            else if (userInfo.StoryItemkey[i].Equals("보라색 열쇠")) { seedimg.sprite = special[5]; }
            else if (userInfo.StoryItemkey[i].Equals("곰인형")) { seedimg.sprite = special[6]; }

            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fruittext = text.GetComponent<Text>(); // 과일 개수
            Fruittext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
            text.SetActive(true);
        }
    }
    void Delete_Item_Fish(string name, Image parentImg, Image buttonImg, GameObject Inventory)
    {
        userInfo.FishItem.Remove(name);
        userInfo.FishItemkey.Remove(name);
        int count = userInfo.FishItemkey.Count;
        Inventory.transform.GetChild(count).transform.GetChild(0).gameObject.SetActive(false);
        Inventory.transform.GetChild(count).transform.GetChild(1).gameObject.SetActive(false);
        buttonImg.sprite = invens[0] as Sprite;
        for (int i = 0; i < userInfo.FishItemkey.Count; i++)
        {
            GameObject bottonobj = InventoryFish.transform.GetChild(i).gameObject;
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
        }
    }

    public void Item_Button_click()
    {
        
        PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        GameObject select_button = EventSystem.current.currentSelectedGameObject;
        GameObject select_Item = select_button.transform.parent.gameObject;
        Image UISeed = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).GetComponent<Image>();
        GameObject UISeedcount0 = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).gameObject;
        Text UISeedcount = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).GetComponent<Text>();
        GameObject UISeedimg = PlayerUI.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject;
        if (select_Item.name.Equals("InventorySeed"))
        {
            for (int i = 0; i < 20; i++)
            {
                Image bottonimg = select_Item.transform.GetChild(i).GetComponent<Image>();
                bottonimg.sprite = invens[0] as Sprite; // 인벤 비선택
            }
            Image sbottonimg = select_button.GetComponent<Image>();
            GameObject asd = select_button.transform.GetChild(0).gameObject;
            Image ibuttonimg = select_button.transform.GetChild(0).GetComponent<Image>();
            sbottonimg.sprite = invens[1] as Sprite; // 인벤 선택
            if(!asd.activeSelf) { return; }
            if (ibuttonimg.sprite.name.Equals("milSeed")) { UISeed.sprite = seed2s[9]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("mil1"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("potatoSeed")) { UISeed.sprite = seed2s[12]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString();  userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name);  userInfo.getItem_Pick().SetPickKinds("Potato");  UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("carrotSeed")) { UISeed.sprite = seed2s[1]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("carrot"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("dhrtntnSeed")) { UISeed.sprite = seed2s[3]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("dhrtntn1"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("dkqhzkehSeed")) { UISeed.sprite = seed2s[4]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("dkqhzkeh1"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("GrapeSeed")) { UISeed.sprite = seed2s[5]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("Grape"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("lemonSeed")) { UISeed.sprite = seed2s[6]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("lemon1"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("blueberrySeed")) { UISeed.sprite = seed2s[0]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("Blueberry"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("melonSeed")) { UISeed.sprite = seed2s[8]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("melon"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("pineappleSeed")) { UISeed.sprite = seed2s[11]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("pineapple1"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("pumpkinSeed")) { UISeed.sprite = seed2s[13]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("Pumpkin"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("rkwlSeed")) { UISeed.sprite = seed2s[14]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("rkwl1"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("strawberrySeed")) { UISeed.sprite = seed2s[16]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("Strawberry"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("tnsanSeed")) { UISeed.sprite = seed2s[17]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("tnsan1"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("tomatoSeed")) { UISeed.sprite = seed2s[18]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("Tomato"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("watermelonSeed")) { UISeed.sprite = seed2s[19]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("watermelon"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("darkSeed")) { UISeed.sprite = seed2s[2]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("DARK"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("lightSeed")) { UISeed.sprite = seed2s[7]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("LIGHT"); UISeedimg.SetActive(true); }
            else if (ibuttonimg.sprite.name.Equals("starrySeed")) { UISeed.sprite = seed2s[15]; UISeedcount0.SetActive(true); UISeedcount.text = userInfo.SeedItem[ibuttonimg.sprite.name].ToString(); userInfo.getItem_Pick().SetPickName(ibuttonimg.sprite.name); userInfo.getItem_Pick().SetPickKinds("starry"); UISeedimg.SetActive(true); }
        }
        else if (select_Item.name.Equals("InventoryFruit"))
        {
            for (int i = 0; i < 20; i++)
            {
                Image bottonimg = select_Item.transform.GetChild(i).GetComponent<Image>();
                bottonimg.sprite = invens[0] as Sprite; // 인벤 비선택
            }
            Image sbottonimg = select_button.GetComponent<Image>();
            Image ibuttonimg = select_button.transform.GetChild(0).GetComponent<Image>();
            sbottonimg.sprite = invens[1] as Sprite; // 인벤 선택
        }
        else if (select_Item.name.Equals("InventoryFish"))
        {
            for (int i = 0; i < 20; i++)
            {
                Image bottonimg = select_Item.transform.GetChild(i).GetComponent<Image>();
                bottonimg.sprite = invens[0] as Sprite; // 인벤 비선택
            }
            Image sbottonimg = select_button.GetComponent<Image>();
            Image ibuttonimg = select_button.transform.GetChild(0).GetComponent<Image>();
            sbottonimg.sprite = invens[1] as Sprite; // 인벤 선택
        }
        else if (select_Item.name.Equals("InventoryStory"))
        {
            for (int i = 0; i < 20; i++)
            {
                Image bottonimg = select_Item.transform.GetChild(i).GetComponent<Image>();
                bottonimg.sprite = invens[0] as Sprite; // 인벤 비선택
            }
            Image sbottonimg = select_button.GetComponent<Image>();
            Image ibuttonimg = select_button.transform.GetChild(0).GetComponent<Image>();
            sbottonimg.sprite = invens[1] as Sprite; // 인벤 선택
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
