using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFirstStory : MonoBehaviour
{
    public bool isFirststory;
    public GameManager textmanager;
    public GameObject scanObj;

    void Start()
    {
        isFirststory = true;
        if (isFirststory)
        {
            textmanager.Action(scanObj); // ��ȭâ ���
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && scanObj != null)
        {
            textmanager.Action(scanObj); // ��ȭâ ���
        }
    }
}
