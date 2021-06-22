using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 가져올 때

public class GameManager : MonoBehaviour
{
    public Text text1;
    public GameObject scanobject;
    public GameObject talk;
    public bool isAction; // 대화창이 켜져있는지 아닌지 확인

    public void Action(GameObject scanobj)
    {
        if (isAction) // 대화창이 켜져 있으면
        {
            isAction = false; // 대화창 꺼지게
        }
        else // 대화창이 꺼져 있으면
        {
            isAction = true; // 대화창 켜지게
            scanobject = scanobj; 
            if (scanobject.name.Equals("dog")) // 강아지 이름
            {
                text1.text = "멍멍!";
            }
        }
        talk.SetActive(isAction);
    }
}

