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
    MenuControl menuControl;
    public Button Menu_Button1, Menu_Button2;
    void Awake()
    {
        menuControl = GameObject.Find("MenuControl").GetComponent<MenuControl>();
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        Menu_Button1 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Button>();
        Menu_Button2 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.GetComponent<Button>();
        Debug.Log(Menu_Button1);
        Menu_Button1.onClick.AddListener(menuControl.Menu1Clicked);
        Menu_Button2.onClick.AddListener(menuControl.Menu2Clicked);
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            player = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();
            player.moveSpeed = 10; // 속도 변경
            user_man.transform.localScale = new Vector3(1f, 1f, 0); // 사이즈 변경
            if (userInfo.userWhere == 1) { user_man.transform.position = new Vector3(-288.67f, 60.9f, 0); userInfo.userWhere = 0; } // 집에서 나오기
            if (userInfo.userWhere == 2) { user_man.transform.position = new Vector3(-274.17f, 46.9f, 0); userInfo.userWhere = 0; } // town1에서 나오기
            if (userInfo.userWhere == 3) { user_man.transform.position = new Vector3(-259.47f, 67.89999f, 0); userInfo.userWhere = 0; } // 동굴에서 나오기
            if (userInfo.userWhere == 4) { user_man.transform.position = new Vector3(-260f, 55.9f, 0); userInfo.userWhere = 0; } // town2에서 나오기
        }
        else
        {
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
            player.moveSpeed = 10; // 속도 변경
            user_woman.transform.localScale = new Vector3(1f, 1f, 0); // 사이즈 변경
            if (userInfo.userWhere == 1) { user_woman.transform.position = new Vector3(-288.67f, 60.9f, 0); userInfo.userWhere = 0; } // 집에서 나오기
            if (userInfo.userWhere == 2) { user_woman.transform.position = new Vector3(-274.17f, 46.9f, 0); userInfo.userWhere = 0; } // town1에서 나오기
            if (userInfo.userWhere == 3) { user_woman.transform.position = new Vector3(-259.47f, 67.89999f, 0); userInfo.userWhere = 0; } // 동굴에서 나오기
            if (userInfo.userWhere == 4) { user_woman.transform.position = new Vector3(-260f, 55.9f, 0); userInfo.userWhere = 0; } // town2에서 나오기
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
