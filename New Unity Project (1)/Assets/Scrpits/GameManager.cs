using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ������ ��

public class GameManager : MonoBehaviour
{
    public Text text1;
    public GameObject scanobject;
    public GameObject talk;
    public bool isAction; // ��ȭâ�� �����ִ��� �ƴ��� Ȯ��

    public void Action(GameObject scanobj)
    {
        if (isAction) // ��ȭâ�� ���� ������
        {
            isAction = false; // ��ȭâ ������
        }
        else // ��ȭâ�� ���� ������
        {
            isAction = true; // ��ȭâ ������
            scanobject = scanobj; 
            if (scanobject.name.Equals("dog")) // ������ �̸�
            {
                text1.text = "�۸�!";
            }
        }
        talk.SetActive(isAction);
    }
}

