using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Hole_UI, furnace, fin_box, exit;
    public GameObject furnace_UI, furnace_inven1, furnace_inven2, furnace_inven3, furnace_inven4, furnace_inven5;
    public GameObject fire, exit2;
    public GameManager textmanager;
    public GameObject text1, text2, text3;

    public GameObject confirm, fail, text5, ok, success, text6;
    public GameObject pinkKey, blueKey, greenKey, purpleKey, finalKey;
    public GameObject strawberry, angel, devil, bear, hat, musicbox, starry;

    UserInfo userInfo;
    GameObject user_man, user_woman;

    bool isPinkKey, isGreenKey, isBlueKey, isPurpleKey, isWhiteKey;

    void Start()
    {
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        Hole_UI = GameObject.Find("Hole_UI").transform.GetChild(0).gameObject;
        furnace = Hole_UI.transform.GetChild(0).gameObject;
        fin_box = Hole_UI.transform.GetChild(1).gameObject;
        exit = Hole_UI.transform.GetChild(2).gameObject;

        furnace_UI = GameObject.Find("Hole_UI").transform.GetChild(1).gameObject;
        furnace_inven1 = furnace_UI.transform.GetChild(0).gameObject;
        furnace_inven2 = furnace_UI.transform.GetChild(1).gameObject;
        furnace_inven3 = furnace_UI.transform.GetChild(2).gameObject;
        furnace_inven4 = furnace_UI.transform.GetChild(3).gameObject;
        furnace_inven5 = furnace_UI.transform.GetChild(4).gameObject;
        fire = furnace_UI.transform.GetChild(5).gameObject;
        exit2 = furnace_UI.transform.GetChild(6).gameObject;

        text1 = GameObject.Find("Hole_UI").transform.GetChild(2).gameObject;
        text2 = GameObject.Find("Hole_UI").transform.GetChild(3).gameObject;
        text3 = GameObject.Find("Hole_UI").transform.GetChild(4).gameObject;

        confirm = GameObject.Find("Hole_UI").transform.GetChild(5).gameObject;
        fail = confirm.transform.GetChild(0).gameObject;
        text5 = confirm.transform.GetChild(1).gameObject;
        ok = confirm.transform.GetChild(2).gameObject;
        success = confirm.transform.GetChild(3).gameObject;
        text6 = confirm.transform.GetChild(4).gameObject;

        strawberry = furnace_inven1.transform.GetChild(0).gameObject;
        angel = furnace_inven2.transform.GetChild(0).gameObject;
        devil = furnace_inven3.transform.GetChild(0).gameObject;
        bear = furnace_inven4.transform.GetChild(0).gameObject;
        hat = furnace_inven4.transform.GetChild(1).gameObject;
        musicbox = furnace_inven4.transform.GetChild(2).gameObject;
        starry = furnace_inven4.transform.GetChild(3).gameObject;

        pinkKey = furnace_inven5.transform.GetChild(0).gameObject;
        blueKey = furnace_inven5.transform.GetChild(1).gameObject;
        greenKey = furnace_inven5.transform.GetChild(2).gameObject;
        purpleKey = furnace_inven5.transform.GetChild(3).gameObject;
        finalKey = furnace_inven5.transform.GetChild(4).gameObject;


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
    }


    public void click_furnace()
    {
        furnace_UI.SetActive(true);
        furnace_inven1.SetActive(true);
        furnace_inven2.SetActive(true);
        furnace_inven3.SetActive(true);
        furnace_inven4.SetActive(true);
        furnace_inven5.SetActive(true);
        fire.SetActive(true);
        exit2.SetActive(true);

        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
    }

    public void click_finalbox()
    {

    }

    public void click_fire()
    {
        // 연두색 열쇠 여는 조건 (과일: 천사, 악마, 스태리, 딸기 보유했을 때)
        
        int fruitcount = 0;
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            if (userInfo.FruitItemkey[i].Equals("DARK")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { fruitcount++; }   
        }

        if(fruitcount == 4) // 열쇠 만들기 가능
        {
            strawberry.SetActive(true);
            angel.SetActive(true);
            devil.SetActive(true);
            starry.SetActive(true);
            greenKey.SetActive(true);

            ok.SetActive(true);
            success.SetActive(true);
            text6.SetActive(true);

            //인벤토리에 초록색 열쇠 넣기
           
        }

        else // 실패했을 시 알림창
        {
            ok.SetActive(true);
            fail.SetActive(true);
            text5.SetActive(true);
        }
    }

    public void click_ok()
    {
        ok.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
    }

    public void click_exit()
    {
        Hole_UI.SetActive(false);
        furnace.SetActive(false);
        fin_box.SetActive(false);
        exit.SetActive(false);
        textmanager.isAction = false;
    }

    public void click_exit2()
    {
        furnace_UI.SetActive(false);
        furnace_inven1.SetActive(false);
        furnace_inven2.SetActive(false);
        furnace_inven3.SetActive(false);
        furnace_inven4.SetActive(false);
        furnace_inven5.SetActive(false);
        fire.SetActive(false);
        exit2.SetActive(false);

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);

        confirm.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
        ok.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);

        pinkKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);
        purpleKey.SetActive(false);
        finalKey.SetActive(false);

        strawberry.SetActive(false);
        angel.SetActive(false);
        devil.SetActive(false);
        bear.SetActive(false);
        hat.SetActive(false);
        musicbox.SetActive(false);
        starry.SetActive(false);
    }

}
