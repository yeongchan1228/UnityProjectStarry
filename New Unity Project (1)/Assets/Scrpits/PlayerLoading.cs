using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoading : MonoBehaviour
{
    private PlayerController player;
    private CameraMoving camera;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //player.setXY(-261.6f, 69.3f);

        camera = FindObjectOfType<CameraMoving>();
        //camera.transform.position = new Vector3(-261.6f, 69.3f, -4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
