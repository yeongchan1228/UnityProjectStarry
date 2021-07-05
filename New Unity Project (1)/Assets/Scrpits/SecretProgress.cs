using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretProgress : MonoBehaviour
{
    PlayerController playerController;
    GameObject user_man, user_woman, proobj;
    UserInfo userInfo;
    Image progressBar;
    Text progresstext;
    float currentValue;
    public float speed;
    public GameManager textmanager;

    // Start is called before the first frame update
    void Start()
    {
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        proobj = GameObject.Find("Secret").transform.GetChild(0).gameObject;
        progressBar = proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
        progresstext = proobj.transform.GetChild(2).gameObject.GetComponent<Text>();

        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();

        if (userinfo2.isTrue)
        {
            playerController = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();

        }
        else
        {
            playerController = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        progresstext.text = "비밀의 문이 열립니다...";
        textmanager.isAction = true;
        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
        }
       progressBar.fillAmount = currentValue / 100;


        if (progressBar.fillAmount == 1)
        {
            playerController.isSecret = true;
            proobj.SetActive(false);
            textmanager.isAction = false;
        }
    }
}

