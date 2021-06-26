using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject Menu; // �޴� ������Ʈ
    GameManager textmanager;
    GameObject user_man, user_woman;
    GameObject Sleep;
    PlayerController playercontrol;
    public GameObject game1, game2;
    GameObject chatEffect;
    House House;
    ChatEffect chat;
    bool isMan; // ��������
    bool isWoman; // ��������
    private Sprite[] genders;
    public Button Menu_Button1, Menu_Button2;
    //public Image man, woman;
    //Image ManImage, WomanImage;
    UserInfo userInfo;
    // Start is called before the first frame update
    void Start()
    {
        //ManImage = ManButton.GetComponent<Image>();
        //WomanImage = WomanButton.GetComponent<Image>();
        //genders = Resources.LoadAll<Sprite>("Sprites/SelectGender");
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        chatEffect = GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).gameObject;
        chat = chatEffect.GetComponent<ChatEffect>();
        GetInfo();
        Menu_Button1 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.GetComponent<Button>();
        Menu_Button2 = GameObject.Find("Canvas").transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.GetComponent<Button>();
        Debug.Log(Menu_Button1);
        Menu_Button1.onClick.AddListener(Menu1Clicked);
        Menu_Button2.onClick.AddListener(Menu2Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) // Esc ������ ��
        {
            if (Menu.activeSelf)
            {
                textmanager.isAction = false; // �ٽ� �����̰�
                Menu.SetActive(false);
            }
            else
            {
                Menu.SetActive(true);
                textmanager.isAction = true; // ĳ���� �������� ���ϰ� ����
            }
        }
    }

    void GetInfo()
    {
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (isMan)
        {
            userInfo = user_man.GetComponent<UserInfo>();
            playercontrol = user_man.GetComponent<PlayerController>();
        }
        else { 
            userInfo = user_woman.GetComponent<UserInfo>();
            playercontrol = user_woman.GetComponent<PlayerController>();
        }
    }

    public void GameContinues() // ���� ��� ����
    {
        textmanager.isAction = false; // �ٽ� �����̰�
        Menu.SetActive(false); // �޴� ����
    }

    public void GameExit() // ���� ����
    {
        Application.Quit();
    }

    public void GameSave() // ���� ����
    {
        //PlayerPefs ������ ���� �Լ�
        //�÷��̾� ��ġ ����
        PlayerPrefs.SetFloat("PlayerX", user_man.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", user_man.transform.position.y);
        
        //UserInfo ����


        //PlayerPrefs�� ����
        PlayerPrefs.Save();

        //�޴� �ݱ�
        textmanager.isAction = false; // �ٽ� �����̰�
        Menu.SetActive(false); // �޴� ����
    } 
    
    public void GameLoad() // ���� ������ �ҷ�����
    {
        if (!PlayerPrefs.HasKey("PlayerX")) // Ű PlayerX ã��
        {
            return;
        }
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        user_man.transform.position = new Vector3(x, y, 0);
    }

    public void GameInfo() // ĳ���� ���� ����â���� �̵�
    {
        SceneManager.LoadScene("InputInfo (2)");
    }

    public void CreateMan()
    {
        isMan = true;
        isWoman = false;
        //ManImage.sprite = genders[0];
    }

    public void CreateWoMan()
    {
        isMan = false;
        isWoman = true;
        //WomanImage.sprite = genders[1];
    }

    public void Name_FarmName()
    {
        GetInfo();
        Text text1 = game1.GetComponent<Text>();
        Text text2 = game2.GetComponent<Text>();
        userInfo.setName(text1.text);
        userInfo.setFarmName(text2.text);
        userInfo.isTrue = true;
        userInfo.Hp = 100;
        userInfo.Day = 1;
        SceneManager.LoadScene("FirstStory (4)");
    }

    public void Menu1Clicked()
    {
        if (playercontrol.scanObj.name.Equals("poor-kid1")) // ������ ��
        {
            textmanager.isAction = false; // �ٽ� �����̰�
            textmanager.talk.SetBool("isShow", textmanager.isAction);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            textmanager.talkIndex = 0;
            userInfo.userWhere = 1;
            chat.buttonOn = false;
            SceneManager.LoadScene("Dungeon (11)");
        }
        if (playercontrol.scanObj.name.Equals("bed")) // ħ���� ��(����)
        {
            Debug.Log("���۵�");
            Sleep = GameObject.Find("Sleep").transform.GetChild(0).gameObject;
            House = GameObject.Find("House").GetComponent<House>();
            textmanager.isAction = false; // �ٽ� �����̰�
            textmanager.talk.SetBool("isShow", textmanager.isAction);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            textmanager.talkIndex = 0;
            chat.buttonOn = false;
        }
    }

    public void Menu2Clicked()
    {
        Debug.Log(playercontrol.transform.position);
        Debug.Log(playercontrol.scanObj.name);
        if (playercontrol.scanObj.name.Equals("poor-kid1")) // ������ ��
        {
            textmanager.isAction = false; // �ٽ� �����̰�
            textmanager.talk.SetBool("isShow", textmanager.isAction);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            chat.buttonOn = false;
            textmanager.talkIndex = 0;
        }
        else if (playercontrol.scanObj.name.Equals("bed")) // ħ���� �� (���ڱ�)
        {
            Sleep = GameObject.Find("Sleep").transform.GetChild(0).gameObject;
            Debug.Log("���۵ʤ�����");
            textmanager.isAction = false; // �ٽ� �����̰�
            textmanager.talk.SetBool("isShow", textmanager.isAction);
            textmanager.button1.SetActive(false);
            textmanager.button2.SetActive(false);
            chat.buttonOn = false;
            textmanager.talkIndex = 0;
            Sleep.SetActive(true);
            House = GameObject.Find("House").GetComponent<House>();
            House.isAction = true;
            House.sleep.SetBool("isSleep", House.isAction);
        }
    }
}
