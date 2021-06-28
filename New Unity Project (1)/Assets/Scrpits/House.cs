using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    GameObject user_man;
    GameObject user_woman;
    GameObject PlayerUI;
    PlayerController player;
    UserInfo userInfo;
    public Animator sleep;
    //public Button Menu_Button1, Menu_Button2;
    //MenuControl menuControl;
    //public bool isAction; // 애니시작/종료
    //public Animator ImgAnimator;
    void Awake()
    {
       
        //sleep = GameObject.Find("Sleep").transform.GetChild(0).gameObject.GetComponent<Animator>();
        GameObject game = GameObject.Find("Player");
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        GameObject obj = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        if (obj.name.Equals("FirstStoryImage"))
        {
            Destroy(obj); // FirstImage 지우기
        }
        //GameObject Camera1 = GameObject.Find("Main Camera");
        //Camera camera = Camera1.GetComponent<Camera>();
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
            if (userInfo.storycounter < 1)
            {
                user_man.SetActive(true);
                player = user_man.GetComponent<PlayerController>();
                player.SetStartXY(-47f, -29f);
                userInfo.storycounter++;
                if (!player.isPlayerUI)
                {
                    PlayerUI = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
                    Debug.Log(PlayerUI);
                    Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                    Debug.Log(maptext);
                    maptext.text = "House";
                    PlayerUI.SetActive(true);
                    player.isPlayerUI = true;
                }
            }
            else {
                PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
                Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                maptext.text = "House";
                user_man.transform.position = new Vector3(-50.5f, -33f, 0);
                player = user_man.GetComponent<PlayerController>(); 

            }
        }
        else
        {
            userInfo = user_woman.GetComponent<UserInfo>();
            if (userInfo.storycounter < 1)
            {
                user_woman.SetActive(true);
                player = user_woman.GetComponent<PlayerController>();
                player.SetStartXY(-47f, -29f);
                userInfo.storycounter++;
                if (!player.isPlayerUI)
                {
                    PlayerUI = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
                    Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                    maptext.text = "House";
                    PlayerUI.SetActive(true);
                    player.isPlayerUI = true;
                }
            }
            else {
                PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
                Text maptext = PlayerUI.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                maptext.text = "House";
                user_woman.transform.position = new Vector3(-50.5f, -33f, 0);
                player = user_man.GetComponent<PlayerController>();
            }
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
