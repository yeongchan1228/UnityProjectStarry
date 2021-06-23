using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject A; // Ä³¸¯ÅÍ
    Transform AT;
    
    // Start is called before the first frame update
    void Start()
    {
        AT = A.transform;
        transform.position = new Vector3(-3, 0, -4);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, -4);
    }
}
