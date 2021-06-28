using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        { // ����
            GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(-30, -20);
            Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            maptext.text = "����";
            player = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();
            if (userInfo.userWhere == 1) { user_man.transform.position = new Vector3(-288.67f, 60.9f, 0); userInfo.userWhere = 0; } // ������ ������
            if (userInfo.userWhere == 2) { user_man.transform.position = new Vector3(-274.17f, 46.9f, 0); userInfo.userWhere = 0; } // town1���� ������
            if (userInfo.userWhere == 3) { user_man.transform.position = new Vector3(-259.47f, 67.89999f, 0); userInfo.userWhere = 0; } // �������� ������
            if (userInfo.userWhere == 4) { user_man.transform.position = new Vector3(-260f, 55.9f, 0); userInfo.userWhere = 0; } // town2���� ������
        }
        else
        { // ����
            GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            RectTransform pos = PlayerUI.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(-30, -20);
            Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            maptext.text = "Farm";
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
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
