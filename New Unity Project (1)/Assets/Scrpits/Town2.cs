using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Town2 : MonoBehaviour
{

    GameObject user_man;
    GameObject user_woman;
    PlayerController player;
    UserInfo userInfo;
    void Awake()
    {
        GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        maptext.text = "마을 2";
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            player = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();
            if (userInfo.userWhere == 1) { user_man.transform.position = new Vector3(3.5f, -26f, 0); userInfo.userWhere = 0; } // farm에서 나오기
            if (userInfo.userWhere == 2) { user_man.transform.position = new Vector3(19.27f, -13.5f, 0); userInfo.userWhere = 0; // store에서 나오기
                player.moveSpeed = 10; // 속도 변경
                user_man.transform.localScale = new Vector3(1f, 1f, 0); // 사이즈 변경
            } // store에서 나오기

        }
        else
        {
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
            if (userInfo.userWhere == 1) { user_woman.transform.position = new Vector3(3.5f, -26f, 0); userInfo.userWhere = 0; } // farm에서 나오기
            if (userInfo.userWhere == 2) { user_woman.transform.position = new Vector3(19.27f, -13.5f, 0); userInfo.userWhere = 0; // store에서 나오기
                player.moveSpeed = 10; // 속도 변경
                user_woman.transform.localScale = new Vector3(1f, 1f, 0); // 사이즈 변경
            } // store에서 나오기

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
