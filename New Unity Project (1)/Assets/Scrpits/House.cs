using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    GameObject user_man;
    GameObject user_woman;
    PlayerController player;
    void Awake()
    {
        GameObject game = GameObject.Find("Player");
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            Debug.Log(user_man.name);
            user_man.SetActive(true);
            player = user_man.GetComponent<PlayerController>();
            player.setStartXY(-36f,-27f);
        }
        else
        {
            user_woman.SetActive(true);
            player = user_woman.GetComponent<PlayerController>();
            player.setStartXY(-36f, -27f);
        }
        GameObject gameObject1 = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        gameObject1.SetActive(false); // Canvas ¿ÃπÃ¡ˆ ≤Ù±‚
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
