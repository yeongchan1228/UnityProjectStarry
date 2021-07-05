using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FirstMenuHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void GameLoad() // 저장 데이터 불러오기
    {

        string gender = PlayerPrefs.GetString("Gender");
        if (gender.Equals("man"))
        {
            GameObject user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        }




        if (!PlayerPrefs.HasKey("PlayerX")) // 키 PlayerX 찾기
        {
            return;
        }
        //float x = PlayerPrefs.GetFloat("PlayerX");
        //float y = PlayerPrefs.GetFloat("PlayerY");





        string scene = PlayerPrefs.GetString("Scene");
        SceneManager.LoadScene(scene);
        //user_man.transform.position = new Vector3(x, y, 0);
    }

    public void GameStart() // 캐릭터 성별 선택창으로 이동
    {
        SceneManager.LoadScene("InputInfo (2)");
    }

    public void GameExit() // 게임 종료
    {
        Application.Quit();
    }


}
