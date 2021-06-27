using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFirstStory : MonoBehaviour
{
    public bool isFirststory;
    public GameManager textmanager;
    public GameObject scanObj;
    public TalkManager TalkMake;

    void Start()
    {
        GameObject obj = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        GameObject obj2 = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        TalkMake = GameObject.Find("TalkManager").GetComponent<TalkManager>();
        TalkMake.makeTalking();
        Destroy(obj2);
        obj.SetActive(true);
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        isFirststory = true;
        if (isFirststory)
        {
            textmanager.Action(scanObj); // 대화창 출력
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && scanObj != null)
        {
            textmanager.Action(scanObj); // 대화창 출력
        }
    }
}
