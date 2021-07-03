using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    Dictionary<string, string[]> StoreData; // stinrg : id, string[] : {�̸� , ����, ����}

    void Awake()
    {
        StoreData = new Dictionary<string, string[]>();
        //GenerateData();
    }

    void GenerateData()
    {
        //StoreData.Add("seller", new string[] { "��纣�� ����", "���� ���ִ� ��纣���� ����� �� ���� �� ���� ��� ��纣�� �����̴�.", "500G" });

    }

    public string GetStore(string id, int storeIndex)
    {
        return StoreData[id][storeIndex];
    }
}
