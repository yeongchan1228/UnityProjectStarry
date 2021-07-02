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
  
        if (user_man != null|| user_woman != null) { talking.Add("sign", new string[] { "'" + userInfo.getName() + "'" + "���� ���Դϴ�.:0" }); }
        talking.Add("bed", new string[] { "ħ�뿡 �Ծ��, �� �ұ��?\n\n:1: �޽��� ���Ѵ�.: ���� �ܴ�." });

        //ó�� ���丮

        if (userInfo.getGender.equal == "man") // ��ĳ�� ��
        {
            talking.Add("image1(boy)", new string[] { "-20xx��.:0", 
                "'û�� �Ǿ����� 10%�� �Ѿ�� 'N������'��� ���� ������ ���,\n������ �츮 û����� ����...':0" });

            talking.Add("image2(boy)", new string[] { "���� 3��°��. ���� �� ���� �����ϴ� �� �´� �ɱ�?:0",
                "�ϰ� ���� ��, �ؾ� �ϴ� �� ����\n���� ���� �ϴ´�θ� ��ư��ٰ� ���� ��������� �Դ�.:0",
            "���� ���� �ñ��� ��? �ƹ��͵� ����.\n�׳� �� ���ǿ��� ����� ���� ���� ���̴�.:0",
            "���� ������ �Ǵ� ���� �ڻ��� �����̾���,\n�׳� �ƹ� ���� ���� ��� ��Ȱ�� �����ϰ� �־��� ���̾���.:0"
            "...���� �����̸� ������ �ȴ�.\n���� ���� ���� ���� ���� �� '�װ�'�� �Բ� ���� �� �����̴�.:0"});

            talking.Add("image3(boy)", new string[] { "'�ҸӴ� ���� �ʹ�. ������ �ҸӴϰ� Ī�����ָ� ���� �� �� ���Ҵµ�.':0",
                "�� �λ� ������ ����� �� ���� �� �� ǳ���� ���̶�� �� ������ ����������,\n�׸����� ���� ��ġó�� �������� ���̴�. ������ �����̸� ���� �Ŵϱ�.:0" });

            talking.Add("image4(boy)", new string[] { "... �� ���� �� ���� ������ ���� �� ���̶�� �����ϸ� ���� ���� �����.:0"});

            talking.Add("image5(boy)", new string[] { "\"userInfo.getName()��(��).\":0",
            "\"�ҸӴ�...?\":0"});
        }

        else  // ��ĳ�� ��
        {
            taling.Add("image1(girl)", new string[] { "-20xx��.:0", 
                "'û�� �Ǿ����� 10%�� �Ѿ�� 'N������'��� ���� ������ ���,\n������ �츮 û����� ����...':0" });

            talking.Add("image2(girl)", new string[] { "���� 3��°��. ���� �� ���� �����ϴ� �� �´� �ɱ�?:0",
                "�ϰ� ���� ��, �ؾ� �ϴ� �� ����\n���� ���� �ϴ´�θ� ��ư��ٰ� ���� ��������� �Դ�.:0",
            "���� ���� �ñ��� ��? �ƹ��͵� ����.\n�׳� �� ���ǿ��� ����� ���� ���� ���̴�.:0",
            "���� ������ �Ǵ� ���� �ڻ��� �����̾���,\n�׳� �ƹ� ���� ���� ��� ��Ȱ�� �����ϰ� �־��� ���̾���.:0"
            "...���� �����̸� ������ �ȴ�.\n���� ���� ���� ���� ���� �� '�װ�'�� �Բ� ���� �� �����̴�.:0"});

            talking.Add("image3(girl)", new string[] { "'�ҸӴ� ���� �ʹ�. ������ �ҸӴϰ� Ī�����ָ� ���� �� �� ���Ҵµ�.':0",
                "�� �λ� ������ ����� �� ���� �� �� ǳ���� ���̶�� �� ������ ����������,\n�׸����� ���� ��ġó�� �������� ���̴�. ������ �����̸� ���� �Ŵϱ�.:0" });

            talking.Add("image4(girl)", new string[] { "... �� ���� �� ���� ������ ���� �� ���̶�� �����ϸ� ���� ���� �����.:0" });

            talking.Add("image5(girl)", new string[] { "\"userInfo.getName()��(��).\":0",
            "\"�ҸӴ�...?\":0"});

            //��ĳ, ��ĳ ���� �̹���
            taling.Add("image6", new string[] { "'�츮 �ư�, �� ���ڿ��� ��¦ ������� �� ����ִܴ�. �ñ�����?':0",
                "'��? ������... ��� �� �� ���� ���ε�.':0",
            "'�ϳ��� �� �ñ��ϰŵ��! ������ ������ ���ε�!':0",
            "'... �׸��� �� �� ���ķ� ���ڿ� ���� �� �� �����ܴ�.:0",
            "'�ƹ����� ��� ����Ʈ��鼭 � �����̿� ���ڸ� ���ܳ��µ�,\n�ҹ����� ����� �� �ְ� �״�� ���ư����� ����.':0"});

            talking.Add("image7", new string[] { "'�������� �� ���ڿ� ���� ��������� �� �𸣰ڱ���.\n�, userInfo.getName()(��)�� �ñ����� �ʴ�?':0",
            "'�׷����� �ҸӴ�, ���� �� �̻� ��� ���� �ʤ�...':0",
            "�ҸӴϴ� ���� ���� ����ġ�⵵ ���� ������̴�.\n...����ϰ� ���̴� Starry Farm�̶�� ���ڸ� ���ܵΰ�.:0"});

            talking.Add("image8", new string[] { "�׸��� ����Ե�, �� �տ��� ��� �� ���ڿ�\n��� �ּҰ� ������ �ִ� ���̰� ����� �־���.:0",
            "�ҸӴϰ� ���� �� ���� ������ ������ ���� �Ŷ� �����ϰ�,\n���ڸ� ã���� �ҸӴ� ������ ���߰ڴٴ� ������ �Բ�,:0",
            "... ���� ���¸� ������ ������.:0"});
        }



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
