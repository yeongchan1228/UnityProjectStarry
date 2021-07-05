using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterHP : MonoBehaviour
{
    private MonsterInformation mi;
    public Slider hpBar;
    public float responeTime;
    void Start()
    {
        mi = gameObject.GetComponent<MonsterInformation>();
        responeTime = 5.0F;
    }

    void Update()
    {
        hpBar.value = (float)mi.hp / (float)mi.hpMax;
        hpBar.transform.position = new Vector3(transform.position.x, transform.position.y+(float)0.75, 0);
        if (mi.hp == 0)
        {
            gameObject.SetActive(false);
            hpBar.gameObject.SetActive(false);
            Invoke("Respone", responeTime);
        }
    }

    void Respone()
    {
        gameObject.SetActive(true);
        hpBar.gameObject.SetActive(true);
        mi.hp = 100;
    }

    public void Hit(int power)
    {
        mi.hp = mi.hp - power;
    }
}
