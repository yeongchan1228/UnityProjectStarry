using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 가져올 때

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public ChatEffect chatEffect;
    private PlayerController user;
    public GameObject scanobject;
    public Animator talk;
    public Animator ImgAnimator;
    public Image img; // 초상화
    public int talkIndex;
    public bool isAction; // 대화창이 켜져있는지 아닌지 확인

    void Start()
    {
        user = GameObject.Find("Man_Player").GetComponent<PlayerController>();
    }

    public void Action(GameObject scanobj)
    {
            scanobject = scanobj;
            NPC_DATA npc_Data = scanobject.GetComponent<NPC_DATA>();
            Talking(npc_Data.id, npc_Data.isNPC);
            talk.SetBool("isShow", isAction);
    }


    void Talking(string id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkIndex > 0)
        {
            ImgAnimator.SetTrigger("Effect");
        }
        if (talkData == null && chatEffect.doing == false)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }


        if (isNPC)
        {
            chatEffect.Setting(talkData);
            img.color = new Color(1, 1, 1, 1);
            img.sprite = talkManager.Getimg(id, 0);
        }
        else
        {
            chatEffect.Setting(talkData);
            img.color = new Color(1, 1, 1, 0); // 안보이게하기
        }

        isAction = true;
        if (chatEffect.doing)
        {
            talkIndex++;
        }
    }
}

