using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject A; // Ä³¸¯ÅÍ
    Transform AT;
    GameObject user_man;
    GameObject user_woman;

    // Start is called before the first frame update
    void Start()
    {

        GameObject game = GameObject.Find("Player");
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            A = user_man;
        }
        else
        {
            A = user_woman;
        }
        //DontDestroyOnLoad(gameObject);
        AT = A.transform;
        transform.position = new Vector3(-3, 0, -4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, -4);
    }
}
