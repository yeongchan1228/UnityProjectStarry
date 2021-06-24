using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject Menu; // 메뉴 오브젝트
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
        if (Input.GetButtonDown("Cancel")) // Esc 눌렀을 시
        {
            if (Menu.activeSelf)
            {
                textmanager.isAction = false; // 다시 움직이게
                Menu.SetActive(false);
            }
            else
            {
                Menu.SetActive(true);
                textmanager.isAction = true; // 캐릭터 움직이지 못하게 막기
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

    public void GameContinues() // 게임 계속 실행
    {
        textmanager.isAction = false; // 다시 움직이게
        Menu.SetActive(false); // 메뉴 끄기
    }

    public void GameExit() // 게임 종료
    {
        Application.Quit();
    }

    public void GameSave() // 게임 저장
    {
        //PlayerPefs 데이터 저장 함수
        //플레이어 위치 저장
        PlayerPrefs.SetFloat("PlayerX", user_man.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", user_man.transform.position.y);
        
        //UserInfo 저장


        //PlayerPrefs에 저장
        PlayerPrefs.Save();

        //메뉴 닫기
        textmanager.isAction = false; // 다시 움직이게
        Menu.SetActive(false); // 메뉴 끄기
    } 
    
    public void GameLoad() // 저장 데이터 불러오기
    {
        if (!PlayerPrefs.HasKey("PlayerX")) // 키 PlayerX 찾기
        {
            return;
        }
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        user_man.transform.position = new Vector3(x, y, 0);
    }

    public void GameInfo() // 캐릭터 성별 선택창으로 이동
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
