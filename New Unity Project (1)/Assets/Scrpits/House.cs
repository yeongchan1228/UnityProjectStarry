using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    GameObject user_man;
    GameObject user_woman;
    GameObject PlayerUI;
    PlayerController player;
    UserInfo userInfo;
    public Animator sleep;
    private Sprite[] tools, Uiboxs, swords, seedbarrels,invens;
    MenuControl menuControl;
    //public Button Menu_Button1, Menu_Button2;
    //MenuControl menuControl;
    //public bool isAction; // 애니시작/종료
    //public Animator ImgAnimator;
    void Awake()
    {
        GameObject firststory = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        firststory.SetActive(false);
        //sleep = GameObject.Find("Sleep").transform.GetChild(0).gameObject.GetComponent<Animator>();
        GameObject game = GameObject.Find("Player");
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        tools = Resources.LoadAll<Sprite>("Sprites/Tool");
        Uiboxs = Resources.LoadAll<Sprite>("Sprites/ItemBox");
        swords = Resources.LoadAll<Sprite>("Sprites/sword");
        invens = Resources.LoadAll<Sprite>("Sprites/Inven");
        seedbarrels = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        menuControl = GameObject.Find("MenuManager").GetComponent<MenuControl>();
        //GameObject Camera1 = GameObject.Find("Main Camera");
        //Camera camera = Camera1.GetComponent<Camera>();
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
            if (userInfo.storycounter < 1)
            {
                user_man.SetActive(true);
                player = user_man.GetComponent<PlayerController>();
                player.SetStartXY(-47f, -29f);
                userInfo.storycounter++;
                userInfo.getItem_WaterPPU().SetWaterPPUName("Stone_Water"); // 기본 물뿌리개 장착
                userInfo.getItem_WaterPPU().SetWaterPPUFilled(100);
                userInfo.getItem_Hoe().SetHoeName("Stone_Hoe");
                userInfo.getItem_Hoe().SetHoeSpeed(10f);
                userInfo.getItem_FishingRod().SetFishingRodName("Stone_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(1f);
                userInfo.getItem_Weapon().SetWeaponName("rustysword");
                userInfo.getItem_Weapon().SetWeaponPower(5);
                GameObject Inventory = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
                Image Seedimg = Inventory.transform.GetChild(1).GetComponent<Image>();
                Image Fishimg = Inventory.transform.GetChild(2).GetComponent<Image>();
                Image Fruitimg = Inventory.transform.GetChild(3).GetComponent<Image>();
                Image Storyimg = Inventory.transform.GetChild(11).GetComponent<Image>();
                Seedimg.sprite = invens[2] as Sprite;
                Fishimg.sprite = invens[3] as Sprite;
                Fruitimg.sprite = invens[3] as Sprite;
                Storyimg.sprite = invens[3] as Sprite;
                menuControl.NameInfo.text = "이름 : " + userInfo.getName();
                menuControl.FarmNameInfo.text = "농장 이름 : " + userInfo.getFarmName();
                menuControl.isSeed = true;
                menuControl.ManInfo.SetActive(true);
                if (menuControl.WomanInfo.activeSelf) { menuControl.WomanInfo.SetActive(false); }
                if (!player.isPlayerUI)
                {
                    PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
                    RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
                    pos.anchoredPosition = new Vector2(-120, -20);
                    Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                    maptext.text = "'"+userInfo.getName()+"'의 집";
                    GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                    GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
                    GameObject itemobj1 = itembox1.transform.GetChild(0).gameObject;
                    GameObject itemobj2 = itembox2.transform.GetChild(0).gameObject;
                    GameObject itemobj3 = itembox3.transform.GetChild(0).gameObject;
                    GameObject itemobj4 = itembox4.transform.GetChild(0).gameObject;
                    Image selectItemBox = itembox1.GetComponent<Image>();
                    Image ItemImg1 = itemobj1.GetComponent<Image>();
                    ItemImg1.sprite = swords[6]; // 검
                    Image ItemImg2 = itemobj2.GetComponent<Image>();
                    ItemImg2.sprite = tools[13]; // 호미
                    Image ItemImg3 = itemobj3.GetComponent<Image>();
                    ItemImg3.sprite = tools[11]; // 낚시대
                    Image ItemImg4 = itemobj4.GetComponent<Image>();
                    ItemImg4.sprite = tools[14]; // 물뿌리개
                    PlayerUI.SetActive(true);
                    selectItemBox.sprite = Uiboxs[0]; // 선택으로 변경
                    userInfo.isSword = true;
                    itemobj1.SetActive(true);
                    itemobj2.SetActive(true);
                    itemobj3.SetActive(true);
                    itemobj4.SetActive(true);
                    PlayerUI.SetActive(true);
                    player.isPlayerUI = true;

                }
            }
            else {
                PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
                RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
                pos.anchoredPosition = new Vector2(-120, -20);
                Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                maptext.text = "'" + userInfo.getName() + "'의 집";
                user_man.transform.position = new Vector3(-50.5f, -33f, 0);
                player = user_man.GetComponent<PlayerController>(); 

            }
        }
        else
        {
            userInfo = user_woman.GetComponent<UserInfo>();
            if (userInfo.storycounter < 1)
            {
                user_woman.SetActive(true);
                player = user_woman.GetComponent<PlayerController>();
                player.SetStartXY(-47f, -29f);
                userInfo.storycounter++;
                userInfo.getItem_WaterPPU().SetWaterPPUName("Stone_Water"); // 기본 물뿌리개 장착
                userInfo.getItem_WaterPPU().SetWaterPPUFilled(100);
                userInfo.getItem_Hoe().SetHoeName("Stone_Hoe");
                userInfo.getItem_Hoe().SetHoeSpeed(10f);
                userInfo.getItem_FishingRod().SetFishingRodName("Stone_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(1f);
                userInfo.getItem_Weapon().SetWeaponName("rustysword");
                userInfo.getItem_Weapon().SetWeaponPower(5);
                GameObject Inventory = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
                Image Seedimg = Inventory.transform.GetChild(1).GetComponent<Image>();
                Image Fishimg = Inventory.transform.GetChild(2).GetComponent<Image>();
                Image Fruitimg = Inventory.transform.GetChild(3).GetComponent<Image>();
                Image Storyimg = Inventory.transform.GetChild(11).GetComponent<Image>();
                Seedimg.sprite = invens[2] as Sprite;
                Fishimg.sprite = invens[3] as Sprite;
                Fruitimg.sprite = invens[3] as Sprite;
                Storyimg.sprite = invens[3] as Sprite;
                menuControl.NameInfo.text = "이름 : " + userInfo.getName();
                menuControl.FarmNameInfo.text = "농장 이름 : " + userInfo.getFarmName();
                menuControl.WomanInfo.SetActive(true);
                if (menuControl.ManInfo.activeSelf) { menuControl.ManInfo.SetActive(false); }
                menuControl.isSeed = true;
                if (!player.isPlayerUI)
                {
                    PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
                    RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
                    pos.anchoredPosition = new Vector2(-120, -20);
                    Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                    maptext.text = "'" + userInfo.getName() + "'의 집";
                    GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                    GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
                    GameObject itemobj1 = itembox1.transform.GetChild(0).gameObject;
                    GameObject itemobj2 = itembox2.transform.GetChild(0).gameObject;
                    GameObject itemobj3 = itembox3.transform.GetChild(0).gameObject;
                    GameObject itemobj4 = itembox4.transform.GetChild(0).gameObject;
                    Image selectItemBox = itembox1.GetComponent<Image>();
                    Image ItemImg1 = itemobj1.GetComponent<Image>();
                    ItemImg1.sprite = swords[6]; // 검
                    Image ItemImg2 = itemobj2.GetComponent<Image>();
                    ItemImg2.sprite = tools[13]; // 호미
                    Image ItemImg3 = itemobj3.GetComponent<Image>();
                    ItemImg3.sprite = tools[11]; // 낚시대
                    Image ItemImg4 = itemobj4.GetComponent<Image>();
                    ItemImg4.sprite = tools[14]; // 물뿌리개
                    PlayerUI.SetActive(true);
                    PlayerUI.SetActive(true);
                    selectItemBox.sprite = Uiboxs[0]; // 선택으로 변경
                    userInfo.isSword = true;
                    itemobj1.SetActive(true);
                    itemobj2.SetActive(true);
                    itemobj3.SetActive(true);
                    itemobj4.SetActive(true);
                    PlayerUI.SetActive(true);
                    player.isPlayerUI = true;
                }
            }
            else {
                PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
                RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
                pos.anchoredPosition = new Vector2(-120, -20);
                Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                maptext.text = "'" + userInfo.getName() + "'의 집";
                user_woman.transform.position = new Vector3(-50.5f, -33f, 0);
                player = user_man.GetComponent<PlayerController>();
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
