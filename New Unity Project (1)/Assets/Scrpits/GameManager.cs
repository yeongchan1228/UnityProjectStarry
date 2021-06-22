using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 가져올 때

public class GameManager : MonoBehaviour
{
    public Text text1;
    private PlayerController user;
    public GameObject scanobject;
    public GameObject talk;
    public bool isAction; // 대화창이 켜져있는지 아닌지 확인

    void Start()
    {
        user = GameObject.Find("Man_Player").GetComponent<PlayerController>();
    }

    public void Action(GameObject scanobj)
    {
        if (isAction) // 대화창이 켜져 있으면
        {
            scanobject = null;
            text1.text = "";
            isAction = false; // 대화창 꺼지게
        }
        else // 대화창이 꺼져 있으면
        {
            scanobject = scanobj;
            Debug.Log(scanobject.name);
            if (scanobject.name.Equals("dog")) // 강아지 이름
            {
                isAction = true; // 대화창 켜지게
                text1.text = "멍멍!";
            }
            else if (scanobject.name.Equals("sign"))
            {
                isAction = true; // 대화창 켜지게
                text1.text ="'" + user.user_name +"'"+ "의 집입니다.";
            }
        }
        talk.SetActive(isAction);
    }
}

