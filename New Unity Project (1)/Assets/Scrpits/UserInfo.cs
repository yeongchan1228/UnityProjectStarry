using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public int Day; // 날짜
    public int Gold; // 돈
    public int Hp; // 체력
    public string Name; // 이름
    public string FarmName; // 농장 이름
    public int Power; // 공겨력
    public int Defense; // 방어력
    public string Gender; // 성별
    public bool isTrue; // 남자, 여자 선택

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