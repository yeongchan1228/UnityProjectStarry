using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rigid2D;
    Vector3 viewpos;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-17.5f, 16, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        
        //transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }



   
   
}
