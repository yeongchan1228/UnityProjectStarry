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
    void Update()
    {
        
    }
    public void GameLoad() // ���� ������ �ҷ�����
    {
        if (!PlayerPrefs.HasKey("PlayerX")) // Ű PlayerX ã��
        {
            return;
        }
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        //user_man.transform.position = new Vector3(x, y, 0);
    }

    public void GameStart() // ĳ���� ���� ����â���� �̵�
    {
        SceneManager.LoadScene("InputInfo (2)");
    }

    public void GameExit() // ���� ����
    {
        Application.Quit();
    }


}
