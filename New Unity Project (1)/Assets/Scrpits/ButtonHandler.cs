using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Hole_UI, furnace, fin_box, exit, furnace_on;
    public GameObject furnace_UI, furnace_inven1, furnace_inven2, furnace_inven3, furnace_inven4, furnace_inven5;
    public GameObject fire, exit2;
    public GameManager textmanager;
    public GameObject text1, text2, text3;

    void Start()
    {
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        Hole_UI = GameObject.Find("Hole_UI").transform.GetChild(0).gameObject;
        furnace = Hole_UI.transform.GetChild(0).gameObject;
        fin_box = Hole_UI.transform.GetChild(1).gameObject;
        exit = Hole_UI.transform.GetChild(2).gameObject;
        //furnace_on = Hole_UI.transform.GetChild(3).gameObject;

        furnace_UI = GameObject.Find("Hole_UI").transform.GetChild(1).gameObject;
        furnace_inven1 = furnace_UI.transform.GetChild(0).gameObject;
        furnace_inven2 = furnace_UI.transform.GetChild(1).gameObject;
        furnace_inven3 = furnace_UI.transform.GetChild(2).gameObject;
        furnace_inven4 = furnace_UI.transform.GetChild(3).gameObject;
        furnace_inven5 = furnace_UI.transform.GetChild(4).gameObject;
        fire = furnace_UI.transform.GetChild(5).gameObject;
        exit2 = furnace_UI.transform.GetChild(6).gameObject;

        text1 = GameObject.Find("Hole_UI").transform.GetChild(2).gameObject;
        text2 = GameObject.Find("Hole_UI").transform.GetChild(3).gameObject;
        text3 = GameObject.Find("Hole_UI").transform.GetChild(4).gameObject;

    }


    public void click_furnace()
    {
        furnace_UI.SetActive(true);
        furnace_inven1.SetActive(true);
        furnace_inven2.SetActive(true);
        furnace_inven3.SetActive(true);
        furnace_inven4.SetActive(true);
        furnace_inven5.SetActive(true);
        fire.SetActive(true);
        exit2.SetActive(true);

        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
    }

    public void click_finalbox()
    {

    }

    public void click_fire()
    {

    }

    public void click_exit()
    {
        Hole_UI.SetActive(false);
        furnace.SetActive(false);
        fin_box.SetActive(false);
        exit.SetActive(false);
        textmanager.isAction = false;
    }

    public void click_exit2()
    {
        furnace_UI.SetActive(false);
        furnace_inven1.SetActive(false);
        furnace_inven2.SetActive(false);
        furnace_inven3.SetActive(false);
        furnace_inven4.SetActive(false);
        furnace_inven5.SetActive(false);
        fire.SetActive(false);
        exit2.SetActive(false);


        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);

    }

}
