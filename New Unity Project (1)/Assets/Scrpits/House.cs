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
    private Sprite[] tools, Uiboxs, swords, seedbarrels;
    //public Button Menu_Button1, Menu_Button2;
    //MenuControl menuControl;
    //public bool isAction; // 애니시작/종료
    //public Animator ImgAnimator;
    void Awake()
    {
       
        //sleep = GameObject.Find("Sleep").transform.GetChild(0).gameObject.GetComponent<Animator>();
        GameObject game = GameObject.Find("Player");
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        GameObject obj = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        tools = Resources.LoadAll<Sprite>("Sprites/Tool");
        Uiboxs = Resources.LoadAll<Sprite>("Sprites/ItemBox");
        swords = Resources.LoadAll<Sprite>("Sprites/sword");
        seedbarrels = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        if (obj.name.Equals("FirstStoryImage"))
        {
            Destroy(obj); // FirstImage 지우기
        }
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
                userInfo.getItem_FishingRod().SetFishingRodDifficulty(2);
                userInfo.getItem_Weapon().SetWeaponName("CutlassSword");
                userInfo.getItem_Weapon().SetWeaponPower(5);
                userInfo.getItem_Pick().SetPickName("blueberrySeed");
                userInfo.getItem_Pick().SetPickKinds("blueberry");
                if (!player.isPlayerUI)
                {
                    PlayerUI = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
                    RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
                    pos.anchoredPosition = new Vector2(-120, -20);
                    Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                    maptext.text = "'"+userInfo.getName()+"'의 집";
                    GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                    GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
                    GameObject itembox5 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
                    GameObject itemobj1 = itembox1.transform.GetChild(0).gameObject;
                    GameObject itemobj2 = itembox2.transform.GetChild(0).gameObject;
                    GameObject itemobj3 = itembox3.transform.GetChild(0).gameObject;
                    GameObject itemobj4 = itembox4.transform.GetChild(0).gameObject;
                    GameObject itemobj5 = itembox5.transform.GetChild(0).gameObject;
                    Image selectItemBox = itembox1.GetComponent<Image>();
                    Image ItemImg1 = itemobj1.GetComponent<Image>();
                    ItemImg1.sprite = swords[0]; // 검
                    Image ItemImg2 = itemobj2.GetComponent<Image>();
                    ItemImg2.sprite = tools[13]; // 호미
                    Image ItemImg3 = itemobj3.GetComponent<Image>();
                    ItemImg3.sprite = tools[11]; // 낚시대
                    Image ItemImg4 = itemobj4.GetComponent<Image>();
                    ItemImg4.sprite = tools[14]; // 물뿌리개
                    Image ItemImg5 = itemobj5.GetComponent<Image>();
                    ItemImg5.sprite = seedbarrels[0]; // 씨앗통
                    PlayerUI.SetActive(true);
                    selectItemBox.sprite = Uiboxs[0]; // 선택으로 변경
                    userInfo.isSword = true;
                    itemobj1.SetActive(true);
                    itemobj2.SetActive(true);
                    itemobj3.SetActive(true);
                    itemobj4.SetActive(true);
                    itemobj5.SetActive(true);
                    PlayerUI.SetActive(true);
                    player.isPlayerUI = true;

                }
            }
            else {
                PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
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
                userInfo.getItem_Hoe().SetHoeSpeed(10);
                userInfo.getItem_FishingRod().SetFishingRodName("Stone_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodDifficulty(2);
                userInfo.getItem_Pick().SetPickName("blueberrySeed");
                userInfo.getItem_Pick().SetPickKinds("blueberry");
                if (!player.isPlayerUI)
                {
                    PlayerUI = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
                    RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
                    pos.anchoredPosition = new Vector2(-120, -20);
                    Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                    maptext.text = "'" + userInfo.getName() + "'의 집";
                    GameObject itembox1 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    GameObject itembox2 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    GameObject itembox3 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                    GameObject itembox4 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
                    GameObject itembox5 = PlayerUI.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
                    GameObject itemobj1 = itembox1.transform.GetChild(0).gameObject;
                    GameObject itemobj2 = itembox2.transform.GetChild(0).gameObject;
                    GameObject itemobj3 = itembox3.transform.GetChild(0).gameObject;
                    GameObject itemobj4 = itembox4.transform.GetChild(0).gameObject;
                    GameObject itemobj5 = itembox5.transform.GetChild(0).gameObject;
                    Image selectItemBox = itembox1.GetComponent<Image>();
                    Image ItemImg1 = itemobj1.GetComponent<Image>();
                    ItemImg1.sprite = swords[0]; // 검
                    Image ItemImg2 = itemobj2.GetComponent<Image>();
                    ItemImg2.sprite = tools[13]; // 호미
                    Image ItemImg3 = itemobj3.GetComponent<Image>();
                    ItemImg3.sprite = tools[11]; // 낚시대
                    Image ItemImg4 = itemobj4.GetComponent<Image>();
                    ItemImg4.sprite = tools[14]; // 물뿌리개
                    Image ItemImg5 = itemobj5.GetComponent<Image>();
                    ItemImg5.sprite = seedbarrels[0]; // 씨앗통
                    PlayerUI.SetActive(true);
                    PlayerUI.SetActive(true);
                    selectItemBox.sprite = Uiboxs[0]; // 선택으로 변경
                    userInfo.isSword = true;
                    itemobj1.SetActive(true);
                    itemobj2.SetActive(true);
                    itemobj3.SetActive(true);
                    itemobj4.SetActive(true);
                    itemobj5.SetActive(true);
                    PlayerUI.SetActive(true);
                    player.isPlayerUI = true;
                }
            }
            else {
                PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
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
