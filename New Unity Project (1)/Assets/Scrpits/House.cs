using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    GameObject user_man;
    GameObject user_woman;
    PlayerController player;
    UserInfo userInfo;
    void Awake()
    {
        GameObject game = GameObject.Find("Player");
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        GameObject Camera1 = GameObject.Find("Main Camera");
        Camera camera = Camera1.GetComponent<Camera>();
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
            if (userInfo.storycounter < 1)
            {
                user_man.SetActive(true);
                //user_man.transform.localScale = new Vector3(3f, 3f, 0); // ������ ����
                player = user_man.GetComponent<PlayerController>();
                //player.moveSpeed = 15; // �ӵ� ����
                //camera.orthographicSize = 12; // ī�޶� ũ�� ���� 
                player.SetStartXY(-47f, -29f);
                userInfo.storycounter++;
            }
            else {
                user_man.transform.position = new Vector3(-50.5f, -33f, 0);
                player = user_man.GetComponent<PlayerController>();
                //player.moveSpeed = 15; // �ӵ� ����
                //camera.orthographicSize = 12; // ī�޶� ũ�� ���� 
                //user_man.transform.localScale = new Vector3(3f, 3f, 0); 
            }
        }
        else
        {
            userInfo = user_woman.GetComponent<UserInfo>();
            if (userInfo.storycounter < 1)
            {
                user_woman.SetActive(true);
                //user_woman.transform.localScale = new Vector3(3f, 3f, 0); // ũ�� ����
                player = user_woman.GetComponent<PlayerController>();
                //player.moveSpeed = 15; // �ӵ� ����
                //camera.orthographicSize = 12; // ī�޶� ũ�� ���� 
                player.SetStartXY(-47f, -29f);
                userInfo.storycounter++;
            }
            else { 
                user_woman.transform.position = new Vector3(-50.5f, -33f, 0);
                player = user_man.GetComponent<PlayerController>();
               // player.moveSpeed = 15;
                //user_woman.transform.localScale = new Vector3(3f, 3f, 0);
                //camera.orthographicSize = 12; // ī�޶� ũ�� ���� 
            }
        }
        GameObject gameObject1 = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        gameObject1.SetActive(false); // Canvas �̹��� ����
        /*if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else { userInfo = user_woman.GetComponent<UserInfo>(); }*/
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
