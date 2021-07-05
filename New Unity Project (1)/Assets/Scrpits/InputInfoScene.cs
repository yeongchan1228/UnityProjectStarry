using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInfoScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject scene = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        scene.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
