using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town1 : MonoBehaviour
{
    GameObject user_man;
    GameObject user_woman;
    PlayerController player;
    UserInfo userInfo;
    void Awake()
    {
        GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        maptext.text = "마을 1";
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            player = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();
            if (userInfo.userWhere == 1) { user_man.transform.position = new Vector3(-2.9f, -25.4f, 0); userInfo.userWhere = 0; } // 농장에서 나오기
            if (userInfo.userWhere == 2) { user_man.transform.position = new Vector3(-2.9f, -35.4f, 0); userInfo.userWhere = 0; } // 바다에서 나오기
        }
        else
        {
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
            if (userInfo.userWhere == 1) { user_woman.transform.position = new Vector3(-2.9f, -25.4f, 0); userInfo.userWhere = 0; } // 농장에서 나오기
            if (userInfo.userWhere == 2) { user_woman.transform.position = new Vector3(-2.9f, -35.4f, 0); userInfo.userWhere = 0; } // 바다에서 나오기

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
