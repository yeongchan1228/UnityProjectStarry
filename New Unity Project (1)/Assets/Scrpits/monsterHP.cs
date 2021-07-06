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
    //int kindsvalue;

    void Start()
    {
        PlayerUI = GameObject.Find("PlayerUI").gameObject;
        userInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<UserInfo>();
        mi = gameObject.GetComponent<MonsterInformation>();
        //slimeMovement = gameObject.GetComponent<SlimeMovement>();
        respawnTime = 5.0F;
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
        if (mi.hp == 0)
        {
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            EarnGold = (int)mi.hpMax * 10;
            userInfo.setGold(userInfo.getGold() + EarnGold);
            UIGold.text = userInfo.getGold().ToString();
            hpBar.gameObject.SetActive(false);
            if (isKing)
                kingLight.SetActive(false);
            gameObject.SetActive(false);
            Invoke("Respawn", respawnTime);
        }
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
