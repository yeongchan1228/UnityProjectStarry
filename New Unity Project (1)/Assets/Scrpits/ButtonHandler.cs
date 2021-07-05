using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Hole_UI, furnace, fin_box, exit;
    public GameObject furnace_UI, furnace_inven1, furnace_inven2, furnace_inven3, furnace_inven4, furnace_inven5;
    public GameObject fire, exit2;
    public GameManager textmanager;
    public GameObject text1, text2, text3;

    public GameObject confirm, fail, text5, ok, success, text6;
    public GameObject pinkKey, blueKey, greenKey, purpleKey, finalKey;
    public GameObject pinkKey2, blueKey2, greenKey2, purpleKey2;
    public GameObject strawberry, angel, devil, bear, hat, musicbox, starry;

    UserInfo userInfo;
    GameObject user_man, user_woman;
    MenuControl menuControl;

    Sprite[] spec_orgol;
    Sprite[] special;

    //bool isPinkKey, isGreenKey, isBlueKey, isPurpleKey, isFinalKey;
    int isOk = 0; // �˸�â�� �ߺ����� �ߴ� ���� ����
    
    int fruitcount = 0;
    int orgolcount = 0;
    int teddycount = 0;
    int hatcount = 0;
    int keycount = 0;

    void Start()
    {
        spec_orgol = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        special = Resources.LoadAll<Sprite>("Sprites/Final");

        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        menuControl = GameObject.Find("MenuManager").GetComponent<MenuControl>();

        Hole_UI = GameObject.Find("Hole_UI").transform.GetChild(0).gameObject;
        furnace = Hole_UI.transform.GetChild(0).gameObject;
        fin_box = Hole_UI.transform.GetChild(1).gameObject;
        exit = Hole_UI.transform.GetChild(2).gameObject;

        furnace_UI = GameObject.Find("Hole_UI").transform.GetChild(1).gameObject;
        furnace_inven1 = furnace_UI.transform.GetChild(0).gameObject;
        furnace_inven2 = furnace_UI.transform.GetChild(1).gameObject;
        furnace_inven3 = furnace_UI.transform.GetChild(2).gameObject;
        furnace_inven4 = furnace_UI.transform.GetChild(3).gameObject;
        furnace_inven5 = furnace_UI.transform.GetChild(4).gameObject;
        fire = furnace_UI.transform.GetChild(5).gameObject;
        exit2 = furnace_UI.transform.GetChild(6).gameObject;

        text1 = GameObject.Find("Hole_UI").transform.GetChild(2).gameObject;
        text2 = GameObject.Find("Hole_UI").transform.GetChild(3).gameObject;
        text3 = GameObject.Find("Hole_UI").transform.GetChild(4).gameObject;

        confirm = GameObject.Find("Hole_UI").transform.GetChild(5).gameObject;
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


    public void click_furnace()
    {
        furnace_UI.SetActive(true);
        furnace_inven1.SetActive(true);
        furnace_inven2.SetActive(true);
        furnace_inven3.SetActive(true);
        furnace_inven4.SetActive(true);
        furnace_inven5.SetActive(true);
        fire.SetActive(true);
        exit2.SetActive(true);

        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
    }


    public void click_fire()
    {
        // ���λ� ���� ��� ���� (����: õ��, �Ǹ�, ���¸�, ���� �������� ��)
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            if (userInfo.FruitItemkey[i].Equals("DARK")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { fruitcount++; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { fruitcount++; }   
        }

        if(userInfo.isGreenKey == false && isOk == 0 && fruitcount == 4) // ���� ����� ����
        {
            make_greenKey();
        }

        else if(userInfo.isGreenKey == false && isOk == 0 && fruitcount != 4) // �������� �� �˸�â
        {
            show_fail();
        }


        // ��ȫ�� ���踦 ��� ���� (�������� �쿴�� ��)
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("Orgol"))
                orgolcount++;
        }


        if (userInfo.isPinkKey == false && isOk== 0 && orgolcount==1) // ����
        {
            make_pinkKey();
        }
        
        else if (userInfo.isPinkKey == false && isOk == 0 && orgolcount != 1) // ����
        {
            show_fail();
        }


        // �ϴû� ���踦 ��� ���� (������ �쿴�� ��)
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("������"))
                teddycount++;
        }

        if (userInfo.isBlueKey == false && isOk == 0 && teddycount == 1) // ����
        {
            make_blueKey();
        }

        else if (userInfo.isBlueKey == false && isOk == 0 && teddycount!= 1) // ����
        {
            show_fail();
        }


        // ����� ���� ���� ���� (��¤���� �쿴�� ��)
        for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
        {
            if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����"))
                hatcount++;
        }

        if (userInfo.isPurpleKey == false && isOk == 0 && hatcount == 1) // ����
        {
            make_purpleKey();
        }

        else if (userInfo.isPurpleKey == false && isOk == 0 && hatcount !=1) // ����
        {
            show_fail();
        }


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

        if (userInfo.isFinalKey == false && isOk == 0 && keycount==4) // ����
        {
            make_finalKey();
        }

        else if (userInfo.isFinalKey == false && isOk == 0 && keycount != 4) // ����
        {
            show_fail();
        }
    }

    void active_false()
    {
        confirm.SetActive(false);
        ok.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);
    }

    void make_greenKey()
    {
        strawberry.SetActive(true);
        angel.SetActive(true);
        devil.SetActive(true);
        starry.SetActive(true);
        greenKey.SetActive(true);

        isOk++;

        active_false();
        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);

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
        musicbox.SetActive(true);
        pinkKey.SetActive(true);

        orgolcount = 0;
        isOk++;

        active_false();

        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);


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
        bear.SetActive(true);
        blueKey.SetActive(true);

        active_false();

        teddycount = 0;
        isOk++;

        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);

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
        hat.SetActive(true);
        purpleKey.SetActive(true);

        active_false();

        teddycount = 0;
        isOk++;
        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);

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
        pinkKey2.SetActive(true);
        blueKey2.SetActive(true);
        greenKey2.SetActive(true);
        purpleKey2.SetActive(true);

        active_false();

        keycount = 0;
        isOk++;

        confirm.SetActive(true);
        ok.SetActive(true);
        success.SetActive(true);
        text6.SetActive(true);

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

        active_false();

        confirm.SetActive(true);
        ok.SetActive(true);
        fail.SetActive(true);
        text5.SetActive(true);
    }

    public void click_finalbox()
    {
        //���� ���踦 ������� ��
        if(userInfo.isFinalKey == true)
        {
            // ���߿� ���⿡ ���� �� �߰��ϱ�.
        }
    }

    public void click_ok()
    {
        confirm.SetActive(false);
        ok.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
        isOk = 0;
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
        fire.SetActive(false);
        exit2.SetActive(false);

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);

        confirm.SetActive(false);
        fail.SetActive(false);
        text5.SetActive(false);
        ok.SetActive(false);
        success.SetActive(false);
        text6.SetActive(false);

        pinkKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);
        purpleKey.SetActive(false);
        finalKey.SetActive(false);

        pinkKey2.SetActive(false);
        blueKey2.SetActive(false);
        greenKey2.SetActive(false);
        purpleKey2.SetActive(false);

        strawberry.SetActive(false);
        angel.SetActive(false);
        devil.SetActive(false);
        bear.SetActive(false);
        hat.SetActive(false);
        musicbox.SetActive(false);
        starry.SetActive(false);
    }

}
