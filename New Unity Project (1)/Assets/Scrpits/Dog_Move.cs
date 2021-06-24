using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Move : MonoBehaviour
{

    public float rightMax; //좌로 이동가능한 (x)최대값
    public float leftMax; //우로 이동가능한 (x)최대값
    public float upMax; //위로 이동가능한 (y)최대값
    public float startX, startY;
    GameManager textmanager;
    public float downMax; //아래로 이동가능한 (y)최대값
    float currentPosition; //현재 위치(x) 저장
    float currentPositiony; //현재 위치(y) 저장

    float direction = 1.0f; //이동속도+방향
    // Start is called before the first frame update
    void Start()
    {
        textmanager = GameObject.Find("TextManager").GetComponent<GameManager>();
        transform.position = new Vector3(startX, startY, 0);
        currentPosition = transform.position.x;
        currentPositiony = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!textmanager.isAction)
        {
            currentPosition += Time.deltaTime * direction;
        }
    
        if (currentPosition >= rightMax)
        {
            direction *= -1;
            currentPosition = rightMax;
            currentPositiony += Time.deltaTime * direction;
        }

        else if (currentPosition <= leftMax)
        {
            direction *= -1;
            currentPosition = leftMax;
            currentPositiony += Time.deltaTime * direction;

        }
        else if (currentPositiony <= upMax)
        {
            direction *= -1;
            currentPositiony = upMax;

        }
        else if (currentPositiony <= downMax)
        {
            direction *= -1;
            currentPositiony = downMax;

        }

        transform.position = new Vector3(currentPosition, currentPositiony, 0);
    }
}
