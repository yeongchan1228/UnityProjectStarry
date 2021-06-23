using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatEffect : MonoBehaviour
{
    string msg; // 텍스트
    public GameObject End_Button;
    public int EffectSpeed; // 글자 나오는 속도
    Text text1;
    int index;
    float Invoke_speed;
    public bool doing;
    // Start is called before the first frame update
    void Start()
    {
        text1 = GetComponent<Text>();
    }

    public void Setting(string getmsg)
    {
        if (doing)
        {
            text1.text = msg;
            CancelInvoke(); 
            eEffect();
        }
        else
        {
            msg = getmsg;
            sEffect();
        }

    }
    void sEffect() // 시작
    {
        text1.text = "";
        index = 0;
        doing = true;
        End_Button.SetActive(false);
        Invoke_speed = 1.0f / EffectSpeed;
        Invoke("dEffect", Invoke_speed);
    }
    void dEffect() // 진행
    {
        if(text1.text == msg) // 모든 문자열 출력
        {
            eEffect();
            return;
        }
        text1.text += msg[index];
        index++;

        Invoke("dEffect", Invoke_speed);
    }
    void eEffect() // 끝
    {
        End_Button.SetActive(true);
        doing = false;
    }

}
