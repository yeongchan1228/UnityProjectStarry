using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            if (isFirst.isFirststory) // 첫 번째 스토리 끝나면 이동
            {
                isFirst.isFirststory = false;
                SceneManager.LoadScene("HouseScene (5)"); // 이동
            }
            return;
        }


        if (isNPC)
        {
            if (talkData == null) { chatEffect.Setting("널값임."); }
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
            img.color = new Color(1, 1, 1, 0); // 안보이게하기
        }

        isAction = true;
        if (chatEffect.doing)
        {
            talkIndex++;
        }
    }
}

