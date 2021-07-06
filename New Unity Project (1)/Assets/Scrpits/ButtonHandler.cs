using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Hole_UI, furnace, fin_box, exit;
    public GameObject furnace_UI, furnace_inven1, furnace_inven2, furnace_inven3, furnace_inven4, furnace_inven5;
    public GameObject exit2;
    public GameManager textmanager;
    public GameObject text1, text2, text3;

    public GameObject confirm, fail, text5, ok, success, text6, scanObj;
    public GameObject pinkKey, blueKey, greenKey, purpleKey, finalKey;
    public GameObject pinkKey2, blueKey2, greenKey2, purpleKey2;
    public GameObject strawberry, angel, devil, bear, hat, musicbox, starry;

    AudioSource audioSource;
    UserInfo userInfo;
    GameObject user_man, user_woman;
    MenuControl menuControl;
    bool isFinstory;
    Sprite[] spec_orgol, finstory;
    Sprite[] special;

    //bool isPinkKey, isGreenKey, isBlueKey, isPurpleKey, isFinalKey;

    int fruitcount = 0;
    int orgolcount = 0;
    int teddycount = 0;
    int hatcount = 0;
    int keycount = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        spec_orgol = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        special = Resources.LoadAll<Sprite>("Sprites/Final");
        finstory = Resources.LoadAll<Sprite>("Sprites/FinalStory");

        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        menuControl = GameObject.Find("MenuManager").GetComponent<MenuControl>();

        Hole_UI = GameObject.Find("Hole_UI").transform.GetChild(1).gameObject;
        furnace = Hole_UI.transform.GetChild(0).gameObject;
        fin_box = Hole_UI.transform.GetChild(1).gameObject;
        exit = Hole_UI.transform.GetChild(2).gameObject;

        furnace_UI = GameObject.Find("Hole_UI").transform.GetChild(2).gameObject;
        furnace_inven1 = furnace_UI.transform.GetChild(0).gameObject;
        furnace_inven2 = furnace_UI.transform.GetChild(1).gameObject;
        furnace_inven3 = furnace_UI.transform.GetChild(2).gameObject;
        furnace_inven4 = furnace_UI.transform.GetChild(3).gameObject;
        furnace_inven5 = furnace_UI.transform.GetChild(4).gameObject;
        exit2 = furnace_UI.transform.GetChild(5).gameObject;

        text1 = GameObject.Find("Hole_UI").transform.GetChild(3).gameObject;
        //text2 = GameObject.Find("Hole_UI").transform.GetChild(4).gameObject;
        text3 = GameObject.Find("Hole_UI").transform.GetChild(5).gameObject;



        confirm = GameObject.Find("Hole_UI").transform.GetChild(6).gameObject;
        fail = confirm.transform.GetChild(0).gameObject;
        text5 = confirm.transform.GetChild(1).gameObject;
        ok = confirm.transform.GetChild(2).gameObject;
        success = confirm.transform.GetChild(3).gameObject;
        text6 = confirm.transform.GetChild(4).gameObject;

        strawberry = furnace_inven1.transform.GetChild(0).gameObject;
        angel = furnace_inven2.transform.GetChild(0).gameObject;
        devil = furnace_inven3.transform.GetChild(0).gameObject;
        bear = furnace_inven4.transform.GetChild(0).gameObject;
        hat = furnace_inven4.transform.GetChild(1).gameObject;
        musicbox = furnace_inven4.transform.GetChild(2).gameObject;
        starry = furnace_inven4.transform.GetChild(3).gameObject;

        blueKey = furnace_inven5.transform.GetChild(0).gameObject;
        greenKey = furnace_inven5.transform.GetChild(1).gameObject;
        purpleKey = furnace_inven5.transform.GetChild(2).gameObject;
        pinkKey = furnace_inven5.transform.GetChild(3).gameObject;
        finalKey = furnace_inven5.transform.GetChild(4).gameObject;

        blueKey2 = furnace_inven1.transform.GetChild(1).gameObject;
        greenKey2 = furnace_inven2.transform.GetChild(1).gameObject;
        purpleKey2 = furnace_inven3.transform.GetChild(1).gameObject;
        pinkKey2 = furnace_inven4.transform.GetChild(4).gameObject;

        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;

        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else
        {
            userInfo = user_woman.GetComponent<UserInfo>();
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && scanObj != null)
        {
            textmanager.Action(scanObj); // ��ȭâ ���
        }
    }


    public void click_furnace()
    {
        furnace_UI.SetActive(true);
        furnace_inven1.SetActive(true);
        furnace_inven2.SetActive(true);
        furnace_inven3.SetActive(true);
        furnace_inven4.SetActive(true);
        furnace_inven5.SetActive(true);
        exit2.SetActive(true);

        text1.SetActive(true);
        //text2.SetActive(true);
        text3.SetActive(true);


        for(int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("�ϴû� ����")) 
            {
                blueKey2.SetActive(true);
                GameObject bt = furnace_inven1.transform.GetChild(2).gameObject;
                bt.SetActive(false);
                teddycount = 10;
            }
            else if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����")) 
            {
                greenKey2.SetActive(true);
                GameObject bt = furnace_inven2.transform.GetChild(2).gameObject;
                bt.SetActive(false);
                fruitcount = 10;
            }
            else if (userInfo.StoryItemkey[i].Equals("����� ����")) 
            {
                purpleKey2.SetActive(true);
                GameObject bt = furnace_inven3.transform.GetChild(2).gameObject;
                bt.SetActive(false);
                hatcount = 10;
            }
            else if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����"))
            {
                pinkKey2.SetActive(true);
                GameObject bt = furnace_inven4.transform.GetChild(5).gameObject;
                bt.SetActive(false);
                orgolcount = 10;
            }
            else if (userInfo.StoryItemkey[i].Equals("���� ����")) 
            {
                pinkKey.SetActive(true);
                blueKey.SetActive(true);
                greenKey.SetActive(true);
                purpleKey.SetActive(true);
                GameObject bt = furnace_inven5.transform.GetChild(5).gameObject;
                bt.SetActive(false);

                keycount = 10;

            }
        }
    }


    public void click1()
    {

        // �ϴû� ���踦 ��� ���� (������ �쿴�� ��)
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("������"))
                teddycount++;
        }

        if (userInfo.isBlueKey == false && teddycount == 1) // ����
        {
            make_blueKey();
            return;
        }

        else if (userInfo.isBlueKey == false && teddycount != 1) // ����
        {
            show_fail();
            return;
        }
    }



    public void click2()
    {
        // ���λ� ���� ��� ���� (����: õ��, �Ǹ�, ���¸�, ���� �������� ��)
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            if (userInfo.FruitItemkey[i].Equals("DARK")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { fruitcount++; }
        }

        if (userInfo.isGreenKey == false && fruitcount == 4) // ���� ����� ����
        {
            make_greenKey();
        }
        else if (userInfo.isGreenKey == false && fruitcount != 4) // �������� �� �˸�â
        {
            show_fail();
        }
    }
    public void click3()
    {

        // ����� ���� ���� ���� (��¤���� �쿴�� ��)
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����"))
                hatcount++;
        }

        if (userInfo.isPurpleKey == false && hatcount == 1) // ����
        {
            make_purpleKey();
        }

        else if (userInfo.isPurpleKey == false && hatcount != 1) // ����
        {
            show_fail();
        }
    }

    public void click4()
    {
        // ��ȫ�� ���踦 ��� ���� (�������� �쿴�� ��)
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("Orgol"))
                orgolcount++;
        }


        if (userInfo.isPinkKey == false && orgolcount == 1) // ����
        {
            make_pinkKey();
        }

        else if (userInfo.isPinkKey == false && orgolcount != 1) // ����
        {
            show_fail();
        }
    }
    public void click5()
    {
        // ���� ���� ����� (�ٸ� ��� 4������ ���踦 ������� ��)
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����"))
                keycount++;
            if (userInfo.StoryItemkey[i].Equals("����� ����"))
                keycount++;
            if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����"))
                keycount++;
            if (userInfo.StoryItemkey[i].Equals("�ϴû� ����"))
                keycount++;
        }

        if (userInfo.isFinalKey == false && keycount == 4) // ����
        {
            make_finalKey();
        }

        else if (userInfo.isFinalKey == false && keycount != 4) // ����
        {
            show_fail();
        }

    }

   /* void active_false()
    {
        confirm.SetActive(false);
        ok.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);
    }*/

    void make_greenKey()
    {
        greenKey2.SetActive(true);
        GameObject bt = furnace_inven2.transform.GetChild(2).gameObject;
        bt.SetActive(false);


        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);
        fail.SetActive(false);
        text5.SetActive(false);

        fruitcount = 0;

        //�κ��丮�� �ʷϻ� ���� �ֱ� (�۹� 4��)
        userInfo.StoryItemkey.Add("�ʷϻ� ����");
        userInfo.StoryItem.Add("�ʷϻ� ����", 1);
        userInfo.isGreenKey = true;

        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;

            Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
            else if (userInfo.StoryItemkey[i].Equals("�ϴû� ����")) { keyimg.sprite = special[0]; }
            else if (userInfo.StoryItemkey[i].Equals("���� ����")) { keyimg.sprite = special[1]; }
            else if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����")) { keyimg.sprite = special[2]; }
            else if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����")) { keyimg.sprite = special[3]; }
            else if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����")) { keyimg.sprite = special[4]; }
            else if (userInfo.StoryItemkey[i].Equals("����� ����")) { keyimg.sprite = special[5]; }
            else if (userInfo.StoryItemkey[i].Equals("������")) { keyimg.sprite = special[6]; }


            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text GreenKeytext = text.GetComponent<Text>(); // ������ ����
            GreenKeytext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
            text.SetActive(true);
        }

    }

    void make_pinkKey()
    {
        pinkKey2.SetActive(true);
        GameObject bt = furnace_inven4.transform.GetChild(5).gameObject;
        bt.SetActive(false);

        orgolcount = 0;


        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);
        fail.SetActive(false);
        text5.SetActive(false);


        //�κ��丮�� ��ȫ�� ���� �ֱ� (������)
        userInfo.StoryItemkey.Add("��ȫ�� ����");
        userInfo.StoryItem.Add("��ȫ�� ����", 1);
        userInfo.isPinkKey = true;

        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;

            Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.StoryItemkey[i].Equals("Orgol")){ keyimg.sprite = spec_orgol[10];}
            else if (userInfo.StoryItemkey[i].Equals("�ϴû� ����")) { keyimg.sprite = special[0]; }
            else if (userInfo.StoryItemkey[i].Equals("���� ����")) { keyimg.sprite = special[1]; }
            else if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����")) { keyimg.sprite = special[2]; }
            else if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����")) { keyimg.sprite = special[3]; }
            else if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����")) { keyimg.sprite = special[4]; }
            else if (userInfo.StoryItemkey[i].Equals("����� ����")) { keyimg.sprite = special[5]; }
            else if (userInfo.StoryItemkey[i].Equals("������")) { keyimg.sprite = special[6]; }


            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text PinkKeytext = text.GetComponent<Text>();
            PinkKeytext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
            text.SetActive(true);
        }
    }

    void make_blueKey()
    {
        //bear.SetActive(true);
        blueKey2.SetActive(true);
        GameObject bt = furnace_inven1.transform.GetChild(2).gameObject;
        bt.SetActive(false);
        

        teddycount = 0;

        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);
        fail.SetActive(false);
        text5.SetActive(false);

        //�κ��丮�� �ϴû� ���� �ֱ� (������)
        userInfo.StoryItemkey.Add("�ϴû� ����");
        userInfo.StoryItem.Add("�ϴû� ����", 1);

        userInfo.isBlueKey = true;

        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;

            Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
            else if (userInfo.StoryItemkey[i].Equals("�ϴû� ����")) { keyimg.sprite = special[0]; }
            else if (userInfo.StoryItemkey[i].Equals("���� ����")) { keyimg.sprite = special[1]; }
            else if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����")) { keyimg.sprite = special[2]; }
            else if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����")) { keyimg.sprite = special[3]; }
            else if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����")) { keyimg.sprite = special[4]; }
            else if (userInfo.StoryItemkey[i].Equals("����� ����")) { keyimg.sprite = special[5]; }
            else if (userInfo.StoryItemkey[i].Equals("������")) { keyimg.sprite = special[6]; }


            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text BlueKeytext = text.GetComponent<Text>(); 
            BlueKeytext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
            text.SetActive(true);
        }
    }

    void make_purpleKey()
    {
        purpleKey2.SetActive(true);
        GameObject bt = furnace_inven3.transform.GetChild(2).gameObject;
        bt.SetActive(false);


        hatcount = 0;
        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);
        fail.SetActive(false);
        text5.SetActive(false);

        //�κ��丮�� ����� ���� �ֱ� (��¤����)
        userInfo.StoryItemkey.Add("����� ����");
        userInfo.StoryItem.Add("����� ����", 1);

        userInfo.isPurpleKey = true;

        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;

            Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
            else if (userInfo.StoryItemkey[i].Equals("�ϴû� ����")) { keyimg.sprite = special[0]; }
            else if (userInfo.StoryItemkey[i].Equals("���� ����")) { keyimg.sprite = special[1]; }
            else if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����")) { keyimg.sprite = special[2]; }
            else if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����")) { keyimg.sprite = special[3]; }
            else if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����")) { keyimg.sprite = special[4]; }
            else if (userInfo.StoryItemkey[i].Equals("����� ����")) { keyimg.sprite = special[5]; }
            else if (userInfo.StoryItemkey[i].Equals("������")) { keyimg.sprite = special[6]; }


            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text PurpleKeytext = text.GetComponent<Text>(); 
            PurpleKeytext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
            text.SetActive(true);
        }
    }

    void make_finalKey()
    {
        pinkKey.SetActive(true);
        blueKey.SetActive(true);
        greenKey.SetActive(true);
        purpleKey.SetActive(true);
        GameObject bt = furnace_inven5.transform.GetChild(5).gameObject;
        bt.SetActive(false);

        keycount = 0;

        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);
        fail.SetActive(false);
        text5.SetActive(false);

        //�κ��丮�� ���� ���� �ֱ�
        userInfo.StoryItemkey.Add("���� ����");
        userInfo.StoryItem.Add("���� ����", 1);

        userInfo.isFinalKey = true;

        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;

            Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
            else if (userInfo.StoryItemkey[i].Equals("�ϴû� ����")) { keyimg.sprite = special[0]; }
            else if (userInfo.StoryItemkey[i].Equals("���� ����")) { keyimg.sprite = special[1]; }
            else if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����")) { keyimg.sprite = special[2]; }
            else if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����")) { keyimg.sprite = special[3]; }
            else if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����")) { keyimg.sprite = special[4]; }
            else if (userInfo.StoryItemkey[i].Equals("����� ����")) { keyimg.sprite = special[5]; }
            else if (userInfo.StoryItemkey[i].Equals("������")) { keyimg.sprite = special[6]; }


            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text FinalKeytext = text.GetComponent<Text>(); 
            FinalKeytext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
            text.SetActive(true);
        }
    }

    void show_fail()
    {
        fruitcount = 0;
        orgolcount = 0;
        teddycount = 0;
        hatcount = 0;
        keycount = 0;

        confirm.SetActive(true);
        success.SetActive(false);
        text6.SetActive(false);
        ok.SetActive(true);
        fail.SetActive(true);
        text5.SetActive(true);
    }

    public void click_finalbox()
    {
        //���� ���踦 ������� ��
        if(userInfo.isFinalKey == true)
        {
            scanObj = GameObject.Find("final_man");
            isFinstory = true;
            GameObject background = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
            GameObject finbox = GameObject.Find("Hole_UI").transform.GetChild(7).gameObject;
            GameObject hole = GameObject.Find("Hole_UI").transform.GetChild(1).gameObject;
            GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            GameObject BGM = GameObject.Find("BGM");
            if (isFinstory)
            {
                hole.SetActive(false);
                background.SetActive(true);
                PlayerUI.SetActive(false);
                Destroy(BGM);
                audioSource.Play();
                //finbox.SetActive(true);
                textmanager.Action(scanObj); // ��ȭâ ���
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void click_ok()
    {
        confirm.SetActive(false);
        ok.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
    }

    public void click_exit()
    {
        Hole_UI.SetActive(false);
        furnace.SetActive(false);
        fin_box.SetActive(false);
        exit.SetActive(false);
        textmanager.isAction = false;
    }

    public void click_exit2()
    {
        furnace_UI.SetActive(false);
        furnace_inven1.SetActive(false);
        furnace_inven2.SetActive(false);
        furnace_inven3.SetActive(false);
        furnace_inven4.SetActive(false);
        furnace_inven5.SetActive(false);
        exit2.SetActive(false);

        text1.SetActive(false);
        //text2.SetActive(false);
        text3.SetActive(false);

        confirm.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
        ok.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);

        /*pinkKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);
        purpleKey.SetActive(false);
        finalKey.SetActive(false);*/

        /*pinkKey2.SetActive(false);
        blueKey2.SetActive(false);
        greenKey2.SetActive(false);
        purpleKey2.SetActive(false);*/

    }

}
