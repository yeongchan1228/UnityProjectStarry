using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<string, string[]> talking;
    Dictionary<string, Sprite> img; // 초상화
    GameObject user_man;
    GameObject user_woman;
    public Sprite[] spriteimg;
    UserInfo userInfo;
    void Awake()
    {
        talking = new Dictionary<string, string[]>();
        img = new Dictionary<string, Sprite>();
        //makeTalking();
    }

   
    public void makeTalking() // 대사 넣는 곳 
    {
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else { userInfo = user_woman.GetComponent<UserInfo>(); }
       
        //대화
        talking.Add("worker", new string[] { "여기는 몬스터가 살고있는 동굴이야.:0", "위험하니깐 저리가.:0", "그래도 들어갈꺼야?\n\n:1: 들어간다.: 돌아간다." });
        talking.Add("dog", new string[] { "멍멍!:0", "멍멍머엉!!!(꺼져):0" });
        talking.Add("grandma", new string[] { " -20xx년, 3월.할머니가...:0", "사랑하는 나의 "+ userInfo.getName() + "에게.:0", "잘 지내고 있었니, 아가야.:0",
            "네가 이 편지를 읽을 때 즈음이면 나는 이 세상에 없을 것 같구나.:0", "혼자 타지에 올라가, 힘든 날들이 정말 많았을 거라고 생각한다.:0",
        "문득 모든 걸 포기하고 싶어질 때가 온다면, 북쪽 너머에 있는 StarryFarm 마을로 떠나거라.:0", "이곳에서는 네가 원하는 건 무엇이든지 만들어나갈 수 있을 거야.:0",
        "늘 응원하고 있으마.:0", ".......사랑하는 너의 할머니가.:0"});
        if (user_man != null|| user_woman != null) { talking.Add("sign", new string[] { "'" + userInfo.getName() + "'" + "님의 집입니다.:0" }); }
        talking.Add("bed", new string[] { "침대에 왔어요, 뭘 할까요?\n\n:1: 휴식을 취한다.: 잠을 잔다." });
       




        //초상화
        img.Add("worker", spriteimg[0]);
        img.Add("dog", spriteimg[1]);
        img.Add("grandma", spriteimg[2]);
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
