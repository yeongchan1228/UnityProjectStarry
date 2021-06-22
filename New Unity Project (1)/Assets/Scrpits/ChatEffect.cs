using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatEffect : MonoBehaviour
{
    string msg; // �ؽ�Ʈ
    public GameObject End_Button;
    public int EffectSpeed; // ���� ������ �ӵ�
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
    void sEffect() // ����
    {
        text1.text = "";
        index = 0;
        doing = true;
        End_Button.SetActive(false);
        Invoke_speed = 1.0f / EffectSpeed;
        Invoke("dEffect", Invoke_speed);
    }
    void dEffect() // ����
    {
        if(text1.text == msg) // ��� ���ڿ� ���
        {
            eEffect();
            return;
        }
        text1.text += msg[index];
        index++;

        Invoke("dEffect", Invoke_speed);
    }
    void eEffect() // ��
    {
        End_Button.SetActive(true);
        doing = false;
    }

}
