using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatHandle : MonoBehaviour
{
    string wherecheck;
    public GameManager game;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1_Clicked()
    {
        wherecheck = game.select3;
        if(game.select3 == "1")
        {
            SceneManager.LoadScene("Dungeon");
            //player.setXY(-261.6f, 69.5f);
        }
    }

    public void Button2_Clicked()
    {
        wherecheck = game.select3;
        if (game.select3 == "1")
        {
            Debug.Log("실행되었다;;;;");
        }
    }
}
