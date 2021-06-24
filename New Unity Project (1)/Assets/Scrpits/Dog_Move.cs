using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Move : MonoBehaviour
{

    public float rightMax; //�·� �̵������� (x)�ִ밪
    public float leftMax; //��� �̵������� (x)�ִ밪
    public float upMax; //���� �̵������� (y)�ִ밪
    public float startX, startY;
    GameManager textmanager;
    public float downMax; //�Ʒ��� �̵������� (y)�ִ밪
    float currentPosition; //���� ��ġ(x) ����
    float currentPositiony; //���� ��ġ(y) ����

    float direction = 1.0f; //�̵��ӵ�+����
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
