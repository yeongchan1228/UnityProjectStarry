using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    GameObject user_woman, user_man;
    UserInfo userInfo;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else
        {
            userInfo = user_woman.GetComponent<UserInfo>();

        }
        gameManager = GameObject.Find("TextManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public void off_noWater()
    {
        GameObject gameogj = GameObject.Find("WaterPPU").transform.GetChild(0).gameObject;
        gameogj.SetActive(false);
    }
   public void off_Water()
    {
        GameObject gameogj = GameObject.Find("WaterPPU").transform.GetChild(1).gameObject;
        if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Stone_Water"))
        {
            userInfo.getItem_WaterPPU().SetWaterPPUFilled(100);
        }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Guri_Water"))
        {
            userInfo.getItem_WaterPPU().SetWaterPPUFilled(150);

        }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Silver_Water"))
        {
            userInfo.getItem_WaterPPU().SetWaterPPUFilled(200);
        }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Iridium_Water"))
        {
            userInfo.getItem_WaterPPU().SetWaterPPUFilled(250);
        }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Dia_Water"))
        {
            userInfo.getItem_WaterPPU().SetWaterPPUFilled(300);
        }
        gameogj.SetActive(false);
    }
    public void off_Map()
    {
        GameObject gameogj = GameObject.Find("Treasure_Map").transform.GetChild(0).gameObject;
        gameogj.SetActive(false);
        gameManager.isAction = false;
        gameManager.isButton = false;
    }
}
