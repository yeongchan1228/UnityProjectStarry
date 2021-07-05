using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoeingLoading : MonoBehaviour
{
    PlayerController playerController;
    GameObject user_man, user_woman, proobj;
    Image progressBar;
    UserInfo userInfo;
    int count, count2, counter, counter2;
    // Start is called before the first frame update
    void Start()
    {
        proobj = GameObject.Find("Farm").transform.GetChild(0).gameObject;
        progressBar =proobj.transform.GetChild(1).gameObject.GetComponent<Image>();
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        count2 = 0;
        if (userinfo2.isTrue)
        {
            playerController = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();

        }
        else
        {
            playerController = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.isHoeing && counter == 0)
        {
            count = playerController.count;
            fillProgressBar();
            counter = 1;
        }
    }

    void fillProgressBar()
    {
        if(counter2 != 0)
        {
            if (count == 10) { progressBar.fillAmount += 0.1f; }
            else if (count == 8) { progressBar.fillAmount += 0.125f; }
            else if (count == 6) { progressBar.fillAmount += 0.166f; }
            else if (count == 4) { progressBar.fillAmount += 0.25f; }
            else if (count == 2) { progressBar.fillAmount += 0.5f; }
            count2++;
        }
        if (count2 == count) 
        {
            progressBar.fillAmount = 1f;
            proobj.SetActive(false);
            count2 = 0;
            counter = 0;
            counter2 = 0;
            playerController.isHoeing = false;
            return; 
        }
        counter2++;
        
        Invoke("fillProgressBar", 1f);
    }
}
