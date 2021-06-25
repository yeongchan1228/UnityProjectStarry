using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{

    GameObject user_man;
    GameObject user_woman;
    PlayerController player;
    UserInfo userInfo;
    void Awake()
    {
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            player = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();
            if (userInfo.userWhere == 1) { user_man.transform.position = new Vector3(-271.55f, 78.5f, 0); userInfo.userWhere = 0; } // farm에서 나오기
            if (userInfo.userWhere == 2) { user_man.transform.position = new Vector3(-258.5f, 92.43f, 0); userInfo.userWhere = 0; } // dungeon2에서 나오기
            if (userInfo.userWhere == 3) { user_man.transform.position = new Vector3(-249.01f, 84.12f, 0); userInfo.userWhere = 0; } // dungeon1에서 나오기

        }
        else
        {
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
            if (userInfo.userWhere == 1) { user_woman.transform.position = new Vector3(-271.55f, 78.5f, 0); userInfo.userWhere = 0; } // farm에서 나오기
            if (userInfo.userWhere == 2) { user_man.transform.position = new Vector3(-258.5f, 92.43f, 0); userInfo.userWhere = 0; } // dungeon2에서 나오기
            if (userInfo.userWhere == 3) { user_man.transform.position = new Vector3(-249.01f, 84.12f, 0); userInfo.userWhere = 0; } // dungeon1에서 나오기

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
