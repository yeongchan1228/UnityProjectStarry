using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ������ ��

public class GameManager : MonoBehaviour
{
    public Text text1;
    private PlayerController user;
    public GameObject scanobject;
    public GameObject talk;
    public bool isAction; // ��ȭâ�� �����ִ��� �ƴ��� Ȯ��

    void Start()
    {
        user = GameObject.Find("Man_Player").GetComponent<PlayerController>();
    }

    public void Action(GameObject scanobj)
    {
        if (isAction) // ��ȭâ�� ���� ������
        {
            scanobject = null;
            text1.text = "";
            isAction = false; // ��ȭâ ������
        }
        else // ��ȭâ�� ���� ������
        {
            scanobject = scanobj;
            Debug.Log(scanobject.name);
            if (scanobject.name.Equals("dog")) // ������ �̸�
            {
                isAction = true; // ��ȭâ ������
                text1.text = "�۸�!";
            }
            else if (scanobject.name.Equals("sign"))
            {
                isAction = true; // ��ȭâ ������
                text1.text ="'" + user.user_name +"'"+ "�� ���Դϴ�.";
            }
        }
        talk.SetActive(isAction);
    }
}

