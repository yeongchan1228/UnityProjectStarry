using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<string, string[]> talking;
    Dictionary<string, Sprite> img; // �ʻ�ȭ
    public GameObject user_man;
    public GameObject user_woman;
    public Sprite[] spriteimg;
    void Awake()
    {
        talking = new Dictionary<string, string[]>();
        img = new Dictionary<string, Sprite>();
        makeTalking();
    }

   
    void makeTalking() // ��� �ִ� �� 
    {

        UserInfo userInfo = user_man.GetComponent<UserInfo>();
        if (userInfo.getGender().Equals("man")) { }
        else { userInfo = user_woman.GetComponent<UserInfo>(); }
        //��ȭ
        talking.Add("worker", new string[] { "����� ���Ͱ� ����ִ� �����̾�.", "�����ϴϱ� ������." });
        talking.Add("dog", new string[] { "�۸�!", "�۸۸Ӿ�!!!(����)" });
        talking.Add("sign", new string[] { "'"+userInfo.getName()+"'" +"���� ���Դϴ�." });




        //�ʻ�ȭ
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

    public Sprite Getimg(string id, int imgIndex) // imgIndex�� �׸��� ���� �� �־��� ��
    {
        return img[id];
    }
}
