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
    Sprite[] firstimgs; 
    float Invoke_speed;
    public GameManager game;
    public bool doing;
    public bool buttonOn, isSetWhatNum;
    //public bool isbt1, isbt2;
    //public bool isallbutton;
    Text ButtonText1, ButtonText2;
    public GameObject Button1, Button2;
    int whatnum;

    // Start is called before the first frame update
    void Awake()
    {
        firstimgs = Resources.LoadAll<Sprite>("Sprites/FirstStory");
        text1 = GetComponent<Text>();
        ButtonText1 = Button1.GetComponent<Text>();
        ButtonText2 = Button2.GetComponent<Text>();
    }

    public void Setting(string getmsg)
    {
        if (doing)
        {
            text1.text = msg;
            CancelInvoke(); 
            eEffect();
            if (game.isButton)
            {
                buttonOn = true;
                Button1_On(game.select1);
                Invoke("Button2_On", 0.2f);
                game.isButton = false;
            }
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
        if (game.isButton)
        {
            buttonOn = true;
            Button1_On(game.select1);
            Invoke("Button2_On", 0.2f);
            game.isButton = false;
        }
        else if (game.isFirstImg)
        {
            Image FirstImg = GameObject.Find("FirstStory").transform.GetChild(0).GetComponent<Image>();
            if(game.isman)
            {
                if (!isSetWhatNum)
                {
                    whatnum = 1;
                    isSetWhatNum = true;
                }
                FirstImg.sprite = firstimgs[whatnum];
                whatnum++;
            }
            else if(game.iswoman)
            {
                if (!isSetWhatNum)
                {
                    whatnum = 9;
                    isSetWhatNum = true;
                }
                FirstImg.sprite = firstimgs[whatnum];
                whatnum++;
            }
            game.isFirstImg = false;
        }
    }

    void Button1_On(string text1)
    {
        ButtonText1.text = "    "+text1;
        game.button1.SetActive(true);
        //Animator bt1 = game.button1.GetComponent<Animator>();
        //Debug.Log(bt1);
        //bt1.SetTrigger("Highlighted");
        //isbt1 = true;
    }

    void Button2_On()
    {
        ButtonText2.text = "    " + game.select2;
        game.button2.SetActive(true);
        //Invoke("allButton", 1f);
    }

    /*void allButton()
    {
        isallbutton = true;
    }*/

}
