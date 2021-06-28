using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{

    GameObject user_man;
    GameObject user_woman;
    PlayerController player;
    UserInfo userInfo;
    void Awake()
    {
        GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        maptext.text = "����";
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        GameObject Camera1 = GameObject.Find("Main Camera");
        Camera camera = Camera1.GetComponent<Camera>();
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            player = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();
            //user_man.transform.localScale = new Vector3(3f, 3f, 0); // ������ ����
            //player.moveSpeed = 15; // �ӵ� ����
            //camera.orthographicSize = 12; // ī�޶� ũ�� ���� 
            if (userInfo.userWhere == 1) { user_man.transform.position = new Vector3(-47.15f, -28f, 0); userInfo.userWhere = 0; } // town2���� ������
        }
        else
        {
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
            //user_woman.transform.localScale = new Vector3(3f, 3f, 0); // ������ ����
            //player.moveSpeed = 15; // �ӵ� ����
           // camera.orthographicSize = 12; // ī�޶� ũ�� ���� 
            if (userInfo.userWhere == 1) { user_woman.transform.position = new Vector3(47.15f, -28f, 0); userInfo.userWhere = 0; } // town2���� ������

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
