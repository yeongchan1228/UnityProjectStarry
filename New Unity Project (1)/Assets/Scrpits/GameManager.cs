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
    public GameObject Chat;
    public Animator talk;
    public Animator ImgAnimator;
    public Image img; // 초상화
    public int talkIndex, talkIndex2;
    public bool isAction; // 대화창이 켜져있는지 아닌지 확인
    public GameObject button1;
    public GameObject button2;
    public bool isButton, isFirstImg, isFinimg, is_off, isman, iswoman;
    public string select1, select2, select3;
    public GameObject user_man;
    public GameObject user_woman;
    bool getinfo;
    public UserInfo userInfo;
    ButtonHandler buttonHandler;

    void Start()
    {
    }
    void user_Infp()
    {
        if (userInfo == null)
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
    }

    public void Action(GameObject scanobj)
    {
        user_Infp();
        //Chat.SetActive(true);
        
        scanobject = scanobj;
        NPC_DATA npc_Data = scanobject.GetComponent<NPC_DATA>();
        Talking(npc_Data.id, npc_Data.isNPC, npc_Data.isHINT, npc_Data.isSELLER);
        talk.SetBool("isShow", isAction);
        if(!isAction && npc_Data.isSELLER && userInfo.grandmaFish == 1) { userInfo.npcFinish = true; }
        if(!isAction && scanobj.name.Equals("final_man")) 
        {
            GameObject off_img = GameObject.Find("Hole_UI").transform.GetChild(7).gameObject;
            GameObject enddingimg = GameObject.Find("Hole_UI").transform.GetChild(8).gameObject;
            off_img.SetActive(false);
            buttonHandler = GameObject.Find("ButtonHandler").GetComponent<ButtonHandler>();
            buttonHandler.scanObj = null;
            enddingimg.SetActive(true);
        }
        if (!isAction)
        {
            GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            GameObject ItemUI = PlayerUI.transform.GetChild(0).gameObject;
            ItemUI.SetActive(true);
        }
    }


    

    void Talking(string id, bool isNPC, bool isHINT, bool isSELLER)
    {
        user_Infp();
        button1.SetActive(false);
        button2.SetActive(false);
        
        string talkData = talkManager.GetTalk(id, talkIndex);

        //talkIndex2 = Random.Range(0, 8);
        //string talkData2 = talkManager.GetTalk(id, talkIndex2);


        if (talkIndex > 0)
        {
            ImgAnimator.SetTrigger("Effect");
        }

    

        if (talkData == null && chatEffect.doing == false)
        {
            isAction = false;
            talkIndex = 0;
            
            if (!getinfo)
            {
                user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
                user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
                UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
                if (userinfo2.isTrue)
                {
                    userInfo = user_man.GetComponent<UserInfo>();
                }
                else { userInfo = user_woman.GetComponent<UserInfo>(); }
                getinfo = true;
            }

            if (userInfo.storycounter < 1)
            {
                IsFirstStory isFirst = GameObject.Find("Trigger").GetComponent<IsFirstStory>();
                if (isFirst.isFirststory) // 첫 번째 스토리 끝나면 이동
                {
                    isFirst.isFirststory = false;
                    SceneManager.LoadScene("HouseScene (5)"); // 이동
                }
            }
            return;
        }


        if (isSELLER)
        {
            if (talkData == null) {
                chatEffect.Setting("널값임.");
            }
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

        else if (isNPC)
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

        
        else if(isHINT)
        {
            if (talkData == null) { chatEffect.Setting("널값임."); }
            else
            {
                chatEffect.Setting(talkData.Split(':')[0]);

                img.color = new Color(1, 1, 1, 1);
                img.sprite = talkManager.Getimg(id, 0);
            }

        }

        else
        {
            if (talkData == null) { chatEffect.Setting("널값임."); }
            else
            {
                chatEffect.Setting(talkData.Split(':')[0]);
                img.color = new Color(1, 1, 1, 0); // 안보이게하기
                select3 = talkData.Split(':')[1];
                if (select3 == "1")
                {
                    isButton = true;
                    select1 = talkData.Split(':')[2];
                    select2 = talkData.Split(':')[3];
                }
                else if (select3 == "3")
                {
                    isFirstImg = true;
                }
                else if (select3 == "4")
                {
                    is_off = true;
                }
                else if (select3 == "5")
                {
                    isFinimg = true;
                }
            }
        }

        isAction = true;
        if (chatEffect.doing)
        {
            talkIndex++;
        }
    }
}

