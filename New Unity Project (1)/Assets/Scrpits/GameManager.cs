using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ������ ��

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public Text text1;
    private PlayerController user;
    public GameObject scanobject;
    public GameObject talk;
    public Image img; // �ʻ�ȭ
    public int talkIndex;
    public bool isAction; // ��ȭâ�� �����ִ��� �ƴ��� Ȯ��

    void Start()
    {
        user = GameObject.Find("Man_Player").GetComponent<PlayerController>();
    }

    public void Action(GameObject scanobj)
    {
            scanobject = scanobj;
            NPC_DATA npc_Data = scanobject.GetComponent<NPC_DATA>();
            Debug.Log("npc  data " +npc_Data.id);
            Talking(npc_Data.id, npc_Data.isNPC);
            talk.SetActive(isAction);
    }


    void Talking(string id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }


        if (isNPC)
        {
            text1.text = talkData;
            img.color = new Color(1, 1, 1, 1);
            img.sprite = talkManager.Getimg(id, 0);
        }
        else
        {
            text1.text = talkData;
            img.color = new Color(1, 1, 1, 0); // �Ⱥ��̰��ϱ�
        }

        isAction = true;
        talkIndex++;
    }
}

