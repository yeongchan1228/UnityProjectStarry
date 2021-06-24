using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject Menu; // �޴� ������Ʈ
    public GameManager textmanager;
    public GameObject user_man;
    public GameObject user_woman;
    public GameObject game1, game2;

    UserInfo userInfo;
    // Start is called before the first frame update
    void Start()
    {
        //userInfo = user_man.GetComponent<UserInfo>();
        GameObject game = GameObject.Find("Player");
        if (game != null)
        {
            GetInfo();
        }
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
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else { userInfo = user_woman.GetComponent<UserInfo>(); }
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
        UserInfo userinfo = user_man.GetComponent<UserInfo>();
        userinfo.isTrue = true;
        SceneManager.LoadScene("InputInfo2 (3)");
    }

    public void CreateWoMan()
    {
        UserInfo userinfo = user_woman.GetComponent<UserInfo>();
        userinfo.isTrue = true;
        SceneManager.LoadScene("InputInfo2 (3)");
    }

    public void Name_FarmName()
    {
        Text text1 = game1.GetComponent<Text>();
        Text text2 = game2.GetComponent<Text>();
        userInfo.setName(text1.text);
        userInfo.setFarmName(text2.text);
        SceneManager.LoadScene("FirstStory (4)");
    }
}
