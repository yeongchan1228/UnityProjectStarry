using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI ������ ��

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public ChatEffect chatEffect;
    private PlayerController user;
    public GameObject scanobject;
    public Animator talk;
    public Animator ImgAnimator;
    public Image img; // �ʻ�ȭ
    public int talkIndex;
    public bool isAction; // ��ȭâ�� �����ִ��� �ƴ��� Ȯ��
    public GameObject button1;
    public GameObject button2;
    public bool isButton;
    public string select1, select2, select3;
    

    void Start()
    {
        //user = GameObject.Find("Man_Player").GetComponent<PlayerController>(); 
       
    }


    public void Action(GameObject scanobj)
    {
        scanobject = scanobj;
        NPC_DATA npc_Data = scanobject.GetComponent<NPC_DATA>();
        Debug.Log(scanobj);
        Talking(npc_Data.id, npc_Data.isNPC);
        talk.SetBool("isShow", isAction);
    }


    

    void Talking(string id, bool isNPC)
    {

        button1.SetActive(false);
        button2.SetActive(false);
        
        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkIndex > 0)
        {
            ImgAnimator.SetTrigger("Effect");
        }

        if (talkData == null && chatEffect.doing == false)
        {
            isAction = false;
            talkIndex = 0;
            IsFirstStory isFirst = GameObject.Find("Trigger").GetComponent<IsFirstStory>();
            if (isFirst.isFirststory) // ù ��° ���丮 ������ �̵�
            {
                isFirst.isFirststory = false;
                SceneManager.LoadScene("HouseScene (5)"); // �̵�
            }
            return;
        }


        if (isNPC)
        {
            if (talkData == null) { chatEffect.Setting("�ΰ���."); }
            else
            {
                chatEffect.Setting(talkData.Split(':')[0]);


                img.color = new Color(1, 1, 1, 1);
                img.sprite = talkManager.Getimg(id, 0);
                select3 = talkData.Split(':')[1];
                if (select3 == "1")
                {
                    isButton = true;
                    select1 = talkData.Split(':')[2];
                    select2 = talkData.Split(':')[3];
                }
            }


        }
        else
        {
            chatEffect.Setting(talkData);
            img.color = new Color(1, 1, 1, 0); // �Ⱥ��̰��ϱ�
        }

        isAction = true;
        if (chatEffect.doing)
        {
            talkIndex++;
        }
    }
}

