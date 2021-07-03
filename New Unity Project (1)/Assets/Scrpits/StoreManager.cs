using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    Dictionary<string, string[]> StoreData; // stinrg : id, string[] : {이름 , 설명, 가격}

    void Awake()
    {
        StoreData = new Dictionary<string, string[]>();
        //GenerateData();
    }

    void GenerateData()
    {
        //StoreData.Add("seller", new string[] { "블루베리 씨앗", "아주 맛있는 블루베리를 재배할 수 있을 것 같은 고급 블루베리 씨앗이다.", "500G" });

    }

    public string GetStore(string id, int storeIndex)
    {
        return StoreData[id][storeIndex];
    }
}
