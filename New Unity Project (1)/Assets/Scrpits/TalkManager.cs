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
  
        if (user_man != null|| user_woman != null) { talking.Add("sign", new string[] { "'" + userInfo.getName() + "'" + "님의 집입니다.:0" }); }
        talking.Add("bed", new string[] { "침대에 왔어요, 뭘 할까요?\n\n:1: 휴식을 취한다.: 잠을 잔다." });

        //처음 스토리

        if (userInfo.getGender.equal == "man") // 남캐일 때
        {
            talking.Add("image1(boy)", new string[] { "-20xx년.:0", 
                "'청년 실업률이 10%를 넘어가며 'N포세대'라는 말이 나오는 가운데,\n갈수록 우리 청년들의 삶은...':0" });

            talking.Add("image2(boy)", new string[] { "벌써 3년째다. 내가 이 세상에 존재하는 게 맞는 걸까?:0",
                "하고 싶은 일, 해야 하는 일 없이\n그저 남들 하는대로만 살아가다가 벌써 이지경까지 왔다.:0",
            "세상에 대해 궁금한 일? 아무것도 없다.\n그냥 이 현실에서 벗어나고 싶은 감정 뿐이다.:0",
            "나는 서른이 되는 날에 자살할 예정이었고,\n그냥 아무 생각 없이 백수 생활만 지속하고 있었을 뿐이었다.:0"
            "...이제 내일이면 서른이 된다.\n오늘 나는 내일 나의 목을 맬 '그것'과 함께 잠이 들 예정이다.:0"});

            talking.Add("image3(boy)", new string[] { "'할머니 보고 싶다. 옛날엔 할머니가 칭찬해주면 뭐든 될 것 같았는데.':0",
                "내 인생 마지막 장면이 늘 보던 내 방 풍경일 것이라는 게 조금은 서러웠지만,\n그마저도 작은 사치처럼 느껴졌을 뿐이다. 어차피 내일이면 죽을 거니까.:0" });

            talking.Add("image4(boy)", new string[] { "... 이 밤이 내 생의 마지막 밤이 될 것이라고 생각하며 나는 잠이 들었다.:0"});

            talking.Add("image5(boy)", new string[] { "\"userInfo.getName()아(야).\":0",
            "\"할머니...?\":0"});
        }

        else  // 여캐일 때
        {
            taling.Add("image1(girl)", new string[] { "-20xx년.:0", 
                "'청년 실업률이 10%를 넘어가며 'N포세대'라는 말이 나오는 가운데,\n갈수록 우리 청년들의 삶은...':0" });

            talking.Add("image2(girl)", new string[] { "벌써 3년째다. 내가 이 세상에 존재하는 게 맞는 걸까?:0",
                "하고 싶은 일, 해야 하는 일 없이\n그저 남들 하는대로만 살아가다가 벌써 이지경까지 왔다.:0",
            "세상에 대해 궁금한 일? 아무것도 없다.\n그냥 이 현실에서 벗어나고 싶은 감정 뿐이다.:0",
            "나는 서른이 되는 날에 자살할 예정이었고,\n그냥 아무 생각 없이 백수 생활만 지속하고 있었을 뿐이었다.:0"
            "...이제 내일이면 서른이 된다.\n오늘 나는 내일 나의 목을 맬 '그것'과 함께 잠이 들 예정이다.:0"});

            talking.Add("image3(girl)", new string[] { "'할머니 보고 싶다. 옛날엔 할머니가 칭찬해주면 뭐든 될 것 같았는데.':0",
                "내 인생 마지막 장면이 늘 보던 내 방 풍경일 것이라는 게 조금은 서러웠지만,\n그마저도 작은 사치처럼 느껴졌을 뿐이다. 어차피 내일이면 죽을 거니까.:0" });

            talking.Add("image4(girl)", new string[] { "... 이 밤이 내 생의 마지막 밤이 될 것이라고 생각하며 나는 잠이 들었다.:0" });

            talking.Add("image5(girl)", new string[] { "\"userInfo.getName()아(야).\":0",
            "\"할머니...?\":0"});

            //남캐, 여캐 공동 이미지
            taling.Add("image6", new string[] { "'우리 아가, 이 상자에는 깜짝 놀랄만한 게 들어있단다. 궁금하지?':0",
                "'어? 누구지... 어디서 본 것 같은 얼굴인데.':0",
            "'하나도 안 궁금하거든요! 어차피 상자일 뿐인데!':0",
            "'... 그리고 이 날 이후로 상자에 대해 볼 수 없었단다.:0",
            "'아버지가 비밀 아지트라면서 어떤 구덩이에 상자를 숨겨놨는데,\n할미한테 열쇠는 안 주고 그대로 돌아가셨지 뭐니.':0"});

            talking.Add("image7", new string[] { "'아직까지 그 상자에 뭐가 들어있을지 잘 모르겠구나.\n어때, userInfo.getName()(이)도 궁금하지 않니?':0",
            "'그렇지만 할머니, 저는 더 이상 살고 싶지 않ㅇ...':0",
            "할머니는 내가 말을 끝마치기도 전에 사라지셨다.\n...희미하게 보이는 Starry Farm이라는 글자만 남겨두고.:0"});

            talking.Add("image8", new string[] { "그리고 놀랍게도, 내 손에는 방금 본 글자와\n어느 주소가 쓰여져 있는 종이가 쥐어져 있었다.:0",
            "할머니가 내게 이 꿈을 보여준 이유가 있을 거라 생각하고,\n상자만 찾으면 할머니 곁으로 가야겠다는 다짐과 함께,:0",
            "... 나는 스태리 팜으로 떠났다.:0"});
        }



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
