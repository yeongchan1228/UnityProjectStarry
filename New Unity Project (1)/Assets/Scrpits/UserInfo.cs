using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public int Day; // ��¥
    public int Gold; // ��
    public int Hp; // ü��
    public string Name; // �̸�
    public string FarmName; // ���� �̸�
    public int Power; // ���ܷ�
    public int Defense; // ����
    public string Gender; // ����
    public bool isTrue; // ����, ���� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public string getName()
    {
        return Name;
    }
    public string getGender()
    {
        return Gender;
    }

    public void setName(string Name)
    {
        this.Name = Name;
    }
    public void setFarmName(string FarmName)
    {
        this.FarmName = FarmName;
    }

}