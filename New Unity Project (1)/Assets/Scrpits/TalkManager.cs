using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<string, string[]> talking;
    Dictionary<string, Sprite> img; // 초상화
    public GameObject user_man;
    public GameObject user_woman;
    public Sprite[] spriteimg;
    void Awake()
    {
        talking = new Dictionary<string, string[]>();
        img = new Dictionary<string, Sprite>();
        makeTalking();
    }

   
    void makeTalking() // 대사 넣는 곳 
    {

        UserInfo userInfo = user_man.GetComponent<UserInfo>();
        if (userInfo.getGender().Equals("man")) { }
        else { userInfo = user_woman.GetComponent<UserInfo>(); }
        //대화
        talking.Add("worker", new string[] { "여기는 몬스터가 살고있는 동굴이야.", "위험하니깐 저리가." });
        talking.Add("dog", new string[] { "멍멍!", "멍멍머엉!!!(꺼져)" });
        talking.Add("sign", new string[] { "'"+userInfo.getName()+"'" +"님의 집입니다." });




        //초상화
        img.Add("worker", spriteimg[0]);
        img.Add("dog", spriteimg[1]);
    }

    public string GetTalk(string id, int talkIndex)
    {
        if (talkIndex == talking[id].Length)
        {
            return null;
        }
        else
        {
            return talking[id][talkIndex];
        }
    }

    public Sprite Getimg(string id, int imgIndex) // imgIndex는 그림을 여러 개 넣었을 때
    {
        return img[id];
    }
}
