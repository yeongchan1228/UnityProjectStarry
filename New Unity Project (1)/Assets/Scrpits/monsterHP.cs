using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterHP : MonoBehaviour
{
    public UserInfo userInfo;
    public bool isKing;
    GameObject PlayerUI;
    public GameObject kingLight;
    private MonsterInformation mi;
    //public SlimeMovement slimeMovement;
    public Slider hpBar;
    //public int kindsRangeL;
    //public int kindsRangeR;
    public float respawnTime;
    int EarnGold;
    MenuControl menuControl;
    //int kindsvalue;
    GameObject Msgbox;
    Sprite[] special;
    Sprite[] spec_orgol;
    void Start()
    {
        menuControl = GameObject.Find("MenuManager").GetComponent<MenuControl>();
        special = Resources.LoadAll<Sprite>("Sprites/Final");
        spec_orgol = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        PlayerUI = GameObject.Find("PlayerUI").gameObject;
        userInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<UserInfo>();
        mi = gameObject.GetComponent<MonsterInformation>();
        mi.startX = transform.position.x;
        mi.startY = transform.position.y;
        //slimeMovement = gameObject.GetComponent<SlimeMovement>();
        respawnTime = 5.0F;
        if (mi.hpMax == 100)
        {
            mi.power = 10;
            mi.exp = 100;
        }
        else if (mi.hpMax == 150)
        {
            mi.power = 13;
            mi.exp = 200;
        }
        else if (mi.hpMax == 300)
        {
            mi.power = 17;
            mi.exp = 400;
        }
        else if (mi.hpMax == 366)
        {
            mi.power = 20;
            mi.exp = 500;
        }
        else if (mi.hpMax == 500)
        {
            mi.power = 22;
            mi.exp = 700;
        }
        else if (mi.hpMax == 700)
        {
            mi.power = 30;
            mi.exp = 1200;
        }
        // 슬라임 종 랜덤으로 정해줌.  값에 따른 종--> 0~20 : 레드/ 21~40 : 그린/ 41~60 : 블루/ 61~75 : 라이트/ 76~90 : 다크/ 91~96 : 스태리/ 97~100 : 킹
        //mi.kinds = DecideKinds();
        //slimeMovement.SetActive(true);
        //slimeMovement.Spawn(GameObject.Find(mi.kinds).GetComponent<Animator>());
    }

    void Update()
    {
        hpBar.value = (float)mi.hp / (float)mi.hpMax;
        hpBar.transform.position = new Vector3(transform.position.x, transform.position.y+(float)0.75, 0);
        if(isKing)
            kingLight.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (mi.hp <= 0)
        {
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            EarnGold = (int)mi.hpMax * 10;
            userInfo.setGold(userInfo.getGold() + EarnGold);
            userInfo.setExp(userInfo.getExp() + mi.exp);
            userInfo.setExpInfo();
            UIGold.text = userInfo.getGold().ToString();
            hpBar.gameObject.SetActive(false);
            if (isKing)
            {
                Msgbox = GameObject.Find("MessageCanvas").transform.GetChild(0).gameObject;
                kingLight.SetActive(false);

                userInfo.StoryItemkey.Add("곰인형");
                userInfo.StoryItem.Add("곰인형", 1);

                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
                    bottonobj.SetActive(true);
                    Image bottonimg = bottonobj.GetComponent<Image>();
                    GameObject Image = bottonobj.transform.GetChild(0).gameObject;

                    Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                    if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
                    else if (userInfo.StoryItemkey[i].Equals("하늘색 열쇠")) { keyimg.sprite = special[0]; }
                    else if (userInfo.StoryItemkey[i].Equals("최종 열쇠")) { keyimg.sprite = special[1]; }
                    else if (userInfo.StoryItemkey[i].Equals("초록색 열쇠")) { keyimg.sprite = special[2]; }
                    else if (userInfo.StoryItemkey[i].Equals("할머니의 밀짚모자")) { keyimg.sprite = special[3]; }
                    else if (userInfo.StoryItemkey[i].Equals("분홍색 열쇠")) { keyimg.sprite = special[4]; }
                    else if (userInfo.StoryItemkey[i].Equals("보라색 열쇠")) { keyimg.sprite = special[5]; }
                    else if (userInfo.StoryItemkey[i].Equals("곰인형")) { keyimg.sprite = special[6]; }


                    Image.SetActive(true);
                    GameObject text = bottonobj.transform.GetChild(1).gameObject;
                    Text Hattext = text.GetComponent<Text>();
                    Hattext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
                    text.SetActive(true);
                }
                Message();
            }

            gameObject.SetActive(false);
            Invoke("Respawn", respawnTime);
        }
    }

    void Message()
    {
        Msgbox.SetActive(true);
        Invoke("CloseMessage", 0.5f);
    }

    void CloseMessage()
    {
        Msgbox.SetActive(false);
    }

    /*
    string DecideKinds()
    {
        kindsvalue = Random.Range(kindsRangeL, kindsRangeR);
        if (0 <= kindsvalue && kindsvalue <= 20)
            return "Red";
        else if (21 <= kindsvalue && kindsvalue <= 40)
            return "Green";
        else if (41 <= kindsvalue && kindsvalue <= 60)
            return "Blue";
        else if (61 <= kindsvalue && kindsvalue <= 75)
            return "Light";
        else if (76 <= kindsvalue && kindsvalue <= 90)
            return "Dark";
        else if (91 <= kindsvalue && kindsvalue <= 96)
            return "Starry";
        else if (97 <= kindsvalue && kindsvalue <= 100)
            return "King";
        return null;
    }
    */
    void Respawn()
    {
        gameObject.transform.position = new Vector3(mi.startX, mi.startY, 0);
        gameObject.SetActive(true);
        hpBar.gameObject.SetActive(true);
        if (isKing)
            kingLight.SetActive(true);
        mi.hp = mi.hpMax;
    }

    public void Hit(int power)
    {
        mi.hp = mi.hp - power;
    }
}
