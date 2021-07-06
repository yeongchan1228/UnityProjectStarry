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
    public Sprite[] firstimgs, finimgs;
    AudioSource audio1;
    float Invoke_speed;
    public GameManager game;
    public bool doing;
    public bool buttonOn, isSetWhatNum;
    //public bool isbt1, isbt2;
    //public bool isallbutton;
    Text ButtonText1, ButtonText2;
    public GameObject Button1, Button2;
    int whatnum, finnum;

    // Start is called before the first frame update
    void Awake()
    {
        firstimgs = Resources.LoadAll<Sprite>("Sprites/FirstStory");
        finimgs = Resources.LoadAll<Sprite>("Sprites/FinalStory");
        audio1 = GetComponent<AudioSource>();
        text1 = GetComponent<Text>();
        ButtonText1 = Button1.GetComponent<Text>();
        ButtonText2 = Button2.GetComponent<Text>();
    }

    public void Setting(string getmsg)
    {
        if (game.is_off)
        {
            GameObject Fin_off = GameObject.Find("Hole_UI").transform.GetChild(7).gameObject;
            Fin_off.SetActive(false);
            game.is_off = false;
        }

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

        if(msg[index] != ' ' || msg[index] != '.')
            GetComponent<AudioSource>().Play();

        index++;





        Invoke("dEffect", Invoke_speed);
    }
    void eEffect() // ��
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
            Image FirstImg = GameObject.Find("FirstStory").transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
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
        else if (game.isFinimg)
        {
            GameObject ison = GameObject.Find("Hole_UI").transform.GetChild(7).gameObject;
            if (!ison.activeSelf) { ison.SetActive(true); }
            Image FinImg = GameObject.Find("Hole_UI").transform.GetChild(7).transform.GetChild(0).GetComponent<Image>();
            FinImg.sprite = finimgs[finnum];
            finnum++;
            game.isFinimg = false;
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
