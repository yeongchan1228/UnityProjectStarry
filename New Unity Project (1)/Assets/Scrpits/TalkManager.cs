using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<string, string[]> talking;
    Dictionary<string, Sprite> img; // �ʻ�ȭ
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

   
    public void makeTalking() // ��� �ִ� �� 
    {
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else { userInfo = user_woman.GetComponent<UserInfo>(); }
       
        //��ȭ
        talking.Add("worker", new string[] { "����� ���Ͱ� ����ִ� �����̾�.:0", "�����ϴϱ� ������.:0", "�׷��� ������?\n\n:1: ����.: ���ư���." });
        talking.Add("dog", new string[] { "�۸�!:0", "�۸۸Ӿ�!!!(����):0" });
        talking.Add("grandma", new string[] { " -20xx��, 3��.�ҸӴϰ�...:0", "����ϴ� ���� "+ userInfo.getName() + "����.:0", "�� ������ �־���, �ư���.:0",
            "�װ� �� ������ ���� �� �����̸� ���� �� ���� ���� �� ������.:0", "ȥ�� Ÿ���� �ö�, ���� ������ ���� ������ �Ŷ�� �����Ѵ�.:0",
        "���� ��� �� �����ϰ� �;��� ���� �´ٸ�, ���� �ʸӿ� �ִ� StarryFarm ������ �����Ŷ�.:0", "�̰������� �װ� ���ϴ� �� �����̵��� ������ �� ���� �ž�.:0",
        "�� �����ϰ� ������.:0", ".......����ϴ� ���� �ҸӴϰ�.:0"});
        if (user_man != null|| user_woman != null) { talking.Add("sign", new string[] { "'" + userInfo.getName() + "'" + "���� ���Դϴ�.:0" }); }
        talking.Add("bed", new string[] { "ħ�뿡 �Ծ��, �� �ұ��?\n\n:1: �޽��� ���Ѵ�.: ���� �ܴ�." });
       




        //�ʻ�ȭ
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

    public Sprite Getimg(string id, int imgIndex) // imgIndex�� �׸��� ���� �� �־��� ��
    {
        return img[id];
    }
}
