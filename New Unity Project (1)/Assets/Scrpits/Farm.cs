using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
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
            player.moveSpeed = 10; // �ӵ� ����
            user_man.transform.localScale = new Vector3(1f, 1f, 0); // ������ ����
            if (userInfo.userWhere == 1) { user_man.transform.position = new Vector3(-288.67f, 60.9f, 0); userInfo.userWhere = 0; } // ������ ������
            if (userInfo.userWhere == 2) { user_man.transform.position = new Vector3(-274.17f, 46.9f, 0); userInfo.userWhere = 0; } // town1���� ������
            if (userInfo.userWhere == 3) { user_man.transform.position = new Vector3(-259.47f, 67.89999f, 0); userInfo.userWhere = 0; } // �������� ������
            if (userInfo.userWhere == 4) { user_man.transform.position = new Vector3(-260f, 55.9f, 0); userInfo.userWhere = 0; } // town2���� ������
        }
        else
        {
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
            player.moveSpeed = 10; // �ӵ� ����
            user_woman.transform.localScale = new Vector3(1f, 1f, 0); // ������ ����
            if (userInfo.userWhere == 1) { user_woman.transform.position = new Vector3(-288.67f, 60.9f, 0); userInfo.userWhere = 0; } // ������ ������
            if (userInfo.userWhere == 2) { user_woman.transform.position = new Vector3(-274.17f, 46.9f, 0); userInfo.userWhere = 0; } // town1���� ������
            if (userInfo.userWhere == 3) { user_woman.transform.position = new Vector3(-259.47f, 67.89999f, 0); userInfo.userWhere = 0; } // �������� ������
            if (userInfo.userWhere == 4) { user_woman.transform.position = new Vector3(-260f, 55.9f, 0); userInfo.userWhere = 0; } // town2���� ������
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
