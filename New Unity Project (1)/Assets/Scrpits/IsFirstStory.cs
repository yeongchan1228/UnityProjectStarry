using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsFirstStory : MonoBehaviour
{
    public bool isFirststory;
    GameManager textmanager;
    public GameObject scanObj;
    public TalkManager TalkMake;
    public Sprite[] firstimgs;

    void Start()
    {
        GameObject obj = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        GameObject obj2 = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        firstimgs = Resources.LoadAll<Sprite>("Sprites/FirstStory");
        TalkMake = GameObject.Find("TalkManager").GetComponent<TalkManager>();
        TalkMake.makeTalking();
        if (TalkMake.userInfo.getGender().Equals("man"))
        {
            scanObj = TalkMake.user_man;
        }
        else
        {
            scanObj = TalkMake.user_woman;
        }
        Destroy(obj2);
        obj.SetActive(true);
        if (textmanager.isman)
        {
            GameObject Image = GameObject.Find("FirstStory").transform.GetChild(0).gameObject;
            GameObject First = Image.transform.GetChild(0).gameObject;
            Image FirstImg = First.GetComponent<Image>();
            Image.SetActive(true);
            FirstImg.sprite = firstimgs[0];
        }
        else if (textmanager.iswoman)
        {
            GameObject Image = GameObject.Find("FirstStory").transform.GetChild(0).gameObject;
            GameObject First = Image.transform.GetChild(0).gameObject;
            Image FirstImg = First.GetComponent<Image>();
            Image.SetActive(true);
            FirstImg.sprite = firstimgs[8];
        }
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
